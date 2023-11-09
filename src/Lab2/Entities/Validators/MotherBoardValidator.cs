namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class MotherBoardValidator : IComponentValidator
{
    private const string ProcessorRequiresAnotherSocketMessage = "Processor requires another socket\n";
    public ValidationResult Validate(PC computer)
    {
        if (computer.Processor.Socket != computer.Motherboard.Socket)
        {
            return new ValidationResult.Failure(ProcessorRequiresAnotherSocketMessage);
        }

        return new ValidationResult.Success();
    }
}