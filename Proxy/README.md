# Proxy Pattern in .NET

The Proxy pattern is a structural design pattern that provides a surrogate or placeholder for another object to control access to it. It is often used to add an additional level of control, such as lazy initialization, access control, logging, or caching.

## Characteristics of Proxy Pattern
1. **Control Access**: Manages access to the real object.
2. **Add Functionality**: Can add behavior such as logging or caching without modifying the original object.
3. **Transparent to Clients**: The proxy implements the same interface as the real object, making it interchangeable.

## Example Implementation in C#

Here is an example of the Proxy pattern in C#:

```csharp
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
```

## Explanation
1. **Subject**: The `IService` interface defines the common interface for both the `RealService` and the `ProxyService`.
2. **Real Subject**: The `RealService` class contains the core functionality.
3. **Proxy**: The `ProxyService` class controls access to the `RealService`, handling lazy initialization and access control.
4. **Client**: The client interacts with the `ProxyService` as if it were the `RealService`.

## Output
```
Client with access:
Initializing RealService...
Proxy: Logging before delegating to RealService.
Performing operation in RealService.

Client without access:
Access denied: You do not have permission to perform this operation.
```

This implementation demonstrates how the Proxy pattern can be used to control access, perform lazy initialization, and add functionality such as logging without modifying the original `RealService` class.
