﻿namespace IOApp

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

    static class EnumerableExtension
    {
        public static IEnumerable<TResult> Map<TSource, TResult>(this IEnumerable<TSource> that, Func<TSource, TResult> projection)
        {
            foreach (var item in that)
            {
                yield return projection(item);
            }
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> that, Func<T, bool> predicate)
        {
            foreach (var item in that)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
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
            ppl.Map(p => p._firstName).ToList().ForEach(Console.WriteLine);
            ppl.Filter(p => p._firstName == "John").ToList().ForEach(Console.WriteLine);

            //var fPPl = ppl
            //    .Filter(p => p._firstName.EndsWith("N", StringComparison.CurrentCultureIgnoreCase))
            //    .Map(p => p._firstName);


            ////METHOD SYNTAX
            //var fPPl = ppl
            //   .Where(p => p._firstName.EndsWith("N", StringComparison.CurrentCultureIgnoreCase))
            //   .Select(p => p._firstName);


            ////QUERY SYNTAX
            //var fPPl2 =
            //    from p in ppl
            //    where p._firstName.EndsWith("N", StringComparison.CurrentCultureIgnoreCase)
            //    select p._firstName;


            ////Enumerable Class has static methods to use.
            //var num = Enumerable.Range(0, 99)
            //    .Where(n => n % 2 == 0)
            //    .Select(n => n * n);

            ////instantiate empty int enumerble
            //var num2 = Enumerable.Empty<int>();

            ////instantiate enumerable with single element
            Enumerable.Repeat("Riyaz", 20)
                .ToList()
                .ForEach(Console.WriteLine);



            //fPPl.ToList().ForEach(Console.WriteLine);
            //fPPl2.ToList().ForEach(Console.WriteLine);
            Console.ReadKey();
        }


    }
}
