namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IMotherBoardBuilder
{
    IMotherBoardBuilder WithName(string name);
    IMotherBoardBuilder WithSocket(string socket);
    IMotherBoardBuilder WithPciSlots(int number);
    IMotherBoardBuilder WithSataSlots(int number);
    IMotherBoardBuilder WithDdrType(string supportedDdr);
    IMotherBoardBuilder WithRamSlots(int number);
    IMotherBoardBuilder WithChipset(Chipset chipset);
    IMotherBoardBuilder WithFormFactor(string name);
    IMotherBoardBuilder WithBios(Bios bios);

    MotherBoard Build();
    void Reset();
}