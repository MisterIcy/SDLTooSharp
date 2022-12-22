using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Mouse;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Mouse;

public class MouseMotionEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.MouseMotion;
        ev.Motion.WindowID = 1;
        ev.Motion.Which = 1;
        ev.Motion.X = 10;
        ev.Motion.Y = 10;
        ev.Motion.XRel = 2;
        ev.Motion.YRel = 2;
        ev.Motion.State = 0b00000001;

        var args = new MouseMotionEventArgs(ev);
        Assert.Equal(EventType.MouseMotion, args.Type);
        Assert.Equal((uint)1, args.WindowId);
        Assert.Equal((uint)1, args.Which);
        Assert.Equal(10, args.X);
        Assert.Equal(10, args.Y);
        Assert.Equal(new MouseState(0b00000001), args.MouseState);
        Assert.Equal(2, args.RelativeX);
        Assert.Equal(2, args.RelativeY);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.MouseButtonDown;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new MouseMotionEventArgs(ev);
        });
    }
}
