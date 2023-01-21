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
    ///<summary>Use this function to create a new SDL_RWops structure for reading from and/or writing to a named file.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RWFromFile">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_RWFromFile(
            [MarshalAs(UnmanagedType.LPUTF8Str)] string file,
            [MarshalAs(UnmanagedType.LPUTF8Str)] string mode);
    ///<summary>Use this function to prepare a read-write memory buffer for use with SDL_RWops.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RWFromMem">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_RWFromMem(IntPtr mem, int size);
    ///<summary>Use this function to prepare a read-only memory buffer for use with RWops.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RWFromConstMem">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_RWFromConstMem(IntPtr mem, int size);
    ///<summary>Use this function to allocate an empty, unpopulated SDL_RWops structure.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_AllocRW">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_AllocRW();
    ///<summary>Use this function to free an SDL_RWops structure allocated by SDL_AllocRW().</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_FreeRW">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_FreeRW(IntPtr area);

    public const int RW_SEEK_SET = 0;
    public const int RW_SEEK_CUR = 1;
    public const int RW_SEEK_END = 2;
    ///<summary>Use this function to get the size of the data stream in an SDL_RWops.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RWsize">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_RWsize(IntPtr context);
    ///<summary>Seek within an SDL_RWops data stream.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RWseek">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_RWseek(IntPtr context, long offset, int whence);
    ///<summary>Determine the current read/write offset in an SDL_RWops data stream.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RWtell">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_RWtell(IntPtr context);
    ///<summary>Read from a data source.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RWread">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_RWread(IntPtr context, IntPtr ptr, long size, long maxNum);
    ///<summary>Write to an SDL_RWops data stream.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RWwrite">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_RWwrite(IntPtr context, IntPtr ptr, long size, long num);
    ///<summary>Close and free an allocated SDL_RWops structure.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RWclose">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RWclose(IntPtr context);
    ///<summary>Load all the data from an SDL data stream.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LoadFile_RW">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_LoadFile_RW(IntPtr src, out long dataSize, int freeSrc);
    ///<summary>Load all the data from a file path.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LoadFile">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_LoadFile([MarshalAs(UnmanagedType.LPUTF8Str)] string file, out long dataSize);
    ///<summary>Use this function to read a byte from an SDL_RWops.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_ReadU8">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern byte SDL_ReadU8(IntPtr src);
    ///<summary>Use this function to read 16 bits of little-endian data from an SDL_RWops and return in native format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_ReadLE16">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_ReadLE16(IntPtr src);
    ///<summary>Use this function to read 16 bits of big-endian data from an SDL_RWops and return in native format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_ReadBE16">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_ReadBE16(IntPtr src);
    ///<summary>Use this function to read 32 bits of little-endian data from an SDL_RWops and return in native format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_ReadLE32">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_ReadLE32(IntPtr src);
    ///<summary>Use this function to read 32 bits of big-endian data from an SDL_RWops and return in native format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_ReadBE32">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_ReadBE32(IntPtr src);
    ///<summary>Use this function to read 64 bits of little-endian data from an SDL_RWops and return in native format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_ReadLE64">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong SDL_ReadLE64(IntPtr src);
    ///<summary>Use this function to read 64 bits of big-endian data from an SDL_RWops and return in native format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_ReadBE64">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong SDL_ReadBE64(IntPtr src);
    ///<summary>Use this function to write a byte to an SDL_RWops.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_WriteU8">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_WriteU8(IntPtr dst, byte value);
    ///<summary>Use this function to write 16 bits in native format to a SDL_RWops as little-endian data.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_WriteLE16">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_WriteLE16(IntPtr dst, ushort value);
    ///<summary>Use this function to write 16 bits in native format to a SDL_RWops as big-endian data.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_WriteBE16">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_WriteBE16(IntPtr dst, ushort value);
    ///<summary>Use this function to write 32 bits in native format to a SDL_RWops as little-endian data.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_WriteLE32">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_WriteLE32(IntPtr dst, uint value);
    ///<summary>Use this function to write 32 bits in native format to a SDL_RWops as big-endian data.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_WriteBE32">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_WriteBE32(IntPtr dst, uint value);
    ///<summary>Use this function to write 64 bits in native format to a SDL_RWops as little-endian data.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_WriteLE64">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_WriteLE64(IntPtr dst, ulong value);
    ///<summary>Use this function to write 64 bits in native format to a SDL_RWops as big-endian data.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_WriteBE64">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_WriteBE64(IntPtr dst, ulong value);
}
