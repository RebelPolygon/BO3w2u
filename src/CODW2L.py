# Written by RebelPolygon
# Last Updated 5-7-23

import os
import json
import shutil

# Define some ANSI color codes for colored text
GREEN = "\033[1;32m"
YELLOW = "\033[1;33m"
BLUE = "\033[1;34m"
RESET = "\033[0m"

# Define some pathname variables
bo3 = os.getcwd()
work = os.path.abspath(os.path.join(bo3, "..", "..", "workshop", "content", "311210"))

# Check if workshop folder is found
if not os.path.exists(work):
    print(f"The workshop folder cannot be found:")
    print(f"{BLUE}{work}{RESET}\n")
    print("Make sure this is execute in the BO3 folder")
    os._exit(0)

# Define the move_maps() function
def move_maps():
    # Get a list of all subdirectories in the workshop directory
    subdirs = [os.path.join(work, d) for d in os.listdir(work) if os.path.isdir(os.path.join(work, d))]

    # Check if there are any subdirectories
    if not subdirs:
        print("No content to move.")
        return

    # Loop through the subdirectories and check for the workshop.json file
    for i, subdir in enumerate(subdirs, start=1):
        json_file = os.path.join(subdir, "workshop.json")
        if not os.path.exists(json_file):
            continue

        with open(json_file) as f:
            data = json.load(f)

        # Extract the necessary information from the JSON file
        try:
            title = data["Title"]
            foldername = data["FolderName"]
            content_type = data["Type"]
        except KeyError:
            continue

        # Move the folder based on the type
        if content_type.lower() == "mod":
            output_folder = os.path.join(bo3, "mods", foldername)
        elif content_type.lower() == "map":
            output_folder = os.path.join(bo3, "usermaps", foldername, "zone")
        else:
            continue

        # Check if the output folder exists and skip if it does
        if os.path.exists(output_folder):
            print(f"Skipping ({i}/{len(subdirs)}): {GREEN}{title}{RESET}")
            print(f"> Type: {YELLOW}{content_type}{RESET} + Folder: {BLUE}{foldername}{RESET}\n")
            continue

        # Check if the source folder already exists in the output folder and skip if it does
        source_folder = os.path.abspath(subdir)
        if os.path.abspath(output_folder) == source_folder:
            continue

        # Display progress message and information for each subdirectory
        print(f"Moving ({i}/{len(subdirs)}): {GREEN}{title}{RESET}")
        print(f"> Type: {YELLOW}{content_type}{RESET} + Folder: {BLUE}{foldername}{RESET}\n")

        # Move the source folder to the output folder
        for item in os.listdir(source_folder):
            item_path = os.path.join(source_folder, item)
            shutil.move(item_path, output_folder)

# Call the move_maps() function
move_maps()
