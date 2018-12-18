namespace NameSorter.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class SimpleNames
    {
        /// <summary>
        /// SimpleName should turn a name string delimited by spaces
        /// into a SimpleName object containing a lastName and givenNames
        /// </summary>
        private string oneWordName;
        private string twoWordName;
        private string threeWordName;
        private string fourWordName;
        private string formerKingOfSpain;
        private SimpleName aName;
        private SimpleName bName;

        [SetUp]
        protected void SetUp()
        {
            oneWordName = "Chris";
            twoWordName = "Penny Wong";
            threeWordName = "Peter Stuart Whish-Wilson";
            fourWordName = "Steven Leigh (Steve) Martin";
            formerKingOfSpain = 
                "Juan Carlos Alfonso Víctor María de Borbón y Borbón - Dos Sicilias";

            aName = new SimpleName("a");
            bName = new SimpleName("b");
        }

        /// <summary>
        /// Are names correctly created, splitting last and given names?
        /// </summary>
        [Test]
        public void SplitLastNameFromGiven()
        {
            SimpleName name_one = new SimpleName(oneWordName);
            SimpleName name_two = new SimpleName(twoWordName);
            SimpleName name_three = new SimpleName(threeWordName);
            SimpleName name_four = new SimpleName(fourWordName);

            Assert.AreEqual(oneWordName, name_one.LastName());
            Assert.AreEqual("", name_one.GivenNames());

            Assert.AreEqual("Wong", name_two.LastName());
            Assert.AreEqual("Penny", name_two.GivenNames());

            Assert.AreEqual("Whish-Wilson", name_three.LastName());

            Assert.AreEqual("Martin", name_four.LastName());

        }

        /// <summary>
        /// Do name objects correctly override ToString() for output? 
        /// </summary>
        [Test]
        public void ReturnToStringUnmutated()
        {
            SimpleName name_one = new SimpleName(oneWordName);
            SimpleName name_two = new SimpleName(twoWordName);
            SimpleName name_three = new SimpleName(threeWordName);
            SimpleName name_four = new SimpleName(fourWordName);

            Assert.AreEqual(name_one.ToString(), name_one.LastName());
            Assert.AreEqual("Chris", name_one.ToString());

            Assert.AreEqual(twoWordName, name_two.ToString());
            Assert.AreEqual(twoWordName.Split(' ')[1], name_two.LastName());

            Assert.AreEqual(threeWordName, name_three.ToString());

            Assert.AreEqual(fourWordName, name_four.ToString());

        }

        /// <summary>
        /// Do we correctly reject blank names?
        /// </summary>
        [Test]
        public void CannotBeEmptyStrings()
        {
            SimpleName name;
            Assert.Throws<InvalidName>(() => name = new SimpleName(""));
        }

        /// <summary>
        /// As per the spec, do we prevent otherwise valid very long names?
        /// </summary>
        [Test]
        public void MustBeLessThanFiveWords()
        {
            SimpleName name;
            Assert.Throws<InvalidName>
            (
                () => name = new SimpleName(formerKingOfSpain)
            );

        }


        /// <summary>
        /// Does the expected comparison method work and use last names?
        /// </summary>
        [Test]
        public void AreComparable()
        {
            SimpleName x1 = new SimpleName("x");
            SimpleName x2 = new SimpleName("X");

            SimpleName name_one = new SimpleName("Jim Molan");
            SimpleName name_two = new SimpleName("Catryna Louise Bilyk");

            Assert.That(aName.CompareTo(bName), Is.LessThan(0));
            Assert.That(x1.CompareTo(x2), Is.EqualTo(0));
            Assert.That(name_two, Is.LessThan(name_one));
        }

        [Test]
        public void ReturnMatchingHashCodesForTheSameNames()
        {
            SimpleName bName2 = new SimpleName("b");
            
            Assert.That(bName.GetHashCode(), Is.EqualTo(bName2.GetHashCode()));
        }

        [Test]
        public void ReturnDifferentHashCodesForDifferentNames()
        {
            Assert.AreNotEqual(aName.GetHashCode(), bName.GetHashCode());
        }
    }
}