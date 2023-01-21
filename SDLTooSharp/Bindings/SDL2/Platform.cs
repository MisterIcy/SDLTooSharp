using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPlatform")]
    private static extern IntPtr _SDL_GetPlatform();
    ///<summary>Get the name of the platform.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetPlatform">SDL2 Documentation</a></remarks>
    public static string SDL_GetPlatform() => PtrToManaged(_SDL_GetPlatform());
}
