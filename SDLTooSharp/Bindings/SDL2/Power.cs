using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    public enum SDL_PowerState
    {
        SDL_POWERSTATE_UNKNOWN,
        SDL_POWERSTATE_ON_BATTERY,
        SDL_POWERSTATE_NO_BATTERY,
        SDL_POWERSTATE_CHARGING,
        SDL_POWERSTATE_CHARGED
    }
    ///<summary>Get the current power supply details.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetPowerInfo">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_PowerState SDL_GetPowerInfo(out int secs, out int percentage);
}
