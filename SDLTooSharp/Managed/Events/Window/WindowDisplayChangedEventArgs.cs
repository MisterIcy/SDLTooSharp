using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowDisplayChangedEventArgs : AbstractWindowEventArgs
{

    public WindowDisplayChangedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Event != (byte)WindowEventType.DisplayChanged )
        {
            throw new ArgumentException("Not a DisplayChanged event", nameof(@event));
        }
    }

    [ExcludeFromCodeCoverage(Justification = "Unused in this event")]
    private new int GetData1() => 0;
    [ExcludeFromCodeCoverage(Justification = "Unused in this event")]
    private new int GetData2() => 0;
    public int GetDisplayId() => base.GetData1();
}
