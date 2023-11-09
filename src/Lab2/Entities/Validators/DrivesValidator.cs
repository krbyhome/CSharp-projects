using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class DrivesValidator : IComponentValidator
{
    private const string DrivesMissingMessage = "Drives missing\n";
    private const string LackOfPcieSlotsMessage = "More pcie slots required\n";
    private const string LackOfSataSlotsMessage = "More sata slots required\n";
    public ValidationResult Validate(PC computer)
    {
        IList<IStorageDevice> drivesList = computer.Drives;
        MotherBoard? motherBoard = computer.Motherboard;

        if (drivesList.Count == 0)
            return new ValidationResult.Failure(DrivesMissingMessage);

        int pcieCounter = drivesList.Count(drive => drive.ConnectionOption is ComputerEBus.PCIe);
        int sataCounter = drivesList.Count(drive => drive.ConnectionOption is ComputerEBus.SATA);

        var message = new StringBuilder();
        if (motherBoard.SataNumber < sataCounter)
        {
            message.Append(LackOfSataSlotsMessage);
        }

        if (motherBoard.PCIeNumber < pcieCounter)
        {
            message.Append(LackOfPcieSlotsMessage);
        }

        string messageString = message.ToString();
        return messageString.Length == 0 ?
            new ValidationResult.Success() :
            new ValidationResult.Failure(messageString);
    }
}