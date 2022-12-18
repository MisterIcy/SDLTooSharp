using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Joystick;

public enum JoystickPowerLevel
{
    Unknown = SDL.SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_UNKNOWN,
    Empty = SDL.SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_EMPTY,
    Low = SDL.SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_LOW,
    Medium = SDL.SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_MEDIUM,
    Full = SDL.SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_FULL,
    Wired = SDL.SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_WIRED,
    Max = SDL.SDL_JoystickPowerLevel.SDL_JOYSTICK_POWER_MAX
}
