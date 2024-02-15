using IOApplication.Abstract;

namespace IOApplication.Classes
{
    internal class Input : IInput
    {
        public string? _input { get; set; }
        public int _inputInt { get; set; }

        public int GetInt()
        {
            _inputInt = int.TryParse(Console.ReadLine(), out int _inp) ? _inp : 0;
            return _inp;
        }

        public string? GetString()
        {
            _input = Console.ReadLine();
            return _input;
        }

        public string? GetYesNo()
        {
            return Console.ReadLine();
        }
    }
}
