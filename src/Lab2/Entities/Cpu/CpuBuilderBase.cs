using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract class CpuBuilderBase : ICpuBuilder
{
    private string? _name;
    private double? _coreFrequency;
    private int? _coreNumber;
    private bool? _hasVideoCore;
    private string? _socket;
    private int? _maxMemoryFrequency;
    private int? _thermalDesignPower;
    private int? _consumption;

    protected CpuBuilderBase(Cpu prototype)
    {
        _name = prototype.Name;
        _coreFrequency = prototype.CoreFrequency;
        _coreNumber = prototype.CoreNumbers;
        _hasVideoCore = prototype.HasVideoCore;
        _socket = prototype.Socket;
        _maxMemoryFrequency = prototype.MaxMemoryFrequency;
        _thermalDesignPower = prototype.ThermalDesignPower;
        _consumption = prototype.PowerConsumption;
    }

    protected CpuBuilderBase()
    {
    }

    public ICpuBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ICpuBuilder WithFrequency(double coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public ICpuBuilder WithCoreNumber(int coreNumber)
    {
        _coreNumber = coreNumber;
        return this;
    }

    public ICpuBuilder WithVideoCore()
    {
        _hasVideoCore = true;
        return this;
    }

    public ICpuBuilder WithSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public ICpuBuilder WithMemoryFrequency(int maxMemoryFrequency)
    {
        _maxMemoryFrequency = maxMemoryFrequency;
        return this;
    }

    public ICpuBuilder WithTdp(int thermalDesignPower)
    {
        _thermalDesignPower = thermalDesignPower;
        return this;
    }

    public ICpuBuilder WithPowerConsumption(int consumption)
    {
        _consumption = consumption;
        return this;
    }

    public Cpu Build()
    {
        return Create(
            _name ?? "undefined",
            _coreFrequency ?? throw new ArgumentNullException(nameof(_coreFrequency)),
            _coreNumber ?? 4,
            _hasVideoCore ?? false,
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _thermalDesignPower ?? 80,
            _consumption ?? 100,
            _maxMemoryFrequency ?? throw new ArgumentNullException(nameof(_maxMemoryFrequency)));
    }

    public void Reset()
    {
        _name = null;
        _coreFrequency = null;
        _coreNumber = null;
        _hasVideoCore = null;
        _socket = null;
        _maxMemoryFrequency = null;
        _thermalDesignPower = null;
        _consumption = null;
    }

    protected abstract Cpu Create(
        string name,
        double frequency,
        int coreNumbers,
        bool hasVideoCore,
        string socket,
        int thermalDesignPower,
        int powerConsumption,
        int maxMemoryFrequency);
}