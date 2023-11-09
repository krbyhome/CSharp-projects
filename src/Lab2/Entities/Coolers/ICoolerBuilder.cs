namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface ICoolerBuilder
{
    ICoolerBuilder WithName(string name);
    ICoolerBuilder WithDimensions(int length, int width, int height);
    ICoolerBuilder WithDimensions(Dimensions dimensions);
    ICoolerBuilder WithDissipatedHeat(int dissipatedHeat);
    ICoolerBuilder AddSocket(string socket);

    ProccessorCoolingSystem Build();
    void Reset();
}