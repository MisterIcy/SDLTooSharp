using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Window;

[ExcludeFromCodeCoverage]
public abstract class WindowEventArgs : CommonEventArgs
{
    public WindowEventType WindowEventType { get; }
    public uint WindowID { get; }
    public int Data1 { get; }
    public int Data2 { get; }

    protected WindowEventArgs(SDL.SDL_Event ev) : base(ev)
    {
        if ( EventType != EventType.WindowEvent )
        {
            throw new InvalidEventTypeException(
                EventType.WindowEvent,
                EventType,
                ev);
        }

        WindowEventType = (WindowEventType)ev.Window.Event;
        WindowID = ev.Window.WindowID;
        Data1 = ev.Window.Data1;
        Data2 = ev.Window.Data2;
    }
}
