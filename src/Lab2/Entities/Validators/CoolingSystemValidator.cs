namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CoolingSystemValidator : IComponentValidator
{
    private const string CoolersCouldNotManageMessage = "Coolers couldn't manage tdp\n";
    private const string CoolersSocketInvalidMessage = "Cooler socket is invalid\n";
    public ValidationResult Validate(PC computer)
    {
        if (!ValidateSocket(computer.Motherboard, computer.CoolingSystem))
        {
            return new ValidationResult.Failure(CoolersSocketInvalidMessage);
        }

        if (!ValidateCpu(computer.Processor, computer.CoolingSystem))
        {
            return new ValidationResult.Warning(CoolersCouldNotManageMessage);
        }

        return new ValidationResult.Success();
    }

    private static bool ValidateCpu(Cpu cpu, ProccessorCoolingSystem cooler)
    {
        return cpu.PowerConsumption < cooler.DissipatedHeat;
    }

    private static bool ValidateSocket(MotherBoard? motherBoard, ProccessorCoolingSystem cooler)
    {
        return motherBoard is null || cooler.SupportedSockets.Contains(motherBoard.Socket);
    }
}