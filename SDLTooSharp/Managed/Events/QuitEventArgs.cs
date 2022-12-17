using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events;

public sealed class QuitEventArgs : AbstractEventArgs
{
    public QuitEventArgs(SDL.SDL_Event ev) : base(ev)
    {
        if ( ev.Type != (uint)EventType.Quit )
        {
            throw new ArgumentException(
                "Not a QuitEvent", nameof(ev)
            );
        }
    }
}
