using System;

// Subject
public interface IService
{
    void PerformOperation();
}

// Real Subject
public class RealService : IService
{
    public void PerformOperation()
    {
        Console.WriteLine("Performing operation in RealService.");
    }
}

// Proxy
public class ProxyService : IService
{
    private RealService _realService;
    private readonly bool _hasAccess;

    public ProxyService(bool hasAccess)
    {
        _hasAccess = hasAccess;
    }

    public void PerformOperation()
    {
        if (!_hasAccess)
        {
            Console.WriteLine("Access denied: You do not have permission to perform this operation.");
            return;
        }

        if (_realService == null)
        {
            Console.WriteLine("Initializing RealService...");
            _realService = new RealService();
        }

        Console.WriteLine("Proxy: Logging before delegating to RealService.");
        _realService.PerformOperation();
    }
}

// Client
class Program
{
    static void Main()
    {
        Console.WriteLine("Client with access:");
        IService proxyWithAccess = new ProxyService(hasAccess: true);
        proxyWithAccess.PerformOperation();

        Console.WriteLine();

        Console.WriteLine("Client without access:");
        IService proxyWithoutAccess = new ProxyService(hasAccess: false);
        proxyWithoutAccess.PerformOperation();
    }
}