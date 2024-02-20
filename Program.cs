namespace IOApp
{
    class Program
    {
        class FuncDictClass
        {
            public Dictionary<string, Func<int>> FuncDict { get; set; }

            public FuncDictClass()
            {
                FuncDict = new Dictionary<string, Func<int>>();
            }

            public void AddFunctions(string key, Func<int> func)
            {
                FuncDict[key] = func;
            }

            public int ExecuteFuncs(string key)
            {
                if (FuncDict.ContainsKey(key))
                {
                    return FuncDict[key]();
                }
                else
                {
                    throw new KeyNotFoundException("Key not Found to be executed");
                }
            }

        }

        public static void Main(string[] args)
        {
            FuncDictClass fdc = new FuncDictClass();

            fdc.AddFunctions("1", () => Function1());
            fdc.AddFunctions("2", () => Function2());

            //execute functions in line

            Console.WriteLine(fdc.ExecuteFuncs("2"));
            Console.WriteLine(fdc.ExecuteFuncs("1"));
            //Console.WriteLine(fdc.ExecuteFuncs("4"));

            static int Function1()
            { return 10; }

            static int Function2()
            { return 20; }
        }
    }
}