using System;
using System.IO;
using UnityEngine;

namespace Lion
{
    public class FileCreator
    {
        public static void CreateCSharpFile(string path, string sourceCode)
        {
            // Ensure the directory exists.
            string directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Write the source code to the file.
            File.WriteAllText(path, sourceCode);
        }
    }
}