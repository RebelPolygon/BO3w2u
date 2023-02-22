using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODW2L
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Clear console and assign BO3 and workshop path variables
            Console.Clear();
            string bo3 = Directory.GetCurrentDirectory();
            string workshop = Path.Combine(Path.Combine(Path.Combine(Path.Combine(bo3, ".."), ".."), "workshop"), "content", "311210");

            // Check through each subfolder found in the workshop directory
            foreach (string d in Directory.GetDirectories(workshop))
            {
                // Check if the directory contains a workshop.json file
                if (File.Exists(Path.Combine(d, "workshop.json")))
                {
                    string json = File.ReadAllText(Path.Combine(d, "workshop.json"));
                    string type = json.Substring(json.IndexOf("Type") + 8).Split('\"')[0];
                    string name = json.Substring(json.IndexOf("Title") + 9).Split('\"')[0];
                    string path = json.Substring(json.IndexOf("FolderName") + 14).Split('\"')[0];

                    //(DEBUG) Console.WriteLine(type +"\n"+name +"\n"+path);

                    // Determine output path based on type
                    string output = "";
                    if (type.Equals("map"))
                    {
                        output = Path.Combine(bo3, "usermaps", path, "zone");
                    }
                    else if (type.Equals("mod"))
                    {
                        output = Path.Combine(bo3, "mods", path);
                    }

                    // Create necessary directories if they don't exist
                    if (!Directory.Exists(output))
                    {
                        Console.WriteLine("(" + type + ") " + name + " [" + path + "] -> " + output);
                        Directory.CreateDirectory(output);
                        var diSource = new DirectoryInfo(d);
                        var diTarget = new DirectoryInfo(output);

                        // Move all files and subdirectories to the output directory
                        MoveAll(diSource, diTarget);
                    }
                }
            }
            Console.WriteLine("\n[DONE] You can unsub from those workshop items to save space");
            Console.ReadKey();
        }

        // Move all files and subdirectories from the source directory to the target directory
        public static void MoveAll(DirectoryInfo source, DirectoryInfo target)
        {
            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.MoveTo(Path.Combine(target.FullName, fi.Name));
            }

            // Move each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                MoveAll(diSourceSubDir, nextTargetSubDir);
                diSourceSubDir.Delete();
            }
        }
    }
}
