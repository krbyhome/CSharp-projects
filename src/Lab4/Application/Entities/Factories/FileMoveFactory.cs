using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public class FileMoveFactory : ICommandFactory
{
    public IFileSystemCommand Create(IList<string> positionalArguments, Dictionary<char, string> parameters)
    {
        return new FileMoveCommand(positionalArguments[0], positionalArguments[1]);
    }
}