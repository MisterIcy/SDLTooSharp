using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event.Attributes;
using SDLTooSharp.Managed.Event.Window;

namespace SDLTooSharp.Managed.Event;

[AcceptableWindowEvent(SDL.SDL_WindowEventID.SDL_WINDOWEVENT_HIT_TEST)]
public sealed class WindowHitTestEventArgs : AbstractWindowEventArgs
{

    public WindowHitTestEventArgs(SDL.SDL_Event evt) : base(evt)
    {
    }
}
