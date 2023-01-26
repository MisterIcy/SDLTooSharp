using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event.Attributes;
using SDLTooSharp.Managed.Exception.Event;

namespace SDLTooSharp.Managed.Event.Application;

public abstract class AbstractApplicationEventArgs : AbstractSDLEventArgs
{
    /// <summary>
    /// An abstract event for all application related things (quit, locale changed, etc).
    /// </summary>
    /// <param name="evt">The event structure which contains event information</param>
    /// <exception cref="InvalidEventTypeException">In case the event type is unacceptable. </exception>
    /// <exception cref="EventClassMissingAttributeException">In case the child class is not annotated with a <see cref="AcceptableEventTypeAttribute"/> and as such the check cannot be performed</exception>
    protected AbstractApplicationEventArgs(SDL.SDL_Event evt) : base(evt)
    {
    }
}
