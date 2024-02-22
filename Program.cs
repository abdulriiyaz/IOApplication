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

///6. MyCount<T>(this IEnumerable<T> source) : int
/// This method returns the number of elements in the input IEnumerable<T>
/// 

///7. MyCount<T>(this IEnumerable<T> that, Func<T, bool> predicate) : int
/// THis method returns the number of elements in the input IEnumerable<T> and counting only those elements for which the predicate returns true.

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
        public static int MyCount<TSource>(this IEnumerable<TSource> that, Func<TSource, bool> predicate)
        {
            //Microsoft Implementation (performant)

            var collection = that as ICollection<TSource>;
            if (collection != null)
                return collection.Count;

            int count = 0;
            foreach (var item in that)
                if (predicate(item))
                    count++;

            return count;
        }
        public static int MyCount<T>(this IEnumerable<T> that)
        {
            int count = 0;
            foreach (var item in that)
                count++;

            return count;
        }

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

            foreach (var item in source)
            {
                return item;
            }

            throw new InvalidOperationException();
        }

        public static TAcc MyAggregate<TAcc, TSource>(this IEnumerable<TSource> that, TAcc seed, Func<TAcc, TSource, TAcc> accumulator)
        {
            var sum = seed;
            foreach (var item in that)
            {
                sum = accumulator(sum, item);
            }
            return sum;
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            //use MySelect
            var num = new List<int> { 1, 2, 3, 4, 5 };
            var num2 = new List<int> { 2, 2, 2 };

            //num.MySelect(x => x * 2).ToList().ForEach(x => Console.WriteLine(x));
            //num.MyWhere(x => x == 5).ToList().ForEach(x => Console.WriteLine(x));

            //Console.WriteLine(num.MyFirst());
            //Console.WriteLine(num.MyCount());
            //Console.WriteLine(num.MyCount(x => x > 2));
            //Console.WriteLine(num.Aggregate(0, (a, i) => a + i));
            Console.WriteLine(num2.Aggregate(0, (a, i) => a + i));
            Console.WriteLine(num2.MyAggregate(0, (a, i) => a + i));


            Console.ReadKey();
        }
    }
}
