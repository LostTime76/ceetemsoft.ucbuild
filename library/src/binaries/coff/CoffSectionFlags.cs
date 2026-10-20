namespace CeetemSoft.UcBuild.Binaries;

/// <summary>
/// Provides access to the flags for a section within a ti coff image
/// </summary>
public readonly struct CoffSectionFlags
{
	private const int DummyFlag  = 0x01;
	private const int NoLoadFlag = 0x02;
	private const int GroupFlag  = 0x04;
	private const int PadFlag    = 0x08;
	private const int CopyFlag   = 0x10;
	private const int TextFlag   = 0x20;
	private const int DataFlag   = 0x40;
	private const int BssFlag    = 0x80;

	private readonly int _data;

	/// <summary>
	/// Creates new flags
	/// </summary>
	/// <param name="data">
	/// The integer value of the flags
	/// </param>
	public CoffSectionFlags(int data)
	{
		_data = data;
	}

	/// <summary>
	/// Implicitly converts flags to an integer
	/// </summary>
	/// <param name="flags">
	/// The flags to convert
	/// </param>
	public static implicit operator int(CoffSectionFlags flags) => flags._data;

	/// <summary>
	/// Implicitly converts an integer to flags
	/// </summary>
	/// <param name="data">
	/// The integer to convert
	/// </param>
	public static implicit operator CoffSectionFlags(int data) => new(data);

	/// <summary>
	/// Indicates if the section is regular, that is no flags are set
	/// </summary>
	public bool Regular => _data == 0;

	/// <summary>
	/// Indicates if the section is a dummy section
	/// </summary>
	public bool Dummy => (_data & DummyFlag) != 0;

	/// <summary>
	/// Indicates if the section is a not loaded
	/// </summary>
	public bool NoLoad => (_data & NoLoadFlag) != 0;

	/// <summary>
	/// Indicates if the section is a grouped
	/// </summary>
	public bool Grouped => (_data & GroupFlag) != 0;

	/// <summary>
	/// Indicates if the section padding
	/// </summary>
	public bool Padding => (_data & PadFlag) != 0;

	/// <summary>
	/// Indicates if the section is a copy section
	/// </summary>
	public bool Copy => (_data & CopyFlag) != 0;

	/// <summary>
	/// Indicates if the section contains executable code
	/// </summary>
	public bool Text => (_data & TextFlag) != 0;

	/// <summary>
	/// Indicates if the section contains initialized data
	/// </summary>
	public bool Data => (_data & DataFlag) != 0;

	/// <summary>
	/// Indicates if the section contains uninitialized data
	/// </summary>
	public bool Bss => (_data & BssFlag) != 0;

	/// <summary>
	/// Indicates if the section resides within target memory
	/// </summary>
	public bool Allocated => (_data & (TextFlag | DataFlag | BssFlag)) != 0;
}