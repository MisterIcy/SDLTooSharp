using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event.Attributes;

namespace TooSharpTests.Managed.Event.Attributes;

public class AcceptableEventTypeAttributeTest
{
    [Fact]
    public void CreateAttribute()
    {
        var type = SDL.SDL_EventType.SDL_USEREVENT;

        var attr = new AcceptableEventTypeAttribute(type);
        Assert.Equal(type, attr.EventType);
    }
}
