// Component
public abstract class FileSystemComponent
{
    public string Name { get; set; }

    protected FileSystemComponent(string name)
    {
        Name = name;
    }

    public abstract void Display(int depth);
}

// Leaf
public class File : FileSystemComponent
{
    public File(string name) : base(name)
    {
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + Name);
    }
}

// Composite
public class Directory : FileSystemComponent
{
    private readonly List<FileSystemComponent> _children = [];

    public Directory(string name) : base(name)
    {
    }

    public void Add(FileSystemComponent component)
    {
        _children.Add(component);
    }

    public void Remove(FileSystemComponent component)
    {
        _children.Remove(component);
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + Name);
        foreach (var component in _children)
        {
            component.Display(depth + 2);
        }
    }
}

// Client Code
class Program
{
    static void Main(string[] args)
    {
        // Create leaf objects (files)
        File file1 = new("File1.txt");
        File file2 = new("File2.txt");
        File file3 = new("File3.txt");

        // Create composite objects (directories)
        Directory root = new("Root");
        Directory subDirectory1 = new("SubDirectory1");
        Directory subDirectory2 = new("SubDirectory2");

        // Build the tree structure
        root.Add(file1);
        root.Add(subDirectory1);
        subDirectory1.Add(file2);
        subDirectory1.Add(subDirectory2);
        subDirectory2.Add(file3);

        // Display the structure
        root.Display(1);
    }
}