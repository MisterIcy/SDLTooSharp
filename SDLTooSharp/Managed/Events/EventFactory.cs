using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events.Controller;
using SDLTooSharp.Managed.Events.Display;
using SDLTooSharp.Managed.Events.Finger;
using SDLTooSharp.Managed.Events.Joystick;
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
            (uint)EventType.JoyAxisMotion => new JoystickAxisMotionEventArgs(ev),
            (uint)EventType.JoyBallMotion => new JoystickBallMotionEventArgs(ev),
            (uint)EventType.JoyBatteryUpdated => new JoystickBatteryChangedEventArgs(ev),
            (uint)EventType.JoyButtonDown => new JoystickButtonDownEventArgs(ev),
            (uint)EventType.JoyButtonUp => new JoystickButtonUpEventArgs(ev),
            (uint)EventType.JoyDeviceAdded => new JoystickDeviceAddedEventArgs(ev),
            (uint)EventType.JoyDeviceRemoved => new JoystickDeviceRemovedEventArgs(ev),
            (uint)EventType.JoyHatMotion => new JoystickHatPositionChangeEventArgs(ev),
            (uint)EventType.ControllerAxisMotion => new ControllerAxisMotionEventArgs(ev),
            (uint)EventType.ControllerButtonDown => new ControllerButtonDownEventArgs(ev),
            (uint)EventType.ControllerButtonUp => new ControllerButtonUpEventArgs(ev),
            (uint)EventType.ControllerDeviceAdded => new ControllerDeviceAddedEventArgs(ev),
            (uint)EventType.ControllerDeviceRemapped => new ControllerDeviceRemappedEventArgs(ev),
            (uint)EventType.ControllerDeviceRemoved => new ControllerDeviceRemovedEventArgs(ev),
            (uint)EventType.ControllerTouchPadDown => new ControllerTouchPadDownEventArgs(ev),
            (uint)EventType.ControllerTouchPadMotion => new ControllerTouchPadMotionEventArgs(ev),
            (uint)EventType.ControllerTouchPadUp => new ControllerTouchPadUpEventArgs(ev),
            (uint)EventType.ControllerSensorUpdate => new ControllerSensorUpdatedEventArgs(ev),
            (uint)EventType.FingerDown => new FingerDownEventArgs(ev),
            (uint)EventType.FingerUp => new FingerUpEventArgs(ev),
            (uint)EventType.FingerMotion => new FingerMotionEventArgs(ev),
            (uint)EventType.DollarGesture => throw new NotImplementedException(),
            (uint)EventType.DollarRecord => throw new NotImplementedException(),
            (uint)EventType.Multigesture => throw new NotImplementedException(),
            (uint)EventType.ClipboardUpdate => throw new NotImplementedException(),
            (uint)EventType.DropFile => throw new NotImplementedException(),
            (uint)EventType.DropText => throw new NotImplementedException(),
            (uint)EventType.DropBegin => throw new NotImplementedException(),
            (uint)EventType.DropComplete => throw new NotImplementedException(),
            (uint)EventType.AudioDeviceAdded => throw new NotImplementedException(),
            (uint)EventType.AudioDeviceRemoved => throw new NotImplementedException(),
            (uint)EventType.SensorUpdate => throw new NotImplementedException(),
            (uint)EventType.RenderDeviceReset => throw new NotImplementedException(),
            (uint)EventType.RenderTargetsReset => throw new NotImplementedException(),
            (uint)EventType.PollSentinel => throw new NotImplementedException(),
            (uint)EventType.UserEvent => throw new NotImplementedException(),
            _ => throw new ArgumentException($"Invalid event type: {ev.Type}")
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
