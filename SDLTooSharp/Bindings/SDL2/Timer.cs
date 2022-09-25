using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_GetTicks();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong SDL_GetTicks64();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SDL_TICKS_PASSED(uint a, uint b)
    {
        return b - a <= 0;
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong SDL_GetPerformanceCounter();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong SDL_GetPerformanceFrequency();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_Delay(uint ms);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint SDL_TimerCallback(uint interval, IntPtr param);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_AddTimer(uint interval, SDL_TimerCallback callback, IntPtr param);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_RemoveTimer(int timerId);
}
