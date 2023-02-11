using System.Runtime.InteropServices;
#pragma warning disable CS1591
namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    ///<summary>Set the SDL error message for the current thread.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetError">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetError([MarshalAs(UnmanagedType.LPUTF8Str)] string error);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetError")]
    private static extern IntPtr _SDL_GetError();
    ///<summary>Retrieve a message about the last error that occurred on the current thread.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetError">SDL2 Documentation</a></remarks>
    public static string SDL_GetError() => PtrToManaged(_SDL_GetError());
    ///<summary>Clear any previous error message for this thread.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_ClearError">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_ClearError();
}
