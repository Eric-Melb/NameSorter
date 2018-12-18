namespace NameSorter
{
    using System;
    using System.Collections.Generic;
    using static NameSorterIO;

    public class ProgramFlow
    {
        private const string OutfileName = "sorted-names-list.txt";

        public static void Main(string[] args)
        {
            string[] rawNames;
            List<SimpleName> nameList = new List<SimpleName>();
            List<SimpleName> sortedNames = new List<SimpleName>();

            // check arguments
            if (args.Length != 1)
            {
                throw new ArgumentException(
                    "Please provide only one argument, " +
                    "which is a filename populated with names"
                );
            } 

            // read file
            try
            {
                rawNames = ReadNames(args[0]);
            }
            catch (Exception)
            {
                Console.WriteLine(
                    "Please ensure your filename argument " + 
                    "is correct"
                );

                throw;
            }

            // construct names
            foreach (string name in rawNames)
            {
                SimpleName newName = new SimpleName(name);
                nameList.Add(newName);
            }

            // sort names
            sortedNames = Sorter.ListSort(nameList);

            // output names to file
            try
            {
                WriteNames(OutfileName, sortedNames);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to write sorted names to new file");
                Console.WriteLine(e);
            }
            
            // output names to screen
            DisplayOutput(sortedNames);
            
        }

    }
}
