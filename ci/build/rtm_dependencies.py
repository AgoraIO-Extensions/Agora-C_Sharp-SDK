"""RTM-only dependency input; never fall back to RTC's video/audio URLs."""
import argparse
import json
import re
from pathlib import Path
from urllib.parse import urlsplit

PLATFORMS = {"iOS": "IOS", "Android": "ANDROID", "Mac": "MAC", "macOS": "MAC", "Windows": "WIN"}
CONFIG = Path(__file__).with_name("rtm_dependencies.json")


def validate_url(url, platform, iris):
    parsed = urlsplit(url)
    if (parsed.scheme != "https" or parsed.hostname not in {"download.agora.io", "download.shengwang.cn"}
            or parsed.port not in {None, 443}
            or parsed.username or parsed.password or parsed.query or parsed.fragment
            or not re.fullmatch(r"/[A-Za-z0-9_./%+-]+\.zip", parsed.path)):
        raise ValueError("RTM requires an explicit HTTPS SDK ZIP on the release CDN")
    name = parsed.path.rsplit("/", 1)[-1]
    if "rtm" not in name.lower() or "dcg" in name.lower():
        raise ValueError("RTC or unidentified artifact supplied to RTM")
    filename_platform = "Mac" if platform == "MAC" else {"IOS": "iOS", "ANDROID": "Android", "WIN": "Windows"}[platform]
    aliases = {"MAC": ("Mac", "macOS"), "WIN": ("Windows", "windows")}.get(platform, (filename_platform,))
    if not any(f"_{alias}_" in name for alias in aliases):
        raise ValueError("Artifact filename does not match its declared platform")
    if not iris and not (f"_Native_SDK_for_{filename_platform}_" in name or
                         re.match(r"(?:Agora|Shengwang)RtmEngine_(?:Android|iOS|windows|macOS)_Preview_", name)):
        raise ValueError("Unity packaging requires a Native SDK release ZIP")
    if iris and not name.startswith("iris_"):
        raise ValueError("Unity requires the standalone Iris build, not a CocoaPods ZIP")
    required = "_Unity_" if platform == "MAC" else "_Standalone_"
    if iris and required not in name:
        raise ValueError(f"Iris {platform} requires {required} artifact")
    return url


def from_results(items):
    urls = {}
    for item in items:
        platform = PLATFORMS.get(item.get("platform"))
        if not platform:
            continue
        if item.get("product_type") not in {"rtm", ""}:
            raise ValueError("Non-RTM dependency result")
        for field, prefix in [("cdn", "NATIVE"), ("iris_cdn", "IRIS")]:
            for url in item.get(field, []):
                # Result text can include both standalone and framework Iris packages.
                if prefix == "IRIS" and ("_Unity_" if platform == "MAC" else "_Standalone_") not in url:
                    continue
                value = validate_url(url, platform, prefix == "IRIS")
                key = f"{prefix}_{platform}_URL"
                if key in urls and urls[key] != value:
                    raise ValueError(f"Ambiguous artifact for {key}")
                urls[key] = value
    validate_config(urls)
    return urls


def validate_config(urls):
    expected = {f"{kind}_{platform}_URL" for kind in ("NATIVE", "IRIS") for platform in set(PLATFORMS.values())}
    if set(urls) != expected:
        raise ValueError("Supply exactly the four Native and four Unity-compatible Iris platform ZIPs; missing: "
                         + ", ".join(sorted(expected - set(urls))))
    for key, url in urls.items():
        kind, platform, _ = key.split("_")
        validate_url(url, platform, kind == "IRIS")


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("--input", type=Path)
    parser.add_argument("--config", type=Path, default=CONFIG)
    parser.add_argument("--env", action="store_true")
    args = parser.parse_args()
    if args.input:
        urls = from_results(json.loads(args.input.read_text()))
        args.config.write_text(json.dumps(urls, indent=2, sort_keys=True) + "\n")
    else:
        urls = json.loads(args.config.read_text())
        validate_config(urls)
    if args.env:
        print("\n".join(f"{key}={value}" for key, value in sorted(urls.items())))


if __name__ == "__main__":
    main()
