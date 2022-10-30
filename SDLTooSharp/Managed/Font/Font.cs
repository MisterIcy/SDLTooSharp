using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Bindings.SDL2Ttf;
using SDLTooSharp.Managed.Exception.Font;

namespace SDLTooSharp.Managed.Font;

/// <summary>
/// Managed class for Font Operations
/// </summary>
public class Font : IDisposable
{
    /// <summary>
    /// Gets a value that represents the Pointer to the font object
    /// </summary>
    public IntPtr FontPtr { get; private set; }

    /// <summary>
    /// Gets a value that indicates the filename of the loaded font
    /// </summary>
    public string Filename { get; private set; }

    private int _pointSize;
    private uint _horizontalDpi;
    private uint _verticalDpi;

    private readonly long _fontIndex = 0;

    /// <summary>
    /// Gets or sets the font's style
    /// </summary>
    /// <see cref="FontStyle"/>
    public FontStyle Style
    {
        get => FontStyle.FromIntegerStyle(SDLTtf.TTF_GetFontStyle(FontPtr));
        set => SDLTtf.TTF_SetFontStyle(FontPtr, value.GetIntegerStyle());
    }

    /// <summary>
    /// Gets or sets the font's outline
    /// </summary>
    /// <remarks>Set 0 to default</remarks>
    public int Outline
    {
        get => SDLTtf.TTF_GetFontOutline(FontPtr);
        set => SDLTtf.TTF_SetFontOutline(FontPtr, value);
    }

    /// <summary>
    /// Gets or sets the font's Hinting
    /// </summary>
    /// <see cref="Hinting"/>
    public Hinting Hinting
    {
        get => (Hinting)SDLTtf.TTF_GetFontHinting(FontPtr);
        set => SDLTtf.TTF_SetFontHinting(FontPtr, (int)value);
    }

    /// <summary>
    /// Gets or sets the font's alignment
    /// </summary>
    public WrapAlignment WrapAlignment
    {
        get => (WrapAlignment)SDLTtf.TTF_GetFontWrappedAlign(FontPtr);
        set => SDLTtf.TTF_SetFontWrappedAlign(FontPtr, (int)value);
    }

    /// <summary>
    /// Gets the font's height
    /// </summary>
    public int Height => SDLTtf.TTF_FontHeight(FontPtr);

    /// <summary>
    /// Gets the font's ascent
    /// </summary>
    public int Ascent => SDLTtf.TTF_FontAscent(FontPtr);

    /// <summary>
    /// Gets the font's descent
    /// </summary>
    public int Descent => SDLTtf.TTF_FontDescent(FontPtr);

    /// <summary>
    /// Gets the font's line skip
    /// </summary>
    public int LineSkip => SDLTtf.TTF_FontLineSkip(FontPtr);

    /// <summary>
    /// Gets or sets a value that indicates whether kerning is enabled for the font.
    /// </summary>
    public bool Kerning
    {
        get => SDLTtf.TTF_GetFontKerning(FontPtr) != 0;
        set => SDLTtf.TTF_SetFontKerning(FontPtr, value ? 1 : 0);
    }

    /// <summary>
    /// Gets a number of faces contained in the font.
    /// </summary>
    public long NumFontFaces => SDLTtf.TTF_FontFaces(FontPtr);

    /// <summary>
    /// Gets a value that indicates whether the font is a fixed width (monospace) one.
    /// </summary>
    public bool IsFixedWidth => SDLTtf.TTF_FontFaceIsFixedWidth(FontPtr) != 0;

    /// <summary>
    /// Gets the font's family name.
    /// </summary>
    public string FamilyName => SDLTtf.TTF_FontFaceFamilyName(FontPtr);

    /// <summary>
    /// Gets the font's style name.
    /// </summary>
    public string StyleName => SDLTtf.TTF_FontFaceStyleName(FontPtr);

    /// <summary>
    /// Checks whether a glyph is provided by the font
    /// </summary>
    /// <param name="glyph"></param>
    /// <returns></returns>
    public bool IsGlyphProvided(ushort glyph)
    {
        return SDLTtf.TTF_GlyphIsProvided(FontPtr, glyph) != 0;
    }

    /// <summary>
    /// Checks whether a glyph is provided by the font
    /// </summary>
    /// <param name="glyph"></param>
    /// <returns></returns>
    public bool IsGlyphProvided(uint glyph)
    {
        return SDLTtf.TTF_GlyphIsProvided32(FontPtr, glyph) != 0;
    }

    /// <summary>
    /// Gets the metrics for a glyph
    /// </summary>
    /// <param name="glyph"></param>
    /// <returns></returns>'
    /// TODO: Other glyph metrics should be included in this structure.
    public GlyphMetrics GetGlyphMetrics(ushort glyph)
    {
        GlyphMetrics metrics = default;
        SDLTtf.TTF_GlyphMetrics(FontPtr, glyph, out metrics.MinX, out metrics.MaxX, out metrics.MinY, out metrics.MaxY,
            out metrics.Advance);

        return metrics;
    }

    /// <summary>
    /// Gets the metrics for a glyph
    /// </summary>
    /// <param name="glyph"></param>
    /// <returns></returns>
    public GlyphMetrics GetGlyphMetrics(uint glyph)
    {
        GlyphMetrics metrics = default;
        SDLTtf.TTF_GlyphMetrics32(FontPtr, glyph, out metrics.MinX, out metrics.MaxX, out metrics.MinY,
            out metrics.MaxY,
            out metrics.Advance);

        return metrics;
    }

    /// <summary>
    /// Measures a text and returns its size
    /// </summary>
    /// <param name="text"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <exception cref="FontException"></exception>
    public void SizeText(string text, out int width, out int height)
    {
        //TODO: Refactor this to a Size Oject
        int result = SDLTtf.TTF_SizeUTF8(FontPtr, text, out width, out height);
        if ( result != 0 )
        {
            throw new FontException("Unable to get the size of the text!");
        }
    }

    /// <summary>
    /// Measures a text against a known width and reports how many characters can be rendered
    /// </summary>
    /// <param name="text"></param>
    /// <param name="measureWidth"></param>
    /// <param name="extent"></param>
    /// <param name="count"></param>
    /// <exception cref="FontException"></exception>
    public void MeasureText(string text, int measureWidth, out int extent, out int count)
    {
        int result = SDLTtf.TTF_MeasureUTF8(FontPtr, text, measureWidth, out extent, out count);
        if ( result != 0 )
        {
            throw new FontException("Unable to measure the text");
        }
    }

    /// <summary>
    /// Gets or sets a value that indicates whether Signed Distance Field is enabled
    /// </summary>
    public bool SignedDistanceField
    {
        get => SDLTtf.TTF_GetFontSDF(FontPtr);
        set => SDLTtf.TTF_SetFontSDF(FontPtr, value);
    }


    /// <summary>
    /// Gets or Sets the size of the font's points
    /// </summary>
    /// <exception cref="FontException">In case we cannot set the font's size. Call TTF_GetError for more details</exception>
    public int PointSize
    {
        get => _pointSize;
        set {
            int result = SDLTtf.TTF_SetFontSize(FontPtr, value);
            if ( result != 0 )
            {
                throw new FontException($"Unable to change the size of the font to {value}");
            }

            _pointSize = value;
        }
    }

    private int _fontStyle;

