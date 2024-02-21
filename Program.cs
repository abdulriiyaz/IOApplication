namespace IOApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var ll = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var odd = Filter<int>(ll, i => i % 2 != 0);

            var even = Filter<int>(ll, i => i % 2 == 0);

            Console.Write("ODD:");
            foreach (var item in odd)
            {
                Console.WriteLine(item + " ");
            }

            Console.Write("EVEN:");
            foreach (var item in even)
            {
                Console.WriteLine(item + " ");
            }

            Console.ReadKey();
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


        //Constraints on generics type parameters

        //method which returns instance of type T with the help of keyowrd 'where' and 'new()'


        //static T Hey<T>() where T : new()
        //{
        //    return new T();
        //}
    }
}
