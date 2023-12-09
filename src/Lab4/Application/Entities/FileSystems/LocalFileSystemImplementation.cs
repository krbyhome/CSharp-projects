using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Application.Entities.Drawers;
using Itmo.ObjectOrientedProgramming.Lab4.Application.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public class LocalFileSystemImplementation : IFileSystemImplemetation
{
    private string _path;

    public LocalFileSystemImplementation(string path)
    {
        _path = path;
    }

    public void TreeGoto(string path, IDrawer drawer)
    {
        if (Directory.Exists(Path.GetFullPath(path, _path)) ||
            File.Exists(Path.GetFullPath(path, _path)))
            _path = Path.GetFullPath(path, _path);
        drawer.WriteLine(_path);
    }

    public void TreeList(int depth, IDrawer drawer)
    {
        if (File.Exists(_path))
        {
            drawer.WriteFileInTree(_path, 0);
            return;
        }

        TreeList(_path, 0, depth, drawer);
    }

    public void FileShow(string path, IDrawer drawer)
    {
        string absolutePath = Path.GetFullPath(path, _path);
        if (!File.Exists(absolutePath))
        {
            throw new FileSystemException($"File {path} does not exist.");
        }

        using var reader = new StreamReader(absolutePath);

        string? line;
        while ((line = reader.ReadLine()) is not null)
        {
            drawer.WriteLine(line);
        }
    }

    public void FileMove(string source, string destination)
    {
        string absoluteSourcePath = Path.GetFullPath(source, _path);
        string absoluteDestPath = Path.GetFullPath(destination, _path);

        if (!File.Exists(absoluteSourcePath))
        {
            throw new FileSystemException($"file {source} do not exist");
        }

        File.Move(absoluteSourcePath, absoluteDestPath);
    }

    public void FileCopy(string source, string destination)
    {
        string absoluteSourcePath = Path.GetFullPath(source, _path);
        string absoluteDestPath = Path.GetFullPath(destination, _path);

        if (!File.Exists(absoluteSourcePath))
        {
            throw new FileSystemException($"file {source} do not exist");
        }

        File.Copy(
            absoluteSourcePath,
            absoluteDestPath,
            overwrite: false);
    }

    public void FileDelete(string path)
    {
        string absolutePath = Path.GetFullPath(path, _path);
        if (!File.Exists(absolutePath))
        {
            throw new FileSystemException($"file {path} do not exist");
        }

        File.Delete(absolutePath);
    }

    public void FileRename(string path, string name)
    {
        if (Path.IsPathRooted(path))
        {
            throw new FileSystemException($"Could not rename {path} file");
        }

        string absolutePath = Path.GetFullPath(path, _path);
        if (!File.Exists(absolutePath))
        {
            throw new FileSystemException($"file {absolutePath} do not exist");
        }

        string directory = absolutePath[..absolutePath.LastIndexOf('\\')];
        string newAbsolutePath = Path.GetFullPath(name, directory);
        File.Move(
            absolutePath,
            newAbsolutePath,
            overwrite: false);
    }

    private static void TreeFileDraw(string currentPath, int currentDepth, int depth, IDrawer drawer)
    {
        if (currentDepth > depth)
            return;

        drawer.WriteFileInTree(currentPath, currentDepth);
    }

    private void TreeList(string currentPath, int currentDepth, int depth, IDrawer drawer)
    {
        if (currentDepth > depth)
            return;

        drawer.WriteFolderInTree(currentPath, currentDepth);

        string[] files = Directory.GetFiles(currentPath);
        foreach (string fileName in files)
        {
            TreeFileDraw(fileName, currentDepth + 1, depth, drawer);
        }

        string[] folders = Directory.GetDirectories(currentPath);
        foreach (string folder in folders)
        {
            TreeList(folder, currentDepth + 1, depth, drawer);
        }
    }
}