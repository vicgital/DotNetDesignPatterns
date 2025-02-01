# Interpreter Pattern in .NET

## Definition
The **Interpreter pattern** is a behavioral design pattern that defines a representation for a grammar along with an interpreter that uses this representation to interpret sentences in the language. This pattern is useful for designing systems that need to evaluate or interpret expressions, such as parsers or configuration interpreters.

## Example in C#
Below is a C# example demonstrating the Interpreter pattern.

### Scenario
We will create a simple arithmetic expression interpreter that can evaluate expressions like `5 + 10 - 3`.

### Code Implementation
```csharp
using System;
using System.Collections.Generic;

// Abstract Expression
interface IExpression
{
    int Interpret();
}

// Terminal Expression (Number)
class NumberExpression : IExpression
{
    private readonly int _number;

    public NumberExpression(int number)
    {
        _number = number;
    }

    public int Interpret() => _number;
}

// Non-Terminal Expression (Addition)
class AddExpression : IExpression
{
    private readonly IExpression _left;
    private readonly IExpression _right;

    public AddExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret() => _left.Interpret() + _right.Interpret();
}

// Non-Terminal Expression (Subtraction)
class SubtractExpression : IExpression
{
    private readonly IExpression _left;
    private readonly IExpression _right;

    public SubtractExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret() => _left.Interpret() - _right.Interpret();
}

// Client
class Program
{
    static void Main()
    {
        // Expression: (5 + 10) - 3
        IExpression expression = new SubtractExpression(
            new AddExpression(
                new NumberExpression(5),
                new NumberExpression(10)
            ),
            new NumberExpression(3)
        );

        int result = expression.Interpret();
        Console.WriteLine($"Result: {result}"); // Output: Result: 12
    }
}
```

### Output
```
Result: 12
```

## Key Points
1. **Grammar Representation:** Defines the grammar using classes for terminal and non-terminal expressions.
2. **Recursive Evaluation:** Uses recursive composition to evaluate expressions.
3. **Extensibility:** Easy to extend by adding new expression types without modifying existing code.

## Use Cases
- Mathematical expression evaluators.
- SQL query interpreters.
- Abstract syntax tree (AST) evaluators.
- Rule-based engines.

The Interpreter pattern is valuable when dealing with complex languages or expression trees that need to be interpreted or executed dynamically.
