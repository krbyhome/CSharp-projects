using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ProccessorCoolingSystem : IComponent<ProccessorCoolingSystem>
{
    private readonly IList<string> _supportedSockets;

    public ProccessorCoolingSystem(
        string name,
        IEnumerable<string> sockets,
        Dimensions dimensions,
        int dissipatedHeat)
    {
        Name = name;
        _supportedSockets = sockets.ToList();
        Dimensions = dimensions;
        DissipatedHeat = dissipatedHeat;
    }

    private ProccessorCoolingSystem(ProccessorCoolingSystem other)
    {
        Name = other.Name;
        _supportedSockets = other.SupportedSockets.ToList();
        Dimensions = other.Dimensions;
        DissipatedHeat = other.DissipatedHeat;
    }

    public string Name { get; }
    public Dimensions Dimensions { get; }
    public int DissipatedHeat { get; }

    public IList<string> SupportedSockets => _supportedSockets.AsReadOnly();

    public ProccessorCoolingSystem Clone()
    {
        return new ProccessorCoolingSystem(this);
    }

    public ICoolerBuilder Direct(ICoolerBuilder builder)
    {
        builder.Reset();
        builder
            .WithName(Name)
            .WithDimensions(Dimensions)
            .WithDissipatedHeat(DissipatedHeat);

        foreach (string socket in _supportedSockets)
        {
            builder.AddSocket(socket);
        }

        return builder;
    }
}