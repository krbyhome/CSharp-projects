using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public abstract class PcValidatorBuilderBase : IPcValidatorBuilder
{
    private IList<IComponentValidator> _validators;

    protected PcValidatorBuilderBase()
    {
        _validators = new List<IComponentValidator>();
    }

    public IPcValidatorBuilder WithCpu()
    {
        _validators.Add(new CpuValidator());
        return this;
    }

    public IPcValidatorBuilder WithMotherBoard()
    {
        _validators.Add(new MotherBoardValidator());
        return this;
    }

    public IPcValidatorBuilder WithCoolingSystem()
    {
        _validators.Add(new CoolingSystemValidator());
        return this;
    }

    public IPcValidatorBuilder WithComputerCase()
    {
        _validators.Add(new ComputerCaseValidator());
        return this;
    }

    public IPcValidatorBuilder WithPowerUnit()
    {
        _validators.Add(new PowerUnitValidator());
        return this;
    }

    public IPcValidatorBuilder WithRam()
    {
        _validators.Add(new RamValidator());
        return this;
    }

    public IPcValidatorBuilder WithGraphics()
    {
        _validators.Add(new GpuValidator());
        return this;
    }

    public IPcValidatorBuilder WithDrive()
    {
        _validators.Add(new DrivesValidator());
        return this;
    }

    public IPcValidator Build()
    {
        return Create(_validators);
    }

    protected abstract IPcValidator Create(IList<IComponentValidator> validators);
}