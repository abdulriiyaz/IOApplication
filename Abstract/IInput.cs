namespace IOApplication.Abstract
{
    interface IInput
    {
        public string? _input { get; set; }
        public int _inputInt { get; set; }

        public string? GetString();
        public int GetInt();
        public string? GetYesNo();
    }
}
