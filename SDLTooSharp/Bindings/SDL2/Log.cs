using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    public enum SDL_LogCategory
    {
        SDL_LOG_CATEGORY_APPLICATION,
        SDL_LOG_CATEGORY_ERROR,
        SDL_LOG_CATEGORY_ASSERT,
        SDL_LOG_CATEGORY_SYSTEM,
        SDL_LOG_CATEGORY_AUDIO,
        SDL_LOG_CATEGORY_VIDEO,
        SDL_LOG_CATEGORY_RENDER,
        SDL_LOG_CATEGORY_INPUT,
        SDL_LOG_CATEGORY_TEST,
        SDL_LOG_CATEGORY_RESERVED1,
        SDL_LOG_CATEGORY_RESERVED2,
        SDL_LOG_CATEGORY_RESERVED3,
        SDL_LOG_CATEGORY_RESERVED4,
        SDL_LOG_CATEGORY_RESERVED5,
        SDL_LOG_CATEGORY_RESERVED6,
        SDL_LOG_CATEGORY_RESERVED7,
        SDL_LOG_CATEGORY_RESERVED8,
        SDL_LOG_CATEGORY_RESERVED9,
        SDL_LOG_CATEGORY_RESERVED10,
        SDL_LOG_CATEGORY_CUSTOM
    }

    public enum SDL_LogPriority
    {
        SDL_LOG_PRIORITY_VERBOSE = 1,
        SDL_LOG_PRIORITY_DEBUG,
        SDL_LOG_PRIORITY_INFO,
        SDL_LOG_PRIORITY_WARN,
        SDL_LOG_PRIORITY_ERROR,
        SDL_LOG_PRIORITY_CRITICAL,
        SDL_NUM_LOG_PRIORITIES
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogSetAllPriority(SDL_LogPriority priority);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogSetPriority(int category, SDL_LogPriority priority);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_LogPriority SDL_LogGetPriority(int category);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogResetPriorities();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_Log([MarshalAs(UnmanagedType.LPUTF8Str)] string message);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogVerbose(int category, [MarshalAs(UnmanagedType.LPUTF8Str)] string message);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogDebug(int category, [MarshalAs(UnmanagedType.LPUTF8Str)] string message);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogInfo(int category, [MarshalAs(UnmanagedType.LPUTF8Str)] string message);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogWarn(int category, [MarshalAs(UnmanagedType.LPUTF8Str)] string message);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogError(int category, [MarshalAs(UnmanagedType.LPUTF8Str)] string message);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogCritical(int category, [MarshalAs(UnmanagedType.LPUTF8Str)] string message);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogMessage(int category, SDL_LogPriority priority,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string message);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SDL_LogOutputFunction(IntPtr userData, int category, SDL_LogPriority priority,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string message);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogGetOutputFunction(out SDL_LogOutputFunction callback, out IntPtr userData);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogSetOutputFunction(SDL_LogOutputFunction callback, IntPtr userData);
}
