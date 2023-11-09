using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class RamValidator : IComponentValidator
{
    private const string RamIsMissingMessage = "Ram is missing\n";
    private const string DdrStandartDoesNotMatchMessage = "Ddr version is not supported\n";
    private const string MoreSlotsRequiredMessage = "More RAM slots required\n";
    private const string RamDoesNotMatchCpuFrequencyMessage = "None of xmp profiles available for RAM and CPU\n";
    public ValidationResult Validate(PC computer)
    {
        if (computer.Memory.Count == 0)
        {
            return new ValidationResult.Failure(RamIsMissingMessage);
        }

        if (!IsProfilesSupported(computer.Processor, computer.Memory))
        {
            return new ValidationResult.Failure(RamDoesNotMatchCpuFrequencyMessage);
        }

        if (!DoesDdrStandartsMatchMotherboard(computer.Motherboard, computer.Memory))
        {
            return new ValidationResult.Failure(DdrStandartDoesNotMatchMessage);
        }

        return computer.Memory.Count <= computer.Motherboard.RamSlotsNumber
            ? new ValidationResult.Success()
            : new ValidationResult.Failure(MoreSlotsRequiredMessage);
    }

    private static bool IsProfilesSupported(Cpu processor, IEnumerable<Ram> memory)
    {
        return memory.All(ram => ram.AvailableProfiles
            .Any(profile => profile.Frequency <= processor.MaxMemoryFrequency));
    }

    private static bool DoesDdrStandartsMatchMotherboard(MotherBoard motherBoard, IEnumerable<Ram> memory)
    {
        return memory.All(ram => ram.DdrVersion == motherBoard.SupportedDdr);
    }
}