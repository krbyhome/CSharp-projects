using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerCaseValidator : IComponentValidator
{
    private const string UnsupportedFormfactorMessage = "Case doesn't support motherboard's formfactor\n";
    private const string GpuDoesNotFitMessage = "Gpu doesn't fit in case\n";
    public ValidationResult Validate(PC computer)
    {
        var message = new StringBuilder();
        if (!ValidateMotherBoard(computer.Motherboard, computer.Case))
        {
            message.Append(UnsupportedFormfactorMessage);
        }

        if (!ValidateGpu(computer.Graphics, computer.Case))
        {
            message.Append(GpuDoesNotFitMessage);
        }

        string messageString = message.ToString();

        return messageString.Length == 0
            ? new ValidationResult.Success()
            : new ValidationResult.Failure(messageString);
    }

    private static bool ValidateGpu(IEnumerable<Gpu> graphics, ComputerCase computerCase)
    {
        return graphics.All(gpu => gpu.Length <= computerCase.MaxGpuLength && gpu.Width <= computerCase.MaxGpuWidth);
    }

    private static bool ValidateMotherBoard(MotherBoard motherboard, ComputerCase computerCase)
    {
        return computerCase.SupportedFormfactors.Contains(motherboard.FormFactor);
    }
}