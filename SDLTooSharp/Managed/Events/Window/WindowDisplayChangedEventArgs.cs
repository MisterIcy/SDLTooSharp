using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowDisplayChangedEventArgs : AbstractWindowEventArgs
{
    public WindowDisplayChangedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Event != (byte)WindowEventType.DisplayChanged )
        {
            throw new InvalidWindowSubtypeEventException(
                WindowEventType.DisplayChanged,
                (WindowEventType)@event.Window.Type
            );
        }
    }
}
