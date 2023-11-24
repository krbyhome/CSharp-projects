using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public interface ICommandFactory
{
    IFileSystemCommand Create(IList<string> positionalArguments, Dictionary<char, string> parameters);
}