using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;

namespace TooSharpTests.Managed.Events;

public class EventFactoryTest
{
    [Fact]
    public void CreateQuitEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;

        var args = ( new EventFactory() ).CreateFromSDLEvent(ev);
        Assert.IsType<QuitEventArgs>(args);
    }
    [Fact]
    public void CreateAppDidEnterForegroundEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.AppDidEnterForeground;

        var args = ( new EventFactory() ).CreateFromSDLEvent(ev);
        Assert.IsType<AppDidEnterForegroundEventArgs>(args);
    }
}
