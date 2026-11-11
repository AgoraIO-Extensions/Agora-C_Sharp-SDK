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
    if (!fileExists('package_urls')) {
        error('Unity packaging did not produce a completed package_urls manifest')
    }
    archiveUrls = readFile(file: 'package_urls', encoding: 'utf-8').readLines()
    if (!archiveUrls || archiveUrls.any { !(it ==~ /https:\/\/[^\/\s]+\/\S+/) }) {
        error('Unity package_urls must contain successful HTTPS upload URLs only')
    }
    archiveUrls = archiveUrls as Set
    archiveArtifacts(artifacts: 'package_urls')
}

pipelineLoad(this, "Unity_SDK_Build", "build", "mac", "mac && unity")
