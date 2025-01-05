# Factory Design Pattern in C#

The Factory Design Pattern is a creational pattern that provides an interface for creating objects in a super-class but allows subclasses to alter the type of objects that will be created. This pattern promotes loose coupling by removing the instantiation of objects from the client code.

## Key Components

1. **Product**: The interface or abstract class that defines the type of object the factory will create.
2. **ConcreteProduct**: The implementation classes of the Product interface.
3. **Creator (Factory)**: Abstract class or interface that declares the factory method for creating Product objects.
4. **ConcreteCreator**: The classes that implement the factory method to create specific ConcreteProduct objects.

## When to Use
- When the exact type of the object is determined at runtime.
- When you want to delegate the responsibility of instantiation to subclasses.
- To achieve better scalability and maintainability of the code.

## Example Implementation
Here is a C# example illustrating the Factory Design Pattern:

```csharp
using System;

// Product Interface
public interface IShape
{
    void Draw();
}

// ConcreteProduct 1
public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Circle.");
    }
}

// ConcreteProduct 2
public class Rectangle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Rectangle.");
    }
}

// Creator
public abstract class ShapeFactory
{
    public abstract IShape CreateShape();
}

// ConcreteCreator 1
public class CircleFactory : ShapeFactory
{
    public override IShape CreateShape()
    {
        return new Circle();
    }
}

// ConcreteCreator 2
public class RectangleFactory : ShapeFactory
{
    public override IShape CreateShape()
    {
        return new Rectangle();
    }
}

// Client
class Program
{
    static void Main(string[] args)
    {
        ShapeFactory factory;

        // Create a Circle using CircleFactory
        factory = new CircleFactory();
        IShape circle = factory.CreateShape();
        circle.Draw();

        // Create a Rectangle using RectangleFactory
        factory = new RectangleFactory();
        IShape rectangle = factory.CreateShape();
        rectangle.Draw();
    }
}
```

## Output
```
Drawing a Circle.
Drawing a Rectangle.
```

## Advantages
- Promotes loose coupling.
- Provides a central location for object creation.
- Makes the code more scalable and easier to maintain.

## Disadvantages
- Can lead to a complex class hierarchy.
- Requires additional code to implement the factory structure.
