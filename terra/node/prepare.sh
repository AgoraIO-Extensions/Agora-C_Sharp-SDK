#!/bin/sh
if [ "$1" = "--json" ]; then
    rm -rf .terra
    npm run terra_json
else
    rm -rf node_modules
    rm -rf yarn.lock
    yarn
    rm -rf .terra
    npm run terra_json
fi
