using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event.Attributes;
using SDLTooSharp.Managed.Exception.Event;

namespace SDLTooSharp.Managed.Event.Application;

/// <summary>
/// The application is moving to the foreground
/// </summary>
[AcceptableEventType(SDL.SDL_EventType.SDL_APP_WILLENTERFOREGROUND)]
public sealed class AppWillEnterForegroundEventArgs : AbstractApplicationEventArgs
{
    /// <summary>
    /// Creates a new AppWillEnterForegroundEventArgs object
    /// </summary>
    /// <param name="evt">The SDL_Event structure containing the event's information</param>
    /// <exception cref="InvalidEventTypeException">In case the event type is unacceptable. </exception>
    /// <exception cref="EventClassMissingAttributeException">In case the child class is not annotated with a <see cref="AcceptableEventTypeAttribute"/> and as such the check cannot be performed</exception>
    public AppWillEnterForegroundEventArgs(SDL.SDL_Event evt) : base(evt)
    {
    }
}
