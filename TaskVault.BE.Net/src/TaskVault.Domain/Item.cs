namespace TaskVault.Domain;

public sealed class Item : Entity
{
    public Item(string name) => Name = name;

    public Item(string name, Priority priority): this(name) => Priority = priority;

    public Item(long id, string name, ushort progress, Priority priority)
    {
        Id = id;
        Name = name;
        Progress = progress;
        Priority = priority;
    }

    public string Name { get; }

    public ushort Progress { get; }

    public Priority Priority { get; }
}
