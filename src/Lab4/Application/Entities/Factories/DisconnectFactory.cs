using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public class DisconnectFactory : ICommandFactory
{
    public IFileSystemCommand Create(IList<string> positionalArguments, Dictionary<char, string> parameters)
    {
        return new DisconnectCommand();
    }
}