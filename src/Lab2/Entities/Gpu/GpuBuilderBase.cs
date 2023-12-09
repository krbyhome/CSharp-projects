using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract class GpuBuilderBase : IGpuBuilder
{
    private string? _name;
    private int? _length;
    private int? _width;
    private int? _memory;
    private string? _pcieVersion;
    private double? _frequency;
    private int? _consumption;

    protected GpuBuilderBase(Gpu prototype)
    {
        _name = prototype.Name;
        _length = prototype.Length;
        _width = prototype.Width;
        _memory = prototype.Memory;
        _pcieVersion = prototype.PCIeVersion;
        _frequency = prototype.ChipFreq;
        _consumption = prototype.PowerConsumption;
    }

    protected GpuBuilderBase()
    {
    }

    public IGpuBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IGpuBuilder WithDimensions(int length, int width)
    {
        _length = length;
        _width = width;
        return this;
    }

    public IGpuBuilder WithMemory(int memory)
    {
        _memory = memory;
        return this;
    }

    public IGpuBuilder WithPCIe(string version)
    {
        _pcieVersion = version;
        return this;
    }

    public IGpuBuilder WithFrequency(double freq)
    {
        _frequency = freq;
        return this;
    }

    public IGpuBuilder WithConsumption(int consumption)
    {
        _consumption = consumption;
        return this;
    }

    public Gpu Build()
    {
        return Create(
            _name ?? "undefined",
            _length ?? 60,
            _width ?? 40,
            _memory ?? throw new ArgumentNullException(nameof(_memory)),
            _pcieVersion ?? throw new ArgumentNullException(nameof(_pcieVersion)),
            _frequency ?? throw new ArgumentNullException(nameof(_frequency)),
            _consumption ?? 300);
    }

    public void Reset()
    {
        _name = null;
        _length = null;
        _width = null;
        _memory = null;
        _pcieVersion = null;
        _frequency = null;
        _consumption = null;
    }

    protected abstract Gpu Create(
        string name,
        int length,
        int width,
        int memory,
        string pcieVersion,
        double chipFreq,
        int powerConsumption);
}