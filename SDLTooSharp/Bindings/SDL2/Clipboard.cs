using System.Runtime.InteropServices;
#pragma warning disable CS1591
namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    ///<summary>Put UTF-8 text into the clipboard.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetClipboardText">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetClipboardText([MarshalAs(UnmanagedType.LPUTF8Str)] string text);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetClipboardText")]
    private static extern IntPtr _SDL_GetClipboardText();
    ///<summary>Get UTF-8 text from the clipboard, which must be freed with SDL_free().</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetClipboardText">SDL2 Documentation</a></remarks>
    public static string SDL_GetClipboardText() => PtrToManaged(_SDL_GetClipboardText(), true);
    ///<summary>Query whether the clipboard exists and contains a non-empty text string.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasClipboardText">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasClipboardText();
    ///<summary>Put UTF-8 text into the primary selection.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetPrimarySelectionText">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetPrimarySelectionText([MarshalAs(UnmanagedType.LPUTF8Str)] string text);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPrimarySelectionText")]
    private static extern IntPtr _SDL_GetPrimarySelectionText();
    ///<summary>Get UTF-8 text from the primary selection, which must be freed with SDL_free().</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetPrimarySelectionText">SDL2 Documentation</a></remarks>
    public static string SDL_GetPrimarySelectionText() => PtrToManaged(_SDL_GetPrimarySelectionText(), true);
    ///<summary>Query whether the primary selection exists and contains a non-empty text string.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasPrimarySelectionText">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasPrimarySelectionText();
}
