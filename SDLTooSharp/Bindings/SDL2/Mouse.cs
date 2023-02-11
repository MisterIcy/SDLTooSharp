using System.Runtime.InteropServices;
#pragma warning disable CS1591
namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    public enum SDL_SystemCursor
    {
        SDL_SYSTEM_CURSOR_ARROW,
        SDL_SYSTEM_CURSOR_IBEAM,
        SDL_SYSTEM_CURSOR_WAIT,
        SDL_SYSTEM_CURSOR_CROSSHAIR,
        SDL_SYSTEM_CURSOR_WAITARROW,
        SDL_SYSTEM_CURSOR_SIZENWSE,
        SDL_SYSTEM_CURSOR_SIZENESW,
        SDL_SYSTEM_CURSOR_SIZEWE,
        SDL_SYSTEM_CURSOR_SIZENS,
        SDL_SYSTEM_CURSOR_SIZEALL,
        SDL_SYSTEM_CURSOR_NO,
        SDL_SYSTEM_CURSOR_HAND,
        SDL_NUM_SYSTEM_CURSORS
    }

    public enum SDL_MouseWheelDirection
    {
        SDL_MOUSEWHEEL_NORMAL,
        SDL_MOUSEWHEEL_FLIPPED
    }
    ///<summary>Get the window which currently has mouse focus.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetMouseFocus">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetMouseFocus();
    ///<summary>Retrieve the current state of the mouse.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetMouseState">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_GetMouseState(out int x, out int y);
    ///<summary>Get the current state of the mouse in relation to the desktop.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetGlobalMouseState">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_GetGlobalMouseState(out int x, out int y);
    ///<summary>Retrieve the relative state of the mouse.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetRelativeMouseState">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_GetRelativeMouseState(out int x, out int y);
    ///<summary>Move the mouse cursor to the given position within the window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_WarpMouseInWindow">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_WarpMouseInWindow(IntPtr window, int x, int y);
    ///<summary>Move the mouse to the given position in global screen space.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_WarpMouseGlobal">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_WarpMouseGlobal(int x, int y);
    ///<summary>Set relative mouse mode.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetRelativeMouseMode">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetRelativeMouseMode(bool enabled);
    ///<summary>Capture the mouse and to track input outside an SDL window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_CaptureMouse">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_CaptureMouse(bool enabled);
    ///<summary>Query whether relative mouse mode is enabled.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetRelativeMouseMode">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GetRelativeMouseMode();
    ///<summary>Create a cursor using the specified bitmap data and mask (in MSB format).</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_CreateCursor">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateCursor(IntPtr data, IntPtr mask, int w, int h, int hotX, int hotY);
    ///<summary>Create a color cursor.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_CreateColorCursor">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateColorCursor(IntPtr surface, int hotX, int hotY);
    ///<summary>Create a system cursor.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_CreateSystemCursor">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateSystemCursor(SDL_SystemCursor id);
    ///<summary>Set the active cursor.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetCursor">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetCursor(IntPtr cursor);
    ///<summary>Get the active cursor.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetCursor">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetCursor();
    ///<summary>Get the default cursor.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetDefaultCursor">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetDefaultCursor();
    ///<summary>Free a previously-created cursor.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_FreeCursor">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_FreeCursor(IntPtr cursor);
    ///<summary>Toggle whether or not the cursor is shown.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_ShowCursor">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_ShowCursor(int toggle);
    ///<summary></summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_BUTTON">SDL2 Documentation</a></remarks>
    public static int SDL_BUTTON(int x)
    {
        return (int)( 1 << ( x - 1 ) );
    }


    public const int SDL_BUTTON_LEFT = 1;
    public const int SDL_BUTTON_MIDDLE = 2;
    public const int SDL_BUTTON_RIGHT = 3;
    public const int SDL_BUTTON_X1 = 4;
    public const int SDL_BUTTON_X2 = 5;
    public const int SDL_BUTTON_LMASK = 1 << ( SDL_BUTTON_LEFT - 1 );
    public const int SDL_BUTTON_MMASK = 1 << ( SDL_BUTTON_MIDDLE - 1 );
    public const int SDL_BUTTON_RMASK = 1 << ( SDL_BUTTON_RIGHT - 1 );
    public const int SDL_BUTTON_X1MASK = 1 << ( SDL_BUTTON_X1 - 1 );
    public const int SDL_BUTTON_X2MASK = 1 << ( SDL_BUTTON_X2 - 1 );
}
