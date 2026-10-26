"""Check the real candidate packages, including Windows PE architecture and hashes."""
import hashlib
import json
from pathlib import Path
import struct
import sys
from zipfile import ZipFile


def machine(data):
    assert data[:2] == b'MZ', 'Expected a Windows executable'
    offset = struct.unpack_from('<I', data, 0x3C)[0]
    assert data[offset:offset + 4] == b'PE\0\0', 'Invalid PE signature'
    return struct.unpack_from('<H', data, offset + 4)[0]


def verify(output):
    manifest = json.loads((output / 'manifest.json').read_text(encoding='utf-8-sig'))
    assert manifest['source_commit'] and manifest['sdk_version'].startswith('4.5.')
    for item in manifest['files']:
        hasher = hashlib.sha256()
        with (output / item['name']).open('rb') as stream:
            for chunk in iter(lambda: stream.read(1024 * 1024), b''):
                hasher.update(chunk)
        digest = hasher.hexdigest()
        assert digest == item['sha256'], f"Hash mismatch: {item['name']}"
    with ZipFile(next(output.glob('*.nupkg'))) as package:
        for tfm in ['net40', 'netstandard2.0']:
            assert package.read(f'lib/{tfm}/agorartc.dll')[:2] == b'MZ'
        for arch, expected in [('x86', 0x14C), ('x64', 0x8664)]:
            for name in ['AgoraRtcWrapper.dll', 'agora_rtc_sdk.dll']:
                binary = package.read(f'runtimes/win-{arch}/native/{name}')
                assert machine(binary) == expected, f'Wrong {arch} native architecture: {name}'
            demo_zip = next(output.glob(f'*APIExample*_{arch}.zip'))
            with ZipFile(demo_zip) as demo:
                assert machine(demo.read('C_Sharp-API_Example.exe')) == expected
                runtime = json.loads(demo.read('C_Sharp-API_Example.runtimeconfig.json'))['runtimeOptions']
                assert runtime['tfm'] == 'net10.0', 'Demo must target supported .NET 10'
                assert not runtime.get('framework') and not runtime.get('frameworks'), 'Demo must not require installed .NET'
                included = {item['name']: item['version'] for item in runtime['includedFrameworks']}
                assert included['Microsoft.NETCore.App'].startswith('10.0.')
                assert included['Microsoft.WindowsDesktop.App'].startswith('10.0.')
                for name in ['hostfxr.dll', 'hostpolicy.dll', 'coreclr.dll', 'System.Private.CoreLib.dll', 'System.Windows.Forms.dll']:
                    assert demo.read(name)[:2] == b'MZ', f'Missing bundled runtime: {arch}/{name}'
                assert machine(demo.read('coreclr.dll')) == expected, 'Runtime architecture must match Demo host'
                assert demo.read('agorartc.dll') == package.read('lib/netstandard2.0/agorartc.dll')
                for name in ['AgoraRtcWrapper.dll', 'agora_rtc_sdk.dll']:
                    assert demo.read(name) == package.read(f'runtimes/win-{arch}/native/{name}')
    print('Package hashes, managed targets, Windows x86/x64 hosts and exact Demo dependencies verified')


if __name__ == '__main__':
    verify(Path(sys.argv[1]))
