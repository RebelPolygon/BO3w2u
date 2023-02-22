// Written by RebelPolygon
// Last Updated 2-22-23

#include <fstream>
#include <iostream>
#include <filesystem>

namespace fs = std::filesystem;

int main() {
    // Assign BO3 and workshop path variables
    fs::path BO3 = fs::current_path();
    fs::path workshop = BO3.parent_path().parent_path() / "workshop" / "content" / "311210";

    // Check through each subfolder found in the workshop directory
    for (auto& entry : fs::directory_iterator(workshop)) {
        // Check if the entry is a directory
        if (entry.is_directory()) {
            // Check if the directory contains a workshop.json file
            fs::path workshop_json = entry.path() / "workshop.json";
            if (fs::exists(workshop_json)) {
                std::ifstream file(workshop_json);
                std::string line;
                std::string type;
                std::string folder_name;

                // Get Type and FolderName of each workshop item
                while (std::getline(file, line)) {
                    if (line.find("\"Type\":") != std::string::npos) {
                        type = line.substr(line.find(":") + 3, 3);
                    }
                    else if (line.find("\"FolderName\":") != std::string::npos) {
                        folder_name = line.substr(line.find(":") + 3, line.length() - line.find(":") - 5);
                    }
                }
                file.close();

                // Determine output path based on type
                fs::path output;
                if (type == "map") {
                    output = BO3 / "usermaps" / folder_name / "zone";
                } else if (type == "mod") {
                    output = BO3 / "mods" / folder_name;
                }

                // Create necessary directories if they don't exist
                fs::create_directories(output);

                // Move or copy the directory to the output path
                std::error_code ec;
                fs::rename(entry.path(), output, ec);
                if (ec) {
                    std::cerr << "Error moving " << entry.path() << " to " << output << ": " << ec.message() << std::endl;
                }
            }
        }
    }

    return 0;
}
