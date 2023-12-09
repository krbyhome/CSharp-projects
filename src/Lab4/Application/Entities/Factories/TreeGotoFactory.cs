using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public class TreeGotoFactory : ICommandFactory
{
    public IFileSystemCommand Create(IList<string> positionalArguments, Dictionary<char, string> parameters)
    {
        return new TreeGotoCommand(positionalArguments[0]);
    }
}