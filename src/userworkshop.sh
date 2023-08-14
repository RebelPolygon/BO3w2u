#!/bin/bash
# Written by: RebelPolygon
# Last Updated: 8-13-2023

# Assign Current Working Directory to BO3
BO3=$(pwd)

# Change directory to workshop folder
cd ../../workshop/content/311210

# Iterate over workshop subdirectories
for d in */ ; do
    if [ -f "$PWD/${d}workshop.json" ]; then
        type=$(grep "Type" "$PWD/${d}workshop.json" | cut -d ":" -f2- |  awk '{ print substr( $0, 3, length($0)-3 ) }')
        name=$(grep "Title" "$PWD/${d}workshop.json" | cut -d ":" -f2- |  awk '{ print substr( $0, 3, length($0)-4 ) }')
        path=$(grep "FolderName" "$PWD/${d}workshop.json" | cut -d ":" -f2- |  awk '{ print substr( $0, 3, length($0)-4 ) }')
        if [ $type == "map" ]; then
          echo "($type) $name [$path] -> /usermaps/"
          mkdir -p "$BO3/usermaps/$path/zone"
          mv -T "$PWD/${d}" "$BO3/usermaps/$path/zone"
        fi
        if [ $type == "mod" ]; then
          echo "($type) $name [$path] -> /mods/"
          mkdir -p "$BO3/mods/$path"
          mv -T "$PWD/${d}" "$BO3/mods/$path"
        fi
    fi
done

# Display Confirmation Message
echo -e "\n[DONE] You can unsubscribe to save space"
