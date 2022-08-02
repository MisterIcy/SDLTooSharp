using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings;

public static partial class SDL2
{
    /// <summary>
    /// Cursor types for SDL_CreateSystemCursor
    /// </summary>
    public enum SDL_SystemCursor
    {
        /// <summary>
        /// Arrow
        /// </summary>
        SDL_SYSTEM_CURSOR_ARROW,

        /// <summary>
        /// I-beam
        /// </summary>
        SDL_SYSTEM_CURSOR_IBEAM,

        /// <summary>
        /// Wait
        /// </summary>
        SDL_SYSTEM_CURSOR_WAIT,

        /// <summary>
        /// Cross hair
        /// </summary>
        SDL_SYSTEM_CURSOR_CROSSHAIR,

        /// <summary>
        /// Small wait cursor
        /// </summary>
        SDL_SYSTEM_CURSOR_WAITARROW,

        /// <summary>
        /// Double arrow pointing NW and SE
        /// </summary>
        SDL_SYSTEM_CURSOR_SIZENWSE,

        /// <summary>
        /// Double arrow pointing NE and SW
        /// </summary>
        SDL_SYSTEM_CURSOR_SIZENESW,

        /// <summary>
        /// Double arrow pointing W and E
        /// </summary>
        SDL_SYSTEM_CURSOR_SIZEWE,

        /// <summary>
        /// Double arrow pointing N and S
        /// </summary>
        SDL_SYSTEM_CURSOR_SIZENS,

        /// <summary>
        /// Quad arrow pointing to all directions
        /// </summary>
        SDL_SYSTEM_CURSOR_SIZEALL,

        /// <summary>
        /// Slashed circle
        /// </summary>
        SDL_SYSTEM_CURSOR_NO,

        /// <summary>
        /// Hand
        /// </summary>
        SDL_SYSTEM_CURSOR_HAND,
        SDL_NUM_SYSTEM_CURSORS
    }

    /// <summary>
    /// Scroll direction types for mouse wheel.
    /// </summary>
    public enum SDL_MouseWheelDirection
    {
        /// <summary>
        /// Normal scroll direction
        /// </summary>
        SDL_MOUSEWHEEL_NORMAL,

        /// <summary>
        /// Natural / flipped scroll direction
        /// </summary>
        SDL_MOUSEWHEEL_FLIPPED
    }

    /// <summary>
    /// Get the windows which cas mouse focus
    /// </summary>
    /// <returns></returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetMouseFocus();

    /// <summary>
    /// Retrieve the current state of the Mouse
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_GetMouseState(out int x, out int y);

    /// <summary>
    /// Get the current state of the mouse in relation to the desktop.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_GetGlobalMouseState(out int x, out int y);

    /// <summary>
    /// Retrieve the relative state of the mouse.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_GetRelativeMouseState(out int x, out int y);

    /// <summary>
    /// Move the mouse cursor to the given position within the window
    /// </summary>
    /// <param name="window"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_WarpMouseInWindow(IntPtr window, int x, int y);

    /// <summary>
    /// Move the mouse to the given position in global screen space
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [SDLVersion(2, 0, 4)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_WarpMouseGlobal(int x, int y);

    /// <summary>
    /// Set relative mouse mode
    /// </summary>
    /// <param name="enabled"></param>
    /// <returns></returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetRelativeMouseMode(bool enabled);

    /// <summary>
    /// Capture the mouse and to track input outside an SDL window.
    /// </summary>
    /// <param name="enabled"></param>
    /// <returns></returns>
    [SDLVersion(2, 0, 4)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_CaptureMouse(bool enabled);

    /// <summary>
    /// Query whether relative mouse mode is enabled.
    /// </summary>
    /// <returns></returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GetRelativeMouseMode();

    /// <summary>
    /// Create a cursor using the specified bitmap data and mask (in MSB format).
    /// </summary>
    /// <param name="data"></param>
    /// <param name="mask"></param>
    /// <param name="w"></param>
    /// <param name="h"></param>
    /// <param name="hotX"></param>
    /// <param name="hotY"></param>
    /// <returns></returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateCursor(IntPtr data, IntPtr mask, int w, int h, int hotX, int hotY);

    /// <summary>
    /// Create a color cursor.
    /// </summary>
    /// <param name="surface"></param>
    /// <param name="hotX"></param>
    /// <param name="hotY"></param>
    /// <returns></returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateColorCursor(IntPtr surface, int hotX, int hotY);

    /// <summary>
    /// Create a system cursor
    /// </summary>
    /// <param name="cursorId"></param>
    /// <returns></returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateSystemCursor(SDL_SystemCursor cursorId);

    /// <summary>
    /// Set the active cursor
    /// </summary>
    /// <param name="cursor"></param>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetCursor(IntPtr cursor);

    /// <summary>
    /// Get the active cursor
    /// </summary>
    /// <returns></returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetCursor();

    /// <summary>
    /// Get the default cursor
    /// </summary>
    /// <returns></returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetDefaultCursor();

    /// <summary>
    /// Free a previously-created cursor
    /// </summary>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_FreeCursor();

    /// <summary>
    /// Toggle whether or not the cursor is shown
    /// </summary>
    /// <param name="toggle"></param>
    /// <returns></returns>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_ShowCursor(int toggle);

    /// <summary>
    /// Used to test buttons in button state
    /// </summary>
    /// <param name="mouseState">The state of the mouse</param>
    /// <param name="testState">The state to be tested</param>
    /// <returns></returns>
    public static bool SDL_Button(uint mouseState, uint testState)
    {
        return (1 << (int) (mouseState - 1)) == testState;
    }

    public const uint SDL_BUTTON_LEFT = 1;
    public const uint SDL_BUTTON_MIDDLE = 2;
    public const uint SDL_BUTTON_RIGHT = 3;
    public const uint SDL_BUTTON_X1 = 4;
    public const uint SDL_BUTTON_X2 = 5;

    public const uint SDL_BUTTON_LMASK = (1 << 0);
    public const uint SDL_BUTTON_MMASK = (1 << 1);
    public const uint SDL_BUTTON_RMASK = (1 << 2);
    public const uint SDL_BUTTON_X1MASK = (1 << 3);
    public const uint SDL_BUTTON_X2MASK = (1 << 4);
}