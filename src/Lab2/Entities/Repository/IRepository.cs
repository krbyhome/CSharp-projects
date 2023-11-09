using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

public interface IRepository<T>
    where T : IComponent<T>
{
    IDictionary<string, T> Values { get; }

    public void Add(T component);
    public T? FindComponentByName(string name);
    public T GetComponentByName(string name);
}