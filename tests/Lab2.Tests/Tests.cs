using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Tests
{
    [Theory]
    [ClassData(typeof(FirstTestDataGenerator))]
    public void ComputerWithRyzenWithRtx3080WithMotherboardB550ShouldBeSuccessfulValidation(
        PC computer,
        IPcValidator validator)
    {
        PcValidationResult result = validator.Validate(computer);
        Assert.IsType<PcValidationResult.Success>(result);
    }

    [Theory]
    [ClassData(typeof(SecondTestDataGenerator))]
    public void ComputerWithIntelCoreAndRtx3080WithPowerlessPowerUnitShouldBeWarning(
        PC computer,
        IPcValidator validator)
    {
        PcValidationResult result = validator.Validate(computer);
        Assert.IsType<PcValidationResult.NoWarrantyObligations>(result);
    }

    [Theory]
    [ClassData(typeof(ThirdTestClassDataGenerator))]
    public void ComputerWithPowerlessCoolerShouldBeWarning(
        PC computer,
        IPcValidator validator)
    {
        PcValidationResult result = validator.Validate(computer);
        Assert.IsType<PcValidationResult.NoWarrantyObligations>(result);
        Assert.True(result.Message == "Coolers couldn't manage tdp\n");
    }

    [Theory]
    [ClassData(typeof(FourthTestClassDataGenerator))]
    public void ComputerWithIntelCpuWithAmdMotherboardWithIntelCoolerWithPowerlessPowerUnitWithUnsupprotedDdrTypeWithLackOfPcieSlotsShouldBeFailure(
        PC computer,
        IPcValidator validator,
        string expectedMessage)
    {
        PcValidationResult result = validator.Validate(computer);
        Assert.IsType<PcValidationResult.Failure>(result);
        Assert.Equal(expectedMessage, result.Message);
    }
}