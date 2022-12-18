using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Keyboard;

public abstract class AbstractKeyboardEventArgs : AbstractEventArgs
{
    private readonly uint _windowId;
    private readonly KeyState _state;
    private readonly byte _repeat;
    private readonly SDL.SDL_Keysym _keysym;

    protected AbstractKeyboardEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type is not ( (uint)EventType.KeyDown or (uint)EventType.KeyUp ) )
        {
            throw new InvalidEventTypeException(
                "KeyDown or KeyUp",
                ( (EventType)@event.Type ).ToString()
            );
        }

        _windowId = @event.Key.WindowID;
        _state = (KeyState)@event.Key.State;
        _repeat = @event.Key.Repeat;
        _keysym = @event.Key.KeySym;
    }

    public virtual uint GetWindowID() => _windowId;
    public virtual KeyState GetState() => _state;
    public virtual byte GetRepeat() => _repeat;
    public virtual SDL.SDL_Keysym GetKeySym() => _keysym;
}
