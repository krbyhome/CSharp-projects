namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface ICpuBuilder
{
    ICpuBuilder WithName(string name);
    ICpuBuilder WithFrequency(double coreFrequency);
    ICpuBuilder WithCoreNumber(int coreNumber);
    ICpuBuilder WithVideoCore();
    ICpuBuilder WithSocket(string socket);
    ICpuBuilder WithMemoryFrequency(int maxMemoryFrequency);
    ICpuBuilder WithTdp(int thermalDesignPower);
    ICpuBuilder WithPowerConsumption(int consumption);

    Cpu Build();
    void Reset();
}