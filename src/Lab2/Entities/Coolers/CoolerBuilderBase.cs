using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract class CoolerBuilderBase : ICoolerBuilder
{
    private readonly IList<string> _sockets;
    private string? _name;
    private Dimensions? _dimensions;
    private int? _dissipatedHeat;

    protected CoolerBuilderBase()
    {
        _sockets = new List<string>();
    }

    public ICoolerBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ICoolerBuilder WithDimensions(int length, int width, int height)
    {
        _dimensions = new Dimensions(length, width, height);
        return this;
    }

    public ICoolerBuilder WithDimensions(Dimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public ICoolerBuilder WithDissipatedHeat(int dissipatedHeat)
    {
        _dissipatedHeat = dissipatedHeat;
        return this;
    }

    public ICoolerBuilder AddSocket(string socket)
    {
        _sockets.Add(socket);
        return this;
    }

    public ProccessorCoolingSystem Build()
    {
        return Create(
            _name ?? "undefined",
            _dimensions ?? new Dimensions(50, 50, 40),
            _dissipatedHeat ?? throw new ArgumentNullException(nameof(_dissipatedHeat)),
            _sockets);
    }

    public void Reset()
    {
        _name = null;
        _dimensions = null;
        _dissipatedHeat = null;
        _sockets.Clear();
    }

    protected abstract ProccessorCoolingSystem Create(
        string name,
        Dimensions dimensions,
        int dissipatedHeat,
        IList<string> sockets);
}