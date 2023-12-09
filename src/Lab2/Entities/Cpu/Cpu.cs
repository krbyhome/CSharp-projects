namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu : IComponent<Cpu>, IConsumingPower
{
    public Cpu(
        string name,
        double frequency,
        int coreNumbers,
        bool hasVideoCore,
        string socket,
        int thermalDesignPower,
        int powerConsumption,
        int maxMemoryFrequency)
    {
        Name = name;
        CoreFrequency = frequency;
        CoreNumbers = coreNumbers;
        HasVideoCore = hasVideoCore;
        Socket = socket;
        ThermalDesignPower = thermalDesignPower;
        PowerConsumption = powerConsumption;
        MaxMemoryFrequency = maxMemoryFrequency;
    }

    private Cpu(Cpu other)
    {
        Name = other.Name;
        CoreFrequency = other.CoreFrequency;
        CoreNumbers = other.CoreNumbers;
        HasVideoCore = other.HasVideoCore;
        Socket = other.Socket;
        MaxMemoryFrequency = other.MaxMemoryFrequency;
        ThermalDesignPower = other.ThermalDesignPower;
        PowerConsumption = other.PowerConsumption;
    }

    public string Name { get; }
    public double CoreFrequency { get; }
    public int CoreNumbers { get; }
    public bool HasVideoCore { get; }
    public string Socket { get; }
    public int MaxMemoryFrequency { get; }
    public int ThermalDesignPower { get; }
    public int PowerConsumption { get; }

    public Cpu Clone()
    {
        return new Cpu(this);
    }

    public ICpuBuilder Direct(ICpuBuilder builder)
    {
        builder.Reset();
        builder
            .WithName(Name)
            .WithFrequency(CoreFrequency)
            .WithTdp(ThermalDesignPower)
            .WithSocket(Socket)
            .WithCoreNumber(CoreNumbers)
            .WithMemoryFrequency(MaxMemoryFrequency)
            .WithVideoCore()
            .WithPowerConsumption(PowerConsumption);
        return builder;
    }
}