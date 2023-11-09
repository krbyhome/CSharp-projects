namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IPcBuilder
{
    IPcBuilder WithName(string name);
    IPcBuilder SetCpu(Cpu processor);
    IPcBuilder SetMotherBoard(MotherBoard motherboard);
    IPcBuilder SetCoolingSystem(ProccessorCoolingSystem cooler);
    IPcBuilder SetComputerCase(ComputerCase computerCase);
    IPcBuilder SetPowerUnit(PowerUnit powerUnit);
    IPcBuilder AddRam(Ram ram);
    IPcBuilder AddGraphics(Gpu gpu);
    IPcBuilder AddDrive(IStorageDevice drive);
    IPcBuilder SetWifiAdapter(WifiAdapter wifiAdapter);

    PC Build();
    void Reset();
}