using System;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.Drawers;

public class ConsoleDrawer : IDrawer
{
    public char FileChar { get; set; } = '-';
    public char FolderChar { get; set; } = '#';

    public void Write(string content)
    {
        Console.Write(content);
    }

    public void WriteLine(string content)
    {
        Console.WriteLine(content);
    }

    public void WriteFileInTree(string path, int depth)
    {
        var builder = new StringBuilder();
        builder.Append(' ', depth);
        builder.Append(FileChar);
        builder.Append(path[(path.LastIndexOf('\\') + 1)..]);
        WriteLine(builder.ToString());
    }

    public void WriteFolderInTree(string path, int depth)
    {
        var builder = new StringBuilder();
        builder.Append(' ', depth);
        builder.Append(FolderChar);
        builder.Append(path[(path.LastIndexOf('\\') + 1)..]);
        WriteLine(builder.ToString());
    }
}