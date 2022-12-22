using System.Runtime.InteropServices;
using System.Text;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Text;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Text;

public class TextEditingExtEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)SDL.SDL_EventType.SDL_TEXTEDITING_EXT;
        ev.EditExt.WindowID = 1;
        ev.EditExt.Start = 0;
        ev.EditExt.Length = 4;
        ev.EditExt.Text = Marshal.StringToCoTaskMemUTF8("test");

        var args = new TextEditingExtEventArgs(ev);
        Assert.Equal(EventType.TextEditingExt, args.Type);
        Assert.Equal((uint)1, args.WindowId);
        Assert.Equal(0, args.Start);
        Assert.Equal(4, args.Length);
        Assert.Equal("test", args.Text);
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)SDL.SDL_EventType.SDL_QUIT;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new TextEditingExtEventArgs(ev);
        });
    }
}
