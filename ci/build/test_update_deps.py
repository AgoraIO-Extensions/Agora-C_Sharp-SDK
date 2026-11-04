import json
from pathlib import Path
import shutil
import subprocess
import sys
import tempfile
import unittest


class DependencyModeTests(unittest.TestCase):
    def run_updater(self, profile, iris_modes=(), explicit='auto'):
        with tempfile.TemporaryDirectory() as root:
            root = Path(root)
            build = root / 'ci/build'
            build.mkdir(parents=True)
            (root / 'terra').mkdir()
            shutil.copyfile(Path(__file__).with_name('Update-Deps.py'), build / 'Update-Deps.py')
            config = '>>>video\r\nNATIVE_WINDOWS=old-video\r\nIRIS_WINDOWS=old-iris-video\r\n<<<end\r\n>>>audio\r\nNATIVE_WINDOWS=old-audio\r\nIRIS_WINDOWS=old-iris-audio\r\n<<<end\r\n'
            (build / 'url_config.txt').write_bytes(config.encode())
            (root / 'terra/rtc.yaml').write_text('sdk: rtc_4.5.3.1\n')
            native = f'https://download.agora.io/sdk/Agora_Native_SDK_for_Windows_rel.v4.5.3.135_33843_{profile}_20261102_1517_1.zip'
            iris = [f'https://download.agora.io/sdk/iris_4.5.3.135-build.1_DCG_Windows_{mode}_Standalone_20261102_1517_1.zip' for mode in iris_modes]
            data = [dict(product_type='rtc', platform='Windows', cdn=[native], iris_cdn=iris,
                         version='4.5.3.135', iris_version='4.5.3.135-build.1')]
            result = subprocess.run([sys.executable, str(build / 'Update-Deps.py'), json.dumps(data),
                                     '--native-mode', explicit], capture_output=True, text=True)
            return result, (build / 'url_config.txt').read_bytes().decode(), native, config

    def test_custom_profiles_follow_selected_iris_video(self):
        for profile in ('FAV', 'CUSTOM_VIDEO', 'customer-7.preview'):
            result, config, native, _ = self.run_updater(profile, ('Video',))
            self.assertEqual(result.returncode, 0, result.stderr)
            self.assertIn('>>>video\r\nNATIVE_WINDOWS=' + native, config)
            self.assertIn('IRIS_WINDOWS=https://download.agora.io', config)

    def test_known_voice_and_full_keep_their_modes(self):
        for profile, mode in (('FULL', 'video'), ('VOICE', 'audio')):
            result, config, native, _ = self.run_updater(profile)
            self.assertEqual(result.returncode, 0, result.stderr)
            self.assertIn('>>>' + mode + '\r\nNATIVE_WINDOWS=' + native, config)

    def test_unknown_or_ambiguous_modes_do_not_write_files(self):
        for modes in ((), ('Video', 'Audio')):
            result, config, _, before = self.run_updater('FAV', modes)
            self.assertNotEqual(result.returncode, 0)
            self.assertIn('native-mode', result.stderr)
            self.assertEqual(config, before)

    def test_explicit_mode_and_audio_iris_are_supported(self):
        for iris, explicit in (((), 'video'), (('Audio',), 'auto')):
            result, config, native, _ = self.run_updater('FAV', iris, explicit)
            self.assertEqual(result.returncode, 0, result.stderr)
            mode = 'audio' if iris else 'video'
            self.assertIn('>>>' + mode + '\r\nNATIVE_WINDOWS=' + native, config)


if __name__ == '__main__':
    unittest.main()
