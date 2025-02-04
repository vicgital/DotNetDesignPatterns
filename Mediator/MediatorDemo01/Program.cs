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

        ColleagueA colleagueA = new();
        ColleagueB colleagueB = new();

        mediator.Register(colleagueA);
        mediator.Register(colleagueB);

        colleagueA.Send("Hello from A!");
        colleagueB.Send("Hello from B!");
    }
}