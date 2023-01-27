using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Event.Attributes;

/// <summary>
/// Attribute class for annotating EventArgs Classes with their acceptable event type
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class AcceptableEventTypeAttribute : Attribute
{
    /// <summary>
    /// Gets the acceptable event type. 
    /// </summary>
    public SDL.SDL_EventType EventType { get; }

    /// <summary>
    /// The acceptable event type
    /// </summary>
    /// <param name="Type">The event type acceptable by the event args class</param>
    public AcceptableEventTypeAttribute(SDL.SDL_EventType Type)
    {
        EventType = Type;
    }
}
