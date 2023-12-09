namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IXmpBuilder
{
    IXmpBuilder WithName(string name);
    IXmpBuilder WithFreq(int frequency);
    IXmpBuilder WithVoltage(int voltage);
    IXmpBuilder AddTiming(int timings);

    XmpProfile Build();
    void Reset();
}