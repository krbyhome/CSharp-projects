using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public class FileSystemFactory : IFileSystemFactory
{
    public IFileSystemImplemetation Create(ConnectionMode mode, string path)
    {
        switch (mode)
        {
            case ConnectionMode.Local:
                return new LocalFileSystemImplementation(path);
        }

        throw new ArgumentException("Unkown FileSystem Mode");
    }
}