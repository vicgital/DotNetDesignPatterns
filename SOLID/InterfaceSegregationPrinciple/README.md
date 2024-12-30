## Interface Segregation Principle

The **Interface Segregation Principle (ISP)** states that a class should not be forced to implement interfaces it does not use. Instead, interfaces should be divided into smaller, more specific ones to ensure that implementing classes only need to be concerned with the methods that are relevant to them.

### Definition
"Clients should not be forced to depend on methods they do not use."

This principle aims to avoid creating large, monolithic interfaces and encourages the design of small, role-specific interfaces.

---

### Example in C#

Below is an example demonstrating the Interface Segregation Principle:

```csharp
// BAD EXAMPLE: Violates ISP
public interface IWorker
{
    void Work();
    void Eat();
}

public class Robot : IWorker
{
    public void Work()
    {
        Console.WriteLine("Robot is working...");
    }

    public void Eat()
    {
        throw new NotImplementedException("Robots do not eat.");
    }
}

public class Human : IWorker
{
    public void Work()
    {
        Console.WriteLine("Human is working...");
    }

    public void Eat()
    {
        Console.WriteLine("Human is eating...");
    }
}

// GOOD EXAMPLE: Follows ISP
public interface IWorkable
{
    void Work();
}

public interface IFeedable
{
    void Eat();
}

public class Robot : IWorkable
{
    public void Work()
    {
        Console.WriteLine("Robot is working...");
    }
}

public class Human : IWorkable, IFeedable
{
    public void Work()
    {
        Console.WriteLine("Human is working...");
    }

    public void Eat()
    {
        Console.WriteLine("Human is eating...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IWorkable robotWorker = new Robot();
        robotWorker.Work();

        IWorkable humanWorker = new Human();
        humanWorker.Work();

        IFeedable humanFeeder = new Human();
        humanFeeder.Eat();
    }
}
```

---

### Explanation
1. **Bad Example:** The `IWorker` interface forces both `Robot` and `Human` to implement the `Eat` method, even though it is irrelevant for `Robot`. This violates the ISP.
2. **Good Example:** The `IWorkable` and `IFeedable` interfaces are more focused and role-specific. `Robot` implements only `IWorkable`, while `Human` implements both `IWorkable` and `IFeedable`. This adheres to the ISP.

By following the ISP, you create more flexible and maintainable code.
