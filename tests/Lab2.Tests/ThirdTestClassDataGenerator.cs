using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ThirdTestClassDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        RepositoryContext context = RepositoryFabric.Create();
        var pcBuilder = new PcBuilder();
        PC pcWithWarning = pcBuilder
            .WithName("pc with powerless cooler")
            .SetCpu(context.Processors.GetComponentByName("Intel"))
            .SetMotherBoard(context.Motherboards.GetComponentByName("TOMAHAWK Z690"))
            .AddGraphics(context.GraphicsCards.GetComponentByName("RTX3080 Ti"))
            .SetComputerCase(context.Cases.GetComponentByName("default case"))
            .SetCoolingSystem(context.Coolers.GetComponentByName("powerless"))
            .SetPowerUnit(context.PowerUnits.GetComponentByName("BeQuiet"))
            .AddRam(context.Memory.GetComponentByName("DDR5 ram"))
            .AddDrive(context.SolidDrives.GetComponentByName("samsung"))
            .Build();

        var validatorBuilder = new PcValidatorBuilder();
        IPcValidator pcValidator = validatorBuilder
            .WithCpu()
            .WithMotherBoard()
            .WithGraphics()
            .WithComputerCase()
            .WithCoolingSystem()
            .WithPowerUnit()
            .WithRam()
            .WithDrive()
            .Build();
        yield return new object[]
        {
            pcWithWarning,
            pcValidator,
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}