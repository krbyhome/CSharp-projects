using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.ApplicationContext;
using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.Drawers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public class FileShowCommand : IFileSystemCommand
{
    public FileShowCommand(string path, IDrawer drawer)
    {
        Path = path;
        Drawer = drawer;
    }

    public string Path { get; }
    public IDrawer Drawer { get; }

    public void Invoke(IApplicationContext context)
    {
        context.FileShow(Path, Drawer);
    }
}