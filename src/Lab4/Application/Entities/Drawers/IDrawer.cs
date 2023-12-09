namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.Drawers;

public interface IDrawer
{
    char FileChar { get; set; }
    char FolderChar { get; set; }
    void Write(string content);
    void WriteLine(string content);
    void WriteFileInTree(string path, int depth);
    void WriteFolderInTree(string path, int depth);
}