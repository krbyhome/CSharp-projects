using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract class BiosBuilderBase : IBiosBuilder
{
    private string? _name;
    private string? _type;
    private string? _version;
    private IList<string> _supportedProcessors;

    protected BiosBuilderBase()
    {
        _supportedProcessors = new List<string>();
    }

    public IBiosBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IBiosBuilder WithType(string type)
    {
        _type = type;
        return this;
    }

    public IBiosBuilder WithVersion(string version)
    {
        _version = version;
        return this;
    }

    public IBiosBuilder WithSupportedCpu(string cpuName)
    {
        _supportedProcessors.Add(cpuName);
        return this;
    }

    public Bios Build()
    {
        return Create(
            _name ?? "undefined",
            _type ?? "Legacy",
            _version ?? "undefined",
            _supportedProcessors);
    }

    public void Reset()
    {
        _name = null;
        _type = null;
        _version = null;
        _supportedProcessors.Clear();
    }

    protected abstract Bios Create(
    string name,
    string type,
    string version,
    IList<string> supportedProcessors);
}