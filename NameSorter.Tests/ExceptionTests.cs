namespace NameSorter.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Tests for exceptions that aren't utilised in other classes
    /// (where they are otherwise tested)
    /// </summary>
    [TestFixture]
    public class Exceptions
    {

        // throw invalid name with no message on blank string to cover
        // this variant (only using message version currently otherwise)
        private string _throwerHelper(string s)
        {
            if (s != "")
            {
                return s;
            }
            else
            {
                throw new InvalidName();
            }
        }

        /// <summary>
        /// Keep our base version of InvalidNameException covered
        /// </summary>
        [Test]
        public void ThrowInvalidName()
        {
            Assert.Throws<InvalidName>(() => _throwerHelper(""));
        }

        /// <summary>
        /// Is getting to 100% coverage impractical?
        /// This test asks, but does not answer.
        /// </summary>
        [Test]
        public void HelperMethodWorks()
        {
            Assert.That("hello", Is.EqualTo(_throwerHelper("hello")));
        }
    }    
}
