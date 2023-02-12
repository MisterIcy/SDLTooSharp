using System.Runtime.InteropServices;
#pragma warning disable CS1591
namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    public const int SDL_SWSURFACE = 0;
    public const int SDL_PREALLOC = 0x00000001;
    public const int SDL_RLEACCEL = 0x00000002;
    public const int SDL_DONTFREE = 0x00000004;
    public const int SDL_SIMD_ALIGNED = 0x00000008;

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_Surface
    {
        public uint Flags;
        public IntPtr Format;
        public int W;
        public int H;
        public int Pitch;
        public IntPtr Pixels;
        public IntPtr UserDta;
        public int Locked;
        private IntPtr ListBlitMap;
        public SDL_Rect ClipRect;
        private IntPtr Map;
        public int RefCount;
    }

    public enum SDL_YUV_CONVERSION_MODE
    {
        SDL_YUV_CONVERSION_JPEG,
        SDL_YUV_CONVERSION_BT601,
        SDL_YUV_CONVERSION_BT709,
        SDL_YUV_CONVERSION_AUTOMATIC
    }
    ///<summary>Allocate a new RGB surface.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_CreateRGBSurface">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateRGBSurface(int flags, int width, int height, int depth, uint rMask,
            uint gMask, uint bMask, uint aMask);
    ///<summary>Allocate a new RGB surface with a specific pixel format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_CreateRGBSurfaceWithFormat">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateRGBSurfaceWithFormat(uint flags, int width, int height, int depth,
            uint format);
    ///<summary>Allocate a new RGB surface with existing pixel data.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_CreateRGBSurfaceFrom">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateRGBSurfaceFrom(IntPtr pixels, int width, int height, int depth, int pitch,
            uint rMask, uint gMask, uint bMask, uint aMask);
    ///<summary>Allocate a new RGB surface with with a specific pixel format and existing pixel data.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_CreateRGBSurfaceWithFormatFrom">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateRGBSurfaceWithFormatFrom(IntPtr pixels, int width, int height, int depth,
            int pitch, uint format);
    ///<summary>Free an RGB surface.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_FreeSurface">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_FreeSurface(IntPtr surface);
    ///<summary>Set the palette used by a surface.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetSurfacePalette">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetSurfacePalette(IntPtr surface, IntPtr palette);
    ///<summary>Set up a surface for directly accessing the pixels.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LockSurface">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_LockSurface(IntPtr surface);
    ///<summary>Release a surface after directly accessing the pixels.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_UnlockSurface">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_UnlockSurface(IntPtr surface);
    ///<summary>Load a BMP image from a seekable SDL data stream.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LoadBMP_RW">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_LoadBMP_RW(IntPtr src, int freeSrc);
    ///<summary>Load a BMP image from a file path.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LoadBMP">SDL2 Documentation</a></remarks>
    public static IntPtr SDL_LoadBMP(string file) => SDL_LoadBMP_RW(
            SDL_RWFromFile(file, "rb"), 1);
    ///<summary>Save a surface to a seekable SDL data stream in BMP format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SaveBMP_RW">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SaveBMP_RW(IntPtr surface, IntPtr dst, int freeDst);
    ///<summary>Save a surface to a seekable SDL data stream in BMP format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SaveBMP_RW">SDL2 Documentation</a></remarks>
    public static int SDL_SaveBMP_RW(IntPtr surface, string file) =>
            SDL_SaveBMP_RW(surface, SDL_RWFromFile(file, "wb"), 1);
    ///<summary>Set the RLE acceleration hint for a surface.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetSurfaceRLE">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetSurfaceRLE(IntPtr surface, int flag);
    ///<summary>Returns whether the surface is RLE enabled</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasSurfaceRLE">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasSurfaceRLE(IntPtr surface);
    ///<summary>Set the color key (transparent pixel) in a surface.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetColorKey">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetColorKey(IntPtr surface, int flag, uint key);
    ///<summary>Returns whether the surface has a color key</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasColorKey">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasColorKey(IntPtr surface);
    ///<summary>Get the color key (transparent pixel) for a surface.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetColorKey">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetColorKey(IntPtr surface, out uint key);
    ///<summary>Set an additional color value multiplied into blit operations.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetSurfaceColorMod">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetSurfaceColorMod(IntPtr surface, byte r, byte g, byte b);
    ///<summary>Get the additional color value multiplied into blit operations.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetSurfaceColorMod">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetSurfaceColorMod(IntPtr surface, out byte r, out byte g, out byte b);
    ///<summary>Set an additional alpha value used in blit operations.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetSurfaceAlphaMod">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetSurfaceAlphaMod(IntPtr surface, byte alpha);
    ///<summary>Get the additional alpha value used in blit operations.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetSurfaceAlphaMod">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetSurfaceAlphaMod(IntPtr surface, out byte alpha);
    ///<summary>Set the blend mode used for blit operations.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetSurfaceBlendMode">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetSurfaceBlendMode(IntPtr surface, SDL_BlendMode blendMode);
    ///<summary>Get the blend mode used for blit operations.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetSurfaceBlendMode">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetSurfaceBlendMode(IntPtr surface, out SDL_BlendMode blendMode);
    ///<summary>Set the clipping rectangle for a surface.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetClipRect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetClipRect(IntPtr surface, in SDL_Rect rect);
    ///<summary>Get the clipping rectangle for a surface.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetClipRect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GetClipRect(IntPtr surface, out SDL_Rect rect);
    ///<summary></summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_DuplicateSurface">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_DuplicateSurface(IntPtr surface);
    ///<summary>Copy an existing surface to a new surface of the specified format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_ConvertSurface">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_ConvertSurface(IntPtr src, IntPtr format, uint flags);
    ///<summary>Copy an existing surface to a new surface of the specified format enum.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_ConvertSurfaceFormat">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_ConvertSurfaceFormat(IntPtr src, uint pixelFormat, uint flags);
    ///<summary>Copy a block of pixels of one format to another format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_ConvertPixels">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_ConvertPixels(int width, int height, uint srcFormat, IntPtr src, int srcPitch,
            uint dstFormat, IntPtr dst, int dstPitch);
    ///<summary>Premultiply the alpha on a block of pixels.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_PremultiplyAlpha">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_PremultiplyAlpha(int width, int height, uint srcFormat, IntPtr src, int srcPitch,
            uint dstFormat, IntPtr dst, int dstPitch);
    ///<summary>Perform a fast fill of a rectangle with a specific color.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_FillRect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_FillRect(IntPtr dst, in SDL_Rect rect, uint color);
    ///<summary>Perform a fast fill of a set of rectangles with a specific color.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_FillRects">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_FillRects(IntPtr dst, [In][MarshalAs(UnmanagedType.LPArray)] SDL_Rect[] rects, int count, uint color);
    ///<summary>Perform a fast blit from the source surface to the destination surface.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_UpperBlit">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_UpperBlit(IntPtr src, in SDL_Rect srcRect, IntPtr dst, ref SDL_Rect dstRect);
    ///<summary>Use this function to perform a fast surface copy to a destination surface.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_BlitSurface">SDL2 Documentation</a></remarks>
    public static int SDL_BlitSurface(IntPtr src, in SDL_Rect srcRect, IntPtr dst, ref SDL_Rect dstRect) =>
            SDL_UpperBlit(src, in srcRect, dst, ref dstRect);
    ///<summary>Perform low-level surface blitting only.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LowerBlit">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_LowerBlit(IntPtr src, ref SDL_Rect srcRect, IntPtr dst, ref SDL_Rect dstRect);
    ///<summary>Perform a fast, low quality, stretch blit between two surfaces of the same format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SoftStretch">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SoftStretch(IntPtr src, in SDL_Rect srcRect, IntPtr dst, in SDL_Rect dstRect);
    ///<summary>Perform bilinear scaling between two surfaces of the same format, 32BPP.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SoftStretchLinear">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SoftStretchLinear(IntPtr src, in SDL_Rect srcRect, IntPtr dst, in SDL_Rect dstRect);
    ///<summary>Perform a scaled surface copy to a destination surface.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_UpperBlitScaled">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_UpperBlitScaled(IntPtr src, in SDL_Rect srcRect, IntPtr dst, ref SDL_Rect dstRect);
    ///<summary>Use this function to perform a scaled surface copy to a destination surface.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_BlitScaled">SDL2 Documentation</a></remarks>
    public static int SDL_BlitScaled(IntPtr src, in SDL_Rect srcRect, IntPtr dst, ref SDL_Rect dstRect) =>
            SDL_UpperBlitScaled(src, in srcRect, dst, ref dstRect);
    ///<summary>Perform low-level surface scaled blitting only.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LowerBlitScaled">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_LowerBlitScaled(IntPtr src, ref SDL_Rect srcRect, IntPtr dst, ref SDL_Rect dstRect);
    ///<summary>Set the YUV conversion mode</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetYUVConversionMode">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetYUVConversionMode(SDL_YUV_CONVERSION_MODE mode);
    ///<summary>Get the YUV conversion mode</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetYUVConversionMode">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_YUV_CONVERSION_MODE SDL_GetYUVConversionMode();
    ///<summary>Get the YUV conversion mode, returning the correct mode for the resolution when the current conversion mode is SDL_YUV_CONVERSION_AUTOMATIC</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetYUVConversionModeForResolution">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_YUV_CONVERSION_MODE SDL_GetYUVConversionModeForResolution(int width, int height);
}
