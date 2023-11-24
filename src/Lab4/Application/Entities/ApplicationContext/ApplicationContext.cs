using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.Drawers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.ApplicationContext;

public class ApplicationContext : IApplicationContext
{
    private IApplicationState _applicationState;

    public ApplicationContext()
    {
        _applicationState = new DisconnectedApplication(this);
    }

    public void ChangeState(IApplicationState state)
    {
        _applicationState = state;
    }

    public void Connect(string path, ConnectionMode mode)
    {
        _applicationState.Connect(path, mode);
    }

    public void Disconnect()
    {
        _applicationState.Disconnect();
    }

    public void TreeGoto(string path)
    {
        _applicationState.TreeGoto(path);
    }

    public void TreeList(int depth)
    {
        _applicationState.TreeList(depth);
    }

    public void FileShow(string path, IDrawer drawer)
    {
        _applicationState.FileShow(path, drawer);
    }

    public void FileMove(string source, string destination)
    {
        _applicationState.FileMove(source, destination);
    }

    public void FileCopy(string source, string destination)
    {
        _applicationState.FileCopy(source, destination);
    }

    public void FileDelete(string path)
    {
        _applicationState.FileDelete(path);
    }

    public void FileRename(string path, string name)
    {
        _applicationState.FileRename(path, name);
    }

    public void SetTreeOutputStyle(char fileChar, char folderChar)
    {
        _applicationState.SetTreeOutputStyle(fileChar, folderChar);
    }
}