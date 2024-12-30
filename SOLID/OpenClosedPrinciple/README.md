# Open-Closed Principle in OOP

The Open-Closed Principle (OCP) is one of the SOLID principles in object-oriented programming. It states that:

> **"Software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification."**

This means that the behavior of a module can be extended without modifying its source code, making it easier to maintain and scale without introducing bugs in existing functionality.

## Example in C#

Here is an example demonstrating the Open-Closed Principle in C#:

### Scenario
We have a basic application for calculating the area of different shapes. Instead of modifying existing code to support new shapes, we use polymorphism to extend functionality.

### Implementation
```csharp
using System;
using System.Collections.Generic;

// Base class for shapes
public abstract class Shape
{
    public abstract double CalculateArea();
}

// Rectangle class extending Shape
public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

// Circle class extending Shape
public class Circle : Shape
{
    public double Radius { get; set; }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

// Area calculator
public class AreaCalculator
{
    public double TotalArea(List<Shape> shapes)
    {
        double total = 0;
        foreach (var shape in shapes)
        {
            total += shape.CalculateArea();
        }
        return total;
    }
}

// Example usage
public class Program
{
    public static void Main(string[] args)
    {
        var shapes = new List<Shape>
        {
            new Rectangle { Width = 5, Height = 10 },
            new Circle { Radius = 7 }
        };

        var calculator = new AreaCalculator();
        Console.WriteLine($"Total Area: {calculator.TotalArea(shapes)}");
    }
}
```

### Explanation
1. **Open for Extension:**
   - Adding new shapes (e.g., `Triangle`) is straightforward. You simply create a new class that inherits from `Shape` and implements the `CalculateArea` method.

2. **Closed for Modification:**
   - The existing code for `AreaCalculator` and the `Shape` hierarchy does not need to be modified when introducing new shapes. This ensures stability in the existing codebase.

### Output
For the given example, the output might look like this:

```
Total Area: 178.53981633974485
