namespace NameSorter.Tests
{
    using NUnit.Framework;
    using System;
    using System.IO;

    [TestFixture]
    class MainFlow
    {
        private readonly string[] goodArgument = new[]
        {
            "test-unsorted-names-list.txt"
        };

        private readonly string[] badFilename = new[]
        {
            "this-file-does-not-exist.txt"
        };

        private readonly string[] tooFewArguments = new string[0];

        private readonly string[] tooManyArguments = new []
        {
            "a", "b", "c", "d"
        };

        [Test]
        public void CompletesHappyPath()
        {
            Assert.DoesNotThrow(() => ProgramFlow.Main(goodArgument));
        }

        [Test]
        public void RejectsTooFewArguments()
        {
            Assert.Throws<ArgumentException>(
                () => ProgramFlow.Main(tooFewArguments)
            );
        }

        [Test]
        public void RejectsTooManyArguments()
        {
            Assert.Throws<ArgumentException>(
                () => ProgramFlow.Main(tooManyArguments)
            );
        }

        [Test]
        public void ExitsOnBadFileName()
        {
            Assert.Throws<FileNotFoundException>(
                () => ProgramFlow.Main(badFilename)
            );
        }


    }
}
