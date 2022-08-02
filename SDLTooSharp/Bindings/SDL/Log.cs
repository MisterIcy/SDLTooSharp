using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings;

public static partial class SDL2
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

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Log")]
    private static extern unsafe void _SDL_Log(byte* log);

    public static unsafe void SDL_Log(string log)
    {
        var len = Marshaller.GetStringLengthInBytes(log);
        var buf = stackalloc byte[len];
        _SDL_Log(Marshaller.ManagedToChar(log, buf, len));
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogVerbose")]
    private static extern unsafe void _SDL_LogVerbose(int category, byte* log);

    public static unsafe void SDL_LogVerbose(int category, string log)
    {
        var len = Marshaller.GetStringLengthInBytes(log);
        var buf = stackalloc byte[len];
        _SDL_LogVerbose(category, Marshaller.ManagedToChar(log, buf, len));
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogDebug")]
    private static extern unsafe void _SDL_LogDebug(int category, byte* log);

    public static unsafe void SDL_LogDebug(int category, string log)
    {
        var len = Marshaller.GetStringLengthInBytes(log);
        var buf = stackalloc byte[len];
        _SDL_LogDebug(category, Marshaller.ManagedToChar(log, buf, len));
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogInfo")]
    private static extern unsafe void _SDL_LogInfo(int category, byte* log);

    public static unsafe void SDL_LogInfo(int category, string log)
    {
        var len = Marshaller.GetStringLengthInBytes(log);
        var buf = stackalloc byte[len];
        _SDL_LogInfo(category, Marshaller.ManagedToChar(log, buf, len));
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogWarn")]
    private static extern unsafe void _SDL_LogWarn(int category, byte* log);

    public static unsafe void SDL_LogWarn(int category, string log)
    {
        var len = Marshaller.GetStringLengthInBytes(log);
        var buf = stackalloc byte[len];
        _SDL_LogWarn(category, Marshaller.ManagedToChar(log, buf, len));
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogError")]
    private static extern unsafe void _SDL_LogError(int category, byte* log);

    public static unsafe void SDL_LogError(int category, string log)
    {
        var len = Marshaller.GetStringLengthInBytes(log);
        var buf = stackalloc byte[len];
        _SDL_LogError(category, Marshaller.ManagedToChar(log, buf, len));
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogCritical")]
    private static extern unsafe void _SDL_LogCritical(int category, byte* log);

    public static unsafe void SDL_LogCritical(int category, string log)
    {
        var len = Marshaller.GetStringLengthInBytes(log);
        var buf = stackalloc byte[len];
        _SDL_LogCritical(category, Marshaller.ManagedToChar(log, buf, len));
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LogMessage")]
    private static extern unsafe void _SDL_LogMessage(int category, SDL_LogPriority priority, byte* log);

    public static unsafe void SDL_LogMessage(int category, SDL_LogPriority priority, string log)
    {
        var len = Marshaller.GetStringLengthInBytes(log);
        var buf = stackalloc byte[len];
        _SDL_LogMessage(category, priority, Marshaller.ManagedToChar(log, buf, len));
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SDL_LogOutputFunction(IntPtr userData, int category, SDL_LogCategory priority, IntPtr log);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogGetOutputFunction(out SDL_LogOutputFunction callback, out IntPtr userData);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LogSetOutputFunction(SDL_LogOutputFunction callback, IntPtr userData);
}