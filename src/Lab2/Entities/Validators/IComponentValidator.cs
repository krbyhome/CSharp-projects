namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IComponentValidator
{
    public ValidationResult Validate(PC computer);
}