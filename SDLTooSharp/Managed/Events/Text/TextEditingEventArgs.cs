using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Text;

public sealed class TextEditingEventArgs : AbstractTextEventArgs
{
    private int _start;
    private int _length;

    public TextEditingEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.TextEditing )
        {
            throw new InvalidEventTypeException(
                "TextEditing",
                ( (EventType)@event.Type ).ToString()
            );
        }

        unsafe
        {
            _text = new string(@event.Edit.Text);
        }

        _windowId = @event.Edit.WindowID;
        _start = @event.Edit.Start;
        _length = @event.Edit.Length;


    }

    public int GetStart() => _start;
    public int GetLength() => _length;
}
