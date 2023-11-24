using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.ApplicationContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public class UnknownCommand : IFileSystemCommand
{
    public void Invoke(IApplicationContext context)
    {
    }
}