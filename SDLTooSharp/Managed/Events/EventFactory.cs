using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events.Display;
using SDLTooSharp.Managed.Events.Keyboard;
using SDLTooSharp.Managed.Events.Mouse;
using SDLTooSharp.Managed.Events.Text;
using SDLTooSharp.Managed.Events.Window;

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
            (uint)EventType.WindowEvent => CreateFromSDLWindowEvent(ev),
            (uint)EventType.KeyDown => new KeyDownEventArgs(ev),
            (uint)EventType.KeyUp => new KeyUpEventArgs(ev),
            (uint)EventType.TextEditing => new TextEditingEventArgs(ev),
            (uint)EventType.TextEditingExt => new TextEditingExtEventArgs(ev),
            (uint)EventType.TextInput => new TextInputEventArgs(ev),
            (uint)EventType.MouseMotion => new MouseMotionEventArgs(ev),
            (uint)EventType.MouseButtonDown => new MouseButtonDownEventArgs(ev),
            (uint)EventType.MouseButtonUp => new MouseButtonUpEventArgs(ev),
            (uint)EventType.MouseWheel => new MouseWheelEventArgs(ev),
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

    private ISDLEvent CreateFromSDLWindowEvent(SDL.SDL_Event ev) =>
        ev.Window.Event switch {
            (byte)WindowEventType.Shown => new WindowShownEventArgs(ev),
            (byte)WindowEventType.Hidden => new WindowHiddenEventArgs(ev),
            (byte)WindowEventType.Exposed => new WindowExposedEventArgs(ev),
            (byte)WindowEventType.Moved => new WindowMovedEventArgs(ev),
            (byte)WindowEventType.Resized => new WindowResizedEventArgs(ev),
            (byte)WindowEventType.SizeChanged => new WindowSizeChangedEventArgs(ev),
            (byte)WindowEventType.Minimized => new WindowMinimizedEventArgs(ev),
            (byte)WindowEventType.Maximized => new WindowMaximizedEventArgs(ev),
            (byte)WindowEventType.Restored => new WindowRestoredEventArgs(ev),
            (byte)WindowEventType.Enter => new WindowEnterEventArgs(ev),
            (byte)WindowEventType.Leave => new WindowLeaveEventArgs(ev),
            (byte)WindowEventType.FocusGained => new WindowFocusGainedEventArgs(ev),
            (byte)WindowEventType.FocusLost => new WindowFocusLostEventArgs(ev),
            (byte)WindowEventType.Close => new WindowCloseEventArgs(ev),
            (byte)WindowEventType.TakeFocus => new WindowTakeFocusEventArgs(ev),
            (byte)WindowEventType.HitTest => new WindowHitTestEventArgs(ev),
            (byte)WindowEventType.IccProfileChanged => new WindowIccProfileChangedEventArgs(ev),
            (byte)WindowEventType.DisplayChanged => new WindowDisplayChangedEventArgs(ev),
            _ => throw new ArgumentException("Invalid")
        };


}
