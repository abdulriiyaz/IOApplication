using IOApplication.Abstract;
using System.Text;

namespace IOApplication.Classes
{
    internal class FileIO : IFileIO
    {
        public StreamReader? sr { get; set; }
        public StreamWriter? sw { get; set; }

        public void ReadFromFile(string? path)
        {
            using (sr = new StreamReader(File.Open(path ?? "names.dat", FileMode.OpenOrCreate), Encoding.UTF32))
            {
                var text = sr.ReadToEnd();
                Console.WriteLine(text);
            }
        }

        public StreamWriter? WriteToFile(string? path, Input input)
        {
            using (sw = new StreamWriter(File.Open(path ?? "names.dat", FileMode.OpenOrCreate), Encoding.UTF32))
            {

                sw.WriteLine($"{input._inputInt}, {input._input}\n");
            }
            return sw;
        }
    }
}
