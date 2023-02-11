using System.Runtime.InteropServices;
#pragma warning disable CS1591
namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public const ushort SDL_AUDIO_MASK_BITSIZE = 0xFF;

    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public const ushort SDL_AUDIO_MASK_DATATYPE = 1 << 8;

    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public const ushort SDL_AUDIO_MASK_ENDIAN = 1 << 12;

    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public const ushort SDL_AUDIO_MASK_SIGNED = 1 << 15;

    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public static byte SDL_AUDIO_BITSIZE(ushort x)
    {
        return (byte)( x & SDL_AUDIO_MASK_BITSIZE );
    }

    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public static bool SDL_AUDIO_ISFLOAT(ushort x) => ( x & SDL_AUDIO_MASK_DATATYPE ) == SDL_AUDIO_MASK_DATATYPE;

    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public static bool SDL_AUDIO_ISINT(ushort x) => !SDL_AUDIO_ISFLOAT(x);

    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public static bool SDL_AUDIO_ISBIGENDIAN(ushort x) => ( x & SDL_AUDIO_MASK_ENDIAN ) == SDL_AUDIO_MASK_ENDIAN;

    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public static bool SDL_AUDIO_ISLITTLEENDIAN(ushort x) => !SDL_AUDIO_ISBIGENDIAN(x);

    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public static bool SDL_AUDIO_ISSIGNED(ushort x) => ( x & SDL_AUDIO_MASK_SIGNED ) == SDL_AUDIO_MASK_SIGNED;

    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public static bool SDL_AUDIO_ISUNSIGNED(ushort x) => !SDL_AUDIO_ISSIGNED(x);

    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public const ushort AUDIO_U8 = 0x0008;
    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public const ushort AUDIO_S8 = 0x8008;
    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public const ushort AUDIO_U16LSB = 0x0010;
    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public const ushort AUDIO_S16LSB = 0x8010;
    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public const ushort AUDIO_U16MSB = 0x1010;
    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public const ushort AUDIO_S16MSB = 0x9010;
    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public const ushort AUDIO_U16 = AUDIO_U16LSB;
    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public const ushort AUDIO_S16 = AUDIO_S16LSB;
    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public const ushort AUDIO_S32LSB = 0x8020;
    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public const ushort AUDIO_S32MSB = 0x9020;
    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public const ushort AUDIO_S32 = AUDIO_S32LSB;
    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public const ushort AUDIO_F32LSB = 0x8120;
    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public const ushort AUDIO_F32MSB = 0x9120;
    /// <remarks>
    /// See <a href="https://wiki.libsdl.org/SDL2/SDL_AudioFormat">SDL2 Documentation</a> for details.
    /// </remarks>
    public const ushort AUDIO_F32 = AUDIO_F32LSB;

    /// <summary>
    /// https://wiki.libsdl.org/SDL2/SDL_OpenAudioDevice
    /// </summary>
    public const int SDL_AUDIO_ALLOW_FREQUENCY_CHANGE = 0x00000001;
    /// <summary>
    /// https://wiki.libsdl.org/SDL2/SDL_OpenAudioDevice
    /// </summary>
    public const int SDL_AUDIO_ALLOW_FORMAT_CHANGE = 0x00000002;
    /// <summary>
    /// https://wiki.libsdl.org/SDL2/SDL_OpenAudioDevice
    /// </summary>
    public const int SDL_AUDIO_ALLOW_CHANNELS_CHANGE = 0x00000004;
    /// <summary>
    /// https://wiki.libsdl.org/SDL2/SDL_OpenAudioDevice
    /// </summary>
    public const int SDL_AUDIO_ALLOW_SAMPLES_CHANGE = 0x00000008;
    /// <summary>
    /// https://wiki.libsdl.org/SDL2/SDL_OpenAudioDevice
    /// </summary>
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

    ///<summary>Use this function to get the number of built-in audio drivers.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetNumAudioDrivers">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetNumAudioDrivers();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetAudioDriver")]
    private static extern IntPtr _SDL_GetAudioDriver(int index);

    ///<summary>Use this function to get the name of a built in audio driver.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetAudioDriver">SDL2 Documentation</a></remarks>
    public static string SDL_GetAudioDriver(int index) => PtrToManaged(_SDL_GetAudioDriver(index));

    ///<summary>Use this function to initialize a particular audio driver.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_AudioInit">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_AudioInit([MarshalAs(UnmanagedType.LPUTF8Str)] string driverName);

    ///<summary>Use this function to shut down audio if you initialized it with SDL_AudioInit().</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_AudioQuit">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_AudioQuit();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCurrentAudioDriver")]
    private static extern IntPtr _SDL_GetCurrentAudioDriver();

    ///<summary>Get the name of the current audio driver.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetCurrentAudioDriver">SDL2 Documentation</a></remarks>
    public static string SDL_GetCurrentAudioDriver() =>
        PtrToManaged(_SDL_GetCurrentAudioDriver());

    ///<summary>This function is a legacy means of opening the audio device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_OpenAudio">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_OpenAudio(ref SDL_AudioSpec desired, ref SDL_AudioSpec obtained);

    ///<summary>Get the number of built-in audio devices.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetNumAudioDevices">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetNumAudioDevices(int isCapture);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetAudioDeviceName")]
    private static extern IntPtr _SDL_GetAudioDeviceName(int index, int isCapture);

    ///<summary>Get the human-readable name of a specific audio device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetAudioDeviceName">SDL2 Documentation</a></remarks>
    public static string SDL_GetAudioDeviceName(int index, int isCapture) =>
        PtrToManaged(_SDL_GetAudioDeviceName(index, isCapture));

    ///<summary>Get the preferred audio format of a specific audio device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetAudioDeviceSpec">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetAudioDeviceSpec(int index, int isCapture, ref SDL_AudioSpec spec);

    ///<summary>Get the name and preferred format of the default audio device.</summary>
    ///<remarks>
    /// FIXME: This is an operation to a double pointer which will probably will not work
    /// out of the box with marshalling and `out`. This has to be tested in order to verify
    /// if it works and if not, to be refactored. See issue #1
    /// <a href="https://wiki.libsdl.org/SDL2/SDL_GetDefaultAudioInfo">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetDefaultAudioInfo(
        [MarshalAs(UnmanagedType.LPUTF8Str)] out string name,
        ref SDL_AudioSpec spec,
        int isCapture
    );

    ///<summary>Open a specific audio device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_OpenAudioDevice">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_OpenAudioDevice(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string device,
        int isCapture,
        in SDL_AudioSpec desired,
        ref SDL_AudioSpec obtained,
        int allowedChanges
    );

    public enum SDL_AudioStatus
    {
        SDL_AUDIO_STOPPED = 0,
        SDL_AUDIO_PLAYING,
        SDL_AUDIO_PAUSED
    }

    ///<summary>This function is a legacy means of querying the audio device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetAudioStatus">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_AudioStatus SDL_GetAudioStatus();

    ///<summary>Use this function to get the current audio state of an audio device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetAudioDeviceStatus">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_AudioStatus SDL_GetAudioDeviceStatus(uint deviceId);

    ///<summary>This function is a legacy means of pausing the audio device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_PauseAudio">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_PauseAudio(int pauseOn);

    ///<summary>Use this function to pause and unpause audio playback on a specified device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_PauseAudioDevice">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_PauseAudioDevice(uint deviceId, int pauseOn);

    ///<summary>Load the audio data of a WAVE file into memory.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LoadWAV_RW">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_LoadWAV_RW(
        IntPtr src,
        int freeSrc,
        out SDL_AudioSpec spec,
        [Out] IntPtr buf,
        out uint audioLen
    );

    ///<summary>Use this function to load a WAVE from a file.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LoadWAV">SDL2 Documentation</a></remarks>
    public static IntPtr SDL_LoadWAV(string file, out SDL_AudioSpec spec, [Out] IntPtr buf, out uint audioLen) =>
        SDL_LoadWAV_RW(SDL_RWFromFile(file, "rb"), 1, out spec, buf, out audioLen);

    ///<summary>Free data previously allocated with SDL_LoadWAV() or SDL_LoadWAV_RW().</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_FreeWAV">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_FreeWAV(IntPtr audioBuf);

    ///<summary>Initialize an SDL_AudioCVT structure for conversion.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_BuildAudioCVT">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_BuildAudioCVT(
        out SDL_AudioCVT cvt,
        ushort srcFormat,
        byte srcChannels,
        int srcRate,
        ushort dstFormat,
        byte dstChannels,
        int dstRate
    );

    ///<summary>Convert audio data to a desired audio format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_ConvertAudio">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_ConvertAudio(ref SDL_AudioCVT cvt);

    ///<summary>Create a new audio stream.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_NewAudioStream">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_NewAudioStream(
        ushort srcFormat,
        byte srcChannels,
        int srcRate,
        ushort dstFormat,
        byte dstChannels,
        int dstRate
    );

    ///<summary>Add data to be converted/resampled to the stream.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_AudioStreamPut">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_AudioStreamPut(IntPtr stream, IntPtr buf, int len);

    ///<summary>Get converted/resampled data from the stream</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_AudioStreamGet">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_AudioStreamGet(IntPtr stream, IntPtr buf, int len);

    ///<summary>Get the number of converted/resampled bytes available.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_AudioStreamAvailable">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_AudioStreamAvailable(IntPtr stream);

    ///<summary>Tell the stream that you're done sending data, and anything being buffered should be converted/resampled and made available immediately.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_AudioStreamFlush">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_AudioStreamFlush(IntPtr stream);

    ///<summary>Clear any pending data in the stream without converting it</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_AudioStreamClear">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_AudioStreamClear(IntPtr stream);

    ///<summary>Free an audio stream</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_FreeAudioStream">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_FreeAudioStream(IntPtr stream);

    public const byte SDL_MIX_MAXVOLUME = 128;

    ///<summary>This function is a legacy means of mixing audio.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_MixAudio">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_MixAudio(IntPtr dst, IntPtr src, uint len, int volume);

    ///<summary>Mix audio data in a specified format.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_MixAudioFormat">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_MixAudioFormat(IntPtr dst, IntPtr src, ushort format, uint len, int volume);

    ///<summary>Queue more audio on non-callback devices.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_QueueAudio">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_QueueAudio(uint deviceId, IntPtr data, uint len);

    ///<summary>Dequeue more audio on non-callback devices.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_DequeueAudio">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_DequeueAudio(uint deviceId, IntPtr data, uint len);

    ///<summary>Get the number of bytes of still-queued audio.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetQueuedAudioSize">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_GetQueuedAudioSize(uint deviceId);

    ///<summary>Drop any queued audio data waiting to be sent to the hardware.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_ClearQueuedAudio">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_ClearQueuedAudio(uint deviceId);

    ///<summary>This function is a legacy means of locking the audio device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LockAudio">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LockAudio();

    ///<summary>Use this function to lock out the audio callback function for a specified device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LockAudioDevice">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LockAudioDevice(uint deviceId);

    ///<summary>This function is a legacy means of unlocking the audio device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_UnlockAudio">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_UnlockAudio();

    ///<summary>Use this function to unlock the audio callback function for a specified device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_UnlockAudioDevice">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_UnlockAudioDevice(uint deviceId);

    ///<summary>This function is a legacy means of closing the audio device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_CloseAudio">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_CloseAudio();

    ///<summary>Use this function to shut down audio processing and close the audio device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_CloseAudioDevice">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_CloseAudioDevice(uint deviceId);
}
