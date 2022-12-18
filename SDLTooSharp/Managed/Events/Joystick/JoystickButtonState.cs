using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Joystick;

public enum JoystickButtonState : byte
{
    Pressed = SDL.SDL_PRESSED,
    Released = SDL.SDL_RELEASED
}
