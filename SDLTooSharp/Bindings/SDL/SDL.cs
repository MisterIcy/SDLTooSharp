using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings;

/// <summary>
/// SDL2 Bindings
/// </summary>
public static partial class SDL2
{
    /// <summary>
    /// The name of the DLL that contains the exported methods.
    /// </summary>
    private const string dllName = "SDL2";

    /// <summary>
    /// Timer subsystem flag.
    /// </summary>
    public const uint SDL_INIT_TIMER = 0x00000001u;

    /// <summary>
    /// Audio subsystem flag.
    /// </summary>
    public const uint SDL_INIT_AUDIO = 0x00000010u;

    /// <summary>
    /// Video subsystem flag.
    /// </summary>
    public const uint SDL_INIT_VIDEO = 0x00000020u;

    /// <summary>
    /// Joystick subsystem flag.
    /// </summary>
    public const uint SDL_INIT_JOYSTICK = 0x00000200u;

    /// <summary>
    /// Haptic subsystem flag.
    /// </summary>
    public const uint SDL_INIT_HAPTIC = 0x00001000u;

    /// <summary>
    /// Game Controller subsystem flag.
    /// </summary>
    public const uint SDL_INIT_GAMECONTROLLER = 0x00002000u;

    /// <summary>
    /// Events subsystem flag.
    /// </summary>
    public const uint SDL_INIT_EVENTS = 0x00004000u;

    /// <summary>
    /// Sensor subsystem flag.
    /// </summary>
    public const uint SDL_INIT_SENSOR = 0x00008000u;

    /// <summary>
    /// This flag is ignored 
    /// </summary>
    [Obsolete("This flag is ignored", true)]
    public const uint SDL_INIT_NOPARACHUTE = 0x00100000u;

    /// <summary>
    /// Combined initialization flags for all subsystems.
    /// </summary>
    public const uint SDL_INIT_EVERYTHING = (SDL_INIT_TIMER | SDL_INIT_AUDIO | SDL_INIT_VIDEO | SDL_INIT_EVENTS |
                                             SDL_INIT_JOYSTICK | SDL_INIT_HAPTIC | SDL_INIT_GAMECONTROLLER |
                                             SDL_INIT_SENSOR);

    /// <summary>
    /// Initialize the SDL Library
    /// </summary>
    /// <param name="flags">One or more subsystem initialization flags, ORed together</param>
    /// <returns>0 on success, negative error code on failure</returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_Init(uint flags);

    /// <summary>
    /// Compatibility function to initialize the SDL library.
    /// </summary>
    /// <param name="flags">One or more subsystem initialization flags, ORed together.</param>
    /// <returns>0 on success, a negative error code on failure.</returns>
    [SDLVersion(2, 0, 0)]
    [Obsolete("Compatibility function to initialize the SDL library, use SDL_Init instead", false)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_InitSubSystem(uint flags);

    /// <summary>
    /// Shutdown specific SDL subsystems.
    /// </summary>
    /// <param name="flags">One or more subsystem initialization flags, ORed together.</param>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_QuitSubSystem(uint flags);

    /// <summary>
    /// Get a mask of the subsystems which are currently initialized
    /// </summary>
    /// <param name="flags">One or more subsystem initialization flags, ORed together.</param>
    /// <returns>A mast of the subsystems which are currently initialized if flags is 0, otherwise returns the status of the specified subsystems</returns>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_WasInit(uint flags);

    /// <summary>
    /// Clean up all initialized subsystems.
    /// </summary>
    [SDLVersion(2, 0, 0)]
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_Quit();
}