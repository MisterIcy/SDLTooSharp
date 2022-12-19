using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Keyboard;

public abstract class AbstractKeyboardEventArgs : AbstractEventArgs
{
    public uint WindowId { get; }
    public KeyState State { get; }
    public byte Repeat { get; }
    public SDL.SDL_Keysym Keysym { get; }

    protected AbstractKeyboardEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        WindowId = @event.Key.WindowID;
        State = (KeyState)@event.Key.State;
        Repeat = @event.Key.Repeat;
        Keysym = @event.Key.KeySym;
    }
}
