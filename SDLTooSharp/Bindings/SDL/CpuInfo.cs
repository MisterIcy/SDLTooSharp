using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings;

public static partial class SDL2
{
    /// <summary>
    /// Get the number of CPU cores available.
    /// </summary>
    /// <returns>The number of logical CPU cores available on the system</returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetCPUCount();

    /// <summary>
    /// Determine whether the CPU has the RDTSC instruction
    /// </summary>
    /// <remarks>The rdtsc (Read Time-Stamp Counter) instruction is used to determine how many CPU ticks took place since the processor was reset.</remarks>
    /// <returns>True if exists, false if not or the CPU isn't using the Intel ISA</returns>
    /// <seealso cref="SDL_HasAltiVec"/>
    /// <seealso cref="SDL_HasMMX"/>
    /// <seealso cref="SDL_Has3DNow"/>
    /// <seealso cref="SDL_HasSSE"/>
    /// <seealso cref="SDL_HasSSE2"/>
    /// <seealso cref="SDL_HasSSE3"/>
    /// <seealso cref="SDL_HasSSE41"/>
    /// <seealso cref="SDL_HasSSE42"/>
    /// <seealso cref="SDL_HasAVX"/>
    /// <seealso cref="SDL_HasAVX2"/>
    /// <seealso cref="SDL_HasAVX512F"/>
    /// <seealso cref="SDL_HasARMSIMD"/>
    /// <seealso cref="SDL_HasLSX"/>
    /// <seealso cref="SDL_HasLASX"/>
    /// <seealso cref="SDL_HasNEON"/>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasRDTSC();

    /// <summary>
    /// Determine whether the CPU has AltiVec features
    /// </summary>
    /// <returns>True if the CPU has AltiVec features, or false if not or not using a PowerPC ISA</returns>
    /// <seealso cref="SDL_HasRDTSC"/>
    /// <seealso cref="SDL_HasMMX"/>
    /// <seealso cref="SDL_Has3DNow"/>
    /// <seealso cref="SDL_HasSSE"/>
    /// <seealso cref="SDL_HasSSE2"/>
    /// <seealso cref="SDL_HasSSE3"/>
    /// <seealso cref="SDL_HasSSE41"/>
    /// <seealso cref="SDL_HasSSE42"/>
    /// <seealso cref="SDL_HasAVX"/>
    /// <seealso cref="SDL_HasAVX2"/>
    /// <seealso cref="SDL_HasAVX512F"/>
    /// <seealso cref="SDL_HasARMSIMD"/>
    /// <seealso cref="SDL_HasLSX"/>
    /// <seealso cref="SDL_HasLASX"/>
    /// <seealso cref="SDL_HasNEON"/>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasAltiVec();

    /// <summary>
    /// Determine whether the CPU has MMX Features
    /// </summary>
    /// <returns>True if the CPU has MMX features, or false if not or not using the Intel ISA</returns>
    /// <seealso cref="SDL_HasAltiVec"/>
    /// <seealso cref="SDL_HasRDTSC"/>
    /// <seealso cref="SDL_Has3DNow"/>
    /// <seealso cref="SDL_HasSSE"/>
    /// <seealso cref="SDL_HasSSE2"/>
    /// <seealso cref="SDL_HasSSE3"/>
    /// <seealso cref="SDL_HasSSE41"/>
    /// <seealso cref="SDL_HasSSE42"/>
    /// <seealso cref="SDL_HasAVX"/>
    /// <seealso cref="SDL_HasAVX2"/>
    /// <seealso cref="SDL_HasAVX512F"/>
    /// <seealso cref="SDL_HasARMSIMD"/>
    /// <seealso cref="SDL_HasLSX"/>
    /// <seealso cref="SDL_HasLASX"/>
    /// <seealso cref="SDL_HasNEON"/>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasMMX();

    /// <summary>
    /// Determine whether the CPU has 3DNow! Features
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="SDL_HasAltiVec"/>
    /// <seealso cref="SDL_HasMMX"/>
    /// <seealso cref="SDL_HasRDTSC"/>
    /// <seealso cref="SDL_HasSSE"/>
    /// <seealso cref="SDL_HasSSE2"/>
    /// <seealso cref="SDL_HasSSE3"/>
    /// <seealso cref="SDL_HasSSE41"/>
    /// <seealso cref="SDL_HasSSE42"/>
    /// <seealso cref="SDL_HasAVX"/>
    /// <seealso cref="SDL_HasAVX2"/>
    /// <seealso cref="SDL_HasAVX512F"/>
    /// <seealso cref="SDL_HasARMSIMD"/>
    /// <seealso cref="SDL_HasLSX"/>
    /// <seealso cref="SDL_HasLASX"/>
    /// <seealso cref="SDL_HasNEON"/>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_Has3DNow();

    /// <summary>
    /// Determine whether the CPU has SSE features.
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="SDL_HasAltiVec"/>
    /// <seealso cref="SDL_HasMMX"/>
    /// <seealso cref="SDL_Has3DNow"/>
    /// <seealso cref="SDL_HasRDTSC"/>
    /// <seealso cref="SDL_HasSSE2"/>
    /// <seealso cref="SDL_HasSSE3"/>
    /// <seealso cref="SDL_HasSSE41"/>
    /// <seealso cref="SDL_HasSSE42"/>
    /// <seealso cref="SDL_HasAVX"/>
    /// <seealso cref="SDL_HasAVX2"/>
    /// <seealso cref="SDL_HasAVX512F"/>
    /// <seealso cref="SDL_HasARMSIMD"/>
    /// <seealso cref="SDL_HasLSX"/>
    /// <seealso cref="SDL_HasLASX"/>
    /// <seealso cref="SDL_HasNEON"/>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasSSE();

    /// <summary>
    /// Determine whether the CPU has SSE2 features
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="SDL_HasAltiVec"/>
    /// <seealso cref="SDL_HasMMX"/>
    /// <seealso cref="SDL_Has3DNow"/>
    /// <seealso cref="SDL_HasSSE"/>
    /// <seealso cref="SDL_HasRDTSC"/>
    /// <seealso cref="SDL_HasSSE3"/>
    /// <seealso cref="SDL_HasSSE41"/>
    /// <seealso cref="SDL_HasSSE42"/>
    /// <seealso cref="SDL_HasAVX"/>
    /// <seealso cref="SDL_HasAVX2"/>
    /// <seealso cref="SDL_HasAVX512F"/>
    /// <seealso cref="SDL_HasARMSIMD"/>
    /// <seealso cref="SDL_HasLSX"/>
    /// <seealso cref="SDL_HasLASX"/>
    /// <seealso cref="SDL_HasNEON"/>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasSSE2();

    /// <summary>
    /// Determine whether the CPU has SSE3 features.
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="SDL_HasAltiVec"/>
    /// <seealso cref="SDL_HasMMX"/>
    /// <seealso cref="SDL_Has3DNow"/>
    /// <seealso cref="SDL_HasSSE"/>
    /// <seealso cref="SDL_HasSSE2"/>
    /// <seealso cref="SDL_HasRDTSC"/>
    /// <seealso cref="SDL_HasSSE41"/>
    /// <seealso cref="SDL_HasSSE42"/>
    /// <seealso cref="SDL_HasAVX"/>
    /// <seealso cref="SDL_HasAVX2"/>
    /// <seealso cref="SDL_HasAVX512F"/>
    /// <seealso cref="SDL_HasARMSIMD"/>
    /// <seealso cref="SDL_HasLSX"/>
    /// <seealso cref="SDL_HasLASX"/>
    /// <seealso cref="SDL_HasNEON"/>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasSSE3();

    /// <summary>
    /// Determine whether the CPU has SSE4.1 features
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="SDL_HasAltiVec"/>
    /// <seealso cref="SDL_HasMMX"/>
    /// <seealso cref="SDL_Has3DNow"/>
    /// <seealso cref="SDL_HasSSE"/>
    /// <seealso cref="SDL_HasSSE2"/>
    /// <seealso cref="SDL_HasSSE3"/>
    /// <seealso cref="SDL_HasRDTSC"/>
    /// <seealso cref="SDL_HasSSE42"/>
    /// <seealso cref="SDL_HasAVX"/>
    /// <seealso cref="SDL_HasAVX2"/>
    /// <seealso cref="SDL_HasAVX512F"/>
    /// <seealso cref="SDL_HasARMSIMD"/>
    /// <seealso cref="SDL_HasLSX"/>
    /// <seealso cref="SDL_HasLASX"/>
    /// <seealso cref="SDL_HasNEON"/>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasSSE41();

    /// <summary>
    /// Determine whether the CPU has SSE4.2 features
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="SDL_HasAltiVec"/>
    /// <seealso cref="SDL_HasMMX"/>
    /// <seealso cref="SDL_Has3DNow"/>
    /// <seealso cref="SDL_HasSSE"/>
    /// <seealso cref="SDL_HasSSE2"/>
    /// <seealso cref="SDL_HasSSE3"/>
    /// <seealso cref="SDL_HasSSE41"/>
    /// <seealso cref="SDL_HasRDTSC"/>
    /// <seealso cref="SDL_HasAVX"/>
    /// <seealso cref="SDL_HasAVX2"/>
    /// <seealso cref="SDL_HasAVX512F"/>
    /// <seealso cref="SDL_HasARMSIMD"/>
    /// <seealso cref="SDL_HasLSX"/>
    /// <seealso cref="SDL_HasLASX"/>
    /// <seealso cref="SDL_HasNEON"/>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasSSE42();

    /// <summary>
    /// Determine whether the CPU has AVX features
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="SDL_HasAltiVec"/>
    /// <seealso cref="SDL_HasMMX"/>
    /// <seealso cref="SDL_Has3DNow"/>
    /// <seealso cref="SDL_HasSSE"/>
    /// <seealso cref="SDL_HasSSE2"/>
    /// <seealso cref="SDL_HasSSE3"/>
    /// <seealso cref="SDL_HasSSE41"/>
    /// <seealso cref="SDL_HasSSE42"/>
    /// <seealso cref="SDL_HasRDTSC"/>
    /// <seealso cref="SDL_HasAVX2"/>
    /// <seealso cref="SDL_HasAVX512F"/>
    /// <seealso cref="SDL_HasARMSIMD"/>
    /// <seealso cref="SDL_HasLSX"/>
    /// <seealso cref="SDL_HasLASX"/>
    /// <seealso cref="SDL_HasNEON"/>
    [SDLVersion(2, 0, 2)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasAVX();

    /// <summary>
    /// Determine whether the CPU has AVX2 features
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="SDL_HasAltiVec"/>
    /// <seealso cref="SDL_HasMMX"/>
    /// <seealso cref="SDL_Has3DNow"/>
    /// <seealso cref="SDL_HasSSE"/>
    /// <seealso cref="SDL_HasSSE2"/>
    /// <seealso cref="SDL_HasSSE3"/>
    /// <seealso cref="SDL_HasSSE41"/>
    /// <seealso cref="SDL_HasSSE42"/>
    /// <seealso cref="SDL_HasAVX"/>
    /// <seealso cref="SDL_HasRDTSC"/>
    /// <seealso cref="SDL_HasAVX512F"/>
    /// <seealso cref="SDL_HasARMSIMD"/>
    /// <seealso cref="SDL_HasLSX"/>
    /// <seealso cref="SDL_HasLASX"/>
    /// <seealso cref="SDL_HasNEON"/>
    [SDLVersion(2, 0, 4)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasAVX2();

    /// <summary>
    /// Determine whether the CPU has AVX-512F features
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="SDL_HasAltiVec"/>
    /// <seealso cref="SDL_HasMMX"/>
    /// <seealso cref="SDL_Has3DNow"/>
    /// <seealso cref="SDL_HasSSE"/>
    /// <seealso cref="SDL_HasSSE2"/>
    /// <seealso cref="SDL_HasSSE3"/>
    /// <seealso cref="SDL_HasSSE41"/>
    /// <seealso cref="SDL_HasSSE42"/>
    /// <seealso cref="SDL_HasAVX"/>
    /// <seealso cref="SDL_HasAVX2"/>
    /// <seealso cref="SDL_HasRDTSC"/>
    /// <seealso cref="SDL_HasARMSIMD"/>
    /// <seealso cref="SDL_HasLSX"/>
    /// <seealso cref="SDL_HasLASX"/>
    /// <seealso cref="SDL_HasNEON"/>
    [SDLVersion(2, 0, 9)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasAVX512F();

    /// <summary>
    /// Determine whether the CPU has ARM SIMD features.
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="SDL_HasAltiVec"/>
    /// <seealso cref="SDL_HasMMX"/>
    /// <seealso cref="SDL_Has3DNow"/>
    /// <seealso cref="SDL_HasSSE"/>
    /// <seealso cref="SDL_HasSSE2"/>
    /// <seealso cref="SDL_HasSSE3"/>
    /// <seealso cref="SDL_HasSSE41"/>
    /// <seealso cref="SDL_HasSSE42"/>
    /// <seealso cref="SDL_HasAVX"/>
    /// <seealso cref="SDL_HasAVX2"/>
    /// <seealso cref="SDL_HasAVX512F"/>
    /// <seealso cref="SDL_HasRDTSC"/>
    /// <seealso cref="SDL_HasLSX"/>
    /// <seealso cref="SDL_HasLASX"/>
    /// <seealso cref="SDL_HasNEON"/>
    [SDLVersion(2, 0, 12)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasARMSIMD();

    /// <summary>
    /// Determine whether the CPU has NEON (ARM SIMD) features.
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="SDL_HasAltiVec"/>
    /// <seealso cref="SDL_HasMMX"/>
    /// <seealso cref="SDL_Has3DNow"/>
    /// <seealso cref="SDL_HasSSE"/>
    /// <seealso cref="SDL_HasSSE2"/>
    /// <seealso cref="SDL_HasSSE3"/>
    /// <seealso cref="SDL_HasSSE41"/>
    /// <seealso cref="SDL_HasSSE42"/>
    /// <seealso cref="SDL_HasAVX"/>
    /// <seealso cref="SDL_HasAVX2"/>
    /// <seealso cref="SDL_HasAVX512F"/>
    /// <seealso cref="SDL_HasRDTSC"/>
    /// <seealso cref="SDL_HasLSX"/>
    /// <seealso cref="SDL_HasLASX"/>
    [SDLVersion(2, 0, 6)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasNEON();

    /// <summary>
    /// Determine whether the CPU has LSX (Loongarch SIMD) features
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="SDL_HasAltiVec"/>
    /// <seealso cref="SDL_HasMMX"/>
    /// <seealso cref="SDL_Has3DNow"/>
    /// <seealso cref="SDL_HasSSE"/>
    /// <seealso cref="SDL_HasSSE2"/>
    /// <seealso cref="SDL_HasSSE3"/>
    /// <seealso cref="SDL_HasSSE41"/>
    /// <seealso cref="SDL_HasSSE42"/>
    /// <seealso cref="SDL_HasAVX"/>
    /// <seealso cref="SDL_HasAVX2"/>
    /// <seealso cref="SDL_HasAVX512F"/>
    /// <seealso cref="SDL_HasARMSIMD"/>
    /// <seealso cref="SDL_HasRDTSC"/>
    /// <seealso cref="SDL_HasLASX"/>
    /// <seealso cref="SDL_HasNEON"/>
    [SDLVersion(2, 24, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasLSX();

    /// <summary>
    /// Determine whether the CPU has LASX (Loongarch SIMD) features
    /// </summary>
    /// <returns></returns>
    /// <seealso cref="SDL_HasAltiVec"/>
    /// <seealso cref="SDL_HasMMX"/>
    /// <seealso cref="SDL_Has3DNow"/>
    /// <seealso cref="SDL_HasSSE"/>
    /// <seealso cref="SDL_HasSSE2"/>
    /// <seealso cref="SDL_HasSSE3"/>
    /// <seealso cref="SDL_HasSSE41"/>
    /// <seealso cref="SDL_HasSSE42"/>
    /// <seealso cref="SDL_HasAVX"/>
    /// <seealso cref="SDL_HasAVX2"/>
    /// <seealso cref="SDL_HasAVX512F"/>
    /// <seealso cref="SDL_HasARMSIMD"/>
    /// <seealso cref="SDL_HasLSX"/>
    /// <seealso cref="SDL_HasRDTSC"/>
    /// <seealso cref="SDL_HasNEON"/>
    [SDLVersion(2, 24, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasLASX();

    /// <summary>
    /// Get the amount of RAM configured in the system.
    /// </summary>
    /// <returns>The amount of RAM configured in the system in MiB</returns>
    /// <since>2.0.1</since>
    [SDLVersion(2, 0, 1)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetSystemRAM();
}