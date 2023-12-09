namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract record ValidationResult
{
    internal sealed record Success() : ValidationResult;

    internal sealed record Warning(string Message) : ValidationResult;

    internal sealed record Failure(string Message) : ValidationResult;
}