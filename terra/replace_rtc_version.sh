#!/bin/sh

# Check if parameter is provided
if [ $# -eq 0 ]; then
    echo "Error: Please provide JSON dependencies output"
    echo "Usage: $0 '<json_string>'"
    echo "Example: $0 '[{\"platform\":\"iOS\",\"product_type\":\"rtc\",\"version\":\"4.5.2.2\"}]'"
    exit 1
fi

# Get JSON input parameter
json_input=$1

# Check if jq is available
if ! command -v jq >/dev/null 2>&1; then
    echo "Error: jq is required but not installed. Please install jq first."
    exit 1
fi

# Extract product_type and version from JSON
# Try to get the first non-empty version and its corresponding product_type
product_type=$(echo "$json_input" | jq -r '.[] | select(.version != "" and .version != null) | .product_type' | head -n 1)
version=$(echo "$json_input" | jq -r '.[] | select(.version != "" and .version != null) | .version' | head -n 1)

# Check if we got valid data
if [ -z "$product_type" ] || [ -z "$version" ]; then
    echo "Error: Could not extract product_type or version from JSON input"
    echo "Input JSON: $json_input"
    exit 1
fi

# Validate product_type
if [ "$product_type" != "rtc" ] && [ "$product_type" != "rtm" ]; then
    echo "Error: Invalid product_type '$product_type'. Expected 'rtc' or 'rtm'"
    exit 1
fi

# Construct version string with product_type prefix
new_version="${product_type}_${version}"

echo "Extracted product_type: $product_type"
echo "Extracted version: $version"
echo "Full version string: $new_version"

# Get script directory and yaml file path
script_dir="$(cd "$(dirname "$0")" && pwd)"

# Determine which yaml file to use based on product_type
if [ "$product_type" = "rtc" ]; then
    yaml_file="$script_dir/rtc.yaml"
elif [ "$product_type" = "rtm" ]; then
    yaml_file="$script_dir/rtm.yaml"
else
    echo "Error: Unknown product_type '$product_type'"
    exit 1
fi

# Check if yaml file exists
if [ ! -f "$yaml_file" ]; then
    echo "Error: $product_type.yaml file not found at $yaml_file"
    exit 1
fi

echo "Found $product_type.yaml at: $yaml_file"
echo "Current content of $product_type.yaml:"
cat "$yaml_file"
echo ""

# Extract version number without product_type prefix for path replacement
version_number="$version"
echo "Version number to replace with: $version_number"

# Replace version numbers in paths and headers_version
# This will replace both 'rtc_x.x.x.x' and 'rtm_x.x.x.x' patterns with the new version
echo "Running perl command..."
perl -pi -e "s/${product_type}_[0-9]+(\.[0-9]+)+/${product_type}_${version_number}/g" "$yaml_file"

# Check if replacement was successful
if [ $? -eq 0 ]; then
    echo "Version number successfully updated to: $new_version"
    echo "Updated content of $product_type.yaml:"
    cat "$yaml_file"
else
    echo "Error: Failed to update version number"
    exit 1
fi
