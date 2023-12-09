using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.ApplicationContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public class ConnectCommand : IFileSystemCommand
{
    public ConnectCommand(string address, ConnectionMode mode)
    {
        Mode = mode;
        Address = address;
    }

    public string Address { get; }
    public ConnectionMode Mode { get; }

    public void Invoke(IApplicationContext context)
    {
        context.Connect(Address, Mode);
    }
}