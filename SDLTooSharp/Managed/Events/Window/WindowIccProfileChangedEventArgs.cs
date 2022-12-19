using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowIccProfileChangedEventArgs : AbstractWindowEventArgs
{

    public WindowIccProfileChangedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Event != (byte)WindowEventType.IccProfileChanged )
        {
            throw new InvalidWindowSubtypeEventException(
                WindowEventType.IccProfileChanged,
                (WindowEventType)@event.Window.Type
            );
        }
    }
}
