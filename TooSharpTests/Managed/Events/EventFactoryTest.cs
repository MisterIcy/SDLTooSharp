using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Display;
using SDLTooSharp.Managed.Events.Keyboard;
using SDLTooSharp.Managed.Events.Window;

namespace TooSharpTests.Managed.Events;

public class EventFactoryTest
{
    [Fact]
    public void CreateQuitEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;

        var args = ( new EventFactory() ).CreateFromSDLEvent(ev);
        Assert.IsType<QuitEventArgs>(args);
    }
    [Fact]
    public void CreateAppDidEnterForegroundEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.AppDidEnterForeground;

        var args = ( new EventFactory() ).CreateFromSDLEvent(ev);
        Assert.IsType<AppDidEnterForegroundEventArgs>(args);
    }
    [Fact]
    public void CreateAppDidEnterBackgroundEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.AppDidEnterBackground;

        var args = ( new EventFactory() ).CreateFromSDLEvent(ev);
        Assert.IsType<AppDidEnterBackgroundEventArgs>(args);
    }

    [Fact]
    public void CreateAppLowMemoryEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.AppLowMemory;

        var args = ( new EventFactory() ).CreateFromSDLEvent(ev);
        Assert.IsType<AppLowMemoryEventArgs>(args);
    }

    [Fact]
    public void CreateAppTerminatingEventArgs()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.AppTerminating;

        var args = ( new EventFactory() ).CreateFromSDLEvent(ev);
        Assert.IsType<AppTerminatingEventArgs>(args);
    }

    [Fact]
    public void CreateAppWillEnterBackgroundEventArgs()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.AppWillEnterBackground;

        var args = ( new EventFactory() ).CreateFromSDLEvent(ev);
        Assert.IsType<AppWillEnterBackgroundEventArgs>(args);
    }

    [Fact]
    public void CreateAppWillEnterForegroundEventArgs()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.AppWillEnterForeground;

        var args = ( new EventFactory() ).CreateFromSDLEvent(ev);
        Assert.IsType<AppWillEnterForegroundEventArgs>(args);
    }

    [Fact]
    public void CreateLocaleChangedEventArgs()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.LocaleChanged;

        var args = ( new EventFactory() ).CreateFromSDLEvent(ev);
        Assert.IsType<LocaleChangedEventArgs>(args);
    }

    [Fact]
    public void CreateUnknownEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = 0;

        Assert.Throws<ArgumentException>(() => {
            var args = ( new EventFactory() ).CreateFromSDLEvent(ev);
        });
    }

    [Fact]
    public void CreateDisplayConnectedEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Display.Event = (byte)DisplayEventType.Connected;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<DisplayConnectedEventArgs>(args);
    }

    [Fact]
    public void CreateDisplayDisconnectedEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Display.Event = (byte)DisplayEventType.Disconnected;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<DisplayDisconnectedEventArgs>(args);
    }

    [Fact]
    public void CreateDisplayOrientationChangedEvent()
    {

        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Display.Event = (byte)DisplayEventType.OrientationChanged;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<DisplayOrientationChangedEventArgs>(args);
    }

    [Fact]
    public void CreateUnknownDisplayEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Display.Event = 0;

        Assert.Throws<ArgumentException>(() => {
            ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        });
    }

    [Fact]
    public void CreateWindowShownEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.Shown;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<WindowShownEventArgs>(args);
    }

    [Fact]
    public void CreateWindowHiddenEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.Hidden;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<WindowHiddenEventArgs>(args);
    }

    [Fact]
    public void CreateWindowExposedEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.Exposed;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<WindowExposedEventArgs>(args);
    }

    [Fact]
    public void CreateWindowMovedEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.Moved;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<WindowMovedEventArgs>(args);
    }

    [Fact]
    public void CreateWindowResizedEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.Resized;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<WindowResizedEventArgs>(args);
    }

    [Fact]
    public void CreateWindowSizeChangedEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.SizeChanged;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<WindowSizeChangedEventArgs>(args);
    }

    [Fact]
    public void CreateWindowMinimizedEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.Minimized;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<WindowMinimizedEventArgs>(args);
    }

    [Fact]
    public void CreateWindowMaximizedEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.Maximized;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<WindowMaximizedEventArgs>(args);
    }

    [Fact]
    public void CreateWindowRestoredEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.Restored;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<WindowRestoredEventArgs>(args);
    }

    [Fact]
    public void CreateWindowEnterEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.Enter;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<WindowEnterEventArgs>(args);
    }

    [Fact]
    public void CreateWindowLeaveEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.Leave;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<WindowLeaveEventArgs>(args);
    }

    [Fact]
    public void CreateWindowFocusGainedEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.FocusGained;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<WindowFocusGainedEventArgs>(args);
    }

    [Fact]
    public void CreateWindowFocusLostEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.FocusLost;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<WindowFocusLostEventArgs>(args);
    }

    [Fact]
    public void CreateWindowCloseEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.Close;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<WindowCloseEventArgs>(args);
    }

    [Fact]
    public void CreateWindowTakeFocusEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.TakeFocus;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<WindowTakeFocusEventArgs>(args);
    }

    [Fact]
    public void CreateWindowHitTestEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.HitTest;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<WindowHitTestEventArgs>(args);
    }

    [Fact]
    public void CreateWindowIccProfileChangedEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.IccProfileChanged;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<WindowIccProfileChangedEventArgs>(args);
    }

    [Fact]
    public void CreateWindowDisplayChangedEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.DisplayChanged;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<WindowDisplayChangedEventArgs>(args);
    }

    [Fact]
    public void CreateUnknownWindowEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = 0;

        Assert.Throws<ArgumentException>(() => {
            ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        });
    }

    [Fact]
    public void CreateKeyDownEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.KeyDown;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<KeyDownEventArgs>(args);
    }

    [Fact]
    public void CreateKeyUpEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.KeyUp;

        ISDLEvent args = new EventFactory().CreateFromSDLEvent(ev);
        Assert.IsType<KeyUpEventArgs>(args);
    }
}
