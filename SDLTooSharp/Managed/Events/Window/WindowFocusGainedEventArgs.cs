using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowFocusGainedEventArgs : AbstractWindowEventArgs
{

    public WindowFocusGainedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Event != (byte)WindowEventType.FocusGained )
        {
            throw new InvalidWindowSubtypeEventException(
                WindowEventType.FocusGained,
                (WindowEventType)@event.Window.Type
            );
        }
    }
}
