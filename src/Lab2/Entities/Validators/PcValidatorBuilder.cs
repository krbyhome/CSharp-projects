using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PcValidatorBuilder : PcValidatorBuilderBase
{
    protected override IPcValidator Create(IList<IComponentValidator> validators)
    {
        return new PcValidator(validators);
    }
}