using IOApplication.Classes;

namespace IOApplication.Abstract
{
    internal interface IFileIO
    {
        StreamReader? sr { get; set; }
        StreamWriter? sw { get; set; }
        StreamWriter? WriteToFile(string? path, Input input);
        void ReadFromFile(string? path);
    }
}
