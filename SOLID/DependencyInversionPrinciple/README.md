# Dependency Inversion Principle

The Dependency Inversion Principle (DIP) is one of the SOLID principles in object-oriented design. It states:

1. High-level modules should not depend on low-level modules. Both should depend on abstractions.
2. Abstractions should not depend on details. Details should depend on abstractions.

This principle ensures that the high-level policy of a system does not depend on the details of the low-level implementation. It promotes decoupling and makes the system more flexible and easier to maintain.

## Example in C#

Below is an example of the Dependency Inversion Principle in practice:

```csharp
// Abstraction
public interface IMessageSender
{
    void SendMessage(string message);
}

// Low-level module
public class EmailSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending Email: {message}");
    }
}

// Low-level module
public class SmsSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}

// High-level module
public class Notification
{
    private readonly IMessageSender _messageSender;

    public Notification(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }

    public void Notify(string message)
    {
        _messageSender.SendMessage(message);
    }
}

// Usage
class Program
{
    static void Main(string[] args)
    {
        // Dependency Injection through constructor
        IMessageSender emailSender = new EmailSender();
        Notification emailNotification = new Notification(emailSender);
        emailNotification.Notify("Hello via Email!");

        IMessageSender smsSender = new SmsSender();
        Notification smsNotification = new Notification(smsSender);
        smsNotification.Notify("Hello via SMS!");
    }
}
```

### Explanation
1. **Abstraction (`IMessageSender`)**: Defines the contract that both high-level and low-level modules depend on.
2. **Low-level modules (`EmailSender`, `SmsSender`)**: Implement the `IMessageSender` interface.
3. **High-level module (`Notification`)**: Relies on the abstraction (`IMessageSender`) rather than the concrete implementations (`EmailSender` or `SmsSender`).
4. **Dependency Injection**: Dependencies are provided at runtime, enabling the substitution of different implementations without modifying the high-level module.

By following DIP, we achieve flexibility and scalability in our system.
