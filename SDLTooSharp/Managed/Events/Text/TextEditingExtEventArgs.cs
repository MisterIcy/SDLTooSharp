using System.Runtime.InteropServices;
using System.Text;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Text;

public sealed class TextEditingExtEventArgs : AbstractTextEventArgs
{
    private int _start;
    private int _length;

    public TextEditingExtEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.TextEditingExt )
        {
            throw new InvalidEventTypeException(
                "TextEditingExt",
                ( (EventType)@event.Type ).ToString()
            );
        }

        _text = Marshal.PtrToStringUTF8(@event.EditExt.Text) ?? string.Empty;
        _windowId = @event.EditExt.WindowID;
        _start = @event.EditExt.Start;
        _length = @event.EditExt.Length;
    }

    public int GetStart() => _start;
    public int GetLength() => _length;
}
