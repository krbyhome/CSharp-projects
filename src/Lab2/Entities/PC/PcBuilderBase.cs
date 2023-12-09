using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract class PcBuilderBase : IPcBuilder
{
    private readonly IList<Ram> _memory;
    private readonly IList<Gpu> _graphics;
    private readonly IList<IStorageDevice> _drives;
    private string? _name;
    private Cpu? _processor;
    private MotherBoard? _motherBoard;
    private ProccessorCoolingSystem? _cooler;
    private ComputerCase? _case;
    private PowerUnit? _powerUnit;
    private WifiAdapter? _wifiAdapter;

    protected PcBuilderBase()
    {
        _memory = new List<Ram>();
        _graphics = new List<Gpu>();
        _drives = new List<IStorageDevice>();
    }

    public IPcBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IPcBuilder SetCpu(Cpu processor)
    {
        _processor = processor;
        return this;
    }

    public IPcBuilder SetMotherBoard(MotherBoard motherboard)
    {
        _motherBoard = motherboard;
        return this;
    }

    public IPcBuilder SetCoolingSystem(ProccessorCoolingSystem cooler)
    {
        _cooler = cooler;
        return this;
    }

    public IPcBuilder SetComputerCase(ComputerCase computerCase)
    {
        _case = computerCase;
        return this;
    }

    public IPcBuilder SetPowerUnit(PowerUnit powerUnit)
    {
        _powerUnit = powerUnit;
        return this;
    }

    public IPcBuilder AddRam(Ram ram)
    {
        _memory.Add(ram);
        return this;
    }

    public IPcBuilder AddGraphics(Gpu gpu)
    {
        _graphics.Add(gpu);
        return this;
    }

    public IPcBuilder AddDrive(IStorageDevice drive)
    {
        _drives.Add(drive);
        return this;
    }

    public IPcBuilder SetWifiAdapter(WifiAdapter? wifiAdapter)
    {
        _wifiAdapter = wifiAdapter;
        return this;
    }

    public PC Build()
    {
        return Create(
            _name ?? "undefined",
            _processor ?? throw new ArgumentNullException(nameof(_processor)),
            _motherBoard ?? throw new ArgumentNullException(nameof(_motherBoard)),
            _cooler ?? throw new ArgumentNullException(nameof(_cooler)),
            _case ?? throw new ArgumentNullException(nameof(_case)),
            _powerUnit ?? throw new ArgumentNullException(nameof(_powerUnit)),
            _memory,
            _graphics,
            _drives,
            _wifiAdapter);
    }

    public void Reset()
    {
        _name = null;
        _processor = null;
        _motherBoard = null;
        _cooler = null;
        _case = null;
        _powerUnit = null;
        _memory.Clear();
        _graphics.Clear();
        _drives.Clear();
        _wifiAdapter = null;
    }

    protected abstract PC Create(
        string name,
        Cpu processor,
        MotherBoard motherboard,
        ProccessorCoolingSystem coolingSystem,
        ComputerCase computerCase,
        PowerUnit powerUnit,
        IEnumerable<Ram> memory,
        IEnumerable<Gpu> graphics,
        IEnumerable<IStorageDevice> drives,
        WifiAdapter? wifiAdapter);
}