using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.Drawers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public interface IFileSystemImplemetation
{
    void TreeGoto(string path, IDrawer drawer);
    void TreeList(int depth, IDrawer drawer);
    void FileShow(string path, IDrawer drawer);
    void FileMove(string source, string destination);
    void FileCopy(string source, string destination);
    void FileDelete(string path);
    void FileRename(string path, string name);
}