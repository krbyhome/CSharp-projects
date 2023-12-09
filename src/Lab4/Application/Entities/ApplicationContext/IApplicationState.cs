using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.Drawers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.ApplicationContext;

public interface IApplicationState
{
    void Connect(string path, ConnectionMode mode);
    void Disconnect();
    void TreeGoto(string path);
    void TreeList(int depth);
    void FileShow(string path, IDrawer drawer);
    void FileMove(string source, string destination);
    void FileCopy(string source, string destination);
    void FileDelete(string path);
    void FileRename(string path, string name);

    void SetTreeOutputStyle(char fileChar, char folderChar);
}