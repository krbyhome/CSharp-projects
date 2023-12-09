using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract class ChipsetBuilderBase : IChipsetBuilder
{
    private readonly IList<double> _availableFrequencies;
    private string? _name;
    private bool _xmpCompatible;

    protected ChipsetBuilderBase()
    {
        _xmpCompatible = false;
        _availableFrequencies = new List<double>();
    }

    public IChipsetBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IChipsetBuilder WithXmpSupport()
    {
        _xmpCompatible = true;
        return this;
    }

    public IChipsetBuilder WithFrequency(double frequency)
    {
        _availableFrequencies.Add(frequency);
        return this;
    }

    public Chipset Build()
    {
        return Create(
            _name ?? "undefined",
            _xmpCompatible,
            _availableFrequencies);
    }

    public void Reset()
    {
        _name = null;
        _xmpCompatible = false;
        _availableFrequencies.Clear();
    }

    protected abstract Chipset Create(
        string name,
        bool isXmpCompatible,
        IList<double> frequencies);
}