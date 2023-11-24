using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.Drawers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.ApplicationContext;

public class DisconnectedApplication : IApplicationState
{
    private IApplicationContext _context;

    public DisconnectedApplication(IApplicationContext context)
    {
        _context = context;
    }

    public void Connect(string path, ConnectionMode mode)
    {
        var fsFactory = new FileSystemFactory();
        _context.ChangeState(new ConnectedApplication(_context, fsFactory.Create(mode, path)));
    }

    public void Disconnect()
    {
    }

    public void TreeGoto(string path)
    {
    }

    public void TreeList(int depth)
    {
    }

    public void FileShow(string path, IDrawer drawer)
    {
    }

    public void FileMove(string source, string destination)
    {
    }

    public void FileCopy(string source, string destination)
    {
    }

    public void FileDelete(string path)
    {
    }

    public void FileRename(string path, string name)
    {
    }

    public void SetTreeOutputStyle(char fileChar, char folderChar)
    {
    }
}