using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class FirstTestDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        RepositoryContext context = RepositoryFabric.Create();
        var pcBuilder = new PcBuilder();
        PC computer = pcBuilder
            .WithName("PC test1")
            .SetCpu(context.Processors.GetComponentByName("Ryzen"))
            .SetMotherBoard(context.Motherboards.GetComponentByName("AORUS B550"))
            .AddGraphics(context.GraphicsCards.GetComponentByName("RTX3080"))
            .SetComputerCase(context.Cases.GetComponentByName("default case"))
            .SetCoolingSystem(context.Coolers.GetComponentByName("GAMMAX 400"))
            .SetPowerUnit(context.PowerUnits.GetComponentByName("BeQuiet"))
            .AddRam(context.Memory.GetComponentByName("DDR4 ram"))
            .AddDrive(context.SolidDrives.GetComponentByName("samsung"))
            .Build();
        var validatorBuilder = new PcValidatorBuilder();
        IPcValidator validator = validatorBuilder
            .WithCpu()
            .WithGraphics()
            .WithMotherBoard()
            .WithCoolingSystem()
            .WithPowerUnit()
            .WithRam()
            .WithDrive()
            .WithComputerCase()
            .Build();
        yield return new object[]
        {
            computer,
            validator,
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}