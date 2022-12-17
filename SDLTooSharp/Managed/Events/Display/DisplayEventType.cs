using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Display;

public enum DisplayEventType
{
    None = SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_NONE,
    OrientationChanged = SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_ORIENTATION,
    Connected = SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_CONNECTED,
    Disconnected = SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_DISCONNECTED
}
