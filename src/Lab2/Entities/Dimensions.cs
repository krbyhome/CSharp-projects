using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Dimensions : IFittable
{
    private readonly List<int> _measures;

    public Dimensions(IEnumerable<int> measures)
    {
        _measures = measures.ToList();
    }

    public Dimensions(int x, int y, int z)
    {
        _measures = new List<int>
        {
            x,
            y,
            z,
        };
    }

    public IReadOnlyList<int> Measures => _measures;

    public bool Fits(IFittable slot)
    {
        var slotMeasures = slot.Measures.ToList();
        if (slotMeasures.Count != _measures.Count)
        {
            return false;
        }

        for (int i = 0; i < _measures.Count; ++i)
        {
            if (_measures[i] > slotMeasures[i])
            {
                return false;
            }
        }

        return true;
    }
}