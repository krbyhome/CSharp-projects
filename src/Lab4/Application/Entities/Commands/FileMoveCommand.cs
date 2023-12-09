using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.ApplicationContext;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public class FileMoveCommand : IFileSystemCommand
{
    public FileMoveCommand(string source, string destination)
    {
        SourcePath = source;
        DestinationPath = destination;
    }

    public string SourcePath { get; }
    public string DestinationPath { get; }

    public void Invoke(IApplicationContext context)
    {
        context.FileMove(SourcePath, DestinationPath);
    }
}