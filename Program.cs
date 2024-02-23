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
/// 
///8. MyAggregate<TAcc, TSource>(this IEnumerable<TSource> that, TAcc seed, Func<TAcc, TSource, TAcc> accumulator) : TAcc
/// This method returns the result of applying the accumulator function to each element of the input IEnumerable<TSource> and the seed value.
/// 
// 9. MyUnion<TSource>(this IEnumerable<TSource> that, IEnumerable<TSource> other) : IEnumerable<TSource>
// This method returns a new IEnumerable<TSource> that contains the unique elements from both the input IEnumerable<TSource> and the other IEnumerable<TSource>
// 10. MyConcat<TSource>(this IEnumerable<TSource> that, IEnumerable<TSource> other) : IEnumerable<TSource>
// This method returns a new IEnumerable<TSource> that contains all the elements from the input IEnumerable<TSource> followed by all the elements from the other IEnumerable<TSource>

// 11. MyUnion<TSource>(this IEnumerable<TSource> that, IEnumerable<TSource> other, IEqualityComparer<TSource> comparer) : IEnumerable<TSource>
// This method returns a new IEnumerable<TSource> that contains the unique elements from both the input IEnumerable<TSource> and the other IEnumerable<TSource> using the specified IEqualityComparer<TSource> to compare elements.

//12. MyExcept<TSource>(this IEnumerable<TSource> that, IEnumerable<TSource> other) : IEnumerable<TSource>
// This method returns a new IEnumerable<TSource> that contains the elements from the input IEnumerable<TSource> that are not in the other IEnumerable<TSource>

//13. MyIntersect<TSource>(this IEnumerable<TSource> that, IEnumerable<TSource> other) : IEnumerable<TSource>
// This method returns a new IEnumerable<TSource> that contains the elements that are common to both the input IEnumerable<TSource> and the other IEnumerable<TSource>
///14. MyToDictionary<TSource, TKey, TValue>(this IEnumerable<TSource> that, Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector) : Dictionary<TKey, TValue>
///This method returns a new Dictionary<TKey, TValue> by applying the keySelector and valueSelector functions to each element of the input IEnumerable<TSource>

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
                throw new ArgumentNullException("source");

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

        public static IEnumerable<TSource> MyUnion<TSource>(this IEnumerable<TSource> that, IEnumerable<TSource> other)
        {
            return MyUnion(that, other, EqualityComparer<TSource>.Default);

        }

        public static IEnumerable<TSource> MyUnion<TSource>(this IEnumerable<TSource> that, IEnumerable<TSource> other, IEqualityComparer<TSource> comparer)
        {
            var hashSet = new HashSet<TSource>(comparer);

            foreach (var item in that)
                if (hashSet.Add(item))
                    yield return item;

            foreach (var item in other)
                if (hashSet.Add(item))
                    yield return item;
        }

        public static IEnumerable<TSource> MyConcat<TSource>(this IEnumerable<TSource> that, IEnumerable<TSource> other)
        {
            foreach (var item in that)
            {
                yield return item;
            }
            foreach (var item in other)
            {
                yield return item;
            }
        }

        public static IEnumerable<TSource> MyExcept<TSource>(this IEnumerable<TSource> that, IEnumerable<TSource> other)
        {
            var blackList = new HashSet<TSource>(other);

            foreach (var item in that)
                if (blackList.Add(item))
                    yield return item;
        }

        public static IEnumerable<TSource> MyIntersect<TSource>(this IEnumerable<TSource> that, IEnumerable<TSource> other)
        {
            var itemExist = new HashSet<TSource>(other);

            foreach (var item in that)
                if (itemExist.Remove(item))
                    yield return item;
        }

        public static Dictionary<TKey, TValue> MyToDictionary<TSource, TKey, TValue>(
            this IEnumerable<TSource> that,
            Func<TSource, TKey> keySelector,
            Func<TSource, TValue> valueSelector) where TKey : struct
        {
            var dictionary = new Dictionary<TKey, TValue>();
            foreach (var item in that)
            {
                dictionary.Add(keySelector(item), valueSelector(item));
            }
            return dictionary;
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            //var num = new List<int> { 1, 2, 3, 4, 5 };
            //var num2 = new List<int> { 2, 2, 2, 69, -420 };

            //var str1 = new List<string> { "Hello", "World", "I", "Am", "Here" };
            //var capsStr2 = new List<string> { "HELLO", "WORLD", "I", "AM", "HERE", "really" };

            //num.MySelect(x => x * 2).ToList().ForEach(x => Console.WriteLine(x));
            //num.MyWhere(x => x == 5).ToList().ForEach(x => Console.WriteLine(x));

            //Console.WriteLine(num.MyFirst());
            //Console.WriteLine(num.MyCount());
            //Console.WriteLine(num.MyCount(x => x > 2));
            //Console.WriteLine(num.Aggregate(0, (a, i) => a + i));
            //Console.WriteLine(num2.Aggregate(0, (a, i) => a + i));
            //Console.WriteLine(num2.MyAggregate(0, (a, i) => a + i));

            //Returns MAXIMUM element from the list
            // Console.WriteLine(num2.MyAggregate(0, (a, i) =>
            // {
            //     if (a > i) return a;
            //     return i;
            // }));

            // //Returns MINIMUM element from the list
            // Console.WriteLine(num2.MyAggregate(0, (a, i) =>
            //{
            //    if (a < i) return a;
            //    return i;
            //}));
            //var combined = num2.MyConcat(num);
            //var num3 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //var num4 = new List<int> { 1, 2, 3, 4, 5 };

            //num3.MyExcept(num4).ToList().ForEach(Console.WriteLine);
            //num3.MyIntersect(num4).ToList().ForEach(Console.WriteLine);

            //var union = num3.MyUnion(num4);
            //var union2 = str1.MyUnion(capsStr2, StringComparer.CurrentCultureIgnoreCase);

            //foreach (var item in union)
            //{
            //    Console.WriteLine(item);
            //}
            //foreach (var item in union2)
            //{
            //    Console.WriteLine(item);
            //var source = new List<int> { 1, 2, 3 };
            //source.GroupBy(x => x % 2).ToList().ForEach(x => Console.WriteLine(x.Key));
            //var dictionary = source.MyToDictionary<int, int, int>(x => x, x => x * x);
            //}
            Console.ReadKey();
        }
    }
}
