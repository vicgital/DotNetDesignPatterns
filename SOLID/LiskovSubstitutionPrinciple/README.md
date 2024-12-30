# Liskov Substitution Principle (LSP)

The Liskov Substitution Principle (LSP) is one of the five SOLID principles of object-oriented design. It states:

**"Objects of a superclass should be replaceable with objects of a subclass without altering the correctness of the program."**

This principle ensures that a subclass can stand in for its superclass without unexpected behaviors. Violating LSP often leads to fragile and unpredictable code.

## Key Points
- Subclasses should not override or change the behavior of the base class in a way that breaks the base class's contract.
- Consumers of the base class should be able to use the subclass without knowing the difference.
- A subclass must adhere to the behavior expected by the superclass.

## Example in C#
Below is an example that adheres to the Liskov Substitution Principle.

### Correct Implementation
```csharp
// Base class
public abstract class Shape
{
    public abstract double CalculateArea();
}

// Subclass: Rectangle
public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

// Subclass: Circle
public class Circle : Shape
{
    public double Radius { get; set; }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

// Usage
class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>
        {
            new Rectangle { Width = 5, Height = 10 },
            new Circle { Radius = 7 }
        };

        foreach (var shape in shapes)
        {
            Console.WriteLine($"Area: {shape.CalculateArea()}");
        }
    }
}
```

### Explanation
1. **Base Class:** `Shape` defines a contract (`CalculateArea`) that all subclasses must implement.
2. **Subclasses:** `Rectangle` and `Circle` implement the `CalculateArea` method as per their specific behavior.
3. **Usage:** The `shapes` list contains instances of both `Rectangle` and `Circle`. The `Main` method processes these without knowing their specific types, demonstrating LSP.

### Violating LSP
An example of violating LSP would be if the `Rectangle` class adds a behavior that breaks the base class's expectations, such as throwing an exception in certain scenarios. This would make it unsuitable as a substitute for `Shape`.
