using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Window;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Window;

public class WindowIccProfileChangedEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = (byte)WindowEventType.IccProfileChanged;
        ev.Common.Timestamp = 0;

        WindowIccProfileChangedEventArgs args = new WindowIccProfileChangedEventArgs(ev);
        Assert.Equal(EventType.WindowEvent, args.Type);
        Assert.Equal(WindowEventType.IccProfileChanged, args.WindowEventType);
        Assert.Equal((uint)0, args.Timestamp);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;
        ev.Common.Timestamp = 0;

        Assert.Throws<InvalidEventTypeException>(() => {
            WindowIccProfileChangedEventArgs args = new WindowIccProfileChangedEventArgs(ev);
        });
    }

    [Fact]
    public void CreateInvalidDisplayEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.WindowEvent;
        ev.Window.Event = 0;
        ev.Common.Timestamp = 0;

        Assert.Throws<InvalidWindowSubtypeEventException>(() => {
            WindowIccProfileChangedEventArgs args = new WindowIccProfileChangedEventArgs(ev);
        });
    }
}
