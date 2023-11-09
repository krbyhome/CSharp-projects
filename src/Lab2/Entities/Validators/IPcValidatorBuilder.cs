namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IPcValidatorBuilder
{
    IPcValidatorBuilder WithCpu();
    IPcValidatorBuilder WithMotherBoard();
    IPcValidatorBuilder WithCoolingSystem();
    IPcValidatorBuilder WithComputerCase();
    IPcValidatorBuilder WithPowerUnit();
    IPcValidatorBuilder WithRam();
    IPcValidatorBuilder WithGraphics();
    IPcValidatorBuilder WithDrive();

    IPcValidator Build();
}