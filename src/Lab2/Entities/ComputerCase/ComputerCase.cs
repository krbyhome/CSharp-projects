using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerCase : IComponent<ComputerCase>
{
    private readonly IList<string> _supportedFormfactors;

    public ComputerCase(
        string name,
        IEnumerable<string> formfactors,
        int maxLength,
        int maxWidth,
        Dimensions dimensions)
    {
        Name = name;
        _supportedFormfactors = formfactors.ToList();
        MaxGpuLength = maxLength;
        MaxGpuWidth = maxWidth;
        Dimensions = dimensions;
    }

    private ComputerCase(ComputerCase other)
    {
        Name = other.Name;
        _supportedFormfactors = other.SupportedFormfactors.ToList();
        MaxGpuLength = other.MaxGpuLength;
        MaxGpuWidth = other.MaxGpuWidth;
        Dimensions = other.Dimensions;
    }

    public string Name { get; }
    public int MaxGpuLength { get; }

    public int MaxGpuWidth { get; }

    public Dimensions Dimensions { get; }

    public IList<string> SupportedFormfactors => _supportedFormfactors.AsReadOnly();

    public ComputerCase Clone()
    {
        return new ComputerCase(this);
    }

    public IComputerCaseBuilder Direct(IComputerCaseBuilder builder)
    {
        builder.Reset();
        builder
            .WithName(Name)
            .WithDimensions(100, 50, 30)
            .WithGpuDimensions(MaxGpuLength, MaxGpuWidth);

        foreach (string formfactor in _supportedFormfactors)
        {
            builder.WithFormFactor(formfactor);
        }

        return builder;
    }
}