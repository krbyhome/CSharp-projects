using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.ApplicationContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public class FileCopyCommand : IFileSystemCommand
{
    public FileCopyCommand(string source, string destination)
    {
        SourcePath = source;
        DestinationPath = destination;
    }

    public string SourcePath { get; }
    public string DestinationPath { get; }

    public void Invoke(IApplicationContext context)
    {
        context.FileCopy(SourcePath, DestinationPath);
    }
}