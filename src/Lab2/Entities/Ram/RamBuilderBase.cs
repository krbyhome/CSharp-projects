using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract class RamBuilderBase : IRamBuilder
{
    private string? _name;
    private int? _memorySize;
    private IList<XmpProfile> _availableProfiles;
    private string? _formfactor;
    private string? _ddrVersion;

    protected RamBuilderBase(Ram prototype)
    {
        _name = prototype.Name;
        _memorySize = prototype.MemorySize;
        _availableProfiles = prototype.AvailableProfiles.ToList();
        _formfactor = prototype.FormFactor;
        _ddrVersion = prototype.DdrVersion;
    }

    protected RamBuilderBase()
    {
        _availableProfiles = new List<XmpProfile>();
    }

    public IRamBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IRamBuilder WithMemorySize(int memorySize)
    {
        _memorySize = memorySize;
        return this;
    }

    public IRamBuilder WithProfile(XmpProfile availableProfile)
    {
        _availableProfiles.Add(availableProfile);
        return this;
    }

    public IRamBuilder WithVersion(string ddrVersion)
    {
        _ddrVersion = ddrVersion;
        return this;
    }

    public IRamBuilder WithFormFactor(string formfactor)
    {
        _formfactor = formfactor;
        return this;
    }

    public Ram Build()
    {
        return Create(
            _name ?? "undefined",
            _availableProfiles,
            _memorySize ?? 8,
            _ddrVersion ?? "ddr4",
            _formfactor ?? "default");
    }

    public void Reset()
    {
        _name = null;
        _availableProfiles.Clear();
        _memorySize = null;
        _ddrVersion = null;
        _formfactor = null;
    }

    protected abstract Ram Create(
        string name,
        IList<XmpProfile> availableProfiles,
        int memorySize,
        string ddrVersion,
        string formfactor);
}