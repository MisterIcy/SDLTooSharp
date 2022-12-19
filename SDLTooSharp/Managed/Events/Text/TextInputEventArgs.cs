using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Text;

public sealed class TextInputEventArgs : AbstractTextEventArgs
{

    public TextInputEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.TextInput )
        {
            throw new InvalidEventTypeException(
                EventType.TextInput,
                (EventType)@event.Type
            );
        }

        unsafe
        {
            Text = new string(@event.Text.Text);
        }

        WindowId = @event.Text.WindowID;
    }
}
