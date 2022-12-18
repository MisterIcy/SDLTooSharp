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
                "TextInput",
                ( (EventType)@event.Type ).ToString()
            );
        }

        unsafe
        {
            _text = new string(@event.Text.Text);
        }

        _windowId = @event.Text.WindowID;
    }
}
