using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    ///<summary>Get the number of CPU cores available.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetCPUCount">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetCPUCount();
    ///<summary>Determine the L1 cache line size of the CPU.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetCPUCacheLineSize">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetCPUCacheLineSize();
    ///<summary>Determine whether the CPU has the RDTSC instruction.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasRDTSC">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasRDTSC();
    ///<summary>Determine whether the CPU has AltiVec features.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasAltiVec">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasAltiVec();
    ///<summary>Determine whether the CPU has MMX features.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasMMX">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasMMX();
    ///<summary>Determine whether the CPU has 3DNow! features.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_Has3DNow">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_Has3DNow();
    ///<summary>Determine whether the CPU has SSE features.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasSSE">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasSSE();
    ///<summary>Determine whether the CPU has SSE2 features.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasSSE2">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasSSE2();
    ///<summary>Determine whether the CPU has SSE3 features.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasSSE3">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasSSE3();
    ///<summary>Determine whether the CPU has SSE4.1 features.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasSSE41">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasSSE41();
    ///<summary>Determine whether the CPU has SSE4.2 features.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasSSE42">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasSSE42();
    ///<summary>Determine whether the CPU has AVX features.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasAVX">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasAVX();
    ///<summary>Determine whether the CPU has AVX2 features.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasAVX2">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasAVX2();
    ///<summary>Determine whether the CPU has AVX-512F (foundation) features.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasAVX512F">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasAVX512F();
    ///<summary>Determine whether the CPU has ARM SIMD (ARMv6) features.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasARMSIMD">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasARMSIMD();
    ///<summary>Determine whether the CPU has NEON (ARM SIMD) features.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasNEON">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasNEON();
    ///<summary>Determine whether the CPU has LSX (LOONGARCH SIMD) features.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasLSX">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasLSX();
    ///<summary>Determine whether the CPU has LASX (LOONGARCH SIMD) features.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasLASX">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasLASX();
    ///<summary>Get the amount of RAM configured in the system.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetSystemRAM">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetSystemRAM();
    ///<summary>Report the alignment this system needs for SIMD allocations.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SIMDGetAlignment">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong SDL_SIMDGetAlignment();
    ///<summary>Allocate memory in a SIMD-friendly way.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SIMDAlloc">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_SIMDAlloc(ulong len);
    ///<summary>Reallocate memory obtained from SDL_SIMDAlloc</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SIMDRealloc">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_SIMDRealloc(IntPtr mem, ulong len);
    ///<summary>Deallocate memory obtained from SDL_SIMDAlloc</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SIMDFree">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SIMDFree(IntPtr mem);
}
