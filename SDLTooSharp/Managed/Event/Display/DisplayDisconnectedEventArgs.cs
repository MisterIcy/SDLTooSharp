using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event.Attributes;
using SDLTooSharp.Managed.Exception.Event;

namespace SDLTooSharp.Managed.Event.Display;

/// <summary>
/// Event args for when a display gets disconnected from the system.
/// </summary>
[AcceptableDisplayEvent(SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_DISCONNECTED)]
public sealed class DisplayDisconnectedEventArgs : AbstractDisplayEventArgs
{
    /// <summary>
    /// Creates a new DisplayDisconnectedEventArgs object
    /// </summary>
    /// <param name="evt">The SDL_Event structure containing the event's information</param>
    /// <exception cref="InvalidEventTypeException">In case the event type is unacceptable. </exception>
    /// <exception cref="EventClassMissingAttributeException">In case the child class is not annotated with a <see cref="AcceptableEventTypeAttribute"/> and as such the check cannot be performed</exception>
    public DisplayDisconnectedEventArgs(SDL.SDL_Event evt) : base(evt)
    {
    }
}
