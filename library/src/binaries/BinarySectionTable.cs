using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace CeetemSoft.UcBuild.Binaries;

/// <summary>
/// Stores a collection of sections accessible by name within a binary image
/// </summary>
public class BinarySectionTable : IReadOnlyCollection<string>
{
	private readonly byte[] _data;

	private readonly Dictionary<string, (int, int)> _sections = [];

	internal BinarySectionTable(byte[] data)
	{
		_data = data;
	}

	/// <summary>
	/// Adds a section to the table
	/// </summary>
	/// <param name="section">
	/// The name of the section
	/// </param>
	/// <param name="offset">
	/// The offset within the image where the data starts
	/// </param>
	/// <param name="length">
	/// The length of the data in bytes
	/// </param>
	/// <exception cref="ArgumentException">
	/// Thrown if <paramref name="section"/> is null or contains only whitespace
	/// </exception>
	/// <exception cref="ArgumentOutOfRangeException">
	/// Thrown if the specified range does not represent valid data within the image
	/// </exception>
	public void Add(string section, int offset, int length)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(section, nameof(section));

		if ((ulong)offset + (ulong)length > (ulong)_data.Length)
		{
			ThrowInvalidSectionRange();
		}

		_sections.Add(section, (offset, length));
	}

	/// <summary>
	/// Gets an enumerator for the names of the sections within the table
	/// </summary>
	/// <returns>
	/// The section name enumerator
	/// </returns>
	public IEnumerator<string> GetEnumerator() => _sections.Keys.GetEnumerator();

	/// <summary>
	/// Gets an enumerator for the names of the sections within the table
	/// </summary>
	/// <returns>
	/// The section name enumerator
	/// </returns>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	private Span<byte> GetData(string section)
	{
		var (start, length) = _sections[section];

		return _data.AsSpan(start, length);
	}

	[DoesNotReturn]
	private static void ThrowInvalidSectionRange()
		=> throw new ArgumentOutOfRangeException("The range is outside of the data.");

	/// <summary>
	/// Gets the number of sections within the table
	/// </summary>
	public int Count => _sections.Count;

	/// <summary>
	/// Gets the data for a specified section
	/// </summary>
	/// <param name="section">
	/// The name of the section to access
	/// </param>
	/// <returns>
	/// The data for the section
	/// </returns>
	public Span<byte> this[string section] => GetData(section);
}