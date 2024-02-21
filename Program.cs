namespace IOApp

{
    class Person
    {
        public string _firstName { get; private set; }
        public string _lastName { get; private set; }
        public Person(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            List<Person> ppl = new List<Person>
            {
                new Person("John", "Doe"),
                new Person("Jane", "Doe"),
                new Person("John", "Smith"),
            };
            IEnumerable<Person> ppl2 = Filter(ppl, p => p._firstName.StartsWith("J", StringComparison.CurrentCultureIgnoreCase));

            IEnumerable<string> firstNames = Map<Person, string>(ppl2, p => p._firstName);
            IEnumerable<string> lastNames = Map<Person, string>(ppl2, p => p._lastName);

            Console.ReadKey();
        }

        static IEnumerable<TResult> Map<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> projection)
        {
            foreach (var item in source)
            {
                yield return projection(item);
            }
        }

        static IEnumerable<T> Filter<T>(IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
