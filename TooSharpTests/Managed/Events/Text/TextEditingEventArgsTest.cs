using System.Runtime.InteropServices;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Events;
using SDLTooSharp.Managed.Events.Text;
using SDLTooSharp.Managed.Exception.Events;

namespace TooSharpTests.Managed.Events.Text;

public class TextEditingEventArgsTest
{
    [Fact]
    public void CreateEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)SDL.SDL_EventType.SDL_TEXTEDITING;
        ev.Edit.WindowID = 1;
        ev.Edit.Start = 0;
        ev.Edit.Length = 4;

        var args = new TextEditingEventArgs(ev);
        Assert.Equal(EventType.TextEditing, args.GetType());
        Assert.Equal((uint)1, args.GetWindowID());
        Assert.Equal(0, args.GetStart());
        Assert.Equal(4, args.GetLength());
    }

    [Fact]
    public void CreateInvalidEvent()
    {
        SDL.SDL_Event ev = default;
        ev.Type = (uint)SDL.SDL_EventType.SDL_QUIT;

        Assert.Throws<InvalidEventTypeException>(() => {
            var args = new TextEditingEventArgs(ev);
        });
    }
}
