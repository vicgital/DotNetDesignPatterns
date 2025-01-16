using System;

// Subsystem 1
public class AuthService
{
    public bool Authenticate(string username, string password)
    {
        Console.WriteLine("Authenticating user...");
        return username == "admin" && password == "password123";
    }
}

// Subsystem 2
public class PaymentService
{
    public void ProcessPayment(string accountNumber, decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount:C} to account {accountNumber}...");
    }
}

// Subsystem 3
public class NotificationService
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"Sending notification: {message}");
    }
}

// Facade
public class EcommerceFacade
{
    private readonly AuthService _authService;
    private readonly PaymentService _paymentService;
    private readonly NotificationService _notificationService;

    public EcommerceFacade()
    {
        _authService = new AuthService();
        _paymentService = new PaymentService();
        _notificationService = new NotificationService();
    }

    public void PlaceOrder(string username, string password, string accountNumber, decimal amount)
    {
        Console.WriteLine("Starting order placement...");

        if (!_authService.Authenticate(username, password))
        {
            Console.WriteLine("Authentication failed. Order cannot be placed.");
            return;
        }

        _paymentService.ProcessPayment(accountNumber, amount);
        _notificationService.SendNotification("Your order has been placed successfully!");

        Console.WriteLine("Order placement completed.");
    }
}

// Client Code
class Program
{
    static void Main(string[] args)
    {
        EcommerceFacade ecommerceFacade = new EcommerceFacade();

        // Place an order through the Facade
        ecommerceFacade.PlaceOrder("admin", "password123", "123456789", 99.99m);

        // Attempt to place an order with invalid credentials
        ecommerceFacade.PlaceOrder("user", "wrongpassword", "123456789", 49.99m);
    }
}