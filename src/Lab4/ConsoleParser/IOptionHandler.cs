using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.ConsoleParser;

public interface IOptionHandler
{
    IFileSystemCommand HandleOption(IList<string> input);
}