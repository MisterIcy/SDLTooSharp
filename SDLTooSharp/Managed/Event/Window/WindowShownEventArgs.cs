using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event.Attributes;
using SDLTooSharp.Managed.Event.Window;

namespace SDLTooSharp.Managed.Event;

[AcceptableWindowEvent(SDL.SDL_WindowEventID.SDL_WINDOWEVENT_SHOWN)]
public sealed class WindowShownEventArgs : AbstractWindowEventArgs
{

    public WindowShownEventArgs(SDL.SDL_Event evt) : base(evt)
    {
    }
}
