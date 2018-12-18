namespace NameSorter
{
    using System;

    // Separates given names from last names - for 1 to 4 word names only
    // We are mostly interested in the lastName for sorting & comparison
    // Full name is used for equality, also sorting if lastNames are equal
    public class SimpleName : IComparable<SimpleName>
    {
        
        private const int MaxNameLength = 4;
        private readonly string _givenNames;
        private readonly string _lastName;

        public SimpleName(string name)
        {
            if (name.Trim().Length == 0)
            {
                throw new InvalidName("Name cannot be an empty string");
            }

            string[] nameWords = name.Split(' ');
            int numberOfWords = nameWords.Length;

            if (numberOfWords > MaxNameLength)
            {
                throw new InvalidName("Name too long");
            }

            _lastName = nameWords[numberOfWords - 1];

            if (numberOfWords > 1)
            {
                _givenNames = "";
                for (int i = 0; i < numberOfWords - 1; i++)
                {
                    _givenNames += nameWords[i] + " ";
                }

                _givenNames = _givenNames.Trim();
            }
        }

        public string LastName()
        {
            return _lastName;
        }

        public string GivenNames()
        {
            
            return _givenNames ?? "";
        }

        public override string ToString()
        {
            string name = (
                GivenNames()
                + " " 
                + LastName()
                ).Trim();
                  
            return name;
        }
        
        // compare SimpleNames on lastName (and ignore case) by default
        // this lets us call .Sort() instead of using Sorter.cs if so inclined
        public int CompareTo(SimpleName that)
        {
            int result = String.Compare(
                this.LastName(),
                that.LastName(),
                StringComparison.OrdinalIgnoreCase
            );

            if (result == 0)
            {
                result = String.Compare(
                    this.GivenNames(),
                    that.GivenNames(),
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return result;
        }

        // let us test equality between full names by defining object value
        public override bool Equals(object that)
        {   
            return this.ToString().Equals(that.ToString());
        }

        // let us test equality between full names by defining object hashing
        public override int GetHashCode()
        {
            unchecked
            {
                int result = 0;
                result = LastName().GetHashCode();
                result *= GivenNames().GetHashCode();

                return result;
            }
        }
    }
}
