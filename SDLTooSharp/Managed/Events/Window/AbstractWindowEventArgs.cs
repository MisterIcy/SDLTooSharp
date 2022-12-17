using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

public abstract class AbstractWindowEventArgs : AbstractEventArgs
{

    private WindowEventType _windowEventType;
    private uint _windowId;
    private int _data1;
    private int _data2;

    public AbstractWindowEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.WindowEvent )
        {
            throw new ArgumentException("Not a Window event", nameof(@event));
        }

        _windowEventType = (WindowEventType)@event.Window.Event;
        _windowId = @event.Window.WindowID;
        _data1 = @event.Window.Data1;
        _data2 = @event.Window.Data2;
    }

    public virtual WindowEventType GetEventType() => _windowEventType;
    public virtual uint GetWindowID() => _windowId;
    public virtual int GetData1() => _data1;
    public virtual int GetData2() => _data2;
}
