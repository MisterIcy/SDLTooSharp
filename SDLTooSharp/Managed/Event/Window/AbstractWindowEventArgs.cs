using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event.Attributes;
using SDLTooSharp.Managed.Exception.Event;

namespace SDLTooSharp.Managed.Event.Window;

public abstract class AbstractWindowEventArgs : AbstractSDLEventArgs
{
    public uint WindowId { get; }
    public int Data1 { get; }
    public int Data2 { get; }

    protected AbstractWindowEventArgs(SDL.SDL_Event evt) : base(evt)
    {
        WindowId = evt.Window.WindowID;
        Data1 = evt.Window.Data1;
        Data2 = evt.Window.Data2;
    }

    protected sealed override void CheckEventType(SDL.SDL_Event evt)
    {
        uint declaredEventType;

        if ( evt.Type != (uint)SDL.SDL_EventType.SDL_WINDOWEVENT )
        {
            throw new InvalidEventTypeException(
                GetType().Name,
                (uint)SDL.SDL_EventType.SDL_WINDOWEVENT,
                evt.Display.Type
            );
        }

        try
        {
            var attributeData = GetType()
                               .GetCustomAttributesData()
                               .First(x => x.AttributeType == typeof(AcceptableWindowEventAttribute));

            declaredEventType = (uint)( attributeData.ConstructorArguments[0].Value ?? 0 );
        } catch ( InvalidOperationException )
        {
            throw new EventClassMissingAttributeException(GetType().Name);
        }

        if ( evt.Window.Event != declaredEventType )
        {
            throw new InvalidEventIdException(
                GetType().Name,
                declaredEventType,
                evt.Window.Event
            );
        }
    }
}
