using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event.Attributes;
using SDLTooSharp.Managed.Exception.Event;

namespace SDLTooSharp.Managed.Event;

/// <summary>
/// Abstract class for all SDL Related Events
/// </summary>
public abstract class AbstractSDLEventArgs : EventArgs
{
    /// <summary>
    /// The actual SDL_Event structure as reported by SDL.
    /// </summary>
    public SDL.SDL_Event Event { get; }

    /// <summary>
    /// Gets a value indicating the <see cref="EventType"/>.
    /// </summary>
    public EventType EventType { get; }

    /// <summary>
    /// Creates a new AbstractSDLEventArgs object.
    /// </summary>
    /// <param name="evt">An <see cref="SDL.SDL_Event"/> structure containing the event data.</param>
    /// <exception cref="InvalidEventTypeException">In case the event type is unacceptable. </exception>
    /// <exception cref="EventClassMissingAttributeException">In case the child class is not annotated with a <see cref="AcceptableEventTypeAttribute"/> and as such the check cannot be performed</exception>
    protected AbstractSDLEventArgs(SDL.SDL_Event evt)
    {
        CheckEventType((SDL.SDL_EventType)evt.Type);
        Event = evt;
        EventType = (EventType)evt.Type;
    }

    /// <summary>
    /// Checks whether the event type is acceptable for the event class being created
    /// </summary>
    /// <remarks>
    /// This is a more generic validation than having to perform the same check in each
    /// of the EventArgs classes constructors. 
    /// </remarks>
    /// <param name="evtType">The event type which came from SDL</param>
    /// <exception cref="InvalidEventTypeException">In case the event type is unacceptable. </exception>
    /// <exception cref="EventClassMissingAttributeException">In case the child class is not annotated with a <see cref="AcceptableEventTypeAttribute"/> and as such the check cannot be performed</exception>
    private void CheckEventType(SDL.SDL_EventType evtType)
    {
        if ( DoesInternalChecks() )
        {
            return;
        }

        uint declaredEventType;

        try
        {
            var attributeData = GetType()
                               .GetCustomAttributesData()
                               .First(x => x.AttributeType == typeof(AcceptableEventTypeAttribute));
            declaredEventType = (uint)( attributeData.ConstructorArguments[0].Value ?? 0 );
        } catch ( InvalidOperationException )
        {
            // It doesn't have the attribute we expect
            throw new EventClassMissingAttributeException(GetType().Name);
        }

        if ( (uint)evtType != declaredEventType )
        {
            throw new InvalidEventTypeException(
                GetType().Name,
                declaredEventType,
                (uint)evtType
            );
        }
    }

    /// <summary>
    /// Checks if the class performs internal checks regarding events.
    /// </summary>
    /// <returns>True if the class uses the <see cref="InternalEventChecksAttribute"/> otherwise false</returns>
    private bool DoesInternalChecks()
    {
        return GetType()
              .CustomAttributes
              .Count(x => x.AttributeType == typeof(InternalEventChecksAttribute)) == 1;
    }
}
