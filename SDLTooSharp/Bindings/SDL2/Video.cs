using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
#pragma warning disable CS1591
namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_DisplayMode
    {
        public uint Format;
        public int W;
        public int H;
        public int RefreshRate;
        public IntPtr DriverData;
    }

    public enum SDL_WindowFlags
    {
        SDL_WINDOW_FULLSCREEN = 0x00000001,
        SDL_WINDOW_OPENGL = 0x00000002,
        SDL_WINDOW_SHOWN = 0x00000004,
        SDL_WINDOW_HIDDEN = 0x00000008,
        SDL_WINDOW_BORDERLESS = 0x00000010,
        SDL_WINDOW_RESIZABLE = 0x00000020,
        SDL_WINDOW_MINIMIZED = 0x00000040,
        SDL_WINDOW_MAXIMIZED = 0x00000080,
        SDL_WINDOW_MOUSE_GRABBED = 0x00000100,
        SDL_WINDOW_INPUT_FOCUS = 0x00000200,
        SDL_WINDOW_MOUSE_FOCUS = 0x00000400,
        SDL_WINDOW_FULLSCREEN_DESKTOP = ( SDL_WINDOW_FULLSCREEN | 0x00001000 ),
        SDL_WINDOW_FOREIGN = 0x00000800,
        SDL_WINDOW_ALLOW_HIGHDPI = 0x00002000,
        SDL_WINDOW_MOUSE_CAPTURE = 0x00004000,
        SDL_WINDOW_ALWAYS_ON_TOP = 0x00008000,
        SDL_WINDOW_SKIP_TASKBAR = 0x00010000,
        SDL_WINDOW_UTILITY = 0x00020000,
        SDL_WINDOW_TOOLTIP = 0x00040000,
        SDL_WINDOW_POPUP_MENU = 0x00080000,
        SDL_WINDOW_KEYBOARD_GRABBED = 0x00100000,
        SDL_WINDOW_VULKAN = 0x10000000,
        SDL_WINDOW_METAL = 0x20000000,

        SDL_WINDOW_INPUT_GRABBED = SDL_WINDOW_MOUSE_GRABBED
    }

    public const uint SDL_WINDOWPOS_UNDEFINED_MASK = 0x1FFF0000u;
    public const uint SDL_WINDOWPOS_CENTERED_MASK = 0x2FFF0000u;
    public const uint SDL_WINDOWPOS_UNDEFINED = SDL_WINDOWPOS_UNDEFINED_MASK;
    public const uint SDL_WINDOWPOS_CENTERED = SDL_WINDOWPOS_CENTERED_MASK;

    public enum SDL_WindowEventID
    {
        SDL_WINDOWEVENT_NONE,
        SDL_WINDOWEVENT_SHOWN,
        SDL_WINDOWEVENT_HIDDEN,
        SDL_WINDOWEVENT_EXPOSED,
        SDL_WINDOWEVENT_MOVED,
        SDL_WINDOWEVENT_RESIZED,
        SDL_WINDOWEVENT_SIZE_CHANGED,
        SDL_WINDOWEVENT_MINIMIZED,
        SDL_WINDOWEVENT_MAXIMIZED,
        SDL_WINDOWEVENT_RESTORED,
        SDL_WINDOWEVENT_ENTER,
        SDL_WINDOWEVENT_LEAVE,
        SDL_WINDOWEVENT_FOCUS_GAINED,
        SDL_WINDOWEVENT_FOCUS_LOST,
        SDL_WINDOWEVENT_CLOSE,
        SDL_WINDOWEVENT_TAKE_FOCUS,
        SDL_WINDOWEVENT_HIT_TEST,
        SDL_WINDOWEVENT_ICCPROF_CHANGED,
        SDL_WINDOWEVENT_DISPLAY_CHANGED
    }

    public enum SDL_DisplayEventID
    {
        SDL_DISPLAYEVENT_NONE,
        SDL_DISPLAYEVENT_ORIENTATION,
        SDL_DISPLAYEVENT_CONNECTED,
        SDL_DISPLAYEVENT_DISCONNECTED
    }

    public enum SDL_DisplayOrientation
    {
        SDL_ORIENTATION_UNKNOWN,
        SDL_ORIENTATION_LANDSCAPE,
        SDL_ORIENTATION_LANDSCAPE_FLIPPED,
        SDL_ORIENTATION_PORTRAIT,
        SDL_ORIENTATION_PORTRAIT_FLIPPED
    }

    public enum SDL_FlashOperation
    {
        SDL_FLASH_CANCEL,
        SDL_FLASH_BRIEFLY,
        SDL_FLASH_UNTIL_FOCUSED
    }

    public enum SDL_GLattr
    {
        SDL_GL_RED_SIZE,
        SDL_GL_GREEN_SIZE,
        SDL_GL_BLUE_SIZE,
        SDL_GL_ALPHA_SIZE,
        SDL_GL_BUFFER_SIZE,
        SDL_GL_DOUBLEBUFFER,
        SDL_GL_DEPTH_SIZE,
        SDL_GL_STENCIL_SIZE,
        SDL_GL_ACCUM_RED_SIZE,
        SDL_GL_ACCUM_GREEN_SIZE,
        SDL_GL_ACCUM_BLUE_SIZE,
        SDL_GL_ACCUM_ALPHA_SIZE,
        SDL_GL_STEREO,
        SDL_GL_MULTISAMPLEBUFFERS,
        SDL_GL_MULTISAMPLESAMPLES,
        SDL_GL_ACCELERATED_VISUAL,
        SDL_GL_RETAINED_BACKING,
        SDL_GL_CONTEXT_MAJOR_VERSION,
        SDL_GL_CONTEXT_MINOR_VERSION,
        SDL_GL_CONTEXT_EGL,
        SDL_GL_CONTEXT_FLAGS,
        SDL_GL_CONTEXT_PROFILE_MASK,
        SDL_GL_SHARE_WITH_CURRENT_CONTEXT,
        SDL_GL_FRAMEBUFFER_SRGB_CAPABLE,
        SDL_GL_CONTEXT_RELEASE_BEHAVIOR,
        SDL_GL_CONTEXT_RESET_NOTIFICATION,
        SDL_GL_CONTEXT_NO_ERROR,
        SDL_GL_FLOATBUFFERS
    }

    public enum SDL_GLprofile
    {
        SDL_GL_CONTEXT_PROFILE_CORE = 0x0001,
        SDL_GL_CONTEXT_PROFILE_COMPATIBILITY = 0x0002,
        SDL_GL_CONTEXT_PROFILE_ES = 0x0004
    }

    public enum SDL_GLcontextFlag
    {
        SDL_GL_CONTEXT_DEBUG_FLAG = 0x0001,
        SDL_GL_CONTEXT_FORWARD_COMPATIBLE_FLAG = 0x0002,
        SDL_GL_CONTEXT_ROBUST_ACCESS_FLAG = 0x0004,
        SDL_GL_CONTEXT_RESET_ISOLATION_FLAG = 0x0008
    }

    public enum SDL_GLcontextReleaseFlag
    {
        SDL_GL_CONTEXT_RELEASE_BEHAVIOR_NONE = 0x0000,
        SDL_GL_CONTEXT_RELEASE_BEHAVIOR_FLUSH = 0x0001
    }

    public enum SDL_GLContextResetNotification
    {
        SDL_GL_CONTEXT_RESET_NO_NOTIFICATION = 0x0000,
        SDL_GL_CONTEXT_RESET_LOSE_CONTEXT = 0x0001
    }

    ///<summary>Get the number of video drivers compiled into SDL.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetNumVideoDrivers">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetNumVideoDrivers();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetVideoDriver")]
    private static extern IntPtr _SDL_GetVideoDriver(int index);
    ///<summary>Get the name of a built in video driver.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetVideoDriver">SDL2 Documentation</a></remarks>
    public static string SDL_GetVideoDriver(int index) => PtrToManaged(_SDL_GetVideoDriver(index));
    ///<summary>Initialize the video subsystem, optionally specifying a video driver.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_VideoInit">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_VideoInit([MarshalAs(UnmanagedType.LPUTF8Str)] string driverName);
    ///<summary>Shut down the video subsystem, if initialized with SDL_VideoInit().</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_VideoQuit">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_VideoQuit();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCurrentVideoDriver")]
    private static extern IntPtr _SDL_GetCurrentVideoDriver();
    ///<summary>Get the name of the currently initialized video driver.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetCurrentVideoDriver">SDL2 Documentation</a></remarks>
    public static string SDL_GetCurrentVideoDriver() => PtrToManaged(_SDL_GetCurrentVideoDriver());
    ///<summary>Get the number of available video displays.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetNumVideoDisplays">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetNumVideoDisplays();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayName")]
    private static extern IntPtr _SDL_GetDisplayName(int displayIndex);
    ///<summary>Get the name of a display in UTF-8 encoding.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetDisplayName">SDL2 Documentation</a></remarks>
    public static string SDL_GetDisplayName(int displayIndex) => PtrToManaged(_SDL_GetDisplayName(displayIndex));
    ///<summary>Get the desktop area represented by a display.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetDisplayBounds">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetDisplayBounds(int displayIndex, out SDL_Rect rect);
    ///<summary>Get the usable desktop area represented by a display.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetDisplayUsableBounds">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetDisplayUsableBounds(int displayIndex, out SDL_Rect rect);
    ///<summary>Get the dots/pixels-per-inch for a display.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetDisplayDPI">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetDisplayDPI(int displayIndex, out float ddpi, out float hdpi, out float vdpi);
    ///<summary>Get the orientation of a display.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetDisplayOrientation">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_DisplayOrientation SDL_GetDisplayOrientation(int displayIndex);
    ///<summary>Get the number of available display modes.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetNumDisplayModes">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetNumDisplayModes(int displayIndex);
    ///<summary>Get information about a specific display mode.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetDisplayMode">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetDisplayMode(int displayIndex, int modeIndex, out SDL_DisplayMode mode);
    ///<summary>Get information about the desktop's display mode.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetDesktopDisplayMode">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetDesktopDisplayMode(int displayIndex, out SDL_DisplayMode mode);
    ///<summary>Get information about the current display mode.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetCurrentDisplayMode">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetCurrentDisplayMode(int displayIndex, out SDL_DisplayMode mode);
    ///<summary>Get the closest match to the requested display mode.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetClosestDisplayMode">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetClosestDisplayMode(
        int displayIndex,
        in SDL_DisplayMode mode,
        out SDL_DisplayMode closest
    );
    ///<summary>Get the index of the display containing a point</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetPointDisplayIndex">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetPointDisplayIndex(in SDL_Point point);
    ///<summary>Get the index of the display primarily containing a rect</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetRectDisplayIndex">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetRectDisplayIndex(in SDL_Rect rect);
    ///<summary>Get the index of the display associated with a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowDisplayIndex">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetWindowDisplayIndex(IntPtr window);
    ///<summary>Set the display mode to use when a window is visible at fullscreen.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowDisplayMode">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetWindowDisplayMode(IntPtr window, in SDL_DisplayMode mode);
    ///<summary>Query the display mode to use when a window is visible at fullscreen.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowDisplayMode">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetWindowDisplayMode(IntPtr window, out SDL_DisplayMode mode);
    ///<summary>Get the raw ICC profile data for the screen the window is currently on.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowICCProfile">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetWindowICCProfile(IntPtr window, out long size);
    ///<summary>Get the pixel format associated with the window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowPixelFormat">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_GetWindowPixelFormat(IntPtr window);
    ///<summary>Create a window with the specified position, dimensions, and flags.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_CreateWindow">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateWindow(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string title,
        int x,
        int y,
        int w,
        int h,
        uint flags
    );
    ///<summary>Create an SDL window from an existing native window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_CreateWindowFrom">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateWindowFrom(IntPtr data);
    ///<summary>Get the numeric ID of a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowID">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_GetWindowID(IntPtr window);
    ///<summary>Get a window from a stored ID.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowFromID">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetWindowFromID(uint windowId);
    ///<summary>Get the window flags.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowFlags">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_GetWindowFlags(IntPtr window);
    ///<summary>Set the title of a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowTitle">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowTitle(IntPtr window, [MarshalAs(UnmanagedType.LPUTF8Str)] string title);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowTitle")]
    private static extern IntPtr _SDL_GetWindowTitle(IntPtr window);
    ///<summary>Get the title of a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowTitle">SDL2 Documentation</a></remarks>
    public static string SDL_GetWindowTitle(IntPtr window) => PtrToManaged(_SDL_GetWindowTitle(window));
    ///<summary>Set the icon for a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowIcon">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowIcon(IntPtr window, IntPtr surface);
    ///<summary>Associate an arbitrary named pointer with a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowData">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_SetWindowData(
        IntPtr window,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        IntPtr userData
    );
    ///<summary>Retrieve the data pointer associated with a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowData">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetWindowData(IntPtr window, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);
    ///<summary>Set the position of a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowPosition">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowPosition(IntPtr window, int x, int y);
    ///<summary>Get the position of a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowPosition">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GetWindowPosition(IntPtr window, out int x, out int y);
    ///<summary>Set the size of a window's client area.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowSize">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowSize(IntPtr window, int w, int h);
    ///<summary>Get the size of a window's client area.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowSize">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GetWindowSize(IntPtr window, out int w, out int h);
    ///<summary>Get the size of a window's borders (decorations) around the client area.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowBordersSize">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetWindowBordersSize(
        IntPtr window,
        out int top,
        out int left,
        out int bottom,
        out int right
    );
    ///<summary>Get the size of a window in pixels.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowSizeInPixels">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GetWindowSizeInPixels(IntPtr window, out int w, out int h);
    ///<summary>Set the minimum size of a window's client area.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowMinimumSize">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowMinimumSize(IntPtr window, int minW, int minH);
    ///<summary>Get the minimum size of a window's client area.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowMinimumSize">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GetWindowMinimumSize(IntPtr window, out int w, out int h);
    ///<summary>Set the maximum size of a window's client area.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowMaximumSize">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowMaximumSize(IntPtr window, int maxW, int maxH);
    ///<summary>Get the maximum size of a window's client area.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowMaximumSize">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GetWindowMaximumSize(IntPtr window, out int w, out int h);
    ///<summary>Set the border state of a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowBordered">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowBordered(IntPtr window, bool bordered);
    ///<summary>Set the user-resizable state of a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowResizable">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowResizable(IntPtr window, bool resizable);
    ///<summary>Set the window to always be above the others.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowAlwaysOnTop">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowAlwaysOnTop(IntPtr window, bool onTop);
    ///<summary>Show a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_ShowWindow">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_ShowWindow(IntPtr window);
    ///<summary>Hide a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HideWindow">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_HideWindow(IntPtr window);
    ///<summary>Raise a window above other windows and set the input focus.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RaiseWindow">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_RaiseWindow(IntPtr window);
    ///<summary>Make a window as large as possible.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_MaximizeWindow">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_MaximizeWindow(IntPtr window);
    ///<summary>Minimize a window to an iconic representation.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_MinimizeWindow">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_MinimizeWindow(IntPtr window);
    ///<summary>Restore the size and position of a minimized or maximized window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RestoreWindow">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_RestoreWindow(IntPtr window);
    ///<summary>Set a window's fullscreen state.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowFullscreen">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetWindowFullscreen(IntPtr window, uint flags);
    ///<summary>Get the SDL surface associated with the window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowSurface">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetWindowSurface(IntPtr window);
    ///<summary>Copy the window surface to the screen.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_UpdateWindowSurface">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_UpdateWindowSurface(IntPtr window);
    ///<summary>Copy areas of the window surface to the screen.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_UpdateWindowSurfaceRects">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_UpdateWindowSurfaceRects(
        IntPtr window,
        [In][MarshalAs(UnmanagedType.LPArray)] SDL_Rect[] rects,
        int numRects
    );
    ///<summary>Set a window's input grab mode.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowGrab">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowGrab(IntPtr window, bool grabbed);
    ///<summary>Set a window's keyboard grab mode.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowKeyboardGrab">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowKeyboardGrab(IntPtr window, bool grabbed);
    ///<summary>Set a window's mouse grab mode.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowMouseGrab">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowMouseGrab(IntPtr window, bool grabbed);
    ///<summary>Get a window's input grab mode.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowGrab">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GetWindowGrab(IntPtr window);
    ///<summary>Get a window's keyboard grab mode.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowKeyboardGrab">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GetWindowKeyboardGrab(IntPtr window);
    ///<summary>Get a window's mouse grab mode.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowMouseGrab">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GetWindowMouseGrab(IntPtr window);
    ///<summary>Get the window that currently has an input grab enabled.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetGrabbedWindow">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetGrabbedWindow();
    ///<summary>Confines the cursor to the specified area of a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowMouseRect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetWindowMouseRect(IntPtr window, in SDL_Rect rect);
    ///<summary>Get the mouse confinement rectangle of a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowMouseRect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetWindowMouseRect(IntPtr window);
    ///<summary>Set the brightness (gamma multiplier) for a given window's display.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowBrightness">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetWindowBrightness(IntPtr window, float brightness);
    ///<summary>Get the brightness (gamma multiplier) for a given window's display.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowBrightness">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float SDL_GetWindowBrightness(IntPtr window);
    ///<summary>Set the opacity for a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowOpacity">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetWindowOpacity(IntPtr window, float opacity);
    ///<summary>Get the opacity of a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowOpacity">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetWindowOpacity(IntPtr window, out float opacity);
    ///<summary>Set the window as a modal for another window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowModalFor">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetWindowModalFor(IntPtr modalWindow, IntPtr parentWindow);
    ///<summary>Explicitly set input focus to the window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowInputFocus">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetWindowInputFocus(IntPtr window);
    ///<summary>Set the gamma ramp for the display that owns a given window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowGammaRamp">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetWindowGammaRamp(
        IntPtr window,
        [In][MarshalAs(UnmanagedType.LPArray)] ushort[] red,
        [In][MarshalAs(UnmanagedType.LPArray)] ushort[] green,
        [In][MarshalAs(UnmanagedType.LPArray)] ushort[] blue
    );
    ///<summary>Get the gamma ramp for a given window's display.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetWindowGammaRamp">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetWindowGammaRamp(
        IntPtr window,
        [Out][MarshalAs(UnmanagedType.LPArray)] ushort[] red,
        [Out][MarshalAs(UnmanagedType.LPArray)] ushort[] green,
        [Out][MarshalAs(UnmanagedType.LPArray)] ushort[] blue
    );

    public enum SDL_HitTestResult
    {
        SDL_HITTEST_NORMAL,
        SDL_HITTEST_DRAGGABLE,
        SDL_HITTEST_RESIZE_TOPLEFT,
        SDL_HITTEST_RESIZE_TOP,
        SDL_HITTEST_RESIZE_TOPRIGHT,
        SDL_HITTEST_RESIZE_RIGHT,
        SDL_HITTEST_RESIZE_BOTTOMRIGHT,
        SDL_HITTEST_RESIZE_BOTTOM,
        SDL_HITTEST_RESIZE_BOTTOMLEFT,
        SDL_HITTEST_RESIZE_LEFT
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate SDL_HitTestResult SDL_HitTest(IntPtr window, in SDL_Point area, IntPtr data);

    ///<summary>Provide a callback that decides if a window region has special properties.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetWindowHitTest">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetWindowHitTest(IntPtr window, SDL_HitTest callback, IntPtr callbackData);
    ///<summary>Request a window to demand attention from the user.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_FlashWindow">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_FlashWindow(IntPtr window, SDL_FlashOperation operation);
    ///<summary>Destroy a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_DestroyWindow">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_DestroyWindow(IntPtr window);
    ///<summary>Check whether the screensaver is currently enabled.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_IsScreenSaverEnabled">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IsScreenSaverEnabled();
    ///<summary>Allow the screen to be blanked by a screen saver.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_EnableScreenSaver">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_EnableScreenSaver();
    ///<summary>Prevent the screen from being blanked by a screen saver.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_DisableScreenSaver">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_DisableScreenSaver();
    ///<summary>Check if an OpenGL extension is supported for the current context.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GL_ExtensionSupported">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GL_ExtensionSupported([MarshalAs(UnmanagedType.LPUTF8Str)] string extension);
    ///<summary>Reset all previously set OpenGL context attributes to their default values.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GL_ResetAttributes">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GL_ResetAttributes();
    ///<summary>Set an OpenGL window attribute before window creation.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GL_SetAttribute">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GL_SetAttribute(SDL_GLattr attr, int value);
    ///<summary>Get the actual value for an attribute from the current context.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GL_GetAttribute">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GL_GetAttribute(SDL_GLattr attr, out int value);
    ///<summary>Create an OpenGL context for an OpenGL window, and make it current.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GL_CreateContext">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GL_CreateContext(IntPtr window);
    ///<summary>Set up an OpenGL context for rendering into an OpenGL window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GL_MakeCurrent">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GL_MakeCurrent(IntPtr window, IntPtr context);
    ///<summary>Get the currently active OpenGL window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GL_GetCurrentWindow">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GL_GetCurrentWindow();
    ///<summary>Get the currently active OpenGL context.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GL_GetCurrentContext">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GL_GetCurrentContext();
    ///<summary>Get the size of a window's underlying drawable in pixels.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GL_GetDrawableSize">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GL_GetDrawableSize(IntPtr window, out int w, out int h);
    ///<summary>Set the swap interval for the current OpenGL context.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GL_SetSwapInterval">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GL_SetSwapInterval(int interval);
    ///<summary>Get the swap interval for the current OpenGL context.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GL_GetSwapInterval">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GL_GetSwapInterval();
    ///<summary>Update a window with OpenGL rendering.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GL_SwapWindow">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GL_SwapWindow(IntPtr window);
    ///<summary>Delete an OpenGL context.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GL_DeleteContext">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GL_DeleteContext(IntPtr context);
}