    /// <summary>
    /// Gets a value which indicates the font's index inside the file. 
    /// </summary>
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
        if ( FontPtr == IntPtr.Zero )
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
        if ( FontPtr == IntPtr.Zero )
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
        if ( FontPtr == IntPtr.Zero )
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
        if ( FontPtr == IntPtr.Zero )
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
        if ( FontPtr != IntPtr.Zero )
        {
            SDLTtf.TTF_CloseFont(FontPtr);
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        ReleaseUnmanagedResources();
        if ( disposing )
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

    #region Rendering

    public IntPtr RenderSolid(string text, SDL.SDL_Color foreground)
    {
        IntPtr surface = SDLTtf.TTF_RenderUTF8_Solid(FontPtr, text, foreground);
        if ( surface == IntPtr.Zero )
        {
            throw FontException.UnableToRenderText();
        }

        return surface;
    }

    public IntPtr RenderSolid(string text, SDL.SDL_Color foreground, uint wrapLength)
    {
        IntPtr surface = SDLTtf.TTF_RenderUTF8_Solid_Wrapped(FontPtr, text, foreground, wrapLength);

        if ( surface == IntPtr.Zero )
        {
            throw FontException.UnableToRenderText();
        }

        return surface;
    }

    public IntPtr RenderShaded(string text, SDL.SDL_Color foreground, SDL.SDL_Color background)
    {
        IntPtr surface = SDLTtf.TTF_RenderUTF8_Shaded(FontPtr, text, foreground, background);

        if ( surface == IntPtr.Zero )
        {
            throw FontException.UnableToRenderText();
        }

        return surface;
    }

    public IntPtr RenderShaded(string text, SDL.SDL_Color foreground, SDL.SDL_Color background, uint wrapLength)
    {
        IntPtr surface = SDLTtf.TTF_RenderUTF8_Shaded_Wrapped(FontPtr, text, foreground, background, wrapLength);

        if ( surface == IntPtr.Zero )
        {
            throw FontException.UnableToRenderText();
        }

        return surface;
    }

    public IntPtr RenderBlended(string text, SDL.SDL_Color foreground)
    {
        IntPtr surface = SDLTtf.TTF_RenderUTF8_Blended(FontPtr, text, foreground);

        if ( surface == IntPtr.Zero )
        {
            throw FontException.UnableToRenderText();
        }

        return surface;
    }

    public IntPtr RenderShaded(string text, SDL.SDL_Color foreground, uint wrapLength)
    {
        IntPtr surface = SDLTtf.TTF_RenderUTF8_Blended_Wrapped(FontPtr, text, foreground, wrapLength);

        if ( surface == IntPtr.Zero )
        {
            throw FontException.UnableToRenderText();
        }

        return surface;
    }

    public IntPtr RenderLCD(string text, SDL.SDL_Color foreground, SDL.SDL_Color background)
    {
        IntPtr surface = SDLTtf.TTF_RenderUTF8_LCD(FontPtr, text, foreground, background);

        if ( surface == IntPtr.Zero )
        {
            throw FontException.UnableToRenderText();
        }

        return surface;
    }

    public IntPtr RenderLCD(string text, SDL.SDL_Color foreground, SDL.SDL_Color background, uint wrapLength)
    {
        IntPtr surface = SDLTtf.TTF_RenderUTF8_LCD_Wrapped(FontPtr, text, foreground, background, wrapLength);

        if ( surface == IntPtr.Zero )
        {
            throw FontException.UnableToRenderText();
        }

        return surface;
    }

    public IntPtr RenderGlyphSolid(uint glyph, SDL.SDL_Color foreground)
    {
        IntPtr surface = SDLTtf.TTF_RenderGlyph32_Solid(FontPtr, glyph, foreground);
        if ( surface == IntPtr.Zero )
        {
            throw FontException.UnableToRenderText();
        }

        return surface;
    }

    public IntPtr RenderGlyphBlended(uint glyph, SDL.SDL_Color foreground)
    {
        IntPtr surface = SDLTtf.TTF_RenderGlyph32_Blended(FontPtr, glyph, foreground);
        if ( surface == IntPtr.Zero )
        {
            throw FontException.UnableToRenderText();
        }

        return surface;
    }

    public IntPtr RenderGlyphShaded(uint glyph, SDL.SDL_Color foreground, SDL.SDL_Color background)
    {
        IntPtr surface = SDLTtf.TTF_RenderGlyph32_Shaded(FontPtr, glyph, foreground, background);
        if ( surface == IntPtr.Zero )
        {
            throw FontException.UnableToRenderText();
        }

        return surface;
    }

    public IntPtr RenderGlyphLCD(uint glyph, SDL.SDL_Color foreground, SDL.SDL_Color background)
    {
        IntPtr surface = SDLTtf.TTF_RenderGlyph32_LCD(FontPtr, glyph, foreground, background);
        if ( surface == IntPtr.Zero )
        {
            throw FontException.UnableToRenderText();
        }

        return surface;
    }

    #endregion
}
