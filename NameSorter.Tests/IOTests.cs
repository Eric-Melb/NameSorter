namespace NameSorter.Tests
{
    using NUnit.Framework;
    using System.IO;
    using System.Collections.Generic;
    

    [TestFixture]
    public class InputOutput
    {
        private List<SimpleName> unsortedNames;

        [SetUp]
        protected void SetUp()
        {
            unsortedNames = new List<SimpleName>
            {
                new SimpleName("Brockman"),
                new SimpleName("Anning"),
                new SimpleName("Brian Burston"),
                new SimpleName("David Smith"),
                new SimpleName("Lisa Singh"),
                new SimpleName("Richard Colbeck"),
                new SimpleName("Jacinta Collins"),
                new SimpleName("Kristina Kerscher Keneally"),
                new SimpleName("Catryna Louise Bilyk")
            };
        }

        [Test]
        public void ReadsAndWritesFiles()
        {
            string outfile = "test-outfile.txt";

            NameSorterIO.WriteNames(outfile, unsortedNames);

            string[] namesFromFile = NameSorterIO.ReadNames(outfile);

            Assert.That(namesFromFile, Is.EquivalentTo(unsortedNames));
        }

        [Test]
        public void WritesListToConsoleWithoutThrowing()
        {
            NameSorterIO.DisplayOutput(unsortedNames);
        }

        [Test]
        public void ThrowsOnBadReadPath()
        {
            string badFilepath = "completejunk[].]";

            Assert.Throws<FileNotFoundException>(() => NameSorterIO.ReadNames(badFilepath));
            
        }

        
    }
}
