namespace NameSorter.Tests
{
    using NUnit.Framework;
    using System.Linq;
    using System.Collections.Generic;

    [TestFixture]
    public class Sorting
    {
        private List<string> twoWords;
        private List<string> unsortedPangram;
        private List<string> sortedPangram;
        private List<string> unsortedSimilarWords;
        private List<string> sortedSimilarWords;
        private List<string> unsortedMixedCase;
        private List<string> sortedMixedCase;

        private List<SimpleName> unsortedNames;
        private List<SimpleName> sortedNames;

        [SetUp]
        protected void SetUp()
        {
            twoWords = new List<string> { "apple", "banana" };
            unsortedPangram = new List<string>
            {
                "sphinx", "of", "black", "quartz", "judge", "my", "vow"
            };
            sortedPangram = new List<string>
            {
                "black", "judge", "my", "of", "quartz", "sphinx", "vow"
            };

            unsortedSimilarWords = new List<string>
            {
                "tap", "tank", "tall", "taste", "tax", "takeoff"
            };
            sortedSimilarWords = new List<string>
            {
                "takeoff", "tall", "tank", "tap", "taste", "tax"
            };
            unsortedMixedCase = new List<string>
            {
                "urgent", "UTTERINGS", "uttering", "uniform", "Utiliser",
                "tail", "TALL", "verify"
            };
            sortedMixedCase = new List<string>
            {
                "tail", "TALL", "uniform", "urgent", "Utiliser",
                "uttering", "UTTERINGS", "verify"
            };

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

            sortedNames = new List<SimpleName>
            {
                new SimpleName("Anning"),
                new SimpleName("Catryna Louise Bilyk"),
                new SimpleName("Brockman"),
                new SimpleName("Brian Burston"),
                new SimpleName("Richard Colbeck"),
                new SimpleName("Jacinta Collins"),
                new SimpleName("Kristina Kerscher Keneally"),
                new SimpleName("Lisa Singh"),
                new SimpleName("David Smith"),
            };

        }

        [Test]
        public void IsAlphabeticallyAscending()
        {

            var sorted = Sorter.ListSort(twoWords);
            Assert.AreEqual(twoWords, sorted);

            sorted = Sorter.ListSort(unsortedPangram);
            Assert.AreEqual(sortedPangram, sorted);

            sorted = Sorter.ListSort(unsortedSimilarWords);
            Assert.AreEqual(sortedSimilarWords, sorted);

        }

        [Test]
        public void DeleteMe()
        {
            var sorted = unsortedPangram.ToList();
            sorted.Sort();

            Assert.AreEqual(sorted, sortedPangram);
        }

        [Test]
        public void IsCaseInsensitive()
        {
            var sorted = Sorter.ListSort(unsortedMixedCase);
            Assert.AreEqual(sortedMixedCase, sorted);

        }

        [Test]
        public void DoesNotChangeLength()
        {
            var sorted = Sorter.ListSort(unsortedPangram);
            Assert.AreEqual(sorted.Count, unsortedPangram.Count);
        }

        [Test]
        public void SortsNames()
        {
            var sorted = Sorter.ListSort(unsortedNames);

            for (var i = 0; i < sorted.Count; i++)
            {
                Assert.That(sorted[i], Is.EqualTo(sortedNames[i]));
            }
        }     
    }
}
