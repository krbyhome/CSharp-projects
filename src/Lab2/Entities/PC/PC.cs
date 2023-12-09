using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PC : IComponent<PC>
{
    private readonly IList<Ram> _memory;
    private readonly IList<Gpu> _graphics;
    private readonly IList<IStorageDevice> _drives;
    public PC(
        string name,
        Cpu processor,
        MotherBoard motherboard,
        ProccessorCoolingSystem coolingSystem,
        ComputerCase computerCase,
        PowerUnit powerUnit,
        IEnumerable<Ram> memory,
        IEnumerable<Gpu> graphics,
        IEnumerable<IStorageDevice> drives,
        WifiAdapter? wifiAdapter)
    {
        Name = name;
        Processor = processor;
        Motherboard = motherboard;
        CoolingSystem = coolingSystem;
        Case = computerCase;
        PowerUnit = powerUnit;
        _memory = memory.ToList();
        _graphics = graphics.ToList();
        _drives = drives.ToList();
        WifiAdapter = wifiAdapter;
    }

    public PC(PC other)
    {
        Name = other.Name;
        Processor = other.Processor;
        Motherboard = other.Motherboard;
        CoolingSystem = other.CoolingSystem;
        Case = other.Case;
        PowerUnit = other.PowerUnit;
        _memory = other.Memory;
        _graphics = other.Graphics;
        _drives = other.Drives;
        WifiAdapter = other.WifiAdapter;
    }

    public string Name { get; }
    public Cpu Processor { get; }
    public MotherBoard Motherboard { get; }
    public ProccessorCoolingSystem CoolingSystem { get; }
    public ComputerCase Case { get; }
    public PowerUnit PowerUnit { get; }
    public IList<Ram> Memory => _memory.AsReadOnly();
    public IList<Gpu> Graphics => _graphics.AsReadOnly();
    public IList<IStorageDevice> Drives => _drives.AsReadOnly();
    public WifiAdapter? WifiAdapter { get; }

    public PC Clone()
    {
        return new PC(this);
    }

    public IPcBuilder Direct(IPcBuilder builder)
    {
        builder.Reset();
        builder
            .WithName(Name)
            .SetCpu(Processor)
            .SetMotherBoard(Motherboard)
            .SetCoolingSystem(CoolingSystem)
            .SetComputerCase(Case)
            .SetPowerUnit(PowerUnit);

        if (WifiAdapter is not null)
        {
            builder.SetWifiAdapter(WifiAdapter);
        }

        foreach (Ram ram in Memory)
        {
            builder.AddRam(ram);
        }

        foreach (Gpu gpu in Graphics)
        {
            builder.AddGraphics(gpu);
        }

        foreach (IStorageDevice drive in Drives)
        {
            builder.AddDrive(drive);
        }

        return builder;
    }
}