using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class BiosBuilder : BiosBuilderBase
{
    protected override Bios Create(string name, string type, string version, IList<string> supportedProcessors)
    {
        return new Bios(
            name,
            type,
            version,
            supportedProcessors);
    }
}