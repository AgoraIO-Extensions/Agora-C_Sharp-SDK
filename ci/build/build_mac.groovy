// -*- mode: groovy -*-
// vim: set filetype=groovy :
@Library('agora-build-pipeline-library') _
import groovy.transform.Field

buildUtils = new agora.build.BuildUtils()

compileConfig = [
    "sourceDir": "agora-c_sharp-sdk",
    "non-publish": [
        "command": "./ci/build/build_mac.sh",
        "extraArgs": "",
    ],
    "publish": [
        "command": "./ci/build/build_mac.sh",
        "extraArgs": "",
    ]
]

def doBuild(buildVariables) {
    // withGithubSync("Agora-Unity-Quickstart") {
        type = params.Package_Publish ? "publish" : "non-publish"
        command = compileConfig.get(type).command
        preCommand = compileConfig.get(type).get("preCommand", "")
        postCommand = compileConfig.get(type).get("postCommand", "")
        extraArgs = compileConfig.get(type).extraArgs
        extraArgs += " " + params.getOrDefault("extra_args", "")
        commandConfig = [
            "command": command,
            "sourceRoot": "${compileConfig.sourceDir}",
            "extraArgs": extraArgs
        ]
        loadResources(["config.json", "artifactory_utils.py"])
        buildUtils.customBuild(commandConfig, preCommand, postCommand)
    // }
}

def doPublish(buildVariables) {
    if (!params.Package_Publish) {
        return
    }
    (shortVersion, releaseVersion) = buildUtils.getBranchVersion()
    def archiveInfos = [
        [
          "type": "ARTIFACTORY",
          "archivePattern": "*.zip",
          "serverPath": "Unity_SDK_Build/${shortVersion}/${buildVariables.buildDate}/${env.platform}",
          "serverRepo": "CSDC_repo" // ATTENTIONS: Update the artifactoryRepo if needed.
        ]
    ]
    archiveUrls = archive.archiveFiles(archiveInfos) ?: []
    archiveUrls = archiveUrls as Set
    if (archiveUrls) {
        def content = archiveUrls.join("\n")
        writeFile(file: 'package_urls', text: content, encoding: "utf-8")
    }
    archiveArtifacts(artifacts: "package_urls", allowEmptyArchive:true)
    
    sh "rm -rf *.zip || true"
}

// Missing target preserves every existing Unity invocation. C# is explicit opt-in.
def sdkTarget = params.get('SDK_TARGET') ?: 'Unity'
if (sdkTarget == 'Unity') {
    pipelineLoad(this, "Unity_SDK_Build", "build", "mac", "mac && unity")
} else if (sdkTarget == 'CSharp') {
    // Use the shared Windows node selector, but never the shared /tmp Unity checkout.
    withNode("windows") {
        ws("${pwd()}@csharp-${env.BUILD_NUMBER}") {
            deleteDir()
            try {
                checkout scm
                withEnv(params.collect { key, value -> "${key}=${value}" } + ['platform=windows']) {
                    withCredentials([string(credentialsId: 'jfrog-token', variable: 'JFROG_TOKEN')]) {
                        bat '@powershell -NoProfile -ExecutionPolicy Bypass -File ci\\build\\csharp\\build.ps1'
                    }
                    bat '@py -3 ci\\build\\csharp\\verify_package.py csharp-output'
                    archiveArtifacts(artifacts: 'csharp-output/*.zip,csharp-output/*.nupkg,csharp-output/manifest.json', fingerprint: true)
                    if (params.Package_Publish) {
                        def urls = archive.archiveFiles([[
                            type: 'ARTIFACTORY', sourcePath: 'csharp-output', archivePattern: '*.zip',
                            serverPath: "CSharp_SDK_Build/${params.SDK_VERSION}/${env.BUILD_NUMBER}/windows/signing-input",
                            serverRepo: 'CSDC_repo'
                        ]]) ?: []
                        if (!urls) { error('C# artifact upload returned no URLs') }
                        def codesignUrls = urls.findAll { it?.toString()?.startsWith('https://') }
                        if (codesignUrls.size() != urls.size()) {
                            error('C# CodeSign requires HTTPS Artifactory URLs for every package')
                        }
                        // Same signing service as Iris; never expose release URLs on signing failure.
                        def codesignResult = build(job: '/CodeSign', parameters: [
                            text(name: 'PACKAGE_URLS', value: codesignUrls.join('\n')),
                            string(name: 'SIGN_PACKAGE_WHITELIST', value: 'Agora_CSharp_*.zip'),
                            string(name: 'SIGN_FILE_WHITELIST', value: 'agorartc.dll,agora*.dll,Agora*.dll,C_Sharp-API_Example.dll,C_Sharp-API_Example.exe,SharpDX*.dll,glfw3.dll,lib*.dll,video*.dll'),
                        ], wait: true, propagate: false)
                        if (!codesignResult || codesignResult.result != 'SUCCESS') {
                            error("C# CodeSign failed: ${codesignResult?.result ?: 'UNKNOWN'}")
                        }
                        writeFile(file: 'csharp-signing-urls.json', text: groovy.json.JsonOutput.toJson(codesignUrls), encoding: 'utf-8')
                        try {
                            withCredentials([string(credentialsId: 'jfrog-token', variable: 'JFROG_TOKEN')]) {
                                bat '@powershell -NoProfile -ExecutionPolicy Bypass -File ci\\build\\csharp\\verify_signed.ps1'
                            }
                        } finally {
                            archiveArtifacts(artifacts: 'csharp-signed/signature-report.json', allowEmptyArchive: true)
                        }
                        try {
                            bat '@powershell -NoProfile -ExecutionPolicy Bypass -File ci\\build\\csharp\\smoke_demo.ps1'
                        } finally {
                            archiveArtifacts(artifacts: 'csharp-startup-check/*.json,csharp-startup-check/*.png,csharp-startup-check/**/*.log', allowEmptyArchive: true)
                        }
                        archiveArtifacts(artifacts: 'csharp-release/*.zip,csharp-release/*.nupkg,csharp-release/manifest.json', fingerprint: true)
                        urls = archive.archiveFiles([[
                            type: 'ARTIFACTORY', sourcePath: 'csharp-release', archivePattern: '*.zip',
                            serverPath: "CSharp_SDK_Build/${params.SDK_VERSION}/${env.BUILD_NUMBER}/windows",
                            serverRepo: 'CSDC_repo'
                        ]]) ?: []
                        if (urls.size() != 3) { error('Expected three final signed C# package URLs') }
                        writeFile(file: 'package_urls', text: urls.join('\n'), encoding: 'utf-8')
                        archiveArtifacts(artifacts: 'package_urls')
                        echo "[Pipeline Center]JOB_RESULT_TEXT START\nC# SDK Download URLs:\n${urls.join('\n')}\nNative SDK Download URLs:\n${params.NATIVE_WIN_URL}\nIris Download URLs:\n${params.IRIS_WIN_URL}\n[Pipeline Center]JOB_RESULT_TEXT END"
                    }
                }
            } finally {
                deleteDir()
            }
        }
    }
} else {
    error("Unsupported SDK_TARGET: ${sdkTarget}")
}
