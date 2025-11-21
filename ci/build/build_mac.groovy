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
    
    // Upload to CDN
    def cdnUrls = []
    if (params.Package_Publish && archiveUrls) {
        echo 'Uploading to CDN...'
        
        def cdnJobs = [:]
        archiveUrls.each { fileUrl ->
            def fileName = fileUrl.split("/")[-1].split("\\\\")[-1]
            def cdnUrl = "https://download.agora.io/sdk/release/${fileName}"
            cdnUrls.add(cdnUrl)
            
            cdnJobs << ["CDN_${fileName}": {
                build job: 'GA/Manual_CDN_Release_Url', propagate: false, parameters: [
                    string(name: 'FILE_LINK', value: fileUrl),
                    string(name: 'FILE_NAME', value: ''),
                    string(name: 'TYPE', value: 'sdk')
                ]
            }]
        }
        
        if (cdnJobs) {
            parallel cdnJobs
            echo 'CDN URLs:'
            cdnUrls.each { echo it }
        }
    }
    
    sh "rm -rf *.zip || true"
}

pipelineLoad(this, "Unity_SDK_Build", "build", "mac", "mac && unity")