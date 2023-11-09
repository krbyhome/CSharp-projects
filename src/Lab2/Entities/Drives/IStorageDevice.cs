namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IStorageDevice
{
    public int Capacity { get; }
    public ComputerEBus ConnectionOption { get; }
}