# Flyweight Design Pattern in Software Development

## Definition

The Flyweight Design Pattern is a structural design pattern that focuses on minimizing memory usage by sharing as much data as possible with similar objects. It achieves this by storing common properties externally and using them across multiple objects.

## Key Features

- Reduces memory consumption by sharing common state.
- Splits the object state into intrinsic (shared) and extrinsic (unique per object) data.
- Useful in scenarios where a large number of similar objects are created.

## Example in C#

Below is an example demonstrating the Flyweight Design Pattern in C#.

```csharp
using System;
using System.Collections.Generic;

// Flyweight
public class TreeType
{
    public string Name { get; private set; }
    public string Color { get; private set; }
    public string Texture { get; private set; }

    public TreeType(string name, string color, string texture)
    {
        Name = name;
        Color = color;
        Texture = texture;
    }

    public void Display(int x, int y)
    {
        Console.WriteLine($"Tree [Name: {Name}, Color: {Color}, Texture: {Texture}] at coordinates ({x}, {y})");
    }
}

// Flyweight Factory
public class TreeFactory
{
    private static readonly Dictionary<string, TreeType> _treeTypes = new();

    public static TreeType GetTreeType(string name, string color, string texture)
    {
        string key = $"{name}_{color}_{texture}";

        if (!_treeTypes.ContainsKey(key))
        {
            _treeTypes[key] = new TreeType(name, color, texture);
        }

        return _treeTypes[key];
    }
}

// Context
public class Tree
{
    private int _x;
    private int _y;
    private TreeType _treeType;

    public Tree(int x, int y, TreeType treeType)
    {
        _x = x;
        _y = y;
        _treeType = treeType;
    }

    public void Display()
    {
        _treeType.Display(_x, _y);
    }
}

// Client Code
class Program
{
    static void Main(string[] args)
    {
        List<Tree> forest = new();

        // Creating trees using the Flyweight pattern
        forest.Add(new Tree(1, 2, TreeFactory.GetTreeType("Oak", "Green", "Rough")));
        forest.Add(new Tree(3, 4, TreeFactory.GetTreeType("Pine", "Dark Green", "Smooth")));
        forest.Add(new Tree(5, 6, TreeFactory.GetTreeType("Oak", "Green", "Rough"))); // Reuses existing Oak tree type

        // Display all trees in the forest
        foreach (var tree in forest)
        {
            tree.Display();
        }

        Console.WriteLine($"Total Tree Types Created: {TreeFactory.GetTreeType("", "", "").GetType().Assembly.GetTypes().Length}");
    }
}
```

## Explanation

1. **Flyweight**: The `TreeType` class represents the shared state (intrinsic data) of trees.
2. **Flyweight Factory**: The `TreeFactory` class ensures that `TreeType` instances are shared and reused, avoiding duplication.
3. **Context**: The `Tree` class contains unique state (extrinsic data) such as the position (`x`, `y`) of the tree.
4. **Client Code**: The `Main` method demonstrates creating trees while sharing the common state through the Flyweight pattern.

## Benefits

- Reduces memory usage by sharing intrinsic data.
- Improves application performance in scenarios with a large number of similar objects.

## Drawbacks

- Increased complexity due to the need to distinguish between intrinsic and extrinsic data.
- May introduce synchronization issues in multithreaded environments if shared state is modified.
