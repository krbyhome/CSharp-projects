using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.ApplicationContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public class TreeGotoCommand : IFileSystemCommand
{
    public TreeGotoCommand(string path)
    {
        Path = path;
    }

    public string Path { get; }

    public void Invoke(IApplicationContext context)
    {
        context.TreeGoto(Path);
    }
}