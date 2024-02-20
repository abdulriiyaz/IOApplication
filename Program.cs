namespace IOApp
{
    delegate bool IntPredicate(int num);



    class Program
    {
        public bool isMod3(int n)
        {
            return n % 3 == 0;
        }

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
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = Filter(list, program.isMod3);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}