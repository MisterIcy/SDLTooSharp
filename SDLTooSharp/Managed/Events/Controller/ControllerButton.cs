using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Controller;

public enum ControllerButton
{
    Invalid = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_INVALID,
    A = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_A,
    B = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_B,
    X = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_X,
    Y = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_Y,
    Back = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_BACK,
    Guide = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_GUIDE,
    Start = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_START,
    LeftStick = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_LEFTSTICK,
    RightStick = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_RIGHTSTICK,
    LeftShoulder = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_LEFTSHOULDER,
    RightShoulder = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_RIGHTSHOULDER,
    DPadUp = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_UP,
    DPadDown = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_DOWN,
    DPadLeft = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_LEFT,
    DPadRight = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_RIGHT,
    Misc1 = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_MISC1,
    Paddle1 = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE1,
    Paddle2 = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE2,
    Paddle3 = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE3,
    Paddle4 = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_PADDLE4,
    Touchpad = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_TOUCHPAD,
    Max = SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_MAX
}
