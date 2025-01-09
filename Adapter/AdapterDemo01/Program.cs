using System;

// Existing Class (Adaptee)
public class LegacyPrinter
{
    public void PrintInUppercase(string message)
    {
        Console.WriteLine(message.ToUpper());
    }
}

// Target Interface
public interface IPrinter
{
    void Print(string message);
}

// Adapter Class
public class PrinterAdapter : IPrinter
{
    private readonly LegacyPrinter _legacyPrinter;

    public PrinterAdapter(LegacyPrinter legacyPrinter)
    {
        _legacyPrinter = legacyPrinter;
    }

    public void Print(string message)
    {
        // Adapting the method to match the target interface
        _legacyPrinter.PrintInUppercase(message);
    }
}

// Client Code
class Program
{
    static void Main(string[] args)
    {
        // Using the legacy class through the adapter
        LegacyPrinter legacyPrinter = new LegacyPrinter();
        IPrinter printer = new PrinterAdapter(legacyPrinter);

        // Client uses the adapter's interface
        printer.Print("Hello, Adapter Pattern!");
    }
}