using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CoolerBuilder : CoolerBuilderBase
{
    protected override ProccessorCoolingSystem Create(string name, Dimensions dimensions, int dissipatedHeat, IList<string> sockets)
    {
        return new ProccessorCoolingSystem(
            name,
            sockets,
            dimensions,
            dissipatedHeat);
    }
}