using IOApplication.Classes;

namespace IOApp
{
    class Program
    {
        static void GetUserInputs(Input inp_, GUI gui_)
        {
            Console.Write("Please enter a number: ");
            int i = inp_.GetInt();

            Console.Write("\nPlease enter a string: ");
            string? s = inp_.GetString();

            Console.Write("\nPlease enter yes or no.(y/n): ");
            string? y = inp_.GetYesNo();

            gui_.DisplayInput(inp_);

        }
        public static void Main(string[] args)
        {
            Input inp = new();
            GUI gui = new();
            FileIO file = new();

            GetUserInputs(inp, gui);
            try
            {
                file.WriteToFile("names.dat", inp);
                file.ReadFromFile("names.dat");
            }
            catch (IOException err)
            {
                Console.WriteLine(err);
            }
            Console.ReadKey();
        }
    }
}
