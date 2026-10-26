"""Run with python ci/build/csharp/test_finalize_signed.py (no signing/network)."""
from io import BytesIO
import json
from pathlib import Path
from tempfile import TemporaryDirectory
from zipfile import ZipFile

from finalize_signed import finalize


def zip_bytes(files):
    result = BytesIO()
    with ZipFile(result, 'w') as archive:
        for name, data in files.items():
            archive.writestr(name, data)
    return result.getvalue()


with TemporaryDirectory() as temp:
    root = Path(temp)
    inputs = root / 'inputs'
    inputs.mkdir()
    version = '4.5.3.6-alpha.1'
    manifest = root / 'manifest.json'
    manifest.write_text(json.dumps({'sdk_version': version, 'source_commit': 'abc', 'files': []}))
    canonical = {f'managed/{tfm}/agorartc.dll': f'signed-{tfm}'.encode() for tfm in ('net40', 'netstandard2.0')}
    canonical.update({f'native/{arch}/{name}': f'signed-{arch}-{name}'.encode()
                      for arch in ('x86', 'x64') for name in ('agora_rtc_sdk.dll', 'AgoraRtcWrapper.dll')})
    package_entries = {f'lib/{tfm}/agorartc.dll': b'unsigned' for tfm in ('net40', 'netstandard2.0')}
    package_entries.update({f'runtimes/win-{arch}/native/{name}': b'unsigned'
                            for arch in ('x86', 'x64') for name in ('agora_rtc_sdk.dll', 'AgoraRtcWrapper.dll')})
    package_entries['agora_rtc_sdk.nuspec'] = b'preserved metadata'
    package_name = f'agora_rtc_sdk.{version}.nupkg'
    sdk_name = f'Agora_CSharp_RTC_SDK_{version}_Release.zip'
    (inputs / sdk_name).write_bytes(zip_bytes({**canonical, package_name: zip_bytes(package_entries)}))
    for arch in ('x86', 'x64'):
        (inputs / f'Agora_CSharp_APIExample_{version}_{arch}.zip').write_bytes(zip_bytes({
            'agorartc.dll': b'signed elsewhere', 'agora_rtc_sdk.dll': b'signed elsewhere',
            'AgoraRtcWrapper.dll': b'signed elsewhere', 'C_Sharp-API_Example.exe': b'signed demo host',
            'coreclr.dll': b'Microsoft runtime signature preserved'}))
    output = root / 'release'
    finalize(inputs, output, manifest)
    with ZipFile(output / package_name) as package:
        assert package.read('agora_rtc_sdk.nuspec') == b'preserved metadata'
        assert package.read('lib/net40/agorartc.dll') == b'signed-net40'
        for arch in ('x86', 'x64'):
            with ZipFile(output / f'Agora_CSharp_APIExample_{version}_{arch}.zip') as demo:
                assert demo.read('C_Sharp-API_Example.exe') == b'signed demo host'
                assert demo.read('coreclr.dll') == b'Microsoft runtime signature preserved'
                assert demo.read('agorartc.dll') == package.read('lib/netstandard2.0/agorartc.dll')
                for name in ('agora_rtc_sdk.dll', 'AgoraRtcWrapper.dll'):
                    assert demo.read(name) == package.read(f'runtimes/win-{arch}/native/{name}')
    with ZipFile(output / sdk_name) as sdk:
        assert sdk.read(package_name) == (output / package_name).read_bytes()
    assert len(json.loads((output / 'manifest.json').read_text())['files']) == 4
    (inputs / f'Agora_CSharp_APIExample_{version}_x86.zip').unlink()
    try:
        finalize(inputs, root / 'missing-demo', manifest)
        raise AssertionError('Missing Demo must fail')
    except ValueError:
        pass
print('Signed canonical DLL propagation, nested/standalone NuGet equality, metadata and missing-input checks passed')
