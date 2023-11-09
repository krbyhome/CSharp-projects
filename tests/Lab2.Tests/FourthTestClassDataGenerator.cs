using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class FourthTestClassDataGenerator : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        RepositoryContext context = RepositoryFabric.Create();
        var pcBuilder = new PcBuilder();
        PC pcWithSetOfFails = pcBuilder
            .WithName("pc with powerless cooler")
            .SetCpu(context.Processors.GetComponentByName("Intel"))
            .SetMotherBoard(context.Motherboards.GetComponentByName("AORUS B550"))
            .AddGraphics(context.GraphicsCards.GetComponentByName("RTX3080 Ti"))
            .SetComputerCase(context.Cases.GetComponentByName("default case"))
            .SetCoolingSystem(context.Coolers.GetComponentByName("powerless"))
            .SetPowerUnit(context.PowerUnits.GetComponentByName("Aerocool KCAS"))
            .AddRam(context.Memory.GetComponentByName("DDR5 ram"))
            .AddDrive(context.SolidDrives.GetComponentByName("samsung"))
            .AddDrive(context.SolidDrives.GetComponentByName("samsung"))
            .AddDrive(context.SolidDrives.GetComponentByName("samsung"))
            .AddDrive(context.SolidDrives.GetComponentByName("samsung"))
            .AddDrive(context.SolidDrives.GetComponentByName("samsung"))
            .AddDrive(context.SolidDrives.GetComponentByName("samsung"))
            .Build();

        var validatorBuilder = new PcValidatorBuilder();
        IPcValidator validator = validatorBuilder
            .WithCpu()
            .WithMotherBoard()
            .WithGraphics()
            .WithComputerCase()
            .WithCoolingSystem()
            .WithPowerUnit()
            .WithRam()
            .WithDrive()
            .Build();
        const string expectedMessage = "Processor requires another socket\nCooler socket is invalid\nWarning: perhaps, power unit could not handle with load\nDdr version is not supported\nMore pcie slots required\n";
        yield return new object[]
        {
            pcWithSetOfFails,
            validator,
            expectedMessage,
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}