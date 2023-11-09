using System;
using System.Collections.Generic;
namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

public class Repository<T> : IRepository<T>
    where T : IComponent<T>
{
    private readonly IDictionary<string, T> _components;

    public Repository()
    {
        _components = new Dictionary<string, T>();
    }

    public IDictionary<string, T> Values => _components.AsReadOnly();

    public void Add(T component)
    {
        _components.Add(component.Name, component);
    }

    public T? FindComponentByName(string name)
    {
        return Values.TryGetValue(name, out T? result) ? result : default;
    }

    public T GetComponentByName(string name)
    {
        if (Values.TryGetValue(name, out _) is false)
        {
            throw new ArgumentOutOfRangeException(nameof(name));
        }

        return Values[name];
    }
}