using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event.Attributes;
using SDLTooSharp.Managed.Exception.Event;

namespace SDLTooSharp.Managed.Event.Window;

/// <summary>
/// Event args for when a Window is moved to another display
/// </summary>
[AcceptableWindowEvent(SDL.SDL_WindowEventID.SDL_WINDOWEVENT_DISPLAY_CHANGED)]
public sealed class WindowDisplayChangedEventArgs : AbstractWindowEventArgs
{

    /// <summary>
    /// Creates a new WindowDisplayChangedEventArgs object
    /// </summary>
    /// <remarks>The display where the window moved is stored in <see cref="AbstractWindowEventArgs.Data1"/>.</remarks>
    /// <param name="evt">The SDL_Event structure containing the event's information</param>
    /// <exception cref="InvalidEventTypeException">In case the event type is unacceptable. </exception>
    /// <exception cref="EventClassMissingAttributeException">In case the child class is not annotated with a <see cref="AcceptableEventTypeAttribute"/> and as such the check cannot be performed</exception>
    public WindowDisplayChangedEventArgs(SDL.SDL_Event evt) : base(evt)
    {
    }
}
