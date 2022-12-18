using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Mouse;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Mouse;

public class MouseMotionEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)SDL.SDL_EventType.SDL_MOUSEMOTION;
        ev.Motion.Which = 1;
        ev.Motion.WindowID = 1;
        ev.Motion.State = 0b00000001;
        ev.Motion.X = 10;
        ev.Motion.Y = 20;
        ev.Motion.XRel = 0;
        ev.Motion.YRel = 10;

        var args = new MouseMotionEventArgs(ev);
        Assert.Equal(EventType.MouseMotion, args.GetType());
        Assert.Equal((uint)1, args.GetWindowID());
        Assert.Equal((uint)1, args.GetMouseID());
        Assert.True(args.GetMouseState().Left);
        Assert.False(args.GetMouseState().Right);
        Assert.False(args.GetMouseState().Middle);
        Assert.False(args.GetMouseState().X1);
        Assert.False(args.GetMouseState().X2);
        Assert.Equal(new Point2(10, 20), args.GetPosition());
        Assert.Equal(10, args.GetX());
        Assert.Equal(20, args.GetY());
        Assert.Equal(new Point2(0, 10), args.GetRelativeMotion());
        Assert.Equal(0, args.GetRelativeX());
        Assert.Equal(10, args.GetRelativeY());
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)SDL.SDL_EventType.SDL_QUIT;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new MouseMotionEventArgs(ev);
        });
    }
}
