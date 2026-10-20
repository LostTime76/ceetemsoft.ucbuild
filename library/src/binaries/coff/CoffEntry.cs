namespace CeetemSoft.UcBuild.Binaries;

/// <summary>
/// Represents an entry within a coff image
/// </summary>
public abstract class CoffEntry
{
	internal CoffEntry(string name)
	{
		Name = name;
	}

	/// <summary>
	/// Gets the name of the entry
	/// </summary>
	public string Name { get; private init; }
}