using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Event.Attributes;

/// <summary>
/// Attribute class for annotating Display Event Classes with their acceptable event type
/// </summary>
public class AcceptableDisplayEventAttribute : AcceptableEventTypeAttribute
{
    /// <summary>
    /// The display event Id
    /// </summary>
    public SDL.SDL_DisplayEventID DisplayEventId { get; }

    /// <summary>
    /// Creates a new AcceptableDisplayEventAttribute
    /// </summary>
    /// <param name="displayEventId">The DisplayEventId as reported by SDL</param>
    public AcceptableDisplayEventAttribute(SDL.SDL_DisplayEventID displayEventId) : base(SDL.SDL_EventType
       .SDL_DISPLAYEVENT)
    {
        DisplayEventId = displayEventId;
    }
}
