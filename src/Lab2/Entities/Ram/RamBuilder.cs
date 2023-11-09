using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class RamBuilder : RamBuilderBase
{
    public RamBuilder(Ram prototype)
        : base(prototype)
    {
    }

    public RamBuilder()
        : base()
    {
    }

    protected override Ram Create(
        string name,
        IList<XmpProfile> availableProfiles,
        int memorySize,
        string ddrVersion,
        string formfactor)
    {
        return new Ram(
            name,
            availableProfiles,
            memorySize,
            ddrVersion,
            formfactor);
    }
}