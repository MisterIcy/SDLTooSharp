using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetClipboardText([MarshalAs(UnmanagedType.LPUTF8Str)] string text);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetClipboardText")]
    private static extern IntPtr _SDL_GetClipboardText();

    public static string SDL_GetClipboardText() => PtrToManaged(_SDL_GetClipboardText(), true);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasClipboardText();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetPrimarySelectionText([MarshalAs(UnmanagedType.LPUTF8Str)] string text);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPrimarySelectionText")]
    private static extern IntPtr _SDL_GetPrimarySelectionText();

    public static string SDL_GetPrimarySelectionText() => PtrToManaged(_SDL_GetPrimarySelectionText(), true);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasPrimarySelectionText();
}