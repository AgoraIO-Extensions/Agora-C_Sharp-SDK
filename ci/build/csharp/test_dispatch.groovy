// Run: java -cp groovy-all.jar groovy.ui.GroovyMain ci/build/csharp/test_dispatch.groovy
// No Jenkins/network effects: execute the real dispatcher against bounded pipeline stubs.
def file = new File('ci/build/build_mac.groovy')
def loader = new GroovyClassLoader()
loader.parseClass('package agora.build; class BuildUtils {}')
def source = file.text.replaceAll(/(?m)^@Library\([^\n]+\n/, '')
def run = { parameters, signResult = 'SUCCESS', uploadUrls = ['https://example.invalid/sdk.zip', 'https://example.invalid/x86.zip', 'https://example.invalid/x64.zip'] ->
    def calls = []
    def binding = new Binding([
        params: Collections.unmodifiableMap(parameters), env: [BUILD_NUMBER: '42'], scm: 'same-sdk-scm',
        pipelineLoad: { Object... args -> calls << ['unity', args.toList().drop(1)] },
        withNode: { label, block -> calls << ['node', label]; block() },
        pwd: { -> 'C:/jenkins/workspace/Unity_SDK_Build/build_mac' },
        ws: { path, block -> calls << ['workspace', path]; block() },
        deleteDir: { -> calls << ['clean'] }, checkout: { scm -> calls << ['checkout', scm] },
        withEnv: { values, block -> calls << ['env', values]; block() },
        string: { value -> value }, text: { value -> value },
        build: { config -> calls << ['sign', config]; [result: signResult] },
        withCredentials: { values, block -> block() },
        bat: { command -> calls << ['bat', command] },
        archiveArtifacts: { config -> calls << ['artifacts', config] },
        archive: [archiveFiles: { config -> calls << ['upload', config]; uploadUrls }],
        writeFile: { config -> calls << ['file', config] }, echo: { message -> calls << ['result', message] },
        error: { message -> throw new IllegalArgumentException(message) }
    ])
    new GroovyShell(loader, binding).evaluate(source)
    calls
}
for (params in [[:], [SDK_TARGET: 'Unity'], [SDK_TARGET: '']]) {
    assert run(params) == [['unity', ['Unity_SDK_Build', 'build', 'mac', 'mac && unity']]]
}
def csharp = run([SDK_TARGET: 'CSharp', SDK_VERSION: '4.5.3.6', Package_Publish: false])
assert !csharp.any { it[0] in ['unity', 'upload', 'sign', 'result'] }
assert csharp.find { it[0] == 'node' }[1] == 'windows'
assert csharp.find { it[0] == 'workspace' }[1].endsWith('@csharp-42')
assert csharp.find { it[0] == 'checkout' }[1] == 'same-sdk-scm'
assert csharp.find { it[0] == 'bat' }[1].contains('csharp\\build.ps1')
assert csharp.findAll { it[0] == 'bat' }[1][1].contains('verify_package.py')
assert csharp.find { it[0] == 'artifacts' }[1].artifacts.contains('manifest.json')
def published = run([SDK_TARGET: 'CSharp', SDK_VERSION: '4.5.3.6', Package_Publish: true,
                     IRIS_WIN_URL: 'iris', NATIVE_WIN_URL: 'native'])
assert published.findAll { it[0] == 'upload' }*.getAt(1)*.getAt(0)*.serverPath == [
    'CSharp_SDK_Build/4.5.3.6/42/windows/signing-input', 'CSharp_SDK_Build/4.5.3.6/42/windows']
assert published.find { it[0] == 'result' }[1].contains('[Pipeline Center]JOB_RESULT_TEXT START')
def signing = published.find { it[0] == 'sign' }[1]
assert signing.job == '/CodeSign' && signing.wait && !signing.propagate
assert signing.parameters.find { it.name == 'SIGN_PACKAGE_WHITELIST' }.value == 'Agora_CSharp_*.zip'
assert signing.parameters.find { it.name == 'SIGN_FILE_WHITELIST' }.value.contains('C_Sharp-API_Example.exe')
assert !signing.parameters.find { it.name == 'SIGN_FILE_WHITELIST' }.value.contains('*.dll,*.exe')
assert published.findIndexOf { it[0] == 'upload' } < published.findIndexOf { it[0] == 'sign' }
assert published.findIndexOf { it[0] == 'sign' } < published.findIndexOf { it[0] == 'result' }
assert published.find { it[0] == 'bat' && it[1].contains('verify_signed.ps1') }
for (result in ['FAILURE', 'ABORTED', 'UNSTABLE', null]) {
    try {
        run([SDK_TARGET: 'CSharp', Package_Publish: true], result)
        assert false: 'Signing failure must stop publication'
    } catch (IllegalArgumentException expected) {
        assert expected.message.contains('C# CodeSign failed')
    }
}
try {
    run([SDK_TARGET: 'CSharp', Package_Publish: true], 'SUCCESS', ['http://example.invalid/sdk.zip'])
    assert false: 'Invalid signing URL must stop publication'
} catch (IllegalArgumentException expected) {
    assert expected.message.contains('HTTPS Artifactory URLs')
}
try { run([SDK_TARGET: 'unknown']); assert false } catch (IllegalArgumentException expected) {
    assert expected.message.contains('Unsupported SDK_TARGET')
}
println 'Unity default/explicit/empty, C# isolated build/upload, and invalid-target checks passed'
