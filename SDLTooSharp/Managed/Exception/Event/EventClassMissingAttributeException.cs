using SDLTooSharp.Managed.Event;
using SDLTooSharp.Managed.Event.Attributes;

namespace SDLTooSharp.Managed.Exception.Event;

/// <summary>
/// Exception thrown in case a <see cref="AbstractSDLEventArgs"/> derived class
/// is not annotated with the <see cref="AcceptableEventTypeAttribute"/> and as
/// such, no sanity checks can be performed.
/// </summary>
public sealed class EventClassMissingAttributeException : AbstractEventException
{
    /// <summary>
    /// Creates a new EventClassMissingAttributeException
    /// </summary>
    /// <param name="className">The name of the class which is not annotated with the <see cref="AcceptableEventTypeAttribute"/></param>
    public EventClassMissingAttributeException(
        string className
    ) : base($"The Class {className} is missing the attribute regarding the acceptable event type")
    {
    }
}
