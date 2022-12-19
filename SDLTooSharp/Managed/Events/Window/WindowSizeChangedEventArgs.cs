using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowSizeChangedEventArgs : AbstractWindowEventArgs
{

    public WindowSizeChangedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Event != (byte)WindowEventType.SizeChanged )
        {
            throw new InvalidWindowSubtypeEventException(
                WindowEventType.Close,
                (WindowEventType)@event.Window.Type
            );
        }
    }
}
