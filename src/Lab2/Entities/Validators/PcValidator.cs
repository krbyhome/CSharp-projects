using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PcValidator : PcValidatorBase
{
    public PcValidator(IList<IComponentValidator> validators)
        : base(validators)
    {
    }
}