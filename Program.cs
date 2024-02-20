namespace IOApp
{
    delegate bool IntPredicate(int num);



    class Program
    {
        //public static bool IsMod3(int n)
        //{
        //    return n % 3 == 0;
        //}

        public static IEnumerable<int> Filter(IEnumerable<int> source, IntPredicate predicate)
        {
            var list = new List<int>();
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }
        public static void Main(string[] args)
        {
            var program = new Program();
            var number = 10;
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
            //var result = Filter(list, n => n % 3 == 0);
            //var result = Filter(list, n => n % 5 == 0);
            var result = Filter(list, n =>
            {
                number++;
                return (n % 3 == 0 && n % 5 == 0);
            });
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(number);
            Console.ReadKey();
        }
    }
}