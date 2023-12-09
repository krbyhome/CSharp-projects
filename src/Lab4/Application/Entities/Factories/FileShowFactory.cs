using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Application.Extensions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public class FileShowFactory : ICommandFactory
{
    public IFileSystemCommand Create(IList<string> positionalArguments, Dictionary<char, string> parameters)
    {
        return new FileShowCommand(positionalArguments[0], parameters['m'].ToOutputMode());
    }
}