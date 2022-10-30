using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetBasePath")]
    private static extern IntPtr _SDL_GetBasePath();

    public static string SDL_GetBasePath() => PtrToManaged(_SDL_GetBasePath(), true);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPrefPath")]
    private static extern IntPtr _SDL_GetPrefPath(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string org,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string app);

    public static string SDL_GetPrefPath(string org, string app) => PtrToManaged(_SDL_GetPrefPath(org, app), true);
}
