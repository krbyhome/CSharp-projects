namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

public static class RepositoryFabric
{
    public static RepositoryContext Create()
    {
        var context = new RepositoryContext();

        var cpuBuilder = new CpuBuilder();
        Cpu cpuRyzen = cpuBuilder
            .WithName("Ryzen")
            .WithCoreNumber(6)
            .WithFrequency(3.7)
            .WithMemoryFrequency(3200)
            .WithSocket("AM4")
            .WithTdp(65)
            .WithPowerConsumption(80)
            .Build();
        context.Processors.Add(cpuRyzen);
        cpuBuilder.Reset();

        Cpu cpuIntel = cpuBuilder
            .WithName("Intel")
            .WithCoreNumber(6)
            .WithFrequency(2.5)
            .WithMemoryFrequency(4800)
            .WithSocket("LGA 1700")
            .WithTdp(65)
            .WithPowerConsumption(80)
            .WithVideoCore()
            .Build();
        context.Processors.Add(cpuIntel);

        var biosBuilder = new BiosBuilder();
        Bios defaultBios = biosBuilder
            .WithName("default bios")
            .WithType("UEFI")
            .WithVersion("V1")
            .WithSupportedCpu("Intel")
            .WithSupportedCpu("Ryzen")
            .Build();

        var chipsetBuilder = new ChipsetBuilder();
        Chipset chipsetB550 = chipsetBuilder
            .WithName("B550")
            .WithXmpSupport()
            .WithFrequency(3200)
            .WithFrequency(3400)
            .Build();
        chipsetBuilder.Reset();

        Chipset chipsetZ690 = chipsetBuilder
            .WithName("Z690")
            .WithXmpSupport()
            .WithFrequency(5600)
            .WithFrequency(5800)
            .Build();

        var motherboardBuilder = new MotherBoardBuilder();
        MotherBoard b550MotherBoard = motherboardBuilder
            .WithName("AORUS B550")
            .WithFormFactor("Standart-ATX")
            .WithSocket("AM4")
            .WithBios(defaultBios)
            .WithChipset(chipsetB550)
            .WithDdrType("DDR4")
            .WithPciSlots(3)
            .WithRamSlots(4)
            .WithSataSlots(2)
            .Build();
        context.Motherboards.Add(b550MotherBoard);
        motherboardBuilder.Reset();

        MotherBoard z690Tomahawk = motherboardBuilder
            .WithName("TOMAHAWK Z690")
            .WithFormFactor("micro-ATX")
            .WithSocket("LGA 1700")
            .WithBios(defaultBios)
            .WithChipset(chipsetZ690)
            .WithDdrType("DDR5")
            .WithPciSlots(3)
            .WithRamSlots(4)
            .WithSataSlots(6)
            .Build();
        context.Motherboards.Add(z690Tomahawk);

        var coolerBuilder = new CoolerBuilder();
        ProccessorCoolingSystem cooler = coolerBuilder
            .WithName("GAMMAX 400")
            .WithDissipatedHeat(180)
            .AddSocket("LGA 1700")
            .AddSocket("AM4")
            .Build();
        context.Coolers.Add(cooler);
        coolerBuilder.Reset();

        ProccessorCoolingSystem powerlessCooler = coolerBuilder
            .WithName("powerless")
            .WithDissipatedHeat(40)
            .AddSocket("LGA 1700")
            .Build();
        context.Coolers.Add(powerlessCooler);

        var caseBuilder = new ComputerCaseBuilder();
        ComputerCase computerCase = caseBuilder
            .WithName("default case")
            .WithDimensions(90, 90, 50)
            .WithGpuDimensions(60, 40)
            .WithFormFactor("Standart-ATX")
            .WithFormFactor("micro-ATX")
            .Build();
        context.Cases.Add(computerCase);

        var aerocoolPowerUnit = new PowerUnit("Aerocool KCAS", 500);
        var beQuietPowerUnit = new PowerUnit("BeQuiet", 800);
        context.PowerUnits.Add(aerocoolPowerUnit);
        context.PowerUnits.Add(beQuietPowerUnit);

        var xmpBuilder = new XmpBuilder();
        XmpProfile xmpDefaultProfile = xmpBuilder
            .WithName("DDR4 profile")
            .WithFreq(3200)
            .WithVoltage(1)
            .AddTiming(16)
            .AddTiming(20)
            .AddTiming(20)
            .Build();
        xmpBuilder.Reset();

        XmpProfile xmpFastProfile = xmpBuilder
            .WithName("DDR5 profile")
            .WithFreq(4600)
            .WithVoltage(2)
            .AddTiming(40)
            .AddTiming(40)
            .AddTiming(40)
            .Build();

        var ramBuilder = new RamBuilder();
        Ram ramDdr4 = ramBuilder
            .WithName("DDR4 ram")
            .WithVersion("DDR4")
            .WithMemorySize(4)
            .WithFormFactor("DIMM")
            .WithProfile(xmpDefaultProfile)
            .Build();
        context.Memory.Add(ramDdr4);
        ramBuilder.Reset();

        Ram ramDdr5 = ramBuilder
            .WithName("DDR5 ram")
            .WithVersion("DDR5")
            .WithMemorySize(4)
            .WithFormFactor("DIMM")
            .WithProfile(xmpFastProfile)
            .Build();
        context.Memory.Add(ramDdr5);

        var hardDisk = new Hdd("WD1000", 1024, 5000);
        var solidDisk = new Ssd("samsung", 512, ComputerEBus.PCIe);
        context.HardDrives.Add(hardDisk);
        context.SolidDrives.Add(solidDisk);

        var gpuBuilder = new GpuBuilder();
        Gpu gpu3080 = gpuBuilder
            .WithName("RTX3080")
            .WithDimensions(50, 40)
            .WithMemory(10)
            .WithFrequency(1440)
            .WithPCIe("4.0")
            .WithConsumption(500)
            .Build();
        context.GraphicsCards.Add(gpu3080);
        context.GraphicsCards.Add(
            context.GraphicsCards
                .GetComponentByName("RTX3080")
                .Direct(gpuBuilder)
                .WithName("RTX3080 Ti")
                .WithMemory(12)
                .Build());
        var wifiAdapter = new WifiAdapter(
            "default wifi adapter",
            "5G",
            "4.0",
            true);
        context.WifiAdapters.Add(wifiAdapter);
        return context;
    }
}