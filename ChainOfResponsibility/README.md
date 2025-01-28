# Chain of Responsibility Pattern in .NET

## Definition
The Chain of Responsibility is a behavioral design pattern that allows a request to pass through a chain of handlers. Each handler decides either to process the request or to pass it to the next handler in the chain. This pattern is particularly useful for scenarios where there is a need to decouple the sender of a request from its receivers.

## Example in C#
Below is a C# example of implementing the Chain of Responsibility pattern:

### Scenario
A logging system where messages of different severity levels (Info, Warning, Error) are handled by appropriate loggers in a chain.

### Code Implementation
```csharp
using System;

// Abstract Handler
abstract class Logger
{
    protected Logger NextLogger;

    public void SetNextLogger(Logger nextLogger)
    {
        NextLogger = nextLogger;
    }

    public void LogMessage(int level, string message)
    {
        if (CanHandle(level))
        {
            Write(message);
        }
        else if (NextLogger != null)
        {
            NextLogger.LogMessage(level, message);
        }
    }

    protected abstract bool CanHandle(int level);
    protected abstract void Write(string message);
}

// Concrete Handlers
class InfoLogger : Logger
{
    protected override bool CanHandle(int level) => level == 1;
    protected override void Write(string message) => Console.WriteLine($"Info: {message}");
}

class WarningLogger : Logger
{
    protected override bool CanHandle(int level) => level == 2;
    protected override void Write(string message) => Console.WriteLine($"Warning: {message}");
}

class ErrorLogger : Logger
{
    protected override bool CanHandle(int level) => level == 3;
    protected override void Write(string message) => Console.WriteLine($"Error: {message}");
}

// Client
class Program
{
    static void Main()
    {
        // Create the chain
        Logger infoLogger = new InfoLogger();
        Logger warningLogger = new WarningLogger();
        Logger errorLogger = new ErrorLogger();

        infoLogger.SetNextLogger(warningLogger);
        warningLogger.SetNextLogger(errorLogger);

        // Log messages
        infoLogger.LogMessage(1, "This is an informational message.");
        infoLogger.LogMessage(2, "This is a warning message.");
        infoLogger.LogMessage(3, "This is an error message.");
        infoLogger.LogMessage(4, "This level is not handled.");
    }
}
```

### Output
When the program runs, it produces the following output:
```
Info: This is an informational message.
Warning: This is a warning message.
Error: This is an error message.
```

## Key Points
1. **Decoupling:** The sender of a request is decoupled from its receivers.
2. **Flexibility:** New handlers can be added to the chain without modifying existing code.
3. **Responsibility Sharing:** Multiple handlers can process the same request, ensuring modularity and clarity.

## Use Cases
- Event handling systems
- Validation frameworks
- Logging systems

The Chain of Responsibility pattern is a versatile and powerful tool in object-oriented programming, enabling cleaner and more maintainable code.
