public class Program
{
    // Event declaration using Action delegate
    public event Action<object, EventArgs> MyEvent;

    // Method to raise the event
    protected virtual void OnMyEvent()
    {
        MyEvent?.Invoke(this, EventArgs.Empty);
    }

    public static void Main(string[] args)
    {
        Program instance = new Program();

        // Event handler method using Action delegate
        Action<object, EventArgs> eventHandler = (sender, e) =>
        {
            Console.WriteLine("Event handled successfully!");
        };

        // Subscribe to the event
        instance.MyEvent += eventHandler;

        // Raise the event
        instance.OnMyEvent();
    }
}
