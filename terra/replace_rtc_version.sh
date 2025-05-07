#!/bin/sh

# Check if parameter is provided
if [ $# -eq 0 ]; then
    echo "Error: Please provide version number parameter"
    echo "Usage: $0 rtc_x.x.x or $0 rtc_x.x.x.x"
    exit 1
fi

# Get version number parameter
new_version=$1

# Check version number format using grep
if ! echo "$new_version" | grep -qE '^rtc_[0-9]+(\.[0-9]+)+$'; then
    echo "Error: Invalid version number format"
    echo "Correct format should be: rtc_x.x.x or rtc_x.x.x.x"
    exit 1
fi

# Get script directory and yaml file path
script_dir="$(cd "$(dirname "$0")" && pwd)"
yaml_file="$script_dir/rtc.yaml"

# Check if yaml file exists
if [ ! -f "$yaml_file" ]; then
    echo "Error: rtc.yaml file not found at $yaml_file"
    exit 1
fi

echo "Found rtc.yaml at: $yaml_file"
echo "Current content of rtc.yaml:"

# Extract version number without 'rtc_' prefix for path replacement
version_number=$(echo "$new_version" | sed 's/^rtc_//')
echo "Version number to replace with: $version_number"

# Replace version numbers in paths and headers_version
echo "Running perl command..."
perl -pi -e "s/rtc_[0-9]+(\.[0-9]+)+/rtc_${version_number}/g" "$yaml_file"

# Check if replacement was successful
if [ $? -eq 0 ]; then
    echo "Version number successfully updated to: $new_version"
    echo "Updated content of rtc.yaml:"
    cat "$yaml_file"
else
    echo "Error: Failed to update version number"
    exit 1
fi
