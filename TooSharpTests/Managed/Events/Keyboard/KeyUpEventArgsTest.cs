using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Keyboard;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Keyboard;

public class KeyUpEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.KeyUp;
        ev.Common.Timestamp = 0;
        ev.Key.WindowID = 1;
        ev.Key.Repeat = 1;
        ev.Key.State = SDL.SDL_RELEASED;
        ev.Key.KeySym = new SDL.SDL_Keysym();

        KeyUpEventArgs args = new KeyUpEventArgs(ev);
        Assert.Equal(EventType.KeyUp, args.GetType());
        Assert.Equal((uint)1, args.GetWindowID());
        Assert.Equal((uint)0, args.GetTimestamp());
        Assert.Equal(KeyState.Released, args.GetState());
        Assert.Equal(1, args.GetRepeat());
        Assert.Equal(new SDL.SDL_Keysym(), args.GetKeySym());
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.DisplayEvent;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new KeyUpEventArgs(ev);
        });
    }

    [Fact]
    public void CreateInvalidKeyEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.KeyDown;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new KeyUpEventArgs(ev);
        });
    }
}
