//CREATE THE FOLLOWING EXTENSION METHODS ON IEnumerable<T> INTERFACE ON A CLASS CALLED EnumerableExtension
//1. Map<TSource, TResult>(this IEnumerable<TSource> that, Func<TSource, TResult> projection) : IEnumerable<TResult>
// This method returns a new IEnumerable<TResult> by applying the projection function to each element of the input IEnumerable<TSource>

//2. Filter<T>(this IEnumerable<T> that, Func<T, bool> predicate) : IEnumerable<T>
// This method returns a new IEnumerable<T> by applying the predicate function to each element of the input IEnumerable<T> and returning only those elements for which the predicate returns true

//3. MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> projection) : IEnumerable<TResult>
// This method returns a new IEnumerable<TResult> by applying the projection function to each element of the input IEnumerable<TSource>

//4. MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) : IEnumerable<TSource>
// This method returns a new IEnumerable<TSource> by applying the predicate function to each element of the input IEnumerable<TSource> and returning only those elements for which the predicate returns true

//5. MyFirst<TSource>(this IEnumerable<TSource> source) : TSource
// This method returns the first element of the input IEnumerable<TSource>

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

    static class EnumerableExtension
    {
        public static IEnumerable<TResult> Map<TSource, TResult>(this IEnumerable<TSource> that, Func<TSource, TResult> projection)
        {
            foreach (var item in that)
                yield return projection(item);
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> that, Func<T, bool> predicate)
        {
            foreach (var item in that)
            {
                if (predicate(item))
                    yield return item;
            }
        }

        public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> projection)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            foreach (var item in source)
            {
                yield return projection(item);
            }
        }

        public static IEnumerable<TSource> MyWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            foreach (var item in source)
            {
                if (predicate(item))
                    yield return item;
            }
        }
        public static TSource MyFirst<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("Source");

            return source.First();
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            //use MySelect
            var num = new List<int> { 1, 2, 3, 4, 5 };
            num.MySelect(x => x * 2).ToList().ForEach(x => Console.WriteLine(x));
            num.MyWhere(x => x == 5).ToList().ForEach(x => Console.WriteLine(x));
            var i = num.MyFirst();
            Console.WriteLine(i);
            Console.ReadKey();
        }
    }
}
