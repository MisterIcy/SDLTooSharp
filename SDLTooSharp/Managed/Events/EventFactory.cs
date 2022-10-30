using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events.Application;
using SDLTooSharp.Managed.Events.Display;
using SDLTooSharp.Managed.Events.Window;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events;

[ExcludeFromCodeCoverage]
public static class EventFactory
{
    public static CommonEventArgs Factory(SDL.SDL_Event @event)
    {
        return @event.Type switch {
            (uint)SDL.SDL_EventType.SDL_QUIT => new QuitEventArgs(@event),
            (uint)SDL.SDL_EventType.SDL_APP_TERMINATING => new ApplicationTerminatingEventArgs(@event),
            (uint)SDL.SDL_EventType.SDL_APP_LOWMEMORY => new ApplicationLowMemoryEventArgs(@event),
            (uint)SDL.SDL_EventType.SDL_APP_WILLENTERBACKGROUND => new ApplicationWillEnterBackgroundEventArgs(@event),
            (uint)SDL.SDL_EventType.SDL_APP_DIDENTERBACKGROUND => new ApplicationDidEnterBackgroundEventArgs(@event),
            (uint)SDL.SDL_EventType.SDL_APP_WILLENTERFOREGROUND => new ApplicationWillEnterForegroundEventArgs(@event),
            (uint)SDL.SDL_EventType.SDL_APP_DIDENTERFOREGROUND => new ApplicationDidEnterForegroundEventArgs(@event),
            (uint)SDL.SDL_EventType.SDL_LOCALECHANGED => new LocaleChangedEventArgs(@event),
            (uint)SDL.SDL_EventType.SDL_DISPLAYEVENT => DisplayEventFactory(@event),
            (uint)SDL.SDL_EventType.SDL_WINDOWEVENT => WindowEventFactory(@event),
            _ => throw new UnknownEventTypeException(@event)
        };
    }

    private static DisplayEventArgs DisplayEventFactory(SDL.SDL_Event @event)
    {
        return @event.Display.Event switch {
            (byte)SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_CONNECTED => new DisplayConnectedEventArgs(@event),
            (byte)SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_DISCONNECTED => new DisplayDisconnectedEventArgs(@event),
            (byte)SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_ORIENTATION => new DisplayOrientationChangedEventArgs(@event),
            _ => throw new UnknownEventTypeException(@event)
        };
    }

    private static WindowEventArgs WindowEventFactory(SDL.SDL_Event @event)
    {
        return @event.Window.Event switch {
            (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_SHOWN => new WindowShownEventArgs(@event),
            (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_HIDDEN => new WindowHiddenEventArgs(@event),
            (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_EXPOSED => new WindowExposedEventArgs(@event),
            (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_MOVED => new WindowMovedEventArgs(@event),
            (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_RESIZED => new WindowResizedEventArgs(@event),
            (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_SIZE_CHANGED => new WindowSizeChangedEventArgs(@event),
            (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_MINIMIZED => new WindowMinimizedEventArgs(@event),
            (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_MAXIMIZED => new WindowMaximizedEventArgs(@event),
            (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_RESTORED => new WindowRestoredEventArgs(@event),
            (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_ENTER => new WindowEnterEventArgs(@event),
            (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_LEAVE => new WindowLeaveEventArgs(@event),
            (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_FOCUS_GAINED => new WindowFocusGainedEventArgs(@event),
            (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_FOCUS_LOST => new WindowFocusLostEventArgs(@event),
            (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_CLOSE => new WindowCloseEventArgs(@event),
            (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_TAKE_FOCUS => new WindowTakeFocusEventArgs(@event),
            (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_HIT_TEST => new WindowHitTestEventArgs(@event),
            (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_ICCPROF_CHANGED => new WindowIccProfileChangedEventArgs(@event),
            (byte)SDL.SDL_WindowEventID.SDL_WINDOWEVENT_DISPLAY_CHANGED => new WindowDisplayChangedEventArgs(@event),
            _ => throw new UnknownEventSubtypeException(@event)
        };
    }
}
