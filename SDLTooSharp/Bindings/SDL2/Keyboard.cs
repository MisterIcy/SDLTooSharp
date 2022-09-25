using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_Keysym
    {
        public SDL_Scancode ScanCode;
        public SDL_KeyCode Sym;
        public ushort Mod;
        private uint Unused;
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetKeyboardFocus();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetKeyboardState(out int numKeys);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_ResetKeyboard();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_Keymod SDL_GetModState();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetModState(SDL_Keymod modState);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_KeyCode SDL_GetKeyFromScancode(SDL_Scancode scancode);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_Scancode SDL_GetScancodeFromKey(SDL_KeyCode key);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetScancodeName")]
    private static extern IntPtr _SDL_GetScancodeName(SDL_Scancode scancode);

    public static string SDL_GetScancodeName(SDL_Scancode scancode) =>
        PtrToManaged(_SDL_GetScancodeName(scancode));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_Scancode SDL_GetScancodeFromName([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetKeyName")]
    private static extern IntPtr _SDL_GetKeyName(SDL_KeyCode key);

    public static string SDL_GetKeyName(SDL_KeyCode key) =>
        PtrToManaged(_SDL_GetKeyName(key));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_KeyCode SDL_GetKeyFromName([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_StartTextInput();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IsTextInputActive();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_StopTextInput();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_ClearComposition();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IsTextInputShown();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetTextInputRect(in SDL_Rect rect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasScreenKeyboardSupport();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IsScreenKeyboardShown(IntPtr window);
}
