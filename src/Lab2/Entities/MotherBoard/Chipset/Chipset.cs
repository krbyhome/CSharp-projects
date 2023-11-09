using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public record Chipset(string Name,
    bool IsXmpCompatible,
    IReadOnlyList<double> AvailableFrequencies);