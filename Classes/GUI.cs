using IOApplication.Abstract;

namespace IOApplication.Classes
{
    internal class GUI : IGUI
    {
        public void DisplayInput(Input input)
        {
            if (input != null)
            {
                Console.WriteLine("-----------------*IO APP*------------------");
                Console.WriteLine($"{input._input}: STRING");
                Console.WriteLine($"{input._inputInt}: INTEGER");
            }
        }
    }
}
