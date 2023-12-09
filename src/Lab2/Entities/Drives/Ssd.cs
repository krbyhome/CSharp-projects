namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ssd : IStorageDevice, IComponent<Ssd>
{
    public Ssd(
        string name,
        int capacity,
        ComputerEBus connectionOption)
    {
        Name = name;
        Capacity = capacity;
        ConnectionOption = connectionOption;
    }

    private Ssd(Ssd other)
    {
        Name = other.Name;
        Capacity = other.Capacity;
        ConnectionOption = other.ConnectionOption;
    }

    public string Name { get; }
    public int Capacity { get; }
    public ComputerEBus ConnectionOption { get; }

    public Ssd Clone()
    {
        return new Ssd(this);
    }
}