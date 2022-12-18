using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;

namespace SDLTooSharp.Managed.Events.Window;

public sealed class WindowSizeChangedEventArgs : AbstractWindowEventArgs
{

    public WindowSizeChangedEventArgs(SDL.SDL_Event @event) : base(@event)
    {
        if ( @event.Window.Event != (byte)WindowEventType.SizeChanged )
        {
            throw new ArgumentException("Not a SizeChanged event", nameof(@event));
        }
    }

    [ExcludeFromCodeCoverage(Justification = "Unused in this event")]
    private new int GetData1() => 0;
    [ExcludeFromCodeCoverage(Justification = "Unused in this event")]
    private new int GetData2() => 0;

    public Size GetSize()
    {
        return new Size(base.GetData1(), base.GetData2());
    }
}
