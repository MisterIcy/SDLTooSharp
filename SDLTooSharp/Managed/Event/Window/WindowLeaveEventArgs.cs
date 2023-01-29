using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event.Attributes;
using SDLTooSharp.Managed.Event.Window;

namespace SDLTooSharp.Managed.Event;

[AcceptableWindowEvent(SDL.SDL_WindowEventID.SDL_WINDOWEVENT_LEAVE)]
public sealed class WindowLeaveEventArgs : AbstractWindowEventArgs
{

    public WindowLeaveEventArgs(SDL.SDL_Event evt) : base(evt)
    {
    }
}
