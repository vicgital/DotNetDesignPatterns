using System;

namespace SingletonDemo
{
    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(() => new Singleton());

        // Private constructor to prevent instantiation from outside
        private Singleton()
        {
            Console.WriteLine("Singleton Instance Created");
        }

        // Public property to provide global access to the instance
        public static Singleton Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        // Example method
        public void DisplayMessage(string message)
        {
            Console.WriteLine($"Message: {message}");
        }
    }

    class Program
    {
        static void Main()
        {
            // Accessing the Singleton instance
            Singleton singleton1 = Singleton.Instance;
            singleton1.DisplayMessage("Hello, Singleton Pattern!");

            Singleton singleton2 = Singleton.Instance;
            singleton2.DisplayMessage("This is the same instance.");

            // Verify that both references point to the same instance
            Console.WriteLine(ReferenceEquals(singleton1, singleton2)); // Output: True
        }
    }
}