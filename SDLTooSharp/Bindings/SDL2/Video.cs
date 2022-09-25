using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

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
        SDL_WINDOW_FULLSCREEN_DESKTOP = (SDL_WINDOW_FULLSCREEN | 0x00001000),
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

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetNumVideoDrivers();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetVideoDriver")]
    private static extern IntPtr _SDL_GetVideoDriver(int index);

    public static string SDL_GetVideoDriver(int index) => PtrToManaged(_SDL_GetVideoDriver(index));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_VideoInit([MarshalAs(UnmanagedType.LPUTF8Str)] string driverName);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_VideoQuit();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCurrentVideoDriver")]
    private static extern IntPtr _SDL_GetCurrentVideoDriver();

    public static string SDL_GetCurrentVideoDriver() => PtrToManaged(_SDL_GetCurrentVideoDriver());

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetNumVideoDisplays();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayName")]
    private static extern IntPtr _SDL_GetDisplayName(int displayIndex);

    public static string SDL_GetDisplayName(int displayIndex) => PtrToManaged(_SDL_GetDisplayName(displayIndex));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetDisplayBounds(int displayIndex, out SDL_Rect rect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetDisplayUsableBounds(int displayIndex, out SDL_Rect rect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetDisplayDPI(int displayIndex, out float ddpi, out float hdpi, out float vdpi);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_DisplayOrientation SDL_GetDisplayOrientation(int displayIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetNumDisplayModes(int displayIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetDisplayMode(int displayIndex, int modeIndex, out SDL_DisplayMode mode);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetDesktopDisplayMode(int displayIndex, out SDL_DisplayMode mode);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetCurrentDisplayMode(int displayIndex, out SDL_DisplayMode mode);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetClosestDisplayMode(int displayIndex, in SDL_DisplayMode closest);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetPointDisplayIndex(in SDL_Point point);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetRectDisplayIndex(in SDL_Rect rect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetWindowDisplayIndex(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetWindowDisplayMode(IntPtr window, in SDL_DisplayMode mode);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetWindowDisplayMode(IntPtr window, out SDL_DisplayMode mode);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetWindowICCProfile(IntPtr window, out long size);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_GetWindowPixelFormat(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateWindow([MarshalAs(UnmanagedType.LPUTF8Str)] string title, int x, int y, int w,
        int h, uint flags);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateWindowFrom(IntPtr data);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_GetWindowID(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetWindowFromID(uint windowId);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_GetWindowFlags(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowTitle(IntPtr window, [MarshalAs(UnmanagedType.LPUTF8Str)] string title);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowTitle")]
    private static extern IntPtr _SDL_GetWindowTitle(IntPtr window);

    public static string SDL_GetWindowTitle(IntPtr window) => PtrToManaged(_SDL_GetWindowTitle(window));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowIcon(IntPtr window, IntPtr surface);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_SetWindowData(IntPtr window, [MarshalAs(UnmanagedType.LPUTF8Str)] string name,
        IntPtr userData);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetWindowData(IntPtr window, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowPosition(IntPtr window, int x, int y);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GetWindowPosition(IntPtr window, out int x, out int y);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowSize(IntPtr window, int w, int h);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GetWindowSize(IntPtr window, out int w, out int h);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetWindowBordersSize(IntPtr window, out int top, out int left, out int bottom,
        out int right);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GetWindowSizeInPixels(IntPtr window, out int w, out int h);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowMinimumSize(IntPtr window, int minW, int minH);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GetWindowMinimumSize(IntPtr window, out int w, out int h);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowMaximumSize(IntPtr window, int maxW, int maxH);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GetWindowMaximumSize(IntPtr window, out int w, out int h);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowBordered(IntPtr window, bool bordered);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowResizable(IntPtr window, bool resizable);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowAlwaysOnTop(IntPtr window, bool onTop);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_ShowWindow(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_HideWindow(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_RaiseWindow(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_MaximizeWindow(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_MinimizeWindow(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_RestoreWindow(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetWindowFullscreen(IntPtr window, uint flags);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetWindowSurface(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_UpdateWindowSurface(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_UpdateWindowSurfaceRects(IntPtr window, in SDL_Rect[] rects, int numRects);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowGrab(IntPtr window, bool grabbed);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowKeyboardGrab(IntPtr window, bool grabbed);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetWindowMouseGrab(IntPtr window, bool grabbed);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GetWindowGrab(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GetWindowKeyboardGrab(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GetWindowMouseGrab(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetGrabbedWindow();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetWindowMouseRect(IntPtr window, in SDL_Rect rect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetWindowMouseRect(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetWindowBrightness(IntPtr window, float brightness);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float SDL_GetWindowBrightness(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetWindowOpacity(IntPtr window, float opacity);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetWindowOpacity(IntPtr window, out float opacity);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetWindowModalFor(IntPtr modalWindow, IntPtr parentWindow);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetWindowInputFocus(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetWindowGammaRamp(
        IntPtr window, in ushort[] red, in ushort[] green, in ushort[] blue
    );

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetWindowGammaRamp(
        IntPtr window, out ushort[] red, out ushort[] green, out ushort[] blue);

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

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetWindowHitTest(IntPtr window, SDL_HitTest callback, IntPtr callbackData);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_FlashWindow(IntPtr window, SDL_FlashOperation operation);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_DestroyWindow(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IsScreenSaverEnabled();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_EnableScreenSaver();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_DisableScreenSaver();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GL_ExtensionSupported([MarshalAs(UnmanagedType.LPUTF8Str)] string extension);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GL_ResetAttributes();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GL_SetAttribute(SDL_GLattr attr, int value);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GL_GetAttribute(SDL_GLattr attr, out int value);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GL_CreateContext(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GL_MakeCurrent(IntPtr window, IntPtr context);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GL_GetCurrentWindow();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GL_GetCurrentContext();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GL_GetDrawableSize(IntPtr window, out int w, out int h);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GL_SetSwapInterval(int interval);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GL_GetSwapInterval();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GL_SwapWindow(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GL_DeleteContext(IntPtr context);
}
