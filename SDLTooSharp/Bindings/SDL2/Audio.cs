using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    public const ushort SDL_AUDIO_MASK_BITSIZE = 0xFF;
    public const ushort SDL_AUDIO_MASK_DATATYPE = 1 << 8;
    public const ushort SDL_AUDIO_MASK_ENDIAN = 1 << 12;
    public const ushort SDL_AUDIO_MASK_SIGNED = 1 << 15;

    public static byte SDL_AUDIO_BITSIZE(ushort x)
    {
        return (byte)( x & SDL_AUDIO_MASK_BITSIZE );
    }

    public static bool SDL_AUDIO_ISFLOAT(ushort x) => ( x & SDL_AUDIO_MASK_DATATYPE ) == SDL_AUDIO_MASK_DATATYPE;
    public static bool SDL_AUDIO_ISINT(ushort x) => !SDL_AUDIO_ISFLOAT(x);
    public static bool SDL_AUDIO_ISBIGENDIAN(ushort x) => ( x & SDL_AUDIO_MASK_ENDIAN ) == SDL_AUDIO_MASK_ENDIAN;
    public static bool SDL_AUDIO_ISLITTLEENDIAN(ushort x) => !SDL_AUDIO_ISBIGENDIAN(x);
    public static bool SDL_AUDIO_ISSIGNED(ushort x) => ( x & SDL_AUDIO_MASK_SIGNED ) == SDL_AUDIO_MASK_SIGNED;
    public static bool SDL_AUDIO_ISUNSIGNED(ushort x) => !SDL_AUDIO_ISSIGNED(x);

    public const ushort AUDIO_U8 = 0x0008;
    public const ushort AUDIO_S8 = 0x8008;
    public const ushort AUDIO_U16LSB = 0x0010;
    public const ushort AUDIO_S16LSB = 0x8010;
    public const ushort AUDIO_U16MSB = 0x1010;
    public const ushort AUDIO_S16MSB = 0x9010;
    public const ushort AUDIO_U16 = AUDIO_U16LSB;
    public const ushort AUDIO_S16 = AUDIO_S16LSB;

    public const ushort AUDIO_S32LSB = 0x8020;
    public const ushort AUDIO_S32MSB = 0x9020;
    public const ushort AUDIO_S32 = AUDIO_S32LSB;
    public const ushort AUDIO_F32LSB = 0x8120;
    public const ushort AUDIO_F32MSB = 0x9120;
    public const ushort AUDIO_F32 = AUDIO_F32LSB;

    public const int SDL_AUDIO_ALLOW_FREQUENCY_CHANGE = 0x00000001;
    public const int SDL_AUDIO_ALLOW_FORMAT_CHANGE = 0x00000002;
    public const int SDL_AUDIO_ALLOW_CHANNELS_CHANGE = 0x00000004;
    public const int SDL_AUDIO_ALLOW_SAMPLES_CHANGE = 0x00000008;

    public const int SDL_AUDIO_ALLOW_ANY_CHANGE = SDL_AUDIO_ALLOW_FREQUENCY_CHANGE | SDL_AUDIO_ALLOW_FORMAT_CHANGE |
                                                  SDL_AUDIO_ALLOW_CHANNELS_CHANGE | SDL_AUDIO_ALLOW_SAMPLES_CHANGE;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void SDL_AudioCallback(IntPtr userData, IntPtr stream, int len);

    public delegate void SDL_AudioFilter(ref SDL_AudioCVT cvt, ushort format);

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_AudioSpec
    {
        public int Freq;
        public ushort Format;
        public byte Channels;
        public byte Silence;
        public ushort Samples;
        private ushort Padding;
        public uint Size;
        public SDL_AudioCallback Callback;
        public IntPtr UserData;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_AudioCVT
    {
        public int Needed;
        public ushort SrcFormat;
        public ushort DstFormat;
        public double RateIncr;
        public IntPtr Buffer;
        public int Len;
        public int LenCvt;
        public int LenMutl;
        public double LenRatio;
        public IntPtr filters;
        public int FilterIndex;
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetNumAudioDrivers();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetAudioDriver")]
    private static extern IntPtr _SDL_GetAudioDriver(int index);

    public static string SDL_GetAudioDriver(int index) => PtrToManaged(_SDL_GetAudioDriver(index));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_AudioInit([MarshalAs(UnmanagedType.LPUTF8Str)] string driverName);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_AudioQuit();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCurrentAudioDriver")]
    private static extern IntPtr _SDL_GetCurrentAudioDriver();

    public static string SDL_GetCurrentAudioDriver() =>
        PtrToManaged(_SDL_GetCurrentAudioDriver());

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_OpenAudio(ref SDL_AudioSpec desired, ref SDL_AudioSpec obtained);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetNumAudioDevices(int isCapture);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetAudioDeviceName")]
    private static extern IntPtr _SDL_GetAudioDeviceName(int index, int isCapture);

    public static string SDL_GetAudioDeviceName(int index, int isCapture) =>
        PtrToManaged(_SDL_GetAudioDeviceName(index, isCapture));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetAudioDeviceSpec(int index, int isCapture, ref SDL_AudioSpec spec);

    //FIXME: This is an operation to a double pointer which will probably will not work
    //out of the box with marshalling and `out`. This has to be tested in order to verify
    //if it works and if not, to be refactored. See issue #1
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetDefaultAudioInfo([MarshalAs(UnmanagedType.LPUTF8Str)] out string name,
        ref SDL_AudioSpec spec, int isCapture);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_OpenAudioDevice(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string device,
        int isCapture,
        in SDL_AudioSpec desired,
        ref SDL_AudioSpec obtained,
        int allowedChanges);

    public enum SDL_AudioStatus
    {
        SDL_AUDIO_STOPPED = 0,
        SDL_AUDIO_PLAYING,
        SDL_AUDIO_PAUSED
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_AudioStatus SDL_GetAudioStatus();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_AudioStatus SDL_GetAudioDeviceStatus(uint deviceId);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_PauseAudio(int pauseOn);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_PauseAudioDevice(uint deviceId, int pauseOn);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_LoadWAV_RW(IntPtr src, int freeSrc, out SDL_AudioSpec spec, [Out] IntPtr buf,
        out uint audioLen);

    public static IntPtr SDL_LoadWAV(string file, out SDL_AudioSpec spec, [Out] IntPtr buf, out uint audioLen) =>
        SDL_LoadWAV_RW(SDL_RWFromFile(file, "rb"), 1, out spec, buf, out audioLen);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_FreeWAV(IntPtr audioBuf);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_BuildAudioCVT(out SDL_AudioCVT cvt, ushort srcFormat, byte srcChannels,
        int srcRate, ushort dstFormat, byte dstChannels, int dstRate);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_ConvertAudio(ref SDL_AudioCVT cvt);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_NewAudioStream(
        ushort srcFormat,
        byte srcChannels,
        int srcRate,
        ushort dstFormat,
        byte dstChannels,
        int dstRate);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_AudioStreamPut(IntPtr stream, IntPtr buf, int len);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_AudioStreamGet(IntPtr stream, IntPtr buf, int len);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_AudioStreamAvailable(IntPtr stream);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_AudioStreamFlush(IntPtr stream);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_AudioStreamClear(IntPtr stream);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_FreeAudioStream(IntPtr stream);

    public const byte SDL_MIX_MAXVOLUME = 128;

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_MixAudio(IntPtr dst, IntPtr src, uint len, int volume);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_MixAudioFormat(IntPtr dst, IntPtr src, ushort format, uint len, int volume);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_QueueAudio(uint deviceId, IntPtr data, uint len);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_DequeueAudio(uint deviceId, IntPtr data, uint len);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_GetQueuedAudioSize(uint deviceId);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_ClearQueuedAudio(uint deviceId);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LockAudio();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LockAudioDevice(uint deviceId);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_UnlockAudio();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_UnlockAudioDevice(uint deviceId);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_CloseAudio();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_CloseAudioDevice(uint deviceId);
}
