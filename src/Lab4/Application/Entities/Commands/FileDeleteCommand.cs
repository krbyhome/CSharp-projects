using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.ApplicationContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public class FileDeleteCommand : IFileSystemCommand
{
    public FileDeleteCommand(string path)
    {
        Path = path;
    }

    public string Path { get; }

    public void Invoke(IApplicationContext context)
    {
        context.FileDelete(Path);
    }
}