using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.ApplicationContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public class FileRenameCommand : IFileSystemCommand
{
    public FileRenameCommand(string path, string name)
    {
        Path = path;
        Name = name;
    }

    public string Path { get; }
    public string Name { get; }

    public void Invoke(IApplicationContext context)
    {
        context.FileRename(Path, Name);
    }
}