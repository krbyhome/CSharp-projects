using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PowerUnitValidator : IComponentValidator
{
    private const string LackOfPowerMessage = "Warning: perhaps, power unit could not handle with load\n";
    public ValidationResult Validate(PC computer)
    {
        int totalConsumption = 0;
        totalConsumption += computer.Processor.PowerConsumption;

        totalConsumption += computer.Graphics.Sum(gpu => gpu.PowerConsumption);

        return totalConsumption <= computer.PowerUnit.PeakLoad
            ? new ValidationResult.Success()
            : new ValidationResult.Warning(LackOfPowerMessage);
    }
}