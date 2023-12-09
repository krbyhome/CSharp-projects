namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CpuValidator : IComponentValidator
{
    private const string BiosDoesNotMatchMessage = "Bios doesn't support processor\n";
    public ValidationResult Validate(PC computer)
    {
        if (!ValidateBios(computer.Motherboard, computer.Processor))
        {
            return new ValidationResult.Failure(BiosDoesNotMatchMessage);
        }

        return new ValidationResult.Success();
    }

    private static bool ValidateBios(MotherBoard? motherBoard, Cpu cpu)
    {
        return motherBoard is null || motherBoard.Bios.SupportedProcessors.Contains(cpu.Name);
    }
}