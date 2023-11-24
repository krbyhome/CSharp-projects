using System;
using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.Drawers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Extensions;

internal static class StringToOutputModeExtension
{
    public static IDrawer ToOutputMode(this string str)
    {
        switch (str)
        {
            case "console":
                return new ConsoleDrawer();
        }

        throw new ArgumentException($"{str} drawer is not implemented");
    }
}