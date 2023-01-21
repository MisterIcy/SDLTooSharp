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
    ///<summary>Set the priority of all log categories.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LogSetAllPriority">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogSetAllPriority(SDL_LogPriority priority);
    ///<summary>Set the priority of a particular log category.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LogSetPriority">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogSetPriority(int category, SDL_LogPriority priority);
    ///<summary>Get the priority of a particular log category.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LogGetPriority">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_LogPriority SDL_LogGetPriority(int category);
    ///<summary>Reset all priorities to default.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LogResetPriorities">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogResetPriorities();
    ///<summary>Log a message with SDL_LOG_CATEGORY_APPLICATION and SDL_LOG_PRIORITY_INFO.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_Log">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_Log([MarshalAs(UnmanagedType.LPUTF8Str)] string message);
    ///<summary>Log a message with SDL_LOG_PRIORITY_VERBOSE.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LogVerbose">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogVerbose(int category, [MarshalAs(UnmanagedType.LPUTF8Str)] string message);
    ///<summary>Log a message with SDL_LOG_PRIORITY_DEBUG.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LogDebug">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogDebug(int category, [MarshalAs(UnmanagedType.LPUTF8Str)] string message);
    ///<summary>Log a message with SDL_LOG_PRIORITY_INFO.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LogInfo">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogInfo(int category, [MarshalAs(UnmanagedType.LPUTF8Str)] string message);
    ///<summary>Log a message with SDL_LOG_PRIORITY_WARN.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LogWarn">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogWarn(int category, [MarshalAs(UnmanagedType.LPUTF8Str)] string message);
    ///<summary>Log a message with SDL_LOG_PRIORITY_ERROR.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LogError">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogError(int category, [MarshalAs(UnmanagedType.LPUTF8Str)] string message);
    ///<summary>Log a message with SDL_LOG_PRIORITY_CRITICAL.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LogCritical">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogCritical(int category, [MarshalAs(UnmanagedType.LPUTF8Str)] string message);
    ///<summary>Log a message with the specified category and priority.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LogMessage">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogMessage(int category, SDL_LogPriority priority,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string message);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SDL_LogOutputFunction(IntPtr userData, int category, SDL_LogPriority priority,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string message);
    ///<summary>Get the current log output function.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LogGetOutputFunction">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogGetOutputFunction(out SDL_LogOutputFunction callback, out IntPtr userData);
    ///<summary>Replace the default log output function with one of your own.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LogSetOutputFunction">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogSetOutputFunction(SDL_LogOutputFunction callback, IntPtr userData);
}
