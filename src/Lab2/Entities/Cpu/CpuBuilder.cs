namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CpuBuilder : CpuBuilderBase
{
    public CpuBuilder(Cpu prototype)
        : base(prototype)
    {
    }

    public CpuBuilder()
        : base()
    {
    }

    protected override Cpu Create(
        string name,
        double frequency,
        int coreNumbers,
        bool hasVideoCore,
        string socket,
        int thermalDesignPower,
        int powerConsumption,
        int maxMemoryFrequency)
    {
        return new Cpu(
            name,
            frequency,
            coreNumbers,
            hasVideoCore,
            socket,
            thermalDesignPower,
            powerConsumption,
            maxMemoryFrequency);
    }
}