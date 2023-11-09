using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerCaseBuilder : ComputerCaseBuilderBase
{
    public ComputerCaseBuilder(ComputerCase prototype)
        : base(prototype)
    {
    }

    public ComputerCaseBuilder()
        : base()
    {
    }

    protected override ComputerCase Create(
        string name,
        IEnumerable<string> formfactors,
        int maxLength,
        int maxWidth,
        Dimensions dimensions)
    {
        return new ComputerCase(
            name,
            formfactors,
            maxLength,
            maxWidth,
            dimensions);
    }
}