namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IPcValidator
{
    public PcValidationResult Validate(PC computer);
}