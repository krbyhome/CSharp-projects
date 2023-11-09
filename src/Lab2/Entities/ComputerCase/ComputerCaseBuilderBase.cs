using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract class ComputerCaseBuilderBase : IComputerCaseBuilder
{
    private string? _name;
    private IList<string> _formfactors;
    private int? _maxLength;
    private int? _maxWidth;
    private Dimensions? _dimensions;

    protected ComputerCaseBuilderBase()
    {
        _formfactors = new List<string>();
    }

    protected ComputerCaseBuilderBase(ComputerCase prototype)
    {
        _name = prototype.Name;
        _formfactors = prototype.SupportedFormfactors.ToList();
        _maxLength = prototype.MaxGpuLength;
        _maxWidth = prototype.MaxGpuWidth;
        _dimensions = prototype.Dimensions;
    }

    public IComputerCaseBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IComputerCaseBuilder WithGpuDimensions(int maxLength, int maxWidth)
    {
        _maxLength = maxLength;
        _maxWidth = maxWidth;
        return this;
    }

    public IComputerCaseBuilder WithFormFactor(string supportedFormfactor)
    {
        _formfactors.Add(supportedFormfactor);
        return this;
    }

    public IComputerCaseBuilder WithDimensions(int x, int y, int z)
    {
        _dimensions = new Dimensions(x, y, z);
        return this;
    }

    public ComputerCase Build()
    {
        return Create(
            _name ?? "undefined",
            _formfactors,
            _maxLength ?? throw new ArgumentNullException(nameof(_maxLength)),
            _maxWidth ?? throw new ArgumentNullException(nameof(_maxWidth)),
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)));
    }

    public void Reset()
    {
        _name = null;
        _formfactors.Clear();
        _maxLength = null;
        _maxWidth = null;
        _dimensions = null;
    }

    protected abstract ComputerCase Create(
        string name,
        IEnumerable<string> formfactors,
        int maxLength,
        int maxWidth,
        Dimensions dimensions);
}