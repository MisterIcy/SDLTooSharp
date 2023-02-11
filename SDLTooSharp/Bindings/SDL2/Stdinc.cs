using System.Runtime.InteropServices;
#pragma warning disable CS1591
namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    ///<summary></summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_FOURCC">SDL2 Documentation</a></remarks>
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
    ///<summary></summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_malloc">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_malloc(long size);
    ///<summary></summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_realloc">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_realloc(IntPtr mem, long size);
    ///<summary></summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_free">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_free(IntPtr mem);
    ///<summary>Get the number of outstanding (unfreed) allocations</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetNumAllocations">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetNumAllocations();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_getenv")]
    private static extern IntPtr _SDL_getenv([MarshalAs(UnmanagedType.LPUTF8Str)] string name);
    ///<summary></summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_getenv">SDL2 Documentation</a></remarks>
    public static string SDL_getenv(string name) => PtrToManaged(_SDL_getenv(name), true);
    ///<summary></summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_setenv">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_setenv([MarshalAs(UnmanagedType.LPUTF8Str)] string name,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string value, int overwrite);
}
