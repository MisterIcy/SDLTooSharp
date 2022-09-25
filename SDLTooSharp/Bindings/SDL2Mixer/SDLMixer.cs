using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Bindings.SDL2Mixer;

public static partial class SDLMixer
{
    private const string dllName = "SDL2_mixer";
    
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_Linked_Version")]
    private static extern IntPtr _Mix_Linked_Version();

    public static SDL.SDL_version Mix_Linked_Version()
    {
        IntPtr version = _Mix_Linked_Version();
        return Marshal.PtrToStructure<SDL.SDL_version>(version);
    }
    
    public enum MIX_InitFlags
    {
        MIX_INIT_FLAC = 0x00000001,
        MIX_INIT_MOD = 0x00000002,
        MIX_INIT_MP3 = 0x00000008,
        MIX_INIT_OGG = 0x00000010,
        MIX_INIT_MID = 0x00000020,
        MIX_INIT_OPUS = 0x00000040
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_Init(int flags);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void Mix_Quit();

    public const int MIX_CHANNELS = 8;
    public const int MIX_DEFAULT_FREQUENCY = 44100;
    public const int MIX_DEFAULT_CHANNELS = 2;
    public const int MIX_MAX_VOLUME = SDL.SDL_MIX_MAXVOLUME;

    [StructLayout(LayoutKind.Sequential)]
    public struct Mix_Chunk
    {
        public int Allocated;
        public IntPtr AudioBuffer;
        public uint AudioLength;
        public byte Volume;
    }

    public enum Mix_Fading
    {
        MIX_NO_FADING,
        MIX_FADING_OUT,
        MIX_FADING_IN
    }

    public enum Mix_MusicType
    {
        MUS_NONE,
        MUS_CMD,
        MUS_WAV,
        MUS_MOD,
        MUS_MID,
        MUS_OGG,
        MUS_MP3,
        MUS_MP3_MAD_UNUSED,
        MUS_FLAC,
        MUS_MODPLUG_UNUSED,
        MUS_OPUS
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_OpenAudio(int frequency, ushort format, int channels, int chunkSize);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_OpenAudioDevice(int frequency, ushort format, int channels, int chunkSize,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string device, int allowedChanges);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_QuerySpec(out int frequency, out ushort format, out int channels);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_AllocateChannels(int numChannels);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr Mix_LoadWAV_RW(IntPtr src, int freeSrc);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr Mix_LoadWAV([MarshalAs(UnmanagedType.LPUTF8Str)] string file);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr Mix_LoadMUS([MarshalAs(UnmanagedType.LPUTF8Str)] string file);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr Mix_LoadMUS_RW(IntPtr src, int freeSrc);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr Mix_LoadMUSType_RW(IntPtr src, Mix_MusicType type, int freeSrc);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr Mix_QuickLoad_WAV(IntPtr mem);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr Mix_QuickLoad_RAW(IntPtr mem, uint len);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr Mix_FreeChunk(IntPtr chunk);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr Mix_FreeMusic(IntPtr music);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_GetNumChunkDecoders();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_GetChunkDecoder")]
    private static extern IntPtr _Mix_GetChunkDecoder(int index);

