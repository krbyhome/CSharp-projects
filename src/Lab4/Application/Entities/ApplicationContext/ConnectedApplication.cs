using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.Drawers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.ApplicationContext;

public class ConnectedApplication : IApplicationState
{
    private IApplicationContext _context;
    private IFileSystemImplemetation _fileSystem;
    private IDrawer _drawer;

    public ConnectedApplication(IApplicationContext context, IFileSystemImplemetation fileSystem)
    {
        _context = context;
        _drawer = new ConsoleDrawer();
        _fileSystem = fileSystem;
    }

    public ConnectedApplication(IApplicationContext context, IDrawer drawer, IFileSystemImplemetation fileSystem)
    {
        _context = context;
        _drawer = drawer;
        _fileSystem = fileSystem;
    }

    public void Connect(string path, ConnectionMode mode)
    {
        var fileSystemFactory = new FileSystemFactory();
        _fileSystem = fileSystemFactory.Create(mode, path);
    }

    public void Disconnect()
    {
        _context.ChangeState(new DisconnectedApplication(_context));
    }

    public void TreeGoto(string path)
    {
        _fileSystem.TreeGoto(path, _drawer);
    }

    public void TreeList(int depth)
    {
        _fileSystem.TreeList(depth, _drawer);
    }

    public void FileShow(string path, IDrawer drawer)
    {
        _fileSystem.FileShow(path, drawer);
    }

    public void FileMove(string source, string destination)
    {
        _fileSystem.FileMove(source, destination);
        _drawer.WriteLine($"{source} file moved to {destination}");
    }

    public void FileCopy(string source, string destination)
    {
        _fileSystem.FileCopy(source, destination);
        _drawer.WriteLine($"{source} moved to {destination}");
    }

    public void FileDelete(string path)
    {
        _fileSystem.FileDelete(path);
        _drawer.WriteLine($"{path} deleted");
    }

    public void FileRename(string path, string name)
    {
        _fileSystem.FileRename(path, name);
        _drawer.WriteLine($"{path} changed name to {name}");
    }

    public void SetTreeOutputStyle(char fileChar, char folderChar)
    {
        _drawer.FileChar = fileChar;
        _drawer.FolderChar = folderChar;
        _drawer.WriteLine($"folder: {_drawer.FolderChar}\nfile: {_drawer.FileChar}");
    }
}