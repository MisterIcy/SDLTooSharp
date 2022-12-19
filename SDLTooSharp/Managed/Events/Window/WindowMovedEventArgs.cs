using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowMovedEventArgs : AbstractWindowEventArgs
{

    public WindowMovedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Event != (byte)WindowEventType.Moved )
        {
            throw new InvalidWindowSubtypeEventException(
                WindowEventType.Moved,
                (WindowEventType)@event.Window.Type
            );
        }
    }
}
