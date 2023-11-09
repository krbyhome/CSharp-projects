namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IComponent<out T>
    where T : IComponent<T>
{
    string Name { get; }
    T Clone();
}