using SDLTooSharp.Bindings.SDL2Ttf;
using SDLTooSharp.Managed.Exception.Font;

namespace SDLTooSharp.Managed.Font;

/// <summary>
/// Managed class for Font Operations
/// </summary>
public class Font : IDisposable
{
    public IntPtr FontPtr { get; private set; }

    public string Filename { get; private set; }
    private int _pointSize;
    private uint _horizontalDpi;
    private uint _verticalDpi;

    private readonly long _fontIndex = 0;

    /// <summary>
    /// Sets or get the font's style.
    /// </summary>
    public FontStyle Style
    {
        get => FontStyle.FromIntegerStyle(SDLTtf.TTF_GetFontStyle(FontPtr));
        set => SDLTtf.TTF_SetFontStyle(FontPtr, value.GetIntegerStyle());
    }

    /// <summary>
    /// Gets or Sets the size of the font's points
    /// </summary>
    /// <exception cref="FontException">In case we cannot set the font's size. Call TTF_GetError for more details</exception>
    public int PointSize
    {
        get => _pointSize;
        set
        {
            int result = SDLTtf.TTF_SetFontSize(FontPtr, value);
            if (result != 0)
            {
                throw new FontException($"Unable to change the size of the font to {value}");
            }

            _pointSize = value;
        }
    }

    private int _fontStyle;


    public long FontIndex => _fontIndex;

    public uint HorizontalDPI => _horizontalDpi;
    public uint VerticalDPI => _verticalDpi;

#region Constructors

    /// <summary>
    /// Opens a font file and creates a font object
    /// </summary>
    /// <param name="file">The font file to be opened</param>
    /// <param name="ptSize">The initial size of the font's point</param>
    /// <exception cref="FontException">Thrown if we are unable to open the file</exception>
    public Font(string file, int ptSize)
    {
        FontPtr = SDLTtf.TTF_OpenFont(file, ptSize);
        if (FontPtr == IntPtr.Zero)
        {
            throw FontException.UnableToOpen(file);
        }

        Filename = file;
        _pointSize = ptSize;
        InitializeFont();
    }

    /// <summary>
    /// Opens a font file and creates a font object
    /// </summary>
    /// <param name="file">The font file to be opened</param>
    /// <param name="ptSize">The initial size of the font's points</param>
    /// <param name="index">The index of the font inside the file</param>
    /// <exception cref="FontException">Thrown if we are unable to open the file</exception>
    public Font(string file, int ptSize, long index)
    {
        FontPtr = SDLTtf.TTF_OpenFontIndex(file, ptSize, index);
        if (FontPtr == IntPtr.Zero)
        {
            throw FontException.UnableToOpen(file);
        }

        Filename = file;
        _pointSize = ptSize;
        _fontIndex = index;
        InitializeFont();
    }

    /// <summary>
    /// Opens a font file and creates a font object
    /// </summary>
    /// <param name="file">The font file to be opened</param>
    /// <param name="ptSize">The initial size of the font's points</param>
    /// <param name="horizontalDpi">The target horizontal DPI</param>
    /// <param name="verticalDpi">The target vertical DPI</param>
    /// <remarks>DPI Scaling only applies to scalable fonts.</remarks>
    /// <exception cref="FontException">Thrown if we are unable to open the file</exception>
    public Font(string file, int ptSize, uint horizontalDpi, uint verticalDpi)
    {
        FontPtr = SDLTtf.TTF_OpenFontDPI(file, ptSize, horizontalDpi, verticalDpi);
        if (FontPtr == IntPtr.Zero)
        {
            throw FontException.UnableToOpen(file);
        }

        Filename = file;
        _pointSize = ptSize;
        _horizontalDpi = horizontalDpi;
        _verticalDpi = verticalDpi;
        InitializeFont();
    }

    /// <summary>
    /// Opens a font file and creates a font object
    /// </summary>
    /// <param name="file">The font file to be opened</param>
    /// <param name="ptSize">The initial size of the font's points</param>
    /// <param name="index">The index of the font inside the file</param>
    /// <param name="horizontalDpi">The target horizontal DPI</param>
    /// <param name="verticalDpi">The target vertical DPI</param>
    /// <remarks>
    /// DPI Scaling only applies to scalable fonts.
    /// The index parameter specifies which face from the font file should be used. Fonts with a single face, should specify zero for the index
    /// </remarks>
    /// <exception cref="FontException">Thrown if we are unable to open the file</exception>
    public Font(string file, int ptSize, long index, uint horizontalDpi, uint verticalDpi)
    {
        FontPtr = SDLTtf.TTF_OpenFontIndexDPI(file, ptSize, index, horizontalDpi, verticalDpi);
        if (FontPtr == IntPtr.Zero)
        {
            throw FontException.UnableToOpen(file);
        }

        Filename = file;
        _pointSize = ptSize;
        _fontIndex = index;
        _horizontalDpi = horizontalDpi;
        _verticalDpi = verticalDpi;
        InitializeFont();
    }

#endregion

#region Internals

    private void InitializeFont()
    {
        _fontStyle = SDLTtf.TTF_GetFontStyle(FontPtr);
    }

#endregion

#region IDisposable Implementation

    private void ReleaseUnmanagedResources()
    {
        if (FontPtr != IntPtr.Zero)
        {
            SDLTtf.TTF_CloseFont(FontPtr);
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        ReleaseUnmanagedResources();
        if (disposing)
        {
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~Font()
    {
        Dispose(false);
    }

#endregion
}