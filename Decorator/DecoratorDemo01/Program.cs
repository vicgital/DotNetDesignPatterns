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