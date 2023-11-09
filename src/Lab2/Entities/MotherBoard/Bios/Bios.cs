using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Bios : IComponent<Bios>
{
    private readonly IList<string> _supportedProcessors;
    public Bios(
        string name,
        string type,
        string version,
        IEnumerable<string> supportedProcessors)
    {
        Name = name;
        Type = type;
        Version = version;
        _supportedProcessors = supportedProcessors.ToList();
    }

    private Bios(Bios other)
    {
        Name = other.Name;
        Type = other.Type;
        Version = other.Version;
        _supportedProcessors = other.SupportedProcessors;
    }

    public string Name { get; }
    public string Type { get; }
    public string Version { get; }
    public IList<string> SupportedProcessors => _supportedProcessors.AsReadOnly();

    public Bios Clone()
    {
        return new Bios(this);
    }

    public IBiosBuilder Direct(IBiosBuilder builder)
    {
        builder.Reset();
        builder
            .WithName(Name)
            .WithType(Type)
            .WithVersion(Version);
        foreach (string processor in _supportedProcessors)
        {
            builder.WithSupportedCpu(processor);
        }

        return builder;
    }
}