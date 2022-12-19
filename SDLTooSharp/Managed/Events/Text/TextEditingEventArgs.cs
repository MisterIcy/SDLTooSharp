using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Exception.Events;

namespace SDLTooSharp.Managed.Events.Text;

public sealed class TextEditingEventArgs : AbstractTextEventArgs
{
    public int Start { get; }
    public int Length { get; }

    public TextEditingEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Type != (uint)EventType.TextEditing )
        {
            throw new InvalidEventTypeException(
                EventType.TextEditing,
                (EventType)@event.Type
            );
        }

        unsafe
        {
            Text = new string(@event.Edit.Text);
        }

        WindowId = @event.Edit.WindowID;
        Start = @event.Edit.Start;
        Length = @event.Edit.Length;
    }
}