    public static string Mix_GetChunkDecoder(int index) => SDL.PtrToManaged(_Mix_GetChunkDecoder(index));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool Mix_HasChunkDecoder([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_GetNumMusicDecoders();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_GetMusicDecoder")]
    private static extern IntPtr _Mix_GetMusicDecoder(int index);

    public static string Mix_GetMusicDecoder(int index) => SDL.PtrToManaged(_Mix_GetMusicDecoder(index));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool Mix_HasMusicDecoder([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Mix_MusicType Mix_GetMusicType(IntPtr music);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_GetMusicTitle")]
    private static extern IntPtr _Mix_GetMusicTitle(IntPtr music);

    public static string Mix_GetMusicTitle(IntPtr music) => SDL.PtrToManaged(_Mix_GetMusicTitle(music));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_GetMusicTitleTag")]
    private static extern IntPtr _Mix_GetMusicTitleTag(IntPtr music);

    public static string Mix_GetMusicTitleTag(IntPtr music) => SDL.PtrToManaged(_Mix_GetMusicTitleTag(music));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_GetMusicArtistTag")]
    private static extern IntPtr _Mix_GetMusicArtistTag(IntPtr music);

    public static string Mix_GetMusicArtistTag(IntPtr music) => SDL.PtrToManaged(_Mix_GetMusicArtistTag(music));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_GetMusicAlbumTag")]
    private static extern IntPtr _Mix_GetMusicAlbumTag(IntPtr music);

    public static string Mix_GetMusicAlbumTag(IntPtr music) => SDL.PtrToManaged(_Mix_GetMusicAlbumTag(music));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "Mix_GetMusicCopyrightTag")]
    private static extern IntPtr _Mix_GetMusicCopyrightTag(IntPtr music);

    public static string Mix_GetMusicCopyrightTag(IntPtr music) => SDL.PtrToManaged(_Mix_GetMusicCopyrightTag(music));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void Mix_SetPostMix(MixFunc func, IntPtr arg);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void Mix_HookMusic(MixFunc func, IntPtr arg);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void Mix_HookMusicFinished(MusicFinished finished);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr Mix_GetMusicHookData();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void Mix_ChannelFinished(ChannelFinished finished);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MixFunc(IntPtr userData, IntPtr stream, int len);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MusicFinished();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ChannelFinished(int channel);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void Mix_EffectFunc_t(int channel, IntPtr stream, int len, IntPtr userData);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void Mix_EffectDone_t(int channel, IntPtr userData);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_RegisterEffect(int channel, Mix_EffectFunc_t funcT, Mix_EffectDone_t doneT,
        IntPtr arg);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_UnregisterEffect(int channel, Mix_EffectFunc_t funcT);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_UnregisterAllEffects(int channel);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_SetPanning(int channel, byte left, byte right);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_SetPosition(int channel, short angle, byte distance);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_SetDistance(int channel, byte distance);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_SetReverseStereo(int channel, int flip);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_ReserveChannels(int channel, int num);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_GroupChannel(int which, int tag);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_GroupChannels(int from, int to, int tag);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_GroupAvailable(int tag);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_GroupCount(int tag);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_GroupOldest(int tag);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_GroupNewer(int tag);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_PlayChannel(int channel, IntPtr chunk, int loops);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_PlayChannelTimed(int channel, IntPtr chunk, int loops, int ticks);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_PlayMusic(IntPtr music, int loops);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_FadeInMusic(IntPtr music, int loops, int ms);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_FadeInMusicPos(IntPtr music, int loops, int ms, double position);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_FadeInChannel(int music, IntPtr chunk, int loops, int ms);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_FadeInChannelTimed(int channel, IntPtr chunk, int loops, int ms, int ticks);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_Volume(int channel, int volume);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_VolumeChunk(IntPtr chunk, int volume);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_VolumeMusic(int volume);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_GetMusicVolume(IntPtr music);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_MasterVolume(int volume);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_HaltChannel(int channel);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_HaltGroup(int tag);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_HaltMusic();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_ExpireChannel(int channel, int ticks);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_FadeOutChannel(int which, int ms);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_FadeOutGroup(int tag, int ms);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_FadeOutMusic(int ms);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Mix_Fading Mix_FadingMusic();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Mix_Fading Mix_FadingChannel(int which);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void Mix_Pause(int which);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void Mix_Resume(int channel);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_Paused(int channel);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void Mix_PauseMusic();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void Mix_ResumeMusic();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void Mix_RewindMusic();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_PausedMusic();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_ModMusicJumpToOrder(int order);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_SetMusicPosition(double position);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern double Mix_GetMusicPosition(IntPtr music);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern double Mix_MusicDuration(IntPtr music);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern double Mix_GetMusicLoopStartTime(IntPtr music);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern double Mix_GetMusicLoopEndTime(IntPtr music);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern double Mix_GetMusicLoopLengthTime(IntPtr music);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_Playing(int channel);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int Mix_PlayingMusic();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr Mix_GetChunk(int channel);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void Mix_CloseAudio();

    public static int Mix_SetError(string error) => SDL.SDL_SetError(error);
    public static string Mix_GetError() => SDL.SDL_GetError();
    public static void Mix_ClearError() => SDL.SDL_ClearError();
}
