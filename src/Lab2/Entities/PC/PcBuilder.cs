using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PcBuilder : PcBuilderBase
{
    protected override PC Create(
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
        return new PC(
            name,
            processor,
            motherboard,
            coolingSystem,
            computerCase,
            powerUnit,
            memory,
            graphics,
            drives,
            wifiAdapter);
    }
}