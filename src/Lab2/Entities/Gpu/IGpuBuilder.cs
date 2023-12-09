namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IGpuBuilder
{
    IGpuBuilder WithName(string name);
    IGpuBuilder WithDimensions(int length, int width);
    IGpuBuilder WithMemory(int memory);
    IGpuBuilder WithPCIe(string version);
    IGpuBuilder WithFrequency(double freq);
    IGpuBuilder WithConsumption(int consumption);

    Gpu Build();
    void Reset();
}