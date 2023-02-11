using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#pragma warning disable CS1591
namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    ///<summary>Get the number of milliseconds since SDL library initialization.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetTicks">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_GetTicks();
    ///<summary>Get the number of milliseconds since SDL library initialization.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetTicks64">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong SDL_GetTicks64();
    ///<summary>Use this macro to compare SDL ticks values.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_TICKS_PASSED">SDL2 Documentation</a></remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SDL_TICKS_PASSED(uint a, uint b)
    {
        return b - a <= 0;
    }
    ///<summary>Get the current value of the high resolution counter.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetPerformanceCounter">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong SDL_GetPerformanceCounter();
    ///<summary>Get the count per second of the high resolution counter.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetPerformanceFrequency">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong SDL_GetPerformanceFrequency();
    ///<summary>Wait a specified number of milliseconds before returning.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_Delay">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_Delay(uint ms);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint SDL_TimerCallback(uint interval, IntPtr param);
    ///<summary>Call a callback function at a future time.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_AddTimer">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_AddTimer(uint interval, SDL_TimerCallback callback, IntPtr param);
    ///<summary>Remove a timer created with SDL_AddTimer().</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RemoveTimer">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_RemoveTimer(int timerId);
}
