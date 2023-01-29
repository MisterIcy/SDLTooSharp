using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Event.Attributes;

/// <summary>
/// Attribute class for annotating Window Event Classes with their acceptable event type
/// </summary>
public class AcceptableWindowEventAttribute : AcceptableEventTypeAttribute
{
    /// <summary>
    /// The window event Id
    /// </summary>
    public SDL.SDL_WindowEventID WindowEventId { get; }

    /// <summary>
    /// Creates a new AcceptableWindowEventAttribute
    /// </summary>
    /// <param name="windowEventId">The WindowEventId as reported by SDL</param>
    public AcceptableWindowEventAttribute(SDL.SDL_WindowEventID windowEventId) : base(SDL.SDL_EventType
       .SDL_WINDOWEVENT)
    {
        WindowEventId = windowEventId;
    }
}
