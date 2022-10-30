using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    public static uint SDL_FOURCC(uint a, uint b, uint c, uint d)
    {
        return (uint)( ( (byte)( a ) << 0 ) |
                      ( (byte)( b ) << 8 ) |
                      ( (byte)( c ) << 16 ) |
                      ( (byte)( d ) << 24 ) );
    }

    public const int SDL_FALSE = 0;
    public const int SDL_TRUE = 1;

    public enum SDL_bool
    {
        SDL_FALSE = 0,
        SDL_TRUE = 1,
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_malloc(long size);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_realloc(IntPtr mem, long size);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_free(IntPtr mem);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetNumAllocations();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_getenv")]
    private static extern IntPtr _SDL_getenv([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    public static string SDL_getenv(string name) => PtrToManaged(_SDL_getenv(name), true);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_setenv([MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string value, int overwrite);
}
