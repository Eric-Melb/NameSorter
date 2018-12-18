namespace NameSorter
{
    // An assumption of our scope is to only deal with ASCII names
    public class InvalidName : System.Exception
    {
        public InvalidName()
        {

        }

        public InvalidName(string message) : base(message)
        {

        }

    }
}
