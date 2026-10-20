namespace CeetemSoft.UcBuild.Binaries;

/// <summary>
/// Provides a means to access byte data within a binary image by name
/// </summary>
public class BinaryImage
{
	/// <summary>
	/// Creates a new image
	/// </summary>
	/// <param name="data">
	/// The data comprising the image
	/// </param>
	/// <exception cref="ArgumentNullException">
	/// Thrown if <paramref name="data"/> is null
	/// </exception>
	public BinaryImage(byte[] data)
	{
		ArgumentNullException.ThrowIfNull(data, nameof(data));

		Data     = data;
		Sections = new(data);
	}

	/// <summary>
	/// Gets the data comprising the image
	/// </summary>
	public byte[] Data { get; private init; }

	/// <summary>
	/// Gets the sections within the image
	/// </summary>
	public BinarySectionTable Sections { get; private init; }	
}