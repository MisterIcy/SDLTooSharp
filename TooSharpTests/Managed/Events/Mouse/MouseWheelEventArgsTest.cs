using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Mouse;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Mouse;

public class MouseWheelEventArgsTEst
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.MouseWheel;
        ev.Wheel.WindowID = 1;
        ev.Wheel.Which = 1;
        ev.Wheel.X = 10;
        ev.Wheel.Y = 10;
        ev.Wheel.Direction = (uint)MouseWheelDirection.Flipped;
        ev.Wheel.PreciseX = 10.1f;
        ev.Wheel.PreciseY = 9.9f;

        var args = new MouseWheelEventArgs(ev);
        Assert.Equal(EventType.MouseWheel, args.GetType());
        Assert.Equal((uint)1, args.GetWindowID());
        Assert.Equal((uint)1, args.GetMouseID());
        Assert.Equal(new Point2(10, 10), args.GetScrollingAmount());
        Assert.Equal(10, args.GetX());
        Assert.Equal(10, args.GetY());
        Assert.Equal(MouseWheelDirection.Flipped, args.GetDirection());
        Assert.Equal(new Point2F(10.1f, 9.9f), args.GetPreciseScrollingAmount());
        Assert.Equal(10.1f, args.GetPreciseX());
        Assert.Equal(9.9f, args.GetPreciseY());
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.MouseButtonDown;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new MouseWheelEventArgs(ev);
        });
    }
}
