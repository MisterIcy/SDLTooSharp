using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Event;
using SDLTooSharp.Managed.Event.Attributes;
using SDLTooSharp.Managed.Exception.Event;

namespace TooSharpTests.Managed.Event;

public class AbstractSDLEventArgsTest
{
    [Fact]
    public void TestMissingAnnotationOnEventClass()
    {
        SDL.SDL_Event evt = default;
        evt.Type = (uint)SDL.SDL_EventType.SDL_USEREVENT;

        Assert.Throws<EventClassMissingAttributeException>(
            () => {
                var args = new TestEventMissingAnnotationEventArgs(evt);
            });
    }

    [Fact]
    public void TestEventClassThatPerformsInternalChecks()
    {
        SDL.SDL_Event evt = default;
        evt.Type = (uint)SDL.SDL_EventType.SDL_USEREVENT;

        var args = new TestEventPerformingInternalChecksEventArgs(evt);
        Assert.IsType<TestEventPerformingInternalChecksEventArgs>(args);
    }
    
}

internal class TestEventMissingAnnotationEventArgs : AbstractSDLEventArgs
{
    public TestEventMissingAnnotationEventArgs(SDL.SDL_Event evt) : base(evt)
    {
    }
}

[InternalEventChecks]
internal class TestEventPerformingInternalChecksEventArgs : AbstractSDLEventArgs
{

    public TestEventPerformingInternalChecksEventArgs(SDL.SDL_Event evt) : base(evt)
    {
    }
}
