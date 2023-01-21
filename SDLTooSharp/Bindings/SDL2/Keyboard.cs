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

    ///<summary>Query the window which currently has keyboard focus.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetKeyboardFocus">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetKeyboardFocus();
    ///<summary>Get a snapshot of the current state of the keyboard.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetKeyboardState">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetKeyboardState(out int numKeys);
    ///<summary>Clear the state of the keyboard</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_ResetKeyboard">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_ResetKeyboard();
    ///<summary>Get the current key modifier state for the keyboard.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetModState">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_Keymod SDL_GetModState();
    ///<summary>Set the current key modifier state for the keyboard.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetModState">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetModState(SDL_Keymod modState);
    ///<summary>Get the key code corresponding to the given scancode according to the current keyboard layout.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetKeyFromScancode">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_KeyCode SDL_GetKeyFromScancode(SDL_Scancode scancode);
    ///<summary>Get the scancode corresponding to the given key code according to the current keyboard layout.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetScancodeFromKey">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_Scancode SDL_GetScancodeFromKey(SDL_KeyCode key);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetScancodeName")]
    private static extern IntPtr _SDL_GetScancodeName(SDL_Scancode scancode);
    ///<summary>Get a human-readable name for a scancode.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetScancodeName">SDL2 Documentation</a></remarks>
    public static string SDL_GetScancodeName(SDL_Scancode scancode) =>
        PtrToManaged(_SDL_GetScancodeName(scancode));
    ///<summary>Get a scancode from a human-readable name.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetScancodeFromName">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_Scancode SDL_GetScancodeFromName([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetKeyName")]
    private static extern IntPtr _SDL_GetKeyName(SDL_KeyCode key);
    ///<summary>Get a human-readable name for a key.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetKeyName">SDL2 Documentation</a></remarks>
    public static string SDL_GetKeyName(SDL_KeyCode key) =>
        PtrToManaged(_SDL_GetKeyName(key));
    ///<summary>Get a key code from a human-readable name.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetKeyFromName">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_KeyCode SDL_GetKeyFromName([MarshalAs(UnmanagedType.LPUTF8Str)] string name);
    ///<summary>Start accepting Unicode text input events.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_StartTextInput">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_StartTextInput();
    ///<summary>Check whether or not Unicode text input events are enabled.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_IsTextInputActive">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IsTextInputActive();
    ///<summary>Stop receiving any text input events.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_StopTextInput">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_StopTextInput();
    ///<summary>Dismiss the composition window/IME without disabling the subsystem.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_ClearComposition">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_ClearComposition();
    ///<summary>Returns if an IME Composite or Candidate window is currently shown.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_IsTextInputShown">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IsTextInputShown();
    ///<summary>Set the rectangle used to type Unicode text inputs.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetTextInputRect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetTextInputRect(in SDL_Rect rect);
    ///<summary>Check whether the platform has screen keyboard support.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasScreenKeyboardSupport">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasScreenKeyboardSupport();
    ///<summary>Check whether the screen keyboard is shown for given window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_IsScreenKeyboardShown">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IsScreenKeyboardShown(IntPtr window);
}
