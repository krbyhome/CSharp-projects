namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IChipsetBuilder
{
    IChipsetBuilder WithName(string name);
    IChipsetBuilder WithXmpSupport();
    IChipsetBuilder WithFrequency(double frequency);
    Chipset Build();
    void Reset();
}