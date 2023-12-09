namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IBiosBuilder
{
    IBiosBuilder WithName(string name);
    IBiosBuilder WithType(string type);
    IBiosBuilder WithVersion(string version);
    IBiosBuilder WithSupportedCpu(string cpuName);

    Bios Build();
    void Reset();
}