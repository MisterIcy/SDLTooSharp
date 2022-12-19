using System.Runtime.InteropServices;
using System.Text;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Text;

public sealed class TextEditingExtEventArgs : AbstractTextEventArgs
{
    public int Start { get; }
    public int Length { get; }

    public TextEditingExtEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.TextEditingExt )
        {
            throw new InvalidEventTypeException(
                EventType.TextEditingExt,
                (EventType)@event.Type
            );
        }

        Text = Marshal.PtrToStringUTF8(@event.EditExt.Text) ?? string.Empty;
        WindowId = @event.EditExt.WindowID;
        Start = @event.EditExt.Start;
        Length = @event.EditExt.Length;
    }
}
