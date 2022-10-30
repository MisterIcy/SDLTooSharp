using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Common.Events.Display;

public enum DisplayEventType
{
    Connected = SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_CONNECTED,
    Disconnected = SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_DISCONNECTED,
    OrientationChanged = SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_ORIENTATION
}
