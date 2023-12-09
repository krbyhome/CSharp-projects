using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IFittable
{
    public IReadOnlyList<int> Measures { get; }
}