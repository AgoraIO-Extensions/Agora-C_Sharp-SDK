from pathlib import Path
import subprocess
import tempfile
import unittest


class WorkflowSourceTests(unittest.TestCase):
    def test_existing_terra_branch_uses_triggering_updater_without_resetting_outputs(self):
        source = Path(__file__).resolve().parents[2]
        workflow = (source / '.github/workflows/terra.yml').read_text()
        restore = next(line.strip() for line in workflow.splitlines()
                       if line.strip().startswith('git restore --source='))
        self.assertIn('${{ github.sha }}', restore)
        self.assertLess(workflow.index(restore), workflow.index('python ./Update-Deps.py'))
        updater = Path(__file__).with_name('Update-Deps.py').read_bytes()
        with tempfile.TemporaryDirectory() as directory:
            root = Path(directory)
            build = root / 'ci/build'
            build.mkdir(parents=True)
            (build / 'Update-Deps.py').write_bytes(updater)
            (build / 'url_config.txt').write_text('base configuration\n')
            (root / 'generated.cs').write_text('base output\n')

            def git(*args):
                return subprocess.run(['git', '-c', 'core.hooksPath=/dev/null',
                                       '-c', 'user.name=Fixture', '-c', 'user.email=fixture@example.invalid',
                                       *args], cwd=root, check=True, capture_output=True, text=True).stdout.strip()

            git('init', '-q')
            git('add', '.')
            git('commit', '-qm', 'trigger source')
            trigger = git('rev-parse', 'HEAD')
            git('checkout', '-qb', 'terra/existing')
            (build / 'Update-Deps.py').write_text('raise SystemExit("stale updater")\n')
            (build / 'url_config.txt').write_text('selected target configuration\n')
            (root / 'generated.cs').write_text('existing generated output\n')
            git('add', '.')
            git('commit', '-qm', 'existing result branch')
            subprocess.run(['bash', '-e', '-c', restore.replace('${{ github.sha }}', trigger)],
                           cwd=build, check=True, capture_output=True, text=True)
            self.assertEqual((build / 'Update-Deps.py').read_bytes(), updater)
            self.assertEqual((build / 'url_config.txt').read_text(), 'selected target configuration\n')
            self.assertEqual((root / 'generated.cs').read_text(), 'existing generated output\n')
            self.assertEqual(git('diff', '--name-only'), 'ci/build/Update-Deps.py')


if __name__ == '__main__':
    unittest.main()
