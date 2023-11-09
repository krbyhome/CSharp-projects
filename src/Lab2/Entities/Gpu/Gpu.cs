namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Gpu : IComponent<Gpu>, IConsumingPower
{
    public Gpu(
        string name,
        int length,
        int width,
        int memory,
        string pcieVersion,
        double chipFreq,
        int powerConsumption)
    {
        Name = name;
        Length = length;
        Width = width;
        Memory = memory;
        PCIeVersion = pcieVersion;
        ChipFreq = chipFreq;
        PowerConsumption = powerConsumption;
    }

    private Gpu(Gpu other)
    {
        Name = other.Name;
        Length = other.Length;
        Width = other.Width;
        Memory = other.Memory;
        PCIeVersion = other.PCIeVersion;
        ChipFreq = other.ChipFreq;
        PowerConsumption = other.PowerConsumption;
    }

    public string Name { get; }
    public int Length { get; }
    public int Width { get; }
    public int Memory { get; }
    public string PCIeVersion { get; }
    public double ChipFreq { get; }
    public int PowerConsumption { get; }

    public Gpu Clone()
    {
        return new Gpu(this);
    }

    public IGpuBuilder Direct(IGpuBuilder builder)
    {
        builder.Reset();
        builder
            .WithName(Name)
            .WithDimensions(Length, Width)
            .WithMemory(Memory)
            .WithPCIe(PCIeVersion)
            .WithFrequency(ChipFreq)
            .WithConsumption(PowerConsumption);
        return builder;
    }
}