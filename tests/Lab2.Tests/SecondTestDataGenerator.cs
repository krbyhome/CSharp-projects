using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class SecondTestDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        RepositoryContext context = RepositoryFabric.Create();
        var pcBuilder = new PcBuilder();
        PC pcWithNoWarranty = pcBuilder
            .WithName("pc with powerless power unit")
            .SetCpu(context.Processors.GetComponentByName("Intel"))
            .SetMotherBoard(context.Motherboards.GetComponentByName("TOMAHAWK Z690"))
            .AddGraphics(context.GraphicsCards.GetComponentByName("RTX3080 Ti"))
            .SetComputerCase(context.Cases.GetComponentByName("default case"))
            .SetCoolingSystem(context.Coolers.GetComponentByName("GAMMAX 400"))
            .SetPowerUnit(context.PowerUnits.GetComponentByName("Aerocool KCAS"))
            .AddRam(context.Memory.GetComponentByName("DDR5 ram"))
            .AddDrive(context.SolidDrives.GetComponentByName("samsung"))
            .Build();
        var validatorBuilder = new PcValidatorBuilder();
        IPcValidator pcValidator = validatorBuilder
            .WithCpu()
            .WithMotherBoard()
            .WithGraphics()
            .WithComputerCase()
            .WithComputerCase()
            .WithCoolingSystem()
            .WithPowerUnit()
            .WithRam()
            .WithDrive()
            .Build();
        yield return new object[]
        {
            pcWithNoWarranty,
            pcValidator,
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}