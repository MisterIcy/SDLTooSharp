using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Bindings.SDL2Ttf;

[ExcludeFromCodeCoverage]
public static partial class SDLTtf
{
    private const string dllName = "SDL2_ttf";
    
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_Linked_Version")]
    private static extern IntPtr _TTF_Linked_Version();

    public static SDL.SDL_version TTF_Linked_Version()
    {
        IntPtr version = _TTF_Linked_Version();
        return Marshal.PtrToStructure<SDL.SDL_version>(version);
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void TTF_GetFreeTypeVersion(out int major, out int minor, out int patch);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void TTF_GetHarfBuzzVersion(out int major, out int minor, out int patch);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void TTF_ByteSwappedUNICODE(bool swapped);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_Init();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_OpenFont([MarshalAs(UnmanagedType.LPUTF8Str)] string file, int ptSize);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_OpenFontIndex([MarshalAs(UnmanagedType.LPUTF8Str)] string file, int ptSize,
        long index);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_OpenFontRW(IntPtr src, int freeSrc, int ptSize);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_OpenFontIndexRW(IntPtr src, int freeSrc, int ptSize);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_OpenFontDPI([MarshalAs(UnmanagedType.LPUTF8Str)] string file, int ptSize, uint hdpi,
        uint vdpi);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_OpenFontIndexDPI([MarshalAs(UnmanagedType.LPUTF8Str)] string file, int ptSize,
        long index, uint hdpi, uint vdpi);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_OpenFontDPIRW(IntPtr src, int freeSrc, int ptSize, uint hdpi, uint vdpi);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_OpenFontIndexDPIRW(IntPtr src, int freeSrc, int ptSize, long index, uint hdpi,
        uint vdpi);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_SetFontSize(IntPtr font, int ptSize);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_SetFontSizeDPI(IntPtr font, int ptSize, uint hdpi, uint vdpi);

    public const int TTF_STYLE_NORMAL = 0x00;
    public const int TTF_STYLE_BOLD = 0x01;
    public const int TTF_STYLE_ITALIC = 0x02;
    public const int TTF_STYLE_UNDERLINE = 0x04;
    public const int TTF_STYLE_STRIKETHROUGH = 0x08;

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_GetFontStyle(IntPtr font);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void TTF_SetFontStyle(IntPtr font, int style);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_GetFontOutline(IntPtr font);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void TTF_SetFontOutline(IntPtr font, int outline);

    public const int TTF_HINTING_NORMAL = 0;
    public const int TTF_HINTING_LIGHT = 1;
    public const int TTF_HINTING_MONO = 2;
    public const int TTF_HINTING_NONE = 3;
    public const int TTF_HINTING_LIGHT_SUBPIXEL = 4;

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_GetFontHinting(IntPtr font);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void TTF_SetFontHinting(IntPtr font, int hinting);

    public const int TTF_WRAPPED_ALIGN_LEFT = 0;
    public const int TTF_WRAPPED_ALIGN_CENTER = 1;
    public const int TTF_WRAPPED_ALIGN_RIGHT = 2;

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_GetFontWrappedAlign(IntPtr font);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void TTF_SetFontWrappedAlign(IntPtr font, int align);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_FontHeight(IntPtr font);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_FontAscent(IntPtr font);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_FontDescent(IntPtr font);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_FontLineSkip(IntPtr font);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_GetFontKerning(IntPtr font);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void TTF_SetFontKerning(IntPtr font, int allowed);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long TTF_FontFaces(IntPtr font);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_FontFaceIsFixedWidth(IntPtr font);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontFaceFamilyName")]
    private static extern IntPtr _TTF_FontFaceFamilyName(IntPtr font);

    public static string TTF_FontFaceFamilyName(IntPtr font) => SDL.PtrToManaged(_TTF_FontFaceFamilyName(font));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "TTF_FontFaceStyleName")]
    private static extern IntPtr _TTF_FontFaceStyleName(IntPtr font);

    public static string TTF_FontFaceStyleName(IntPtr font) => SDL.PtrToManaged(_TTF_FontFaceStyleName(font));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_GlyphIsProvided(IntPtr font, ushort ch);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_GlyphIsProvided32(IntPtr font, uint ch);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_GlyphMetrics(IntPtr font, ushort ch, out int minX, out int maxX, out int minY,
        out int maxY, out int advance);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_GlyphMetrics32(IntPtr font, uint ch, out int minX, out int maxX, out int minY,
        out int maxY, out int advance);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_SizeUTF8(IntPtr font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text, out int w,
        out int h);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_MeasureUTF8(IntPtr font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text,
        int measureWidth, out int extent, out int count);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_RenderUTF8_Solid(IntPtr font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text,
        SDL.SDL_Color fg);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_RenderUTF8_Solid_Wrapped(IntPtr font,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string text, SDL.SDL_Color fg, uint wrapLength);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_RenderGlyph_Solid(IntPtr font, ushort ch, SDL.SDL_Color fg);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_RenderGlyph32_Solid(IntPtr font, uint ch, SDL.SDL_Color fg);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_RenderUTF8_Shaded(IntPtr font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text,
        SDL.SDL_Color fg, SDL.SDL_Color bg);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_RenderUTF8_Shaded_Wrapped(IntPtr font,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string text, SDL.SDL_Color fg, SDL.SDL_Color bg, uint wrapLength);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_RenderGlyph_Shaded(IntPtr font, ushort ch, SDL.SDL_Color fg, SDL.SDL_Color bg);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_RenderGlyph32_Shaded(IntPtr font, uint ch, SDL.SDL_Color fg, SDL.SDL_Color bg);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_RenderUTF8_Blended(IntPtr font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text,
        SDL.SDL_Color fg);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_RenderUTF8_Blended_Wrapped(IntPtr font,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string text, SDL.SDL_Color fg, uint wrapLength);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_RenderGlyph_Blended(IntPtr font, ushort ch, SDL.SDL_Color fg);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_RenderGlyph32_Blended(IntPtr font, uint ch, SDL.SDL_Color bg);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_RenderUTF8_LCD(IntPtr font, [MarshalAs(UnmanagedType.LPUTF8Str)] string text,
        SDL.SDL_Color fg, SDL.SDL_Color bg);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_RenderUTF8_LCD_Wrapped(IntPtr font,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string text, SDL.SDL_Color fg, SDL.SDL_Color bg, uint wrapLength);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_RenderGlyph_LCD(IntPtr font, ushort ch, SDL.SDL_Color fg, SDL.SDL_Color bg);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr TTF_RenderGlyph32_LCD(IntPtr font, uint ch, SDL.SDL_Color fg, SDL.SDL_Color bg);

    public static IntPtr TTF_RenderUTF8(IntPtr font, string text, SDL.SDL_Color fg, SDL.SDL_Color bg) =>
        TTF_RenderUTF8_Shaded(font, text, fg, bg);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void TTF_CloseFont(IntPtr font);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void TTF_Quit();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_WasInit();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_GetFontKerningSizeGlyphs(IntPtr font, ushort previousCh, ushort ch);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_GetFontKerningSizeGlyphs32(IntPtr font, uint previousCh, uint ch);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_SetFontSDF(IntPtr font, bool onOff);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool TTF_GetFontSDF(IntPtr font);

    public static string TTF_GetError() => SDL.SDL_GetError();
    public static int TTF_SetError(string error) => SDL.SDL_SetError(error);

    public enum TTF_Direction
    {
        TTF_DIRECTION_LTR = 0,
        TTF_DIRECTION_RTL,
        TTF_DIRECTION_TTB,
        TTF_DIRECTION_BTT
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_SetFontDirection(IntPtr font, TTF_Direction direction);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int TTF_SetFontScriptName(IntPtr font, [MarshalAs(UnmanagedType.LPUTF8Str)] string script);
}
