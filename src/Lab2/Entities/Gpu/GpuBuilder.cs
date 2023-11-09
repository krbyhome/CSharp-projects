namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class GpuBuilder : GpuBuilderBase
{
    public GpuBuilder(Gpu prototype)
    : base(prototype)
    {
    }

    public GpuBuilder()
        : base()
    {
    }

    protected override Gpu Create(
        string name,
        int length,
        int width,
        int memory,
        string pcieVersion,
        double chipFreq,
        int powerConsumption)
    {
        return new Gpu(
            name,
            length,
            width,
            memory,
            pcieVersion,
            chipFreq,
            powerConsumption);
    }
}