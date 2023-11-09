namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IRamBuilder
{
    IRamBuilder WithName(string name);
    IRamBuilder WithMemorySize(int memorySize);
    IRamBuilder WithProfile(XmpProfile availableProfile);
    IRamBuilder WithVersion(string ddrVersion);
    IRamBuilder WithFormFactor(string formfactor);

    Ram Build();
    void Reset();
}