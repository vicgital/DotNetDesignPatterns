// Command Interface
interface ICommand
{
    void Execute();
    void Undo();
}

// Receiver 1
class Light
{
    public void TurnOn() => Console.WriteLine("Light is turned ON");
    public void TurnOff() => Console.WriteLine("Light is turned OFF");
}

// Receiver 2
class TV
{
    private int volume = 10;

    public void VolumeUp()
    {
        volume++;
        Console.WriteLine($"TV volume increased to {volume}");
    }

    public void VolumeDown()
    {
        volume--;
        Console.WriteLine($"TV volume decreased to {volume}");
    }
}

// Concrete Commands
class TurnOnLightCommand : ICommand
{
    private readonly Light _light;

    public TurnOnLightCommand(Light light) => _light = light;

    public void Execute() => _light.TurnOn();
    public void Undo() => _light.TurnOff();
}

class TurnOffLightCommand : ICommand
{
    private readonly Light _light;

    public TurnOffLightCommand(Light light) => _light = light;

    public void Execute() => _light.TurnOff();
    public void Undo() => _light.TurnOn();
}

class VolumeUpCommand : ICommand
{
    private readonly TV _tv;

    public VolumeUpCommand(TV tv) => _tv = tv;

    public void Execute() => _tv.VolumeUp();
    public void Undo() => _tv.VolumeDown();
}

class VolumeDownCommand : ICommand
{
    private readonly TV _tv;

    public VolumeDownCommand(TV tv) => _tv = tv;

    public void Execute() => _tv.VolumeDown();
    public void Undo() => _tv.VolumeUp();
}

// Invoker
class RemoteControl
{
    private readonly Stack<ICommand> _commandHistory = new();

    public void Submit(ICommand command)
    {
        command.Execute();
        _commandHistory.Push(command);
    }

    public void Undo()
    {
        if (_commandHistory.Count > 0)
        {
            ICommand lastCommand = _commandHistory.Pop();
            lastCommand.Undo();
        }
    }
}

// Client
class Program
{
    static void Main()
    {
        Light livingRoomLight = new Light();
        TV livingRoomTV = new TV();

        ICommand turnOnLight = new TurnOnLightCommand(livingRoomLight);
        ICommand turnOffLight = new TurnOffLightCommand(livingRoomLight);
        ICommand volumeUp = new VolumeUpCommand(livingRoomTV);
        ICommand volumeDown = new VolumeDownCommand(livingRoomTV);

        RemoteControl remote = new RemoteControl();

        // Execute commands
        remote.Submit(turnOnLight);
        remote.Submit(volumeUp);
        remote.Submit(volumeUp);
        remote.Submit(turnOffLight);

        // Undo last command
        remote.Undo();
        remote.Undo();
    }
}