namespace IOApp
{
    interface IMyInterface
    {
        void Method();
    }
    class LinkedList<T> where T : IMyInterface
    {
        class Node
        {
            public T Value;
            public Node Next;
        }

        private Node Head;
        public int Count { get; private set; }

        public void Add(T value)
        {
            var node = new Node();
            node.Value.Method();
        }
        public void Remove(T value)
        { }
        public T Get(int index)
        { return default(T); }
    }
    class Program
    {
        public static void Main(string[] args)
        {

            Console.ReadKey();
        }
    }
}
