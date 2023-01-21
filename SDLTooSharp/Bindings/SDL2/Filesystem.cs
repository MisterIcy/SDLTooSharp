using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetBasePath")]
    private static extern IntPtr _SDL_GetBasePath();
    ///<summary>Get the directory where the application was run from.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetBasePath">SDL2 Documentation</a></remarks>
    public static string SDL_GetBasePath() => PtrToManaged(_SDL_GetBasePath(), true);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPrefPath")]
    private static extern IntPtr _SDL_GetPrefPath(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string org,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string app
    );
    ///<summary>Get the user-and-app-specific path where files can be written.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetPrefPath">SDL2 Documentation</a></remarks>
    public static string SDL_GetPrefPath(string org, string app) => PtrToManaged(_SDL_GetPrefPath(org, app), true);
}
