using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event.Attributes;
using SDLTooSharp.Managed.Exception.Event;

namespace SDLTooSharp.Managed.Event.Application;

/// <summary>
/// Event args class for AppLowMemory
/// </summary>
[AcceptableEventType(SDL.SDL_EventType.SDL_APP_LOWMEMORY)]
public sealed class AppLowMemoryEventArgs : AbstractApplicationEventArgs
{

    /// <summary>
    /// Creates a new AppLowMemoryEventArgs object
    /// </summary>
    /// <param name="evt">The SDL_Event structure containing the event's information</param>
    /// <exception cref="InvalidEventTypeException">In case the event type is unacceptable. </exception>
    /// <exception cref="EventClassMissingAttributeException">In case the child class is not annotated with a <see cref="AcceptableEventTypeAttribute"/> and as such the check cannot be performed</exception>
    public AppLowMemoryEventArgs(SDL.SDL_Event evt) : base(evt)
    {
    }
}
