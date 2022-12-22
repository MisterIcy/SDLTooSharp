using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Controller;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Controller;

public class ControllerButtonUpEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.ControllerButtonUp;
        ev.CButton.Which = 1;
        ev.CButton.Button = (byte)ControllerButton.A;
        ev.CButton.State = (byte)ControllerButtonState.Released;

        var args = new ControllerButtonUpEventArgs(ev);
        Assert.Equal(EventType.ControllerButtonUp, args.Type);
        Assert.Equal(1, args.ControllerId);
        Assert.Equal(ControllerButton.A, args.Button);
        Assert.Equal(ControllerButtonState.Released, args.State);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)EventType.Quit;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new ControllerButtonUpEventArgs(ev);
        });
    }
}
