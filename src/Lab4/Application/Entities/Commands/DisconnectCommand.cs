using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.ApplicationContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public class DisconnectCommand : IFileSystemCommand
{
    public void Invoke(IApplicationContext context)
    {
        context.Disconnect();
    }
}