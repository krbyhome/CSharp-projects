namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class WifiAdapter : IComponent<WifiAdapter>
{
    public WifiAdapter(
        string name,
        string version,
        string versionPCIe,
        bool hasBluetooth)
    {
        Name = name;
        StandartVersion = version;
        VersionPCIe = versionPCIe;
        HasBluetooth = hasBluetooth;
    }

    private WifiAdapter(WifiAdapter other)
    {
        Name = other.Name;
        StandartVersion = other.StandartVersion;
        VersionPCIe = other.VersionPCIe;
        HasBluetooth = other.HasBluetooth;
    }

    public string Name { get; }
    public string StandartVersion { get; }
    public string VersionPCIe { get; }
    public bool HasBluetooth { get; }

    public WifiAdapter Clone()
    {
        return new WifiAdapter(this);
    }
}