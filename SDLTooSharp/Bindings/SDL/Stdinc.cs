using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings;

public static partial class SDL2
{
    /// <summary>
    /// Define a four character code as an uint
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    public static uint SDL_FOURCC(byte a, byte b, byte c, byte d)
    {
        return (uint) ((a << 0) | (b << 8) | (c << 16) | (d << 24));
    }

    public const int SDL_FALSE = 0;
    public const int SDL_TRUE = 0;

    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr SDL_malloc(long size);

    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    internal static extern IntPtr SDL_realloc(IntPtr mem, long size);

    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    internal static extern void SDL_free(IntPtr mem);
}