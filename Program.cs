namespace IOApp
{
    class Program
    {
        public static void Main(string[] args)
        {

            Console.ReadKey();
        }


        //Constraints on generics type parameters

        //method which returns instance of type T with the help of keyowrd 'where' and 'new()'


        static T Hey<T>() where T : new()
        {
            return new T();
        }
    }
}
