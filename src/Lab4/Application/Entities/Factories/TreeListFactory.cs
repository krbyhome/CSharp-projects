using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public class TreeListFactory : ICommandFactory
{
    public IFileSystemCommand Create(IList<string> positionalArguments, Dictionary<char, string> parameters)
     {
        return new TreeListCommand(Convert.ToInt32(parameters['d'], System.Globalization.CultureInfo.CurrentCulture.NumberFormat));
    }
}