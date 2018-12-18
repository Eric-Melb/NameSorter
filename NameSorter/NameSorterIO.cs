namespace NameSorter
{
    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;

    // remove IO from main program for future UI considerations
    public static class NameSorterIO
    {
        public static void DisplayOutput(List<SimpleName> output)
        {
            foreach (var item in output)
            {
                Console.WriteLine(item.ToString());
            }
        }

        // one line per array entry (newline delimiter)
        public static string[] ReadNames(string filepath)
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(filepath, Encoding.UTF8);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to read file " + filepath);
                Console.WriteLine(e);
                throw;
            }

            return lines;
        }

        public static void WriteNames(string filepath, List<SimpleName> nameList)
        {
            using (StreamWriter file = new StreamWriter(filepath))
            {
                foreach (SimpleName name in nameList)
                {
                    file.WriteLine(name.ToString());
                }
            }
        }


    }
}