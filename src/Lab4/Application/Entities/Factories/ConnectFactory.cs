using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Application.Extensions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public class ConnectFactory : ICommandFactory
{
    public IFileSystemCommand Create(IList<string> positionalArguments, Dictionary<char, string> parameters)
    {
        var mode = parameters['m'].ToConnectionMode();
        return new ConnectCommand(positionalArguments[0], mode);
    }
}