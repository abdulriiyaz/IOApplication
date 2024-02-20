namespace IOApp
{
    delegate void WriteOutputToConsole(string? output);


    class BlahBlah
    {
        private readonly string _prefix;
        public BlahBlah(string prefix)
        {
            _prefix = prefix;
        }

        public void DoStuff(string? output)
        {
            Console.WriteLine("prefix: {0} - output: {1}", _prefix, output);
        }
    }
    class Program
    {
        static void WriteOutputToConsole(string? output)
        {
            Console.WriteLine(output);
        }

        static void WriteOutputToConsole2(string? output)
        {
            Console.WriteLine(output);
        }
        public static void Main(string[] args)
        {
            BlahBlah b1 = new BlahBlah("b1");
            BlahBlah b2 = new BlahBlah("b2");

            Run(b1.DoStuff, 1, 3);
            Run(b2.DoStuff, 1, 5);


        }

        public static void Run(WriteOutputToConsole writeOutputToConsole, int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                var div3 = i % 3 == 0;
                var div5 = i % 5 == 0;

                if (div3 && div5)
                {
                    writeOutputToConsole("FizzBuzz");
                }
                else if (div3)
                {
                    writeOutputToConsole("Fizz");
                }
                else if (div5)
                {
                    writeOutputToConsole("Buzz");
                }
                else
                {
                    writeOutputToConsole(i.ToString());
                }
            }

        }
    }
}