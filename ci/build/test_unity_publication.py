"""Run with unittest; set UNITY_CI_TEST_GROOVY_JAR to also execute the Jenkins hook."""
import os
from pathlib import Path
import shutil
import subprocess
import sys
import tempfile
import unittest


BUILD = Path(__file__).resolve().parent


class UnityPublicationTests(unittest.TestCase):
    def run_packaging(self, mode='ok', split=False, fail_at=1, rtc=True):
        source = (BUILD / 'build_mac.sh').read_text()
        start = source.index('UNITY_PACKAGE_URLS=')
        end = source.index('\n}\n', start) + 3
        script = source[start:end] + source[source.index('# split vision os package'):]
        with tempfile.TemporaryDirectory() as folder:
            root = Path(folder)
            workspace, binaries, checkout = (root / name for name in ('workspace', 'bin', 'checkout'))
            for path in (workspace, binaries, checkout / 'tempDir/visionos'):
                path.mkdir(parents=True)
            manifest = workspace / 'package_urls'
            manifest.write_text('https://example.invalid/stale.zip\n')
            upload_log = root / 'uploads'
            tools = {
                'Unity': '#!/bin/bash\nexit 0\n',
                '7za': '#!/bin/bash\nprintf fixture > "$2"\n',
                'curl': '#!/bin/bash\nexit 0\n',
                'python3': f'#!{sys.executable}\n' + '''
import os, sys
from pathlib import Path
log = Path(os.environ['UPLOAD_LOG'])
calls = log.read_text().splitlines() if log.exists() else []
name = next(arg[7:] for arg in sys.argv if arg.startswith('--file='))
calls.append(name)
log.write_text('\\n'.join(calls) + '\\n')
mode = os.environ['UPLOAD_MODE'] if len(calls) == int(os.environ['FAIL_AT']) else 'ok'
if mode == 'nonzero': sys.exit(1)
if mode == 'error': print('[ERROR]: No files match the pattern: *.zip.')
elif mode == 'empty': pass
elif mode == 'multiline': print('https://example.invalid/a.zip\\nhttps://example.invalid/b.zip')
else: print('https://example.invalid/packages/' + Path(name).name)
''',
            }
            for name, content in tools.items():
                path = binaries / name
                path.write_text(content)
                path.chmod(0o755)
            env = dict(os.environ, PATH=str(binaries) + os.pathsep + os.environ['PATH'],
                       WORKSPACE=str(workspace), UNITY_DIR=str(binaries), UPLOAD_LOG=str(upload_log),
                       UPLOAD_MODE=mode, FAIL_AT=str(fail_at), RTC=str(rtc).lower(),
                       BRAND='Agora', TYPE='FULL', SDK_VERSION='4.6.4.2', BUILD_NUMBER='684',
                       build_date='20261110', FINAL_SUFFIX='', PLUGIN_NAME='Agora-RTC-Plugin',
                       PLUGIN_CODE_NAME='AgoraRtcEngine', VISIONOS_URL='fixture' if split else '',
                       SPLIT_VISIONOS=str(split).lower(),
                       VISIONOS_DST_PATH=str(checkout / 'tempDir/visionos'))
            result = subprocess.run(['bash', '-e', '-c', script], cwd=checkout / 'tempDir',
                                    env=env, capture_output=True, text=True)
            return (result.returncode, manifest.read_text() if manifest.exists() else None,
                    upload_log.read_text().splitlines() if upload_log.exists() else [],
                    (checkout / 'tempDir').exists(),
                    (workspace / 'package_urls.pending').exists())

    def test_completed_uploads_survive_temporary_directory_cleanup(self):
        for rtc, split in ((True, False), (True, True), (False, False)):
            with self.subTest(rtc=rtc, split=split):
                code, manifest, uploads, temporary, pending = self.run_packaging(split=split, rtc=rtc)
                self.assertEqual(code, 0)
                self.assertEqual(len(uploads), 2 if split else 1)
                self.assertEqual(manifest.splitlines(),
                                 ['https://example.invalid/packages/' + Path(p).name for p in uploads])
                self.assertFalse(temporary)
                self.assertFalse(pending)

    def test_failed_uploads_cannot_reuse_a_stale_or_partial_manifest(self):
        for mode in ('nonzero', 'error', 'empty', 'multiline'):
            for split in (False, True):
                with self.subTest(mode=mode, split=split):
                    code, manifest, uploads, _, pending = self.run_packaging(
                        mode=mode, split=split, fail_at=2 if split else 1)
                    self.assertNotEqual(code, 0)
                    self.assertIsNone(manifest)
                    self.assertEqual(len(uploads), 2 if split else 1)
                    self.assertEqual(pending, split)

    def test_jenkins_archives_only_a_valid_completed_manifest(self):
        groovy = shutil.which('groovy')
        jar = os.environ.get('UNITY_CI_TEST_GROOVY_JAR')
        if not groovy and not jar:
            self.skipTest('Install Groovy or set UNITY_CI_TEST_GROOVY_JAR')
        fixture = r'''
def source = new File(args[0]).text
def start = source.indexOf('def doPublish(')
def hook = source.substring(start, source.indexOf('\n}\n', start) + 3)
def check = { boolean publish, String manifest, boolean expected ->
    def archived = []
    def binding = new Binding([
        params: [Package_Publish: publish],
        fileExists: { String path -> assert path == 'package_urls'; manifest != null },
        readFile: { Map options -> assert options.file == 'package_urls'; manifest },
        archiveArtifacts: { Map options ->
            assert options.artifacts == 'package_urls'
            assert !options.allowEmptyArchive
            archived << options
        },
        error: { String message -> throw new IllegalStateException(message) },
    ])
    def script = new GroovyShell(binding).parse(hook)
    boolean accepted = true
    try { script.doPublish([:]) } catch (IllegalStateException ignored) { accepted = false }
    assert accepted == expected
    assert archived.size() == ((publish && expected) ? 1 : 0)
}
check(false, null, true)
check(true, null, false)
check(true, '', false)
check(true, '\n', false)
check(true, '[ERROR]: No files match the pattern: *.zip.', false)
check(true, 'https://example.invalid/one.zip\nhttp://example.invalid/two.zip\n', false)
check(true, 'https://example.invalid/one.zip\n', true)
check(true, 'https://example.invalid/one.zip\nhttps://example.invalid/two.zip\n', true)
println 'Unity Jenkins publication fixtures passed'
'''
        with tempfile.TemporaryDirectory() as folder:
            path = Path(folder) / 'publication.groovy'
            path.write_text(fixture)
            command = ([groovy] if groovy else
                       ['java', '-cp', jar, 'groovy.ui.GroovyMain'])
            result = subprocess.run(command + [str(path), str(BUILD / 'build_mac.groovy')],
                                    capture_output=True, text=True)
            self.assertEqual(result.returncode, 0, result.stderr)


if __name__ == '__main__':
    unittest.main()
