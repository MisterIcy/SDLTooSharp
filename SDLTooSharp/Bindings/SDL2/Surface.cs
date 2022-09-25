using System.Runtime.InteropServices;

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

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateRGBSurface(int flags, int width, int height, int depth, uint rMask,
        uint gMask, uint bMask, uint aMask);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateRGBSurfaceWithFormat(uint flags, int width, int height, int depth,
        uint format);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateRGBSurfaceFrom(IntPtr pixels, int width, int height, int depth, int pitch,
        uint rMask, uint gMask, uint bMask, uint aMask);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateRGBSurfaceWithFormatFrom(IntPtr pixels, int width, int height, int depth,
        int pitch, uint format);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_FreeSurface(IntPtr surface);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetSurfacePalette(IntPtr surface, IntPtr palette);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_LockSurface(IntPtr surface);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_UnlockSurface(IntPtr surface);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_LoadBMP_RW(IntPtr src, int freeSrc);

    public static IntPtr SDL_LoadBMP(string file) => SDL_LoadBMP_RW(
        SDL_RWFromFile(file, "rb"), 1);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SaveBMP_RW(IntPtr surface, IntPtr dst, int freeDst);

    public static int SDL_SaveBMP_RW(IntPtr surface, string file) =>
        SDL_SaveBMP_RW(surface, SDL_RWFromFile(file, "wb"), 1);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetSurfaceRLE(IntPtr surface, int flag);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasSurfaceRLE(IntPtr surface);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetColorKey(IntPtr surface, int flag, uint key);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasColorKey(IntPtr surface);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetColorKey(IntPtr surface, out uint key);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetSurfaceColorMod(IntPtr surface, byte r, byte g, byte b);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetSurfaceColorMod(IntPtr surface, out byte r, out byte g, out byte b);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetSurfaceAlphaMod(IntPtr surface, byte alpha);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetSurfaceAlphaMod(IntPtr surface, out byte alpha);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetSurfaceBlendMode(IntPtr surface, SDL_BlendMode blendMode);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetSurfaceBlendMode(IntPtr surface, out SDL_BlendMode blendMode);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetClipRect(IntPtr surface, in SDL_Rect rect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GetClipRect(IntPtr surface, out SDL_Rect rect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_DuplicateSurface(IntPtr surface);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_ConvertSurface(IntPtr src, IntPtr format, uint flags);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_ConvertSurfaceFormat(IntPtr src, uint pixelFormat, uint flags);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_ConvertPixels(int width, int height, uint srcFormat, IntPtr src, int srcPitch,
        uint dstFormat, IntPtr dst, int dstPitch);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_PremultiplyAlpha(int width, int height, uint srcFormat, IntPtr src, int srcPitch,
        uint dstFormat, IntPtr dst, int dstPitch);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_FillRect(IntPtr dst, in SDL_Rect rect, uint color);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_FillRects(IntPtr dst, in SDL_Rect[] rects, int count, uint color);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_UpperBlit(IntPtr src, in SDL_Rect srcRect, IntPtr dst, ref SDL_Rect dstRect);

    public static int SDL_BlitSurface(IntPtr src, in SDL_Rect srcRect, IntPtr dst, ref SDL_Rect dstRect) =>
        SDL_UpperBlit(src, in srcRect, dst, ref dstRect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_LowerBlit(IntPtr src, ref SDL_Rect srcRect, IntPtr dst, ref SDL_Rect dstRect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SoftStretch(IntPtr src, in SDL_Rect srcRect, IntPtr dst, in SDL_Rect dstRect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SoftStretchLinear(IntPtr src, in SDL_Rect srcRect, IntPtr dst, in SDL_Rect dstRect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_UpperBlitScaled(IntPtr src, in SDL_Rect srcRect, IntPtr dst, ref SDL_Rect dstRect);

    public static int SDL_BlitScaled(IntPtr src, in SDL_Rect srcRect, IntPtr dst, ref SDL_Rect dstRect) =>
        SDL_UpperBlitScaled(src, in srcRect, dst, ref dstRect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_LowerBlitScaled(IntPtr src, ref SDL_Rect srcRect, IntPtr dst, ref SDL_Rect dstRect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetYUVConversionMode(SDL_YUV_CONVERSION_MODE mode);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_YUV_CONVERSION_MODE SDL_GetYUVConversionMode();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_YUV_CONVERSION_MODE SDL_GetYUVConversionModeForResolution(int width, int height);
}
