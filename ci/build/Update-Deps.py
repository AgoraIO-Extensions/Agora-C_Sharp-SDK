import json
import os
import sys
from typing import TypedDict
import re
import argparse
from urllib.parse import urlsplit


class DepItem(TypedDict):
    product_type: str
    platform: str
    cdn: list[str]
    iris_cdn:list[str]
    iris_version: str


deps = {
    "video": {
        "IRIS_IOS":"",
        "IRIS_ANDROID":"",
        "IRIS_MACOS":"",
        "IRIS_WINDOWS":"",
        "NATIVE_IOS":"",
        "NATIVE_ANDROID":"",
        "NATIVE_MACOS":"",
        "NATIVE_WINDOWS":""
    },
    "audio": {
        "IRIS_IOS":"",
        "IRIS_ANDROID":"",
        "IRIS_MACOS":"",
        "IRIS_WINDOWS":"",
        "NATIVE_IOS":"",
        "NATIVE_ANDROID":"",
        "NATIVE_MACOS":"",
        "NATIVE_WINDOWS":""
    }
}

def package_mode(url: str) -> str | None:
    filename = urlsplit(url).path.rsplit('/', 1)[-1]
    native = re.search(r'_Native_SDK_for_[^_]+_(?:rel\.)?v[^_]+_(?:\d+_)?(.+?)(?:_\d{8}_\d{4}_\d+)?(?:_external)?\.zip$', filename, re.I)
    if native:
        return {'FULL': 'video', 'VIDEO': 'video', 'VOICE': 'audio', 'AUDIO': 'audio'}.get(native.group(1).upper())
    iris = re.search(r'_(Video|Audio)(?:_|\.zip$)', filename, re.I)
    return iris.group(1).lower() if iris else None


def native_mode(url: str, iris_urls: list[str], explicit: str) -> str:
    known = package_mode(url)
    if known:
        return known
    if explicit != 'auto':
        return explicit
    modes = {package_mode(iris) for iris in iris_urls if isUnityWanted(iris)} - {None}
    if len(modes) == 1:
        return modes.pop()
    raise ValueError('Cannot determine audio/video mode for custom Native profile: '
                     + url + '; select matching Iris artifacts or set native-mode to video/audio')


def isUnityWanted(url: str) -> bool:
    url_lower = url.lower()
    if "mac" in url_lower:
        if "unity" in url_lower:
            return True
        return False
    else:
        if "standalone" in url_lower:
            return True
        return False 


def update_url_config_lines(lines: list[str], deps_data: dict[str, dict[str, str]]) -> list[str]:
    updated_lines: list[str] = []
    current_section: str | None = None

    for raw_line in lines:
        line_noeol = raw_line.rstrip("\r\n")
        line_ending = raw_line[len(line_noeol):]
        stripped = line_noeol.strip()

        if stripped.startswith(">>>"):
            current_section = stripped[3:]
            updated_lines.append(raw_line)
            continue
        if stripped == "<<<end":
            current_section = None
            updated_lines.append(raw_line)
            continue

        if current_section and "=" in line_noeol:
            key, value = line_noeol.split("=", 1)
            dep_value = deps_data.get(current_section, {}).get(key, "")
            if dep_value:
                updated_lines.append(f"{key}={dep_value}{line_ending}")
                continue

        updated_lines.append(raw_line)

    return updated_lines

parser = argparse.ArgumentParser(description='Update explicitly selected Native/Iris dependencies')
parser.add_argument('dependencies_json')
parser.add_argument('--native-mode', choices=('auto', 'video', 'audio'), default='auto')
args = parser.parse_args()
data:list[DepItem] = json.loads(args.dependencies_json)

for item in data:
    p_type = item["product_type"]
    platform = item["platform"]
    cdn_list = item["cdn"]
    iris_cdn_list = item["iris_cdn"]

    for cdn in cdn_list:
        mode = native_mode(cdn, iris_cdn_list, args.native_mode)
        deps[mode][f"NATIVE_{platform.upper()}"] = cdn

    for iris_cdn in iris_cdn_list:
        if not isUnityWanted(iris_cdn):
            continue
        mode = package_mode(iris_cdn)
        if mode is None:
            raise ValueError('Cannot determine mode of selected Iris artifact: ' + iris_cdn)
        deps[mode][f"IRIS_{platform.upper()}"] = iris_cdn


# deps["audio"]["NATIVE_MACOS"],  deps["audio"]["NATIVE_WINDOWS"] will use Native_SDK_Video
if deps["audio"]["NATIVE_MACOS"] == "" and deps["video"]["NATIVE_MACOS"] != "":
    deps["audio"]["NATIVE_MACOS"] = deps["video"]["NATIVE_MACOS"]
if deps["audio"]["NATIVE_WINDOWS"] == "" and deps["video"]["NATIVE_WINDOWS"] != "":
    deps["audio"]["NATIVE_WINDOWS"] = deps["video"]["NATIVE_WINDOWS"]


script_dir = os.path.dirname(os.path.abspath(__file__))
url_config_path = os.path.join(script_dir, "..", "..", "ci", "build", "url_config.txt")
with open(url_config_path, "r", encoding="utf-8", newline="") as handle:
    url_config_lines = handle.readlines()

updated_lines = update_url_config_lines(url_config_lines, deps)

with open(url_config_path, "w", encoding="utf-8", newline="") as handle:
    handle.writelines(updated_lines)


# Update rtc.yaml with version
version = ""
for item in data:
    if item["version"] != "":
        version = item["version"]
        break
    if item["iris_version"] != "":
        version = item["iris_version"]
        break

rtc_yaml_path = os.path.join(script_dir, "..", "..", "terra","rtc.yaml")

with open(rtc_yaml_path, "r", encoding="utf-8") as handle:
    rtc_yaml_content = handle.read()

pattern = re.compile(r"rtc_\d+(?:\.\d+)*")
rtc_yaml_content = pattern.sub(f"rtc_{version}", rtc_yaml_content)

with open(rtc_yaml_path, "w", encoding="utf-8") as handle:
    handle.write(rtc_yaml_content)
















    







