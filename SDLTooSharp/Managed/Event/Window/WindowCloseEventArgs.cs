using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event.Attributes;
using SDLTooSharp.Managed.Exception.Event;

namespace SDLTooSharp.Managed.Event;

/// <summary>
/// Event arguments for when the Window Manager requests the window to be closed.
/// </summary>
[AcceptableWindowEvent(SDL.SDL_WindowEventID.SDL_WINDOWEVENT_CLOSE)]
public sealed class WindowCloseEventArgs : AbstractWindowEventArgs
{

    /// <summary>
    /// Creates a new WindowCloseEventArgs object
    /// </summary>
    /// <param name="evt">The SDL_Event structure containing the event's information</param>
    /// <exception cref="InvalidEventTypeException">In case the event type is unacceptable. </exception>
    /// <exception cref="EventClassMissingAttributeException">In case the child class is not annotated with a <see cref="AcceptableEventTypeAttribute"/> and as such the check cannot be performed</exception>
    public WindowCloseEventArgs(SDL.SDL_Event evt) : base(evt)
    {
    }
}
