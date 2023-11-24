using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.ApplicationContext;
namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public class TreeListCommand : IFileSystemCommand
{
    public TreeListCommand(int depth)
    {
        Depth = depth;
    }

    public int Depth { get; }

    public void Invoke(IApplicationContext context)
    {
        context.TreeList(Depth);
    }
}