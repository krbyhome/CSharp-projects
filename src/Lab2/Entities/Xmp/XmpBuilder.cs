using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class XmpBuilder : XmpBuilderBase
{
    protected override XmpProfile Create(string name, int freq, int voltage, IEnumerable<int> timings)
    {
        return new XmpProfile(
            name,
            freq,
            voltage,
            timings);
    }
}