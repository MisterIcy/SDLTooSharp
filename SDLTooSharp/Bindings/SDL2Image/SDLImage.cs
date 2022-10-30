using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Bindings.SDL2Image;

[ExcludeFromCodeCoverage]
public static partial class SDLImage
{
    private const string dllName = "SDL2_image";

    public enum IMG_InitFlags
    {
        IMG_INIT_JPG = 0x00000001,
        IMG_INIT_PNG = 0x00000002,
        IMG_INIT_TIF = 0x00000004,
        IMG_INIT_WEBP = 0x00000008,
        IMG_INIT_JXL = 0x00000010,
        IMG_INIT_AVIF = 0x00000020
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "IMG_Linked_Version")]
    private static extern IntPtr _IMG_Linked_Version();

    public static SDL.SDL_version IMG_Linked_Version()
    {
        IntPtr version = _IMG_Linked_Version();
        return Marshal.PtrToStructure<SDL.SDL_version>(version);
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_Init(int flags);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void IMG_Quit();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadTyped_RW(IntPtr src, int freeSrc,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string type);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_Load([MarshalAs(UnmanagedType.LPUTF8Str)] string file);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_Load_RW(IntPtr src, int freeSrc);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadTexture(IntPtr renderer, [MarshalAs(UnmanagedType.LPUTF8Str)] string file);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadTexture_RW(IntPtr renderer, IntPtr src, int freeSrc);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadTextureTyped_RW(IntPtr renderer, IntPtr src, int freeSrc,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string type);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_isAVIF(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_isICO(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_isCUR(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_isBMP(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_isGIF(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_isJPG(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_isJXL(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_isLBM(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_isPCX(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_isPNG(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_isPNM(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_isSVG(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_isQOI(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_isTIF(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_isXCF(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_isXPM(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_isXV(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_isWEBP(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadAVIF_RW(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadICO_RW(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadCUR_RW(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadBMP_RW(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadGIF_RW(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadJPG_RW(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadJXL_RW(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadLBM_RW(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadPCX_RW(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadPNG_RW(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadPNM_RW(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadSVG_RW(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadQOI_RW(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadTGA_RW(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadTIF_RW(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadXCF_RW(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadXPM_RW(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadXV_RW(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadWEBP_RW(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadSizedSVG_RW(IntPtr src, int width, int height);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_SavePNG(IntPtr surface, [MarshalAs(UnmanagedType.LPUTF8Str)] string file);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_SavePNG_RW(IntPtr surface, IntPtr dst, int freeDst);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_SaveJPG(IntPtr surface, [MarshalAs(UnmanagedType.LPUTF8Str)] string file, int quality);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int IMG_SaveJPG_RW(IntPtr surface, IntPtr dst, int freeDst, int quality);

    [StructLayout(LayoutKind.Sequential)]
    public struct IMG_Animation
    {
        public int W;
        public int H;
        public int Count;
        public IntPtr Frames;
        public IntPtr Delays;
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadAnimation([MarshalAs(UnmanagedType.LPUTF8Str)] string file);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadAnimation_RW(IntPtr src, int freeSrc);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadAnimationTyped_RW(IntPtr src, int freeSrc,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string type);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void IMG_FreeAnimation(IntPtr animation);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr IMG_LoadGIFAnimation_RW(IntPtr src);

    public static int IMG_SetError(string error) => SDL2.SDL.SDL_SetError(error);
    public static string IMG_GetError() => SDL2.SDL.SDL_GetError();
}
