using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Keyboard;

public abstract class KeyboardEventArgs : EventArgs
{
    public uint WindowId { get; protected init; }
    public byte State { get; protected init; }
    public byte Repeat { get; protected init; }
    public SDL.SDL_Keysym Keysym { get; protected init; }

    public KeyboardEventArgs(SDL.SDL_Event ev)
    {
        if ( ev.Type != (uint)SDL.SDL_EventType.SDL_KEYUP || ev.Type != (uint)SDL.SDL_EventType.SDL_KEYUP )
        {
            //TODO: Throw
        }

        WindowId = ev.Key.WindowID;
        State = ev.Key.State;
        Repeat = ev.Key.Repeat;
        Keysym = ev.Key.KeySym;
    }
}
