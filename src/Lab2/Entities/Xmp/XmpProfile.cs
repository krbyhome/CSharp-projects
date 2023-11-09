using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class XmpProfile : IComponent<XmpProfile>
{
    private readonly IList<int> _timings;
    public XmpProfile(
        string name,
        int freq,
        int voltage,
        IEnumerable<int> timings)
    {
        Name = name;
        _timings = timings.ToList();
        Voltage = voltage;
        Frequency = freq;
    }

    private XmpProfile(XmpProfile other)
    {
        Name = other.Name;
        _timings = other.Timings.ToList();
        Voltage = other.Voltage;
        Frequency = other.Frequency;
    }

    public string Name { get; }
    public double Voltage { get; }
    public int Frequency { get; }
    public IList<int> Timings => _timings;

    public XmpProfile Clone()
    {
        return new XmpProfile(this);
    }
}