# Bridge Pattern in .NET

The Bridge pattern is a structural design pattern that decouples an abstraction from its implementation, allowing them to vary independently. It is particularly useful when dealing with complex systems where abstraction and implementation can have multiple orthogonal hierarchies.

## Characteristics of Bridge Pattern
1. **Decoupling**: Separates the abstraction from its implementation.
2. **Flexibility**: Allows abstraction and implementation to evolve independently.
3. **Scalability**: Simplifies the addition of new abstractions or implementations without modifying existing code.

## Example Implementation in C#

Here is an example of the Bridge pattern in C#:

```csharp
using System;

// Abstraction
public abstract class Device
{
    protected IRemoteControl _remoteControl;

    public Device(IRemoteControl remoteControl)
    {
        _remoteControl = remoteControl;
    }

    public abstract void Operate();
}

// Refined Abstraction
public class Television : Device
{
    public Television(IRemoteControl remoteControl) : base(remoteControl) { }

    public override void Operate()
    {
        Console.WriteLine("Operating Television:");
        _remoteControl.PowerOn();
        _remoteControl.ChangeChannel(5);
        _remoteControl.PowerOff();
    }
}

public class Radio : Device
{
    public Radio(IRemoteControl remoteControl) : base(remoteControl) { }

    public override void Operate()
    {
        Console.WriteLine("Operating Radio:");
        _remoteControl.PowerOn();
        _remoteControl.ChangeChannel(2);
        _remoteControl.PowerOff();
    }
}

// Implementor
public interface IRemoteControl
{
    void PowerOn();
    void PowerOff();
    void ChangeChannel(int channel);
}

// Concrete Implementor
public class BasicRemoteControl : IRemoteControl
{
    public void PowerOn()
    {
        Console.WriteLine("Powering on.");
    }

    public void PowerOff()
    {
        Console.WriteLine("Powering off.");
    }

    public void ChangeChannel(int channel)
    {
        Console.WriteLine($"Changing to channel {channel}.");
    }
}

public class AdvancedRemoteControl : IRemoteControl
{
    public void PowerOn()
    {
        Console.WriteLine("Powering on with advanced features.");
    }

    public void PowerOff()
    {
        Console.WriteLine("Powering off with advanced features.");
    }

    public void ChangeChannel(int channel)
    {
        Console.WriteLine($"Changing to channel {channel} with advanced features.");
    }
}

// Client
class Program
{
    static void Main()
    {
        IRemoteControl basicRemote = new BasicRemoteControl();
        Device tv = new Television(basicRemote);
        tv.Operate();

        Console.WriteLine();

        IRemoteControl advancedRemote = new AdvancedRemoteControl();
        Device radio = new Radio(advancedRemote);
        radio.Operate();
    }
}
```

## Explanation
1. **Abstraction**: The `Device` class defines the abstraction and contains a reference to the `IRemoteControl` interface.
2. **Refined Abstraction**: The `Television` and `Radio` classes extend the abstraction with specific implementations.
3. **Implementor**: The `IRemoteControl` interface defines methods for controlling devices.
4. **Concrete Implementor**: The `BasicRemoteControl` and `AdvancedRemoteControl` classes provide specific implementations.

## Output
```
Operating Television:
Powering on.
Changing to channel 5.
Powering off.

Operating Radio:
Powering on with advanced features.
Changing to channel 2 with advanced features.
Powering off with advanced features.
```

This implementation demonstrates how the Bridge pattern decouples the abstraction (`Device`) from its implementation (`IRemoteControl`), making them independently extendable.
