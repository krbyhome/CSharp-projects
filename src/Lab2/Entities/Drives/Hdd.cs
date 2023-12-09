namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Hdd : IStorageDevice, IComponent<Hdd>
{
    public Hdd(
        string name,
        int capacity,
        int spindleRotationSpeed)
    {
        Name = name;
        Capacity = capacity;
        SpindleRotationSpeed = spindleRotationSpeed;
        ConnectionOption = ComputerEBus.SATA;
    }

    private Hdd(Hdd other)
    {
        Name = other.Name;
        Capacity = other.Capacity;
        SpindleRotationSpeed = other.SpindleRotationSpeed;
        ConnectionOption = ComputerEBus.SATA;
    }

    public string Name { get; }
    public int Capacity { get; }
    public int SpindleRotationSpeed { get; }
    public ComputerEBus ConnectionOption { get; }

    public Hdd Clone()
    {
        return new Hdd(this);
    }
}