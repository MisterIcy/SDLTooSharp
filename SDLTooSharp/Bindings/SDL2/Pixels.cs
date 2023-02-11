using System.ComponentModel;
using System.Runtime.InteropServices;
#pragma warning disable CS1591
namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    public const byte SDL_ALPHA_OPAQUE = 255;
    public const byte SDL_ALPHA_TRANSPARENT = 0;

    public enum SDL_PixelType
    {
        SDL_PIXELTYPE_UNKNOWN,
        SDL_PIXELTYPE_INDEX1,
        SDL_PIXELTYPE_INDEX4,
        SDL_PIXELTYPE_INDEX8,
        SDL_PIXELTYPE_PACKED8,
        SDL_PIXELTYPE_PACKED16,
        SDL_PIXELTYPE_PACKED32,
        SDL_PIXELTYPE_ARRAYU8,
        SDL_PIXELTYPE_ARRAYU16,
        SDL_PIXELTYPE_ARRAYU32,
        SDL_PIXELTYPE_ARRAYF16,
        SDL_PIXELTYPE_ARRAYF32
    }

    public enum SDL_BitmapOrder
    {
        SDL_BITMAPORDER_NONE,
        SDL_BITMAPORDER_4321,
        SDL_BITMAPORDER_1234
    }

    public enum SDL_PackedOrder
    {
        SDL_PACKEDORDER_NONE,
        SDL_PACKEDORDER_XRGB,
        SDL_PACKEDORDER_RGBX,
        SDL_PACKEDORDER_ARGB,
        SDL_PACKEDORDER_RGBA,
        SDL_PACKEDORDER_XBGR,
        SDL_PACKEDORDER_BGRX,
        SDL_PACKEDORDER_ABGR,
        SDL_PACKEDORDER_BGRA
    }

    public enum SDL_ArrayOrder
    {
        SDL_ARRAYORDER_NONE,
        SDL_ARRAYORDER_RGB,
        SDL_ARRAYORDER_RGBA,
        SDL_ARRAYORDER_ARGB,
        SDL_ARRAYORDER_BGR,
        SDL_ARRAYORDER_BGRA,
        SDL_ARRAYORDER_ABGR
    }

    public enum SDL_PackedLayout
    {
        SDL_PACKEDLAYOUT_NONE,
        SDL_PACKEDLAYOUT_332,
        SDL_PACKEDLAYOUT_4444,
        SDL_PACKEDLAYOUT_1555,
        SDL_PACKEDLAYOUT_5551,
        SDL_PACKEDLAYOUT_565,
        SDL_PACKEDLAYOUT_8888,
        SDL_PACKEDLAYOUT_2101010,
        SDL_PACKEDLAYOUT_1010102
    }
    ///<summary></summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_DEFINE_PIXELFOURCC">SDL2 Documentation</a></remarks>
    public static uint SDL_DEFINE_PIXELFOURCC(uint a, uint b, uint c, uint d) => SDL_FOURCC(a, b, c, d);
    ///<summary></summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_DEFINE_PIXELFORMAT">SDL2 Documentation</a></remarks>
    public static uint SDL_DEFINE_PIXELFORMAT(int type, int order, int layout, int bits, int bytes)
    {
        return (uint)( ( 1 << 28 ) | ( type << 24 ) | ( order << 20 ) | ( layout << 16 ) | ( bits << 8 ) | ( bytes << 0 ) );
    }
    ///<summary></summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_PIXELFLAG">SDL2 Documentation</a></remarks>
    public static byte SDL_PIXELFLAG(uint x)
    {
        return (byte)( ( x >> 28 ) & 0x0f );
    }
    ///<summary></summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_PIXELTYPE">SDL2 Documentation</a></remarks>
    public static byte SDL_PIXELTYPE(uint x)
    {
        return (byte)( ( x >> 24 ) & 0x0f );
    }
    ///<summary></summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_PIXELORDER">SDL2 Documentation</a></remarks>
    public static byte SDL_PIXELORDER(uint x)
    {
        return (byte)( ( x >> 20 ) & 0x0f );
    }
    ///<summary></summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_PIXELLAYOUT">SDL2 Documentation</a></remarks>
    public static byte SDL_PIXELLAYOUT(uint x)
    {
        return (byte)( ( x >> 16 ) & 0x0f );
    }
    ///<summary></summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_BITSPERPIXEL">SDL2 Documentation</a></remarks>
    public static byte SDL_BITSPERPIXEL(uint x)
    {
        return (byte)( ( x >> 8 ) & 0xff );
    }

    public enum SDL_PixelFormatEnum : uint
    {
        SDL_PIXELFORMAT_UNKNOWN,

        SDL_PIXELFORMAT_INDEX1LSB = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_INDEX1 << 24 ) |
                                     ( SDL_BitmapOrder.SDL_BITMAPORDER_4321 << 20 ) | ( 0 << 16 ) | ( 1 << 8 ) | ( 0 << 0 ) ),

        SDL_PIXELFORMAT_INDEX1MSB = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_INDEX1 << 24 ) |
                                     ( SDL_BitmapOrder.SDL_BITMAPORDER_1234 << 20 ) | ( 0 << 16 ) | ( 1 << 8 ) | ( 0 << 0 ) ),

        SDL_PIXELFORMAT_INDEX4LSB = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_INDEX4 << 24 ) |
                                     ( SDL_BitmapOrder.SDL_BITMAPORDER_4321 << 20 ) | ( 0 << 16 ) | ( 4 << 8 ) | ( 0 << 0 ) ),

        SDL_PIXELFORMAT_INDEX4MSB = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_INDEX4 << 24 ) |
                                     ( SDL_BitmapOrder.SDL_BITMAPORDER_1234 << 20 ) | ( 0 << 16 ) | ( 4 << 8 ) | ( 0 << 0 ) ),

        SDL_PIXELFORMAT_INDEX8 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_INDEX8 << 24 ) | ( 0 << 20 ) | ( 0 << 16 ) |
                                  ( 8 << 8 ) | ( 1 << 0 ) ),

        SDL_PIXELFORMAT_RGB332 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED8 << 24 ) |
                                  ( SDL_PackedOrder.SDL_PACKEDORDER_XRGB << 20 ) |
                                  ( SDL_PackedLayout.SDL_PACKEDLAYOUT_332 << 16 ) | ( 8 << 8 ) | ( 1 << 0 ) ),

        SDL_PIXELFORMAT_XRGB4444 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED16 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_XRGB << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_4444 << 16 ) | ( 12 << 8 ) | ( 2 << 0 ) ),
        SDL_PIXELFORMAT_RGB444 = SDL_PIXELFORMAT_XRGB4444,

        SDL_PIXELFORMAT_XBGR4444 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED16 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_XBGR << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_4444 << 16 ) | ( 12 << 8 ) | ( 2 << 0 ) ),
        SDL_PIXELFORMAT_BGR444 = SDL_PIXELFORMAT_XBGR4444,

        SDL_PIXELFORMAT_XRGB1555 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED16 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_XRGB << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_1555 << 16 ) | ( 15 << 8 ) | ( 2 << 0 ) ),
        SDL_PIXELFORMAT_RGB555 = SDL_PIXELFORMAT_XRGB1555,

        SDL_PIXELFORMAT_XBGR1555 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED16 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_XBGR << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_1555 << 16 ) | ( 15 << 8 ) | ( 2 << 0 ) ),
        SDL_PIXELFORMAT_BGR555 = SDL_PIXELFORMAT_XBGR1555,

        SDL_PIXELFORMAT_ARGB4444 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED16 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_ARGB << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_4444 << 16 ) | ( 16 << 8 ) | ( 2 << 0 ) ),

        SDL_PIXELFORMAT_RGBA4444 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED16 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_RGBA << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_4444 << 16 ) | ( 16 << 8 ) | ( 2 << 0 ) ),

        SDL_PIXELFORMAT_ABGR4444 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED16 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_ABGR << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_4444 << 16 ) | ( 16 << 8 ) | ( 2 << 0 ) ),

        SDL_PIXELFORMAT_BGRA4444 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED16 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_BGRA << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_4444 << 16 ) | ( 16 << 8 ) | ( 2 << 0 ) ),

        SDL_PIXELFORMAT_ARGB1555 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED16 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_ARGB << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_1555 << 16 ) | ( 16 << 8 ) | ( 2 << 0 ) ),

        SDL_PIXELFORMAT_RGBA5551 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED16 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_RGBA << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_5551 << 16 ) | ( 16 << 8 ) | ( 2 << 0 ) ),

        SDL_PIXELFORMAT_ABGR1555 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED16 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_ABGR << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_1555 << 16 ) | ( 16 << 8 ) | ( 2 << 0 ) ),

        SDL_PIXELFORMAT_BGRA5551 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED16 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_BGRA << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_5551 << 16 ) | ( 16 << 8 ) | ( 2 << 0 ) ),

        SDL_PIXELFORMAT_RGB565 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED16 << 24 ) |
                                  ( SDL_PackedOrder.SDL_PACKEDORDER_XRGB << 20 ) |
                                  ( SDL_PackedLayout.SDL_PACKEDLAYOUT_565 << 16 ) | ( 16 << 8 ) | ( 2 << 0 ) ),

        SDL_PIXELFORMAT_BGR565 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED16 << 24 ) |
                                  ( SDL_PackedOrder.SDL_PACKEDORDER_XBGR << 20 ) |
                                  ( SDL_PackedLayout.SDL_PACKEDLAYOUT_565 << 16 ) | ( 16 << 8 ) | ( 2 << 0 ) ),

        SDL_PIXELFORMAT_RGB24 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_ARRAYU8 << 24 ) |
                                 ( SDL_ArrayOrder.SDL_ARRAYORDER_RGB << 20 ) | ( 0 << 16 ) | ( 24 << 8 ) | ( 3 << 0 ) ),

        SDL_PIXELFORMAT_BGR24 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_ARRAYU8 << 24 ) |
                                 ( SDL_ArrayOrder.SDL_ARRAYORDER_BGR << 20 ) | ( 0 << 16 ) | ( 24 << 8 ) | ( 3 << 0 ) ),

        SDL_PIXELFORMAT_XRGB8888 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED32 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_XRGB << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_8888 << 16 ) | ( 24 << 8 ) | ( 4 << 0 ) ),
        SDL_PIXELFORMAT_RGB888 = SDL_PIXELFORMAT_XRGB8888,

        SDL_PIXELFORMAT_RGBX8888 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED32 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_RGBX << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_8888 << 16 ) | ( 24 << 8 ) | ( 4 << 0 ) ),

        SDL_PIXELFORMAT_XBGR8888 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED32 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_XBGR << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_8888 << 16 ) | ( 24 << 8 ) | ( 4 << 0 ) ),
        SDL_PIXELFORMAT_BGR888 = SDL_PIXELFORMAT_XBGR8888,

        SDL_PIXELFORMAT_BGRX8888 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED32 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_BGRX << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_8888 << 16 ) | ( 24 << 8 ) | ( 4 << 0 ) ),

        SDL_PIXELFORMAT_ARGB8888 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED32 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_ARGB << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_8888 << 16 ) | ( 32 << 8 ) | ( 4 << 0 ) ),

        SDL_PIXELFORMAT_RGBA8888 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED32 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_RGBA << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_8888 << 16 ) | ( 32 << 8 ) | ( 4 << 0 ) ),

        SDL_PIXELFORMAT_ABGR8888 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED32 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_ABGR << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_8888 << 16 ) | ( 32 << 8 ) | ( 4 << 0 ) ),

        SDL_PIXELFORMAT_BGRA8888 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED32 << 24 ) |
                                    ( SDL_PackedOrder.SDL_PACKEDORDER_BGRA << 20 ) |
                                    ( SDL_PackedLayout.SDL_PACKEDLAYOUT_8888 << 16 ) | ( 32 << 8 ) | ( 4 << 0 ) ),

        SDL_PIXELFORMAT_ARGB2101010 = ( ( 1 << 28 ) | ( SDL_PixelType.SDL_PIXELTYPE_PACKED32 << 24 ) |
                                       ( SDL_PackedOrder.SDL_PACKEDORDER_ARGB << 20 ) |
                                       ( SDL_PackedLayout.SDL_PACKEDLAYOUT_2101010 << 16 ) | ( 32 << 8 ) | ( 4 << 0 ) ),
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_Color
    {
        public byte R;
        public byte G;
        public byte B;
        public byte A;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_Palette
    {
        public int NColors;
        public IntPtr Colors;
        public uint Version;
        public int RefCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_PixelFormat
    {
        public uint Format;
        public IntPtr Palette;
        public byte BitsPerPixel;
        public byte BytesPerPixel;
        private byte Padding1;
        private byte Padding2;
        public uint RMask;
        public uint GMask;
        public uint BMask;
        public uint AMask;
        public byte RLoss;
        public byte GLoss;
        public byte BLoss;
        public byte ALoss;
        public byte RShift;
        public byte GShift;
        public byte BShift;
        public byte AShift;
        public int RefCount;
        public IntPtr Next;
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPixelFormatName")]
    private static extern IntPtr _SDL_GetPixelFormatName(uint format);
    ///<summary>Get the human readable name of a pixel format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetPixelFormatName">SDL2 Documentation</a></remarks>
    public static string SDL_GetPixelFormatName(uint format) => PtrToManaged(_SDL_GetPixelFormatName(format));
    ///<summary>Convert one of the enumerated pixel formats to a bpp value and RGBA masks.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_PixelFormatEnumToMasks">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_PixelFormatEnumToMasks(uint format, ref int bpp, out uint rMask, out uint gMask,
            out uint bMask, out uint aMask);
    ///<summary>Convert a bpp value and RGBA masks to an enumerated pixel format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_MasksToPixelFormatEnum">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_MasksToPixelFormatEnum(int bpp, uint rMask, uint gMask, uint bMask, uint aMask);
    ///<summary>Create an SDL_PixelFormat structure corresponding to a pixel format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_AllocFormat">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_AllocFormat(uint pixelFormat);
    ///<summary>Free an SDL_PixelFormat structure allocated by SDL_AllocFormat().</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_FreeFormat">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_FreeFormat(IntPtr format);
    ///<summary>Create a palette structure with the specified number of color entries.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_AllocPalette">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_AllocPalette(int nColors);
    ///<summary>Set the palette for a pixel format structure.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetPixelFormatPalette">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetPixelFormatPalette(IntPtr format, IntPtr palette);
    ///<summary>Set a range of colors in a palette.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetPaletteColors">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetPaletteColors(IntPtr palette, [In] SDL_Color[] colors, int firstColor, int nColors);
    ///<summary>Free a palette created with SDL_AllocPalette().</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_FreePalette">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_FreePalette(IntPtr palette);
    ///<summary>Map an RGB triple to an opaque pixel value for a given pixel format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_MapRGB">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_MapRGB(in SDL_PixelFormat format, byte r, byte g, byte b);
    ///<summary>Map an RGBA quadruple to a pixel value for a given pixel format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_MapRGBA">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_MapRGBA(in SDL_PixelFormat format, byte r, byte g, byte b, byte a);
    ///<summary>Get RGB values from a pixel in the specified format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetRGB">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GetRGB(uint pixel, in SDL_PixelFormat format, out byte r, out byte g, out byte b);
    ///<summary>Get RGBA values from a pixel in the specified format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetRGBA">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GetRGBA(uint pixel, in SDL_PixelFormat format, out byte r, out byte g, out byte b,
            out byte a);
    ///<summary>Calculate a 256 entry gamma ramp for a gamma value.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_CalculateGammaRamp">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_CalculateGammaRamp(float gamma, [Out] ushort[] ramp);
}
