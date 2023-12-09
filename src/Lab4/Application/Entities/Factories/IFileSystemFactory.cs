namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Entities;

public interface IFileSystemFactory
{
    IFileSystemImplemetation Create(ConnectionMode mode, string path);
}