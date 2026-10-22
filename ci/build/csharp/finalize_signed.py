"""Repack NuGet and Demo copies from the canonical CodeSign-signed SDK DLLs."""
import hashlib
from io import BytesIO
import json
from pathlib import Path
import sys
from zipfile import ZipFile, ZIP_DEFLATED


def rewrite(source, target, replacements):
    names = source.namelist()
    missing = replacements.keys() - set(names)
    if missing:
        raise ValueError(f'Missing candidate entries: {sorted(missing)}')
    with ZipFile(target, 'w', ZIP_DEFLATED) as result:
        for item in source.infolist():
            result.writestr(item, replacements[item.filename] if item.filename in replacements else source.read(item))


def finalize(inputs, output, manifest_path):
    manifest = json.loads(manifest_path.read_text(encoding='utf-8-sig'))
    version = manifest['sdk_version']
    sdk_name = f'Agora_CSharp_RTC_SDK_{version}_Release.zip'
    demo_names = [f'Agora_CSharp_APIExample_{version}_{arch}.zip' for arch in ('x86', 'x64')]
    if {p.name for p in inputs.glob('*.zip')} != {sdk_name, *demo_names}:
        raise ValueError('Signed input ZIPs do not match this candidate version')
    output.mkdir(exist_ok=False)
    with ZipFile(inputs / sdk_name) as sdk:
        nupkgs = [n for n in sdk.namelist() if n.endswith('.nupkg')]
        if len(nupkgs) != 1:
            raise ValueError('Expected exactly one nested NuGet candidate')
        replacements = {f'lib/{tfm}/agorartc.dll': sdk.read(f'managed/{tfm}/agorartc.dll')
                        for tfm in ('net40', 'netstandard2.0')}
        native = {name: sdk.read(name) for name in sdk.namelist()
                  if name.startswith(('native/x86/', 'native/x64/')) and name.lower().endswith(('.dll', '.exe'))}
        if not native:
            raise ValueError('No canonical native binaries found')
        for arch in ('x86', 'x64'):
            for required in ('agora_rtc_sdk.dll', 'AgoraRtcWrapper.dll'):
                if f'native/{arch}/{required}' not in native:
                    raise ValueError(f'Missing canonical {arch}/{required}')
        replacements.update({f'runtimes/win-{name.split("/")[1]}/native/{name.split("/")[-1]}': data
                             for name, data in native.items()})
        with ZipFile(BytesIO(sdk.read(nupkgs[0]))) as package:
            package_path = output / Path(nupkgs[0]).name
            rewrite(package, package_path, replacements)
        rewrite(sdk, output / sdk_name, {nupkgs[0]: package_path.read_bytes()})
        for arch, demo_name in zip(('x86', 'x64'), demo_names):
            demo_replacements = {'agorartc.dll': replacements['lib/netstandard2.0/agorartc.dll']}
            demo_replacements.update({name.split('/')[-1]: data for name, data in native.items()
                                      if name.startswith(f'native/{arch}/')})
            with ZipFile(inputs / demo_name) as demo:
                rewrite(demo, output / demo_name, demo_replacements)
    manifest['signing'] = {'service': 'CodeSign', 'assembly_source': 'signed SDK managed/native binaries'}
    manifest['files'] = []
    for path in sorted(output.iterdir()):
        digest = hashlib.sha256()
        with path.open('rb') as stream:
            for chunk in iter(lambda: stream.read(1024 * 1024), b''):
                digest.update(chunk)
        manifest['files'].append({'name': path.name, 'sha256': digest.hexdigest()})
    (output / 'manifest.json').write_text(json.dumps(manifest, indent=2), encoding='utf-8')
    print('NuGet and Demo dependencies repacked from canonical signed SDK binaries')


if __name__ == '__main__':
    finalize(*(Path(arg) for arg in sys.argv[1:]))
