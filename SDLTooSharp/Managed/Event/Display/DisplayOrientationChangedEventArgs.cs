using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event.Attributes;
using SDLTooSharp.Managed.Exception.Event;

namespace SDLTooSharp.Managed.Event.Display;

/// <summary>
/// A display had its orientation changed
/// </summary>
[AcceptableDisplayEvent(SDL.SDL_DisplayEventID.SDL_DISPLAYEVENT_ORIENTATION)]
public sealed class DisplayOrientationChangedEventArgs : AbstractDisplayEventArgs
{

    /// <summary>
    /// Creates a new DisplayOrientationChangedEventArgs object
    /// </summary>
    /// <param name="evt">The SDL_Event structure containing the event's information</param>
    /// <exception cref="InvalidEventTypeException">In case the event type is unacceptable. </exception>
    /// <exception cref="EventClassMissingAttributeException">In case the child class is not annotated with a <see cref="AcceptableEventTypeAttribute"/> and as such the check cannot be performed</exception>
    public DisplayOrientationChangedEventArgs(SDL.SDL_Event evt) : base(evt)
    {
    }
}
