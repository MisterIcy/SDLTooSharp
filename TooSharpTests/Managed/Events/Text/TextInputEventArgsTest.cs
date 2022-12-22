using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Text;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Text;

public class TextInputEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)SDL.SDL_EventType.SDL_TEXTINPUT;
        ev.Edit.WindowID = 1;

        var args = new TextInputEventArgs(ev);
        Assert.Equal(EventType.TextInput, args.Type);
        Assert.Equal((uint)1, args.WindowId);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)SDL.SDL_EventType.SDL_QUIT;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new TextInputEventArgs(ev);
        });
    }
}
