using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetError([MarshalAs(UnmanagedType.LPUTF8Str)] string error);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetError")]
    private static extern IntPtr _SDL_GetError();

    public static string SDL_GetError() => PtrToManaged(_SDL_GetError());

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_ClearError();
}