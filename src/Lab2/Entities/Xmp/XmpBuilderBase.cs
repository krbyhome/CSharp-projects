using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract class XmpBuilderBase : IXmpBuilder
{
    private readonly IList<int> _timings;
    private string? _name;
    private int? _freq;
    private int? _voltage;

    protected XmpBuilderBase()
    {
        _timings = new List<int>();
    }

    public IXmpBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IXmpBuilder WithFreq(int frequency)
    {
        _freq = frequency;
        return this;
    }

    public IXmpBuilder WithVoltage(int voltage)
    {
        _voltage = voltage;
        return this;
    }

    public IXmpBuilder AddTiming(int timings)
    {
        _timings.Add(timings);
        return this;
    }

    public XmpProfile Build()
    {
        return Create(
            _name ?? "undefined",
            _freq ?? 2400,
            _voltage ?? 2,
            _timings);
    }

    public void Reset()
    {
        _name = null;
        _freq = null;
        _voltage = null;
        _timings.Clear();
    }

    protected abstract XmpProfile Create(
        string name,
        int freq,
        int voltage,
        IEnumerable<int> timings);
}