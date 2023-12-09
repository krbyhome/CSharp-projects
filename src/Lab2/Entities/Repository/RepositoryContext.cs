namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

public record RepositoryContext(
    IRepository<Gpu> GraphicsCards,
    IRepository<Cpu> Processors,
    IRepository<MotherBoard> Motherboards,
    IRepository<ComputerCase> Cases,
    IRepository<Ram> Memory,
    IRepository<Ssd> SolidDrives,
    IRepository<Hdd> HardDrives,
    IRepository<PowerUnit> PowerUnits,
    IRepository<ProccessorCoolingSystem> Coolers,
    IRepository<WifiAdapter> WifiAdapters)
{
    public RepositoryContext()
     : this(new RepositoryContext(
         new Repository<Gpu>(),
         new Repository<Cpu>(),
         new Repository<MotherBoard>(),
         new Repository<ComputerCase>(),
         new Repository<Ram>(),
         new Repository<Ssd>(),
         new Repository<Hdd>(),
         new Repository<PowerUnit>(),
         new Repository<ProccessorCoolingSystem>(),
         new Repository<WifiAdapter>()))
    {
    }
}