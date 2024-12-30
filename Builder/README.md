# Builder Design Pattern in C#

The Builder design pattern is a creational pattern that allows for the step-by-step construction of complex objects. It separates the construction of an object from its representation, enabling the same construction process to create different representations. This pattern is particularly useful when an object has many optional parameters or when its construction process is complex.

## Key Participants

1. **Builder**: Specifies an abstract interface for creating parts of a `Product` object.
2. **ConcreteBuilder**: Implements the `Builder` interface to construct and assemble parts of the product.
3. **Product**: Represents the complex object under construction.
4. **Director**: Constructs an object using the `Builder` interface.

## Implementation in C#

```csharp
using System;

// Product class
public class Car
{
    public string Engine { get; set; }
    public int Wheels { get; set; }
    public string Color { get; set; }

    public override string ToString()
    {
        return $"Car with {Engine} engine, {Wheels} wheels, and {Color} color.";
    }
}

// Builder interface
public interface ICarBuilder
{
    void SetEngine(string engine);
    void SetWheels(int wheels);
    void SetColor(string color);
    Car GetResult();
}

// ConcreteBuilder class
public class SportsCarBuilder : ICarBuilder
{
    private Car _car = new Car();

    public void SetEngine(string engine)
    {
        _car.Engine = engine;
    }

    public void SetWheels(int wheels)
    {
        _car.Wheels = wheels;
    }

    public void SetColor(string color)
    {
        _car.Color = color;
    }

    public Car GetResult()
    {
        return _car;
    }
}

// Director class
public class CarDirector
{
    private readonly ICarBuilder _builder;

    public CarDirector(ICarBuilder builder)
    {
        _builder = builder;
    }

    public void ConstructSportsCar()
    {
        _builder.SetEngine("V8");
        _builder.SetWheels(4);
        _builder.SetColor("Red");
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        ICarBuilder builder = new SportsCarBuilder();
        CarDirector director = new CarDirector(builder);

        director.ConstructSportsCar();
        Car car = builder.GetResult();

        Console.WriteLine(car);
    }
}
```

## Output

```
Car with V8 engine, 4 wheels, and Red color.
```

## Advantages

- **Flexibility**: Different builders can produce different representations of a product.
- **Step-by-step construction**: Helps to construct complex objects incrementally.
- **Readable Code**: Makes the object creation process more readable and organized.

## Use Cases

- When the construction process is complex and needs to be separated from the object's representation.
- When the same construction process should create different representations of the object.
