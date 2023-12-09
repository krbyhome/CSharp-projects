using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ChipsetBuilder : ChipsetBuilderBase
{
    protected override Chipset Create(string name, bool isXmpCompatible, IList<double> frequencies)
    {
        return new Chipset(
            name,
            isXmpCompatible,
            frequencies.AsReadOnly());
    }
}