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