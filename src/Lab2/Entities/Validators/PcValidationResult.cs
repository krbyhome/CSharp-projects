namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract record PcValidationResult(string Message)
{
    internal sealed record Success(string Message) : PcValidationResult(Message);

    internal sealed record NoWarrantyObligations(string Message) : PcValidationResult(Message);

    internal sealed record Failure(string Message) : PcValidationResult(Message);
}