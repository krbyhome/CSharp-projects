using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Extensions;

internal static class StringToConnectionModeExtension
{
    public static ConnectionMode ToConnectionMode(this string str)
    {
        switch (str)
        {
            case "local":
                return ConnectionMode.Local;
        }

        return ConnectionMode.Unknown;
    }
}