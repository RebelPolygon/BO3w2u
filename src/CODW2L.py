# Written by RebelPolygon
# Last Updated 5-7-23

import os
import shutil
import json

# Assign working directory to variable BO3
BO3 = os.getcwd()

# Change directory to ../../workshop/content/311210
try:
    os.chdir(os.path.abspath(os.path.join(BO3, "..", "..", "workshop", "content", "311210")))
except OSError as e:
    print(f"Error changing to workshop directory:\n{e}\n\n")
    input("Press Enter to exit...")
    exit()

# Iterate over subdirectories with numeric names
for dirpath, dirnames, filenames in os.walk("."):
    for dirname in dirnames:
        if dirname.isnumeric():
            dir = os.path.join(dirpath, dirname)
            # Check for workshop.json file
            json_path = os.path.join(dir, "workshop.json")
            if os.path.isfile(json_path):
                # Parse workshop.json using json module
                with open(json_path, "r") as f:
                    data = json.load(f)
                    Type = data["Type"]
                    Title = data["Title"]
                    FolderName = data["FolderName"]
                # Check the type of the workshop item
                if Type == "map":
                    # Create directory and move contents
                    new_dir = os.path.join(BO3, "usermaps", FolderName, "zone")
                    os.makedirs(new_dir, exist_ok=True)
                    for filename in os.listdir(dir):
                        src_path = os.path.join(dir, filename)
                        dst_path = os.path.join(new_dir, filename)
                        if not os.path.exists(dst_path):
                            # Move content when conditions are met
                            shutil.move(src_path, dst_path)
                elif Type == "mod":
                    # Create directory and move contents
                    new_dir = os.path.join(BO3, "mods", FolderName)
                    os.makedirs(new_dir, exist_ok=True)
                    for filename in os.listdir(dir):
                        src_path = os.path.join(dir, filename)
                        dst_path = os.path.join(new_dir, filename)
                        if not os.path.exists(dst_path):
                            # Move content when conditions are met
                            shutil.move(src_path, dst_path)

# Display completion message and wait for user input
print("[DONE] You can unsub from those workshop items to save space")
input("Press Enter to exit...")
