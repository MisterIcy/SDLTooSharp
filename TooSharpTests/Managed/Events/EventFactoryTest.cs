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
    [Fact]
    public void CreateAppDidEnterBackgroundEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.AppDidEnterBackground;

        var args = ( new EventFactory() ).CreateFromSDLEvent(ev);
        Assert.IsType<AppDidEnterBackgroundEventArgs>(args);
    }
    
    [Fact]
    public void CreateAppLowMemoryEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.AppLowMemory;

        var args = ( new EventFactory() ).CreateFromSDLEvent(ev);
        Assert.IsType<AppLowMemoryEventArgs>(args);
    }
    
    [Fact]
    public void CreateAppTerminatingEventArgs()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.AppTerminating;

        var args = ( new EventFactory() ).CreateFromSDLEvent(ev);
        Assert.IsType<AppTerminatingEventArgs>(args);
    }
    
    [Fact]
    public void CreateAppWillEnterBackgroundEventArgs()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.AppWillEnterBackground;

        var args = ( new EventFactory() ).CreateFromSDLEvent(ev);
        Assert.IsType<AppWillEnterBackgroundEventArgs>(args);
    }
    
    [Fact]
    public void CreateAppWillEnterForegroundEventArgs()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.AppWillEnterForeground;

        var args = ( new EventFactory() ).CreateFromSDLEvent(ev);
        Assert.IsType<AppWillEnterForegroundEventArgs>(args);
    }
    
    [Fact]
    public void CreateLocaleChangedEventArgs()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.LocaleChanged;

        var args = ( new EventFactory() ).CreateFromSDLEvent(ev);
        Assert.IsType<LocaleChangedEventArgs>(args);
    }
    
    [Fact]
    public void CreateUnknownEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = 0;

        Assert.Throws<ArgumentException>(() => {
            var args = ( new EventFactory() ).CreateFromSDLEvent(ev);
        });
        
    }
}
