using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPlatform")]
    private static extern IntPtr _SDL_GetPlatform();

    public static string SDL_GetPlatform() => PtrToManaged(_SDL_GetPlatform());
}
