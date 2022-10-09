using SDLTooSharp.Bindings.SDL2Ttf;

namespace SDLTooSharp.Managed.Font;

/// <summary>
/// Defines a <see cref="Font"/>'s Style
/// </summary>
public class FontStyle : IEquatable<FontStyle>
{
    private bool _isBold;
    private bool _isItalic;
    private bool _isUnderline;
    private bool _isStrikethrough;

    /// <summary>
    /// Gets or sets a value which indicates whether the Bold style is active.
    /// </summary>
    public bool Bold
    {
        get => _isBold;
        set => _isBold = value;
    }

    /// <summary>
    /// Gets or sets a value which indicates whether the Italic style is active
    /// </summary>
    public bool Italic
    {
        get => _isItalic;
        set => _isItalic = value;
    }

    /// <summary>
    /// Gets or sets a value which indicates whether the Underline style is active 
    /// </summary>
    public bool Underline
    {
        get => _isUnderline;
        set => _isUnderline = value;
    }

    /// <summary>
    /// Gets or sets a value which indicates whether the Strikethrough style is active.
    /// </summary>
    public bool Strikethrough
    {
        get => _isStrikethrough;
        set => _isStrikethrough = value;
    }

    /// <summary>
    /// Gets or sets a value which indicates that no styling is used.
    /// </summary>
    /// <remarks>Set this to true to eliminate all styling.</remarks>
    public bool Normal
    {
        get => !(_isBold && _isItalic && _isUnderline && _isStrikethrough);
        set
        {
            if (value)
            {
                _isBold = _isItalic = _isUnderline = _isStrikethrough = false;
            }
        }
    }

    /// <summary>
    /// Create a new FontStyle object
    /// </summary>
    /// <param name="isBold">Whether bold is enabled</param>
    /// <param name="isItalic">Whether italic is enabled</param>
    /// <param name="isUnderline">Whether underline is enabled</param>
    /// <param name="isStrikethrough">Whether strikethrough is enabled</param>
    public FontStyle(bool isBold = false, bool isItalic = false, bool isUnderline = false, bool isStrikethrough = false)
    {
        _isBold = isBold;
        _isItalic = isItalic;
        _isUnderline = isUnderline;
        _isStrikethrough = isStrikethrough;
    }

    /// <summary>
    /// Returns an integer representation of the style, to be used in <see cref="SDLTooSharp.Bindings.SDL2Ttf.SDLTtf"/> operations
    /// </summary>
    /// <returns></returns>
    /// <see cref="SDLTtf.TTF_SetFontStyle"/>
    public int GetIntegerStyle()
    {
        var result = 0x00;
        if (Normal)
        {
            return result;
        }

        result |= (_isBold ? 1 : 0) << 0;
        result |= (_isItalic ? 1 : 0) << 1;
        result |= (_isUnderline ? 1 : 0) << 2;
        result |= (_isStrikethrough ? 1 : 0) << 3;

        return result;
    }

    /// <summary>
    /// Creates a <see cref="FontStyle"/> object from an integer representation of style
    /// </summary>
    /// <param name="integerStyle">The style as reported by SDL_TTF</param>
    /// <returns>A font style object</returns>
    /// <see cref="SDLTtf.TTF_GetFontStyle"/>
    public static FontStyle FromIntegerStyle(int integerStyle)
    {
        var style = new FontStyle();
        if (integerStyle == 0x00)
        {
            return style;
        }

        if ((integerStyle & (1 << 0)) != 0)
        {
            style.Bold = true;
        }

        if ((integerStyle & (1 << 1)) != 0)
        {
            style.Italic = true;
        }

        if ((integerStyle & (1 << 2)) != 0)
        {
            style.Underline = true;
        }

        if ((integerStyle & (1 << 3)) != 0)
        {
            style.Strikethrough = true;
        }

        return style;
    }

    public bool Equals(FontStyle? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return _isBold == other._isBold && _isItalic == other._isItalic && _isUnderline == other._isUnderline &&
               _isStrikethrough == other._isStrikethrough;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FontStyle)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_isBold, _isItalic, _isUnderline, _isStrikethrough);
    }
}