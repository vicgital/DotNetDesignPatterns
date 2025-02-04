# Mediator Pattern in Object-Oriented Programming

## Definition
The **Mediator Pattern** is a behavioral design pattern that promotes loose coupling by centralizing communication between objects. Instead of objects communicating directly, they interact through a mediator, which controls and coordinates their interactions.

### Key Benefits:
- Reduces dependencies between objects (loose coupling).
- Improves code maintainability and readability.
- Encapsulates communication logic in a single place.

## Example in C#
Below is a simple implementation of the Mediator Pattern in C#:

```csharp
using System;
using System.Collections.Generic;

// Mediator Interface
public interface IMediator
{
    void SendMessage(string message, Colleague colleague);
}

// Concrete Mediator
public class ConcreteMediator : IMediator
{
    private List<Colleague> _colleagues = new();
    
    public void Register(Colleague colleague)
    {
        _colleagues.Add(colleague);
        colleague.SetMediator(this);
    }
    
    public void SendMessage(string message, Colleague sender)
    {
        foreach (var colleague in _colleagues)
        {
            if (colleague != sender)
            {
                colleague.ReceiveMessage(message);
            }
        }
    }
}

// Colleague Base Class
public abstract class Colleague
{
    protected IMediator _mediator;
    
    public void SetMediator(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public void Send(string message)
    {
        _mediator.SendMessage(message, this);
    }
    
    public abstract void ReceiveMessage(string message);
}

// Concrete Colleague A
public class ColleagueA : Colleague
{
    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"ColleagueA received: {message}");
    }
}

// Concrete Colleague B
public class ColleagueB : Colleague
{
    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"ColleagueB received: {message}");
    }
}

// Client Code
class Program
{
    static void Main()
    {
        ConcreteMediator mediator = new ConcreteMediator();
        
        ColleagueA colleagueA = new ColleagueA();
        ColleagueB colleagueB = new ColleagueB();
        
        mediator.Register(colleagueA);
        mediator.Register(colleagueB);
        
        colleagueA.Send("Hello from A!");
        colleagueB.Send("Hello from B!");
    }
}
```

### Explanation:
1. **IMediator** defines the interface for communication.
2. **ConcreteMediator** manages the communication between colleagues.
3. **Colleague** is an abstract class representing components that interact via the mediator.
4. **ColleagueA** and **ColleagueB** implement specific colleague behavior.
5. The **Client (Main Method)** demonstrates communication between colleagues through the mediator.

### Output:
```
ColleagueB received: Hello from A!
ColleagueA received: Hello from B!
```

The Mediator Pattern ensures that `ColleagueA` and `ColleagueB` do not reference each other directly, promoting decoupling and better maintainability.

