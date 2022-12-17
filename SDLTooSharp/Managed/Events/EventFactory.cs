using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events.Display;

namespace SDLTooSharp.Managed.Events;

public class EventFactory
{
    public ISDLEvent CreateFromSDLEvent(SDL.SDL_Event ev) =>
        ev.Type switch {
            (uint)EventType.Quit => new QuitEventArgs(ev),
            (uint)EventType.AppTerminating => new AppTerminatingEventArgs(ev),
            (uint)EventType.AppLowMemory => new AppLowMemoryEventArgs(ev),
            (uint)EventType.AppWillEnterBackground => new AppWillEnterBackgroundEventArgs(ev),
            (uint)EventType.AppDidEnterBackground => new AppDidEnterBackgroundEventArgs(ev),
            (uint)EventType.AppWillEnterForeground => new AppWillEnterForegroundEventArgs(ev),
            (uint)EventType.AppDidEnterForeground => new AppDidEnterForegroundEventArgs(ev),
            (uint)EventType.LocaleChanged => new LocaleChangedEventArgs(ev),
            (uint)EventType.DisplayEvent => CreateFromSDLDisplayEvent(ev),


            _ => throw new ArgumentException("Test")
        };

    private ISDLEvent CreateFromSDLDisplayEvent(SDL.SDL_Event ev)
    {
        return ev.Display.Event switch {
            (byte)DisplayEventType.Connected => new DisplayConnectedEventArgs(ev),
            (byte)DisplayEventType.Disconnected => new DisplayDisconnectedEventArgs(ev),
            (byte)DisplayEventType.OrientationChanged => new DisplayOrientationChangedEventArgs(ev),
            _ => throw new ArgumentException("Invalid")
        };
    }


}
