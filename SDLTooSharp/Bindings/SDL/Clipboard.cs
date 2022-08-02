using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings;

public static partial class SDL2
{
    /// <summary>
    /// Put text into the clipboard.
    /// </summary>
    /// <param name="text">The text to be put into the clipboard</param>
    /// <returns>0 on success, a negative error code on failure</returns>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    [SDLVersion(2, 0, 0)]
    [Category("Clipboard")]
    public static extern int SDL_SetClipboardText([In] [MarshalAs(UnmanagedType.LPUTF8Str)] string text);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetClipboardText")]
    private static extern IntPtr _SDL_GetClipboardText();

    /// <summary>
    /// Gets text from the clipboard.
    /// </summary>
    /// <returns>The text in the clipboard, or an empty string on failure.</returns>
    [SDLVersion(2, 0, 0)]
    [Category("Clipboard")]
    public static string SDL_GetClipboardText()
    {
        return Marshaller.CharToManaged(_SDL_GetClipboardText(), true);
    }

    /// <summary>
    /// Checks whether the clipboard contains text
    /// </summary>
    /// <returns>True if the clipboard contains text, otherwise false.</returns>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    [SDLVersion(2, 0, 0)]
    [Category("Clipboard")]
    public static extern bool SDL_HasClipboardText();
}