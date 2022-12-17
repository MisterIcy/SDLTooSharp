using System.Security.Cryptography.X509Certificates;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowExposedEventArgs : AbstractWindowEventArgs
{

    public WindowExposedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Type != (byte)WindowEventType.Exposed )
        {
            throw new ArgumentException("Not a Exposed event", nameof(@event));
        }

    }

    private new int GetData1() => 0;
    private new int GetData2() => 0;
}
