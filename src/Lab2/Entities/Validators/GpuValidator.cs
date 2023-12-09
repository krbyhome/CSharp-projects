namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class GpuValidator : IComponentValidator
{
    private const string GpuMissingMessage = "GPU is missing\n";
    public ValidationResult Validate(PC computer)
    {
        if (computer.Processor.HasVideoCore)
            return new ValidationResult.Success();

        if (computer.Graphics.Count == 0)
        {
            return new ValidationResult.Failure(GpuMissingMessage);
        }

        return new ValidationResult.Success();
    }
}