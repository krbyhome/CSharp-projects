namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IComputerCaseBuilder
{
    IComputerCaseBuilder WithName(string name);
    IComputerCaseBuilder WithGpuDimensions(int maxLength, int maxWidth);
    IComputerCaseBuilder WithFormFactor(string supportedFormfactor);
    IComputerCaseBuilder WithDimensions(int x, int y, int z);

    ComputerCase Build();
    void Reset();
}