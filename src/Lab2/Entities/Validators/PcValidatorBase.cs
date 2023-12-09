using System.Collections.Generic;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract class PcValidatorBase : IPcValidator
{
    private readonly IList<IComponentValidator> _validators;
    private readonly IList<ValidationResult> _validationResults;

    protected PcValidatorBase()
    {
        _validators = new List<IComponentValidator>();
        _validationResults = new List<ValidationResult>();
    }

    protected PcValidatorBase(IList<IComponentValidator> validators)
    {
        _validators = validators;
        _validationResults = new List<ValidationResult>();
    }

    public PcValidationResult Validate(PC computer)
    {
        foreach (IComponentValidator validator in _validators)
        {
            _validationResults.Add(validator.Validate(computer));
        }

        var message = new StringBuilder();
        bool isWarning = false;
        bool isFailure = false;
        foreach (ValidationResult result in _validationResults)
        {
            switch (result)
            {
                case ValidationResult.Warning warning:
                    isWarning = true;
                    message.Append(warning.Message);
                    continue;
                case ValidationResult.Failure failure:
                    isFailure = true;
                    message.Append(failure.Message);
                    continue;
            }
        }

        if (isFailure)
        {
            return new PcValidationResult.Failure(message.ToString());
        }

        if (isWarning)
        {
            return new PcValidationResult.NoWarrantyObligations(message.ToString());
        }

        return new PcValidationResult.Success("Good choice!");
    }
}