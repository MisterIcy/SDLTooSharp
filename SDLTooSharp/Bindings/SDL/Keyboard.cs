using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings;

public static partial class SDL2
{
    /// <summary>
    /// The SDL Keysym structure
    /// </summary>
    public struct SDL_Keysym
    {
        /// <summary>
        /// SDL Physical key code
        /// </summary>
        /// <see cref="SDL_Scancode"/>
        public SDL_Scancode Scancode;

        /// <summary>
        /// SDL Virtual key code
        /// </summary>
        /// <see cref="SDL_Keycode"/>
        public SDL_Keycode Sym;

        /// <summary>
        /// Current key modifiers
        /// </summary>
        /// <see cref="SDL_Keymod"/>
        public ushort Mod;

        private uint _unused;
    }

    /// <summary>
    /// Query the window which currently has keyboard focus
    /// </summary>
    /// <returns>The window with keyboard focus</returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetKeyboardFocus();

    /// <summary>
    /// Get a snapshot of the current state of the keyboard
    /// </summary>
    /// <param name="numKeys">The length of the returned array</param>
    /// <returns>A pointer to an array of key states</returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetKeyboardState(out int numKeys);

    /// <summary>
    /// Clear the state of the keyboard
    /// </summary>
    [SDLVersion(2, 24, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_ResetKeyboard();

    /// <summary>
    /// Get the current key modifier state for the keyboard
    /// </summary>
    /// <returns>An ORed combination of the modifier keys</returns>
    /// <seealso cref="SDL_Keymod"/>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_Keymod SDL_GetModState();

    /// <summary>
    /// Set the current key modifier state.
    /// </summary>
    /// <param name="modState">An ORed combination of the modifier keys</param>
    /// <seealso cref="SDL_Keymod"/>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetModState(SDL_Keymod modState);

    /// <summary>
    /// Get a keycode corresponding to the given scancode.
    /// </summary>
    /// <param name="scancode"></param>
    /// <returns></returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_Keycode SDL_GetKeyFromScancode(SDL_Scancode scancode);

    /// <summary>
    /// Get the scancode corresponding to the given key code.
    /// </summary>
    /// <param name="keycode"></param>
    /// <returns></returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_Scancode SDL_GetScancodeFromKey(SDL_Keycode keycode);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetScancodeName")]
    private static extern IntPtr _SDL_GetScancodeName(SDL_Scancode scancode);

    /// <summary>
    /// Get a human readable name for a scancode
    /// </summary>
    /// <param name="scancode"></param>
    /// <returns></returns>
    [SDLVersion(2, 0, 0)]
    public static string SDL_GetScancodeName(SDL_Scancode scancode)
    {
        return Marshaller.CharToManaged(_SDL_GetScancodeName(scancode));
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetScancodeFromName")]
    private static extern unsafe SDL_Scancode _SDL_GetScancodeFromName(byte* name);

    /// <summary>
    /// Get the scancode corresponding to the given key code.
    /// </summary>
    /// <param name="name">The desired scancode to query</param>
    /// <returns>The scancode that corresponds to the key code</returns>
    [SDLVersion(2, 0, 0)]
    public static unsafe SDL_Scancode SDL_GetScancodeFromName(string name)
    {
        var len = Marshaller.GetStringLengthInBytes(name);
        var buf = stackalloc byte[len];
        return _SDL_GetScancodeFromName(
            Marshaller.ManagedToChar(name, buf, len));
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetKeyName")]
    private static extern IntPtr _SDL_GetKeyName(SDL_Keycode key);

    /// <summary>
    /// Get a human readable name for a key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    [SDLVersion(2, 0, 0)]
    public static string SDL_GetKeyName(SDL_Keycode key)
    {
        return Marshaller.CharToManaged(_SDL_GetKeyName(key));
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetKeyFromName")]
    private static extern unsafe SDL_Keycode _SDL_GetKeyFromName(byte* name);

    /// <summary>
    /// Get a key code from a human-readable name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [SDLVersion(2, 0, 0)]
    public static unsafe SDL_Keycode SDL_GetKeyFromName(string name)
    {
        var len = Marshaller.GetStringLengthInBytes(name);
        var buf = stackalloc byte[len];
        return _SDL_GetKeyFromName(
            Marshaller.ManagedToChar(name, buf, len)
        );
    }

    /// <summary>
    /// Start accepting Unicode text input events.
    /// </summary>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_StartTextInput();

    /// <summary>
    /// Check whether or not Unicode text input events are enabled
    /// </summary>
    /// <returns></returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IsTextInputActive();

    /// <summary>
    /// Stop receiving any text input events
    /// </summary>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_StopTextInput();

    /// <summary>
    /// Dismiss the composition window/IME without disabling the subsystem.
    /// </summary>
    [SDLVersion(2, 0, 22)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_ClearComposition();

    /// <summary>
    /// Returns if an IME Composite or Candidate window is currently shown
    /// </summary>
    /// <returns></returns>
    [SDLVersion(2, 0, 22)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IsTextInputShown();

    /// <summary>
    /// Set the rectangle used to type Unicode text inputs
    /// </summary>
    /// <param name="rect"></param>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetTextInputRect(IntPtr rect); //TODO: Implement SDL_Rect

    /// <summary>
    /// Check whether the platform has screen keyboard support
    /// </summary>
    /// <returns></returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasScreenKeyboardSupport();

    /// <summary>
    /// Check whether the screen keyboard is shown for given window
    /// </summary>
    /// <param name="window"></param>
    /// <returns></returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IsScreenKeyboardShown(IntPtr window);
}