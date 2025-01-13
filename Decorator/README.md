# Decorator Design Pattern in Software Development

## Definition
The Decorator Design Pattern is a structural design pattern that allows behavior to be dynamically added to an individual object without affecting the behavior of other objects from the same class. It provides a flexible alternative to subclassing for extending functionality.

## Key Features
- Wraps objects to extend their functionality dynamically.
- Promotes composition over inheritance.
- Provides an alternative to creating multiple subclasses for different combinations of behavior.

## Example in C#
Below is an example demonstrating the Decorator Design Pattern in C#.

```csharp
using System;

// Component Interface
public interface IMessage
{
    string GetContent();
}

// Concrete Component
public class TextMessage : IMessage
{
    private string _content;

    public TextMessage(string content)
    {
        _content = content;
    }

    public string GetContent()
    {
        return _content;
    }
}

// Base Decorator
public abstract class MessageDecorator : IMessage
{
    protected IMessage _message;

    public MessageDecorator(IMessage message)
    {
        _message = message;
    }

    public abstract string GetContent();
}

// Concrete Decorator 1: Encrypt Message
public class EncryptedMessage : MessageDecorator
{
    public EncryptedMessage(IMessage message) : base(message)
    {
    }

    public override string GetContent()
    {
        return Encrypt(_message.GetContent());
    }

    private string Encrypt(string content)
    {
        // Simple encryption simulation (reversing the string)
        char[] contentArray = content.ToCharArray();
        Array.Reverse(contentArray);
        return new string(contentArray);
    }
}

// Concrete Decorator 2: HTML Format Message
public class HtmlMessage : MessageDecorator
{
    public HtmlMessage(IMessage message) : base(message)
    {
    }

    public override string GetContent()
    {
        return FormatAsHtml(_message.GetContent());
    }

    private string FormatAsHtml(string content)
    {
        return $"<html><body>{content}</body></html>";
    }
}

// Client Code
class Program
{
    static void Main(string[] args)
    {
        // Original message
        IMessage message = new TextMessage("Hello, Decorator Pattern!");

        // Add encryption
        IMessage encryptedMessage = new EncryptedMessage(message);
        Console.WriteLine("Encrypted Message: " + encryptedMessage.GetContent());

        // Add HTML formatting on top of encryption
        IMessage htmlMessage = new HtmlMessage(encryptedMessage);
        Console.WriteLine("HTML Encrypted Message: " + htmlMessage.GetContent());

        // Add HTML formatting directly to the original message
        IMessage directHtmlMessage = new HtmlMessage(message);
        Console.WriteLine("HTML Message: " + directHtmlMessage.GetContent());
    }
}
```

## Explanation
1. **Component Interface**: The `IMessage` interface defines the `GetContent` method.
2. **Concrete Component**: The `TextMessage` class implements the `IMessage` interface and provides the basic content.
3. **Base Decorator**: The `MessageDecorator` class implements `IMessage` and contains a reference to an `IMessage` object.
4. **Concrete Decorators**: 
   - `EncryptedMessage` adds encryption functionality.
   - `HtmlMessage` formats the message as HTML.
5. **Client Code**: Demonstrates how decorators can be combined to dynamically add functionalities to the message.

## Benefits
- Adds new responsibilities to an object dynamically without affecting others.
- Follows the Single Responsibility Principle by dividing functionality among classes.
- Promotes flexibility and reuse through composition.

## Drawbacks
- Can result in a large number of small classes.
- Complex combinations of decorators may be hard to manage or understand.
