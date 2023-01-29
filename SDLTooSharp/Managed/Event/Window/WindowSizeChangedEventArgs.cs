using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event.Attributes;
using SDLTooSharp.Managed.Event.Window;

namespace SDLTooSharp.Managed.Event;

[AcceptableWindowEvent(SDL.SDL_WindowEventID.SDL_WINDOWEVENT_SIZE_CHANGED)]
public sealed class WindowSizeChangedEventArgs : AbstractWindowEventArgs
{

    public WindowSizeChangedEventArgs(SDL.SDL_Event evt) : base(evt)
    {
    }
}
