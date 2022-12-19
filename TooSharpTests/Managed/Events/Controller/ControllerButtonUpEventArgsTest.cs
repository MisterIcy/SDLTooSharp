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
        Assert.Equal(EventType.ControllerButtonUp, args.GetType());
        Assert.Equal(1, args.GetControllerID());
        Assert.Equal(ControllerButton.A, args.GetButton());
        Assert.Equal(ControllerButtonState.Released, args.GetState());
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
