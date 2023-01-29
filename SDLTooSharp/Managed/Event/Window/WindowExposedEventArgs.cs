using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event.Attributes;
using SDLTooSharp.Managed.Event.Window;
using SDLTooSharp.Managed.Exception.Event;

namespace SDLTooSharp.Managed.Event;

/// <summary>
/// Event args for when the window has been exposed and needs to be redrawn.
/// </summary>
[AcceptableWindowEvent(SDL.SDL_WindowEventID.SDL_WINDOWEVENT_EXPOSED)]
public sealed class WindowExposedEventArgs : AbstractWindowEventArgs
{
    /// <summary>
    /// Creates a new WindowExposedEventArgs object
    /// </summary>
    /// <param name="evt">The SDL_Event structure containing the event's information</param>
    /// <exception cref="InvalidEventTypeException">In case the event type is unacceptable. </exception>
    /// <exception cref="EventClassMissingAttributeException">In case the child class is not annotated with a <see cref="AcceptableEventTypeAttribute"/> and as such the check cannot be performed</exception>
    public WindowExposedEventArgs(SDL.SDL_Event evt) : base(evt)
    {
    }
}
