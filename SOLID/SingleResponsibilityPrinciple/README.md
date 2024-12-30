# **Single Responsibility Principle (SRP)**

The **Single Responsibility Principle (SRP)** is one of the five SOLID principles in Object-Oriented Programming (OOP). It states:  

**"A class should have only one reason to change."**

This means that a class should focus on a single responsibility or functionality. It should encapsulate behaviors that are closely related, ensuring that each class has a clear and narrow purpose.

---

## **Benefits of SRP**
1. **Improved Maintainability**: A class with a single responsibility is easier to understand and modify.
2. **Reduced Risk of Bugs**: Changes in one responsibility won’t unintentionally affect unrelated ones.
3. **Better Testability**: Focused classes can be tested independently.
4. **Enhanced Reusability**: A class with a single responsibility is more likely to be reusable.

---

## **Example of SRP in C#**

### **Non-SRP Example**
The following class violates SRP because it handles multiple responsibilities:  
- Generating an invoice.
- Saving the invoice to a database.
- Sending the invoice via email.

```csharp
public class InvoiceManager
{
    public void GenerateInvoice()
    {
        // Logic to generate the invoice
        Console.WriteLine("Invoice generated.");
    }

    public void SaveToDatabase()
    {
        // Logic to save the invoice to the database
        Console.WriteLine("Invoice saved to database.");
    }

    public void SendEmail()
    {
        // Logic to send the invoice via email
        Console.WriteLine("Invoice sent via email.");
    }
}

```

## **SRP Compliant Example**

In this version, each responsibility is encapsulated in its own class.

``` csharp
// Class for generating the invoice
public class InvoiceGenerator
{
    public void GenerateInvoice()
    {
        // Logic to generate the invoice
        Console.WriteLine("Invoice generated.");
    }
}

// Class for saving the invoice to the database
public class InvoiceSaver
{
    public void SaveToDatabase()
    {
        // Logic to save the invoice to the database
        Console.WriteLine("Invoice saved to database.");
    }
}

// Class for sending the invoice via email
public class EmailSender
{
    public void SendEmail()
    {
        // Logic to send the invoice via email
        Console.WriteLine("Invoice sent via email.");
    }
}

// Usage
public class Program
{
    public static void Main(string[] args)
    {
        var invoiceGenerator = new InvoiceGenerator();
        var invoiceSaver = new InvoiceSaver();
        var emailSender = new EmailSender();

        invoiceGenerator.GenerateInvoice();
        invoiceSaver.SaveToDatabase();
        emailSender.SendEmail();
    }
}

```

## **Key Improvements**

1. Separation of Concerns: Each class handles only one responsibility.

2. Ease of Modification: Changes to email functionality won’t affect invoice generation or saving logic.

3. Unit Testing: Each class can be tested independently, reducing complexity.
By adhering to SRP, you create more modular, maintainable, and testable code.

