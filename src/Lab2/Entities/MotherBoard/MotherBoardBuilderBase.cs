using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract class MotherBoardBuilderBase : IMotherBoardBuilder
{
    private string? _name;
    private string? _socket;
    private int? _pcieNumber;
    private int? _sataNumber;
    private string? _supportedDdr;
    private int? _ramSlotsNumber;
    private Chipset? _chipset;
    private string? _formFactor;
    private Bios? _bios;

    protected MotherBoardBuilderBase(MotherBoard prototype)
    {
        _name = prototype.Name;
        _socket = prototype.Socket;
        _pcieNumber = prototype.PCIeNumber;
        _sataNumber = prototype.SataNumber;
        _supportedDdr = prototype.SupportedDdr;
        _ramSlotsNumber = prototype.RamSlotsNumber;
        _chipset = prototype.Chipset;
        _formFactor = prototype.FormFactor;
        _bios = prototype.Bios;
    }

    protected MotherBoardBuilderBase()
    {
    }

    public IMotherBoardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IMotherBoardBuilder WithSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public IMotherBoardBuilder WithPciSlots(int number)
    {
        _pcieNumber = number;
        return this;
    }

    public IMotherBoardBuilder WithSataSlots(int number)
    {
        _sataNumber = number;
        return this;
    }

    public IMotherBoardBuilder WithDdrType(string supportedDdr)
    {
        _supportedDdr = supportedDdr;
        return this;
    }

    public IMotherBoardBuilder WithRamSlots(int number)
    {
        _ramSlotsNumber = number;
        return this;
    }

    public IMotherBoardBuilder WithChipset(Chipset chipset)
    {
        _chipset = chipset;
        return this;
    }

    public IMotherBoardBuilder WithFormFactor(string name)
    {
        _formFactor = name;
        return this;
    }

    public IMotherBoardBuilder WithBios(Bios bios)
    {
        _bios = bios;
        return this;
    }

    public MotherBoard Build()
    {
        return Create(
            _name ?? "undefined",
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _pcieNumber ?? 2,
            _sataNumber ?? 2,
            _supportedDdr ?? throw new ArgumentNullException(nameof(_supportedDdr)),
            _ramSlotsNumber ?? 2,
            _chipset ?? throw new ArgumentNullException(nameof(_chipset)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _bios ?? throw new ArgumentNullException(nameof(_bios)));
    }

    public void Reset()
    {
        _name = null;
        _socket = null;
        _pcieNumber = null;
        _sataNumber = null;
        _supportedDdr = null;
        _ramSlotsNumber = null;
        _chipset = null;
        _formFactor = null;
        _bios = null;
    }

    protected abstract MotherBoard Create(
        string name,
        string socket,
        int pcieNumber,
        int sataNumber,
        string supportedDdr,
        int ramSlotsNumber,
        Chipset chipset,
        string formFactor,
        Bios bios);
}