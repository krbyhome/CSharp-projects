namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class MotherBoardBuilder : MotherBoardBuilderBase
{
    public MotherBoardBuilder(MotherBoard prototype)
    : base(prototype)
    {
    }

    public MotherBoardBuilder()
    : base()
    {
    }

    protected override MotherBoard Create(
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
        return new MotherBoard(
            name,
            socket,
            pcieNumber,
            sataNumber,
            supportedDdr,
            ramSlotsNumber,
            chipset,
            formFactor,
            bios);
    }
}