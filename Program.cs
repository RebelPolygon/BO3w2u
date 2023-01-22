using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Assign working directory to variable BO3
        string BO3 = Directory.GetCurrentDirectory();

        // Change directory to ../../workshop/content/311210
        Directory.SetCurrentDirectory("../../workshop/content/311210");

        // Iterate over subdirectories with numeric names
        foreach (string dir in Directory.GetDirectories(".", "*[0-9]*", SearchOption.AllDirectories))
        {
            // Check for workshop.json file
            if (File.Exists(Path.Combine(dir, "workshop.json")))
            {
                // Parse workshop.json
                string Type = File.ReadAllText(Path.Combine(dir, "workshop.json")).Split(new string[] { "Type\": \"" }, StringSplitOptions.None)[1].Split('"')[0];
                string Title = File.ReadAllText(Path.Combine(dir, "workshop.json")).Split(new string[] { "Title\": \"" }, StringSplitOptions.None)[1].Split('"')[0];
                string FolderName = File.ReadAllText(Path.Combine(dir, "workshop.json")).Split(new string[] { "FolderName\": \"" }, StringSplitOptions.None)[1].Split('"')[0];

                // Check the type of the workshop item
                if (Type == "map")
                {
                    // Create directory and move contents
                    Directory.CreateDirectory(Path.Combine(BO3, "usermaps", FolderName, "zone"));
                    MoveDirectory(dir, Path.Combine(BO3, "usermaps", FolderName, "zone"));
                }
                else if (Type == "mod")
                {
                    // Create directory and move contents
                    Directory.CreateDirectory(Path.Combine(BO3, "mods", FolderName));
                    MoveDirectory(dir, Path.Combine(BO3, "mods", FolderName));
                }
            }
        }
    }
    private static void MoveDirectory(string source, string destination)
    {
        // Move all files in the directory
        foreach (string file in Directory.GetFiles(source))
        {
            File.Move(file, Path.Combine(destination, Path.GetFileName(file)));
        }

        // Move all subdirectories
        foreach (string subdir in Directory.GetDirectories(source))
        {
            MoveDirectory(subdir, Path.Combine(destination, Path.GetFileName(subdir)));
        }

        // Delete the empty source directory
        Directory.Delete(source);
    }
}
