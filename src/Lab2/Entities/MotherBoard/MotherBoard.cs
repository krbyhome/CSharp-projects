namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class MotherBoard : IComponent<MotherBoard>
{
    public MotherBoard(
        string name,
        string socket,
        int pcieNumber,
        int sataNumber,
        string supportedDdr,
        int ramSlotsNumber,
        Chipset chipset,
        string formFactor,
        Bios bios)
    {
        Name = name;
        Socket = socket;
        PCIeNumber = pcieNumber;
        SataNumber = sataNumber;
        SupportedDdr = supportedDdr;
        RamSlotsNumber = ramSlotsNumber;
        Chipset = chipset;
        FormFactor = formFactor;
        Bios = bios;
    }

    public MotherBoard(MotherBoard other)
    {
        Name = other.Name;
        Socket = other.Socket;
        PCIeNumber = other.PCIeNumber;
        SataNumber = other.SataNumber;
        SupportedDdr = other.SupportedDdr;
        RamSlotsNumber = other.RamSlotsNumber;
        Chipset = other.Chipset;
        FormFactor = other.FormFactor;
        Bios = other.Bios;
    }

    public string Name { get; }
    public string Socket { get; }
    public int PCIeNumber { get; }
    public int SataNumber { get; }
    public string SupportedDdr { get; }
    public int RamSlotsNumber { get; }
    public Chipset Chipset { get; }
    public string FormFactor { get; }
    public Bios Bios { get; }

    public MotherBoard Clone()
    {
        return new MotherBoard(this);
    }

    public IMotherBoardBuilder Direct(IMotherBoardBuilder builder)
    {
        builder.Reset();
        builder
            .WithName(Name)
            .WithSocket(Socket)
            .WithPciSlots(PCIeNumber)
            .WithSataSlots(SataNumber)
            .WithDdrType(SupportedDdr)
            .WithRamSlots(RamSlotsNumber)
            .WithChipset(Chipset)
            .WithFormFactor(FormFactor)
            .WithBios(Bios);
        return builder;
    }
}