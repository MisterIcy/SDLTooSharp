using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

namespace SDLTooSharp.Bindings.SDL2;

[ExcludeFromCodeCoverage]
public static partial class SDL
{
    private const string dllName = "SDL2";

    public const uint SDL_INIT_TIMER = 0x00000001u;
    public const uint SDL_INIT_AUDIO = 0x00000010u;
    public const uint SDL_INIT_VIDEO = 0x00000020u;
    public const uint SDL_INIT_JOYSTICK = 0x00000200u;
    public const uint SDL_INIT_HAPTIC = 0x00001000u;
    public const uint SDL_INIT_GAMECONTROLLER = 0x00002000u;
    public const uint SDL_INIT_EVENTS = 0x00004000u;
    public const uint SDL_INIT_SENSOR = 0x00008000u;
    public const uint SDL_INIT_NOPARACHUTE = 0x00100000u;

    public const uint SDL_INIT_EVERYTHING = SDL_INIT_TIMER | SDL_INIT_AUDIO | SDL_INIT_VIDEO | SDL_INIT_EVENTS |
                                            SDL_INIT_JOYSTICK | SDL_INIT_HAPTIC | SDL_INIT_GAMECONTROLLER |
                                            SDL_INIT_SENSOR;
    ///<summary>Initialize the SDL library.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_Init">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_Init(uint flags);
    ///<summary>Compatibility function to initialize the SDL library.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_InitSubSystem">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_InitSubSystem(uint flags);
    ///<summary>Shut down specific SDL subsystems.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_QuitSubSystem">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_QuitSubSystem(uint flags);
    ///<summary>Get a mask of the specified subsystems which are currently initialized.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_WasInit">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_WasInit(uint flags);
    ///<summary>Clean up all initialized subsystems.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_Quit">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_Quit();

    internal static string PtrToManaged(IntPtr str, bool mustFree = false)
    {
        if ( str == IntPtr.Zero )
        {
            return string.Empty;
        }

        unsafe
        {
            byte* ptr = (byte*)str;
            while ( *ptr != 0 )
            {
                ptr++;
            }

            var result = Encoding.UTF8.GetString(
                (byte*)str, (int)( ptr - (byte*)str )
            );

            if ( mustFree )
            {
                SDL_free(str);
            }

            return result;
        }
    }
}
