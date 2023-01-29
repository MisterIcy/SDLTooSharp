using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event.Attributes;
using SDLTooSharp.Managed.Exception.Event;

namespace SDLTooSharp.Managed.Event.Display;

public abstract class AbstractDisplayEventArgs : AbstractSDLEventArgs
{
    /// <summary>
    /// The display for which the event got triggered.
    /// </summary>
    public uint Display { get; }

    /// <summary>
    /// Extra data contained by the event (such as the display's orientation)
    /// </summary>
    /// <remarks>The value of this property is event-specific.</remarks>
    public int Data { get; }

    protected AbstractDisplayEventArgs(SDL.SDL_Event evt) : base(evt)
    {
        Display = evt.Display.Display;
        Data = evt.Display.Data1;
    }
    /// <inheritdoc cref="CheckEventType"/>
    protected sealed override void CheckEventType(SDL.SDL_Event evt)
    {
        uint declaredEventType;

        if ( evt.Type != (uint)SDL.SDL_EventType.SDL_DISPLAYEVENT )
        {
            throw new InvalidEventTypeException(
                GetType().Name,
                (uint)SDL.SDL_EventType.SDL_DISPLAYEVENT,
                evt.Display.Type
            );
        }

        try
        {
            var attributeData = GetType()
                               .GetCustomAttributesData()
                               .First(x => x.AttributeType == typeof(AcceptableDisplayEventAttribute));

            declaredEventType = (uint)( attributeData.ConstructorArguments[0].Value ?? 0 );
        } catch ( InvalidOperationException )
        {
            throw new EventClassMissingAttributeException(GetType().Name);
        }

        if ( evt.Display.Event != declaredEventType )
        {
            throw new InvalidEventIdException(
                GetType().Name,
                declaredEventType,
                evt.Display.Event
            );
        }
    }
}
