#!/bin/bash
# Written by RebelPolygon
# Last Updated 2-22-23

# Assign working directory to variable BO3
BO3=$(pwd)

# Change directory to ../../workshop/content/311210
cd ../../workshop/content/311210

# Iterate over subdirectories with numeric names
for dir in $(find . -type d -name "[0-9]*"); do
  # Check for workshop.json file
  if [ -f "$dir/workshop.json" ]; then
    # Parse workshop.json using grep
    Type=$(grep -oP '"Type": "\K[^"]+' "$dir/workshop.json")
    FolderName=$(grep -oP '"FolderName": "\K[^"]+' "$dir/workshop.json")

    # Check the type of the workshop item
    if [ "$Type" == "map" ]; then
      # Create directory and move contents
      mkdir -p "$BO3/usermaps/$FolderName/zone"
      mv "$dir"/* "$BO3/usermaps/$FolderName/zone"
    elif [ "$Type" == "mod" ]; then
      # Create directory and move contents
      mkdir -p "$BO3/mods/$FolderName"
      mv "$dir"/* "$BO3/mods/$FolderName"
    fi
  fi
done
