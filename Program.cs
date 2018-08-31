using System;
using System.IO;
using System.Diagnostics;

namespace kube_mc
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string replic = "1";
            Console.WriteLine("Changing n° of replicas to "+replic);
            yamlscripter(replic);
        }

        static void yamlscripter(string replicas){
            int line_to_edit = 8; // Warning: 1-based indexing!
            string sourceFile = "newpods.yaml";
            string destinationFile = "newpods.yaml";

            // Read the appropriate line from the file.
            string lineToWrite = null;
            using (StreamReader reader = new StreamReader(sourceFile))
            {
                for (int i = 1; i <= line_to_edit; ++i)
                    lineToWrite = reader.ReadLine();
            }

            if (lineToWrite == null)
                throw new InvalidDataException("Line does not exist in " + sourceFile);

            // Read the old file.
            string[] lines = File.ReadAllLines(destinationFile);

            // Write the new file over the old file.
            using (StreamWriter writer = new StreamWriter(destinationFile))
            {
                for (int currentLine = 1; currentLine <= lines.Length; ++currentLine)
                {
                    if (currentLine == line_to_edit)
                    {
                        writer.WriteLine("  replicas: "+replicas);
                    }
                    else
                    {
                        writer.WriteLine(lines[currentLine - 1]);
                    }
                }
            }
        }
    }
}
