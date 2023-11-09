using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ram : IComponent<Ram>
{
    private readonly IList<XmpProfile> _availableProfiles;
    public Ram(
        string name,
        IEnumerable<XmpProfile> availableProfiles,
        int memorySize,
        string ddrVersion,
        string formfactor)
    {
        Name = name;
        _availableProfiles = availableProfiles.ToList();
        MemorySize = memorySize;
        DdrVersion = ddrVersion;
        FormFactor = formfactor;
    }

    private Ram(Ram other)
    {
        Name = other.Name;
        MemorySize = other.MemorySize;
        _availableProfiles = other.AvailableProfiles.ToList();
        FormFactor = other.FormFactor;
        DdrVersion = other.DdrVersion;
    }

    public string Name { get; }
    public int MemorySize { get; }
    public IEnumerable<XmpProfile> AvailableProfiles => _availableProfiles.AsReadOnly();
    public string FormFactor { get; }
    public string DdrVersion { get; }

    public Ram Clone()
    {
        return new Ram(this);
    }

    public IRamBuilder Direct(IRamBuilder builder)
    {
        builder.Reset();
        builder
            .WithName(Name)
            .WithMemorySize(MemorySize)
            .WithFormFactor(FormFactor)
            .WithVersion(DdrVersion);

        foreach (XmpProfile profile in AvailableProfiles)
        {
            builder.WithProfile(profile);
        }

        return builder;
    }
}