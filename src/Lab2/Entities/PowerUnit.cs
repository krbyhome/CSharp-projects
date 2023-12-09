namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PowerUnit : IComponent<PowerUnit>
{
    public PowerUnit(string name, int peakLoad)
    {
        Name = name;
        PeakLoad = peakLoad;
    }

    private PowerUnit(PowerUnit other)
    {
        Name = other.Name;
        PeakLoad = other.PeakLoad;
    }

    public string Name { get; }
    public int PeakLoad { get; }

    public PowerUnit Clone()
    {
        return new PowerUnit(this);
    }
}