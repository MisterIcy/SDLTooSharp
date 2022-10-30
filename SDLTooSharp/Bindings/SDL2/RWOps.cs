using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    public const uint SDL_RWOPS_UNKNOWN = 0U;
    public const uint SDL_RWOPS_WINFILE = 1U;
    public const uint SDL_RWOPS_STDFILE = 2U;
    public const uint SDL_RWOPS_JNIFILE = 3U;
    public const uint SDL_RWOPS_MEMORY = 4U;
    public const uint SDL_RWOPS_MEMORY_RO = 5U;

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_RWFromFile(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string file,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string mode);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_RWFromMem(IntPtr mem, int size);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_RWFromConstMem(IntPtr mem, int size);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_AllocRW();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_FreeRW(IntPtr area);

    public const int RW_SEEK_SET = 0;
    public const int RW_SEEK_CUR = 1;
    public const int RW_SEEK_END = 2;

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_RWsize(IntPtr context);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_RWseek(IntPtr context, long offset, int whence);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_RWtell(IntPtr context);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_RWread(IntPtr context, IntPtr ptr, long size, long maxNum);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_RWwrite(IntPtr context, IntPtr ptr, long size, long num);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RWclose(IntPtr context);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_LoadFile_RW(IntPtr src, out long dataSize, int freeSrc);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_LoadFile([MarshalAs(UnmanagedType.LPUTF8Str)] string file, out long dataSize);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern byte SDL_ReadU8(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_ReadLE16(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_ReadBE16(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_ReadLE32(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_ReadBE32(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong SDL_ReadLE64(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong SDL_ReadBE64(IntPtr src);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_WriteU8(IntPtr dst, byte value);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_WriteLE16(IntPtr dst, ushort value);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_WriteBE16(IntPtr dst, ushort value);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_WriteLE32(IntPtr dst, uint value);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_WriteBE32(IntPtr dst, uint value);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_WriteLE64(IntPtr dst, ulong value);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_WriteBE64(IntPtr dst, ulong value);
}
