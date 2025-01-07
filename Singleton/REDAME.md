# Singleton Pattern in .NET

The Singleton pattern is a creational design pattern that ensures a class has only one instance and provides a global point of access to it. It is useful when exactly one object is needed to coordinate actions across a system.

## Characteristics of Singleton Pattern
1. **Single Instance**: Ensures only one instance of the class is created.
2. **Global Access Point**: Provides a way to access the instance globally.
3. **Thread-Safety**: Ensures the pattern is safe to use in a multithreaded environment.

## Example Implementation in C#

Here is a thread-safe implementation of the Singleton pattern in C#:

```csharp
using System;

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
```

## Explanation
1. **Lazy Initialization**: The `Lazy<T>` type ensures the instance is created only when accessed for the first time.
2. **Thread-Safety**: The `Lazy<T>` implementation is thread-safe by default.
3. **Global Access**: The `Instance` property provides a single, global access point to the instance.

## Output
```
Singleton Instance Created
Message: Hello, Singleton Pattern!
Message: This is the same instance.
True
```

This implementation ensures that the Singleton instance is created only once and is accessible globally in a thread-safe manner.
