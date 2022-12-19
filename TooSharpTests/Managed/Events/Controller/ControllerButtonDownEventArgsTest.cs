using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Controller;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Controller;

public class ControllerButtonDownEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.ControllerButtonDown;
        ev.CButton.Which = 1;
        ev.CButton.Button = (byte)ControllerButton.A;
        ev.CButton.State = (byte)ControllerButtonState.Pressed;

        var args = new ControllerButtonDownEventArgs(ev);
        Assert.Equal(EventType.ControllerButtonDown, args.Type);
        Assert.Equal(1, args.Which);
        Assert.Equal(ControllerButton.A, args.Button);
        Assert.Equal(ControllerButtonState.Pressed, args.State);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new ControllerButtonDownEventArgs(ev);
        });
    }
}
