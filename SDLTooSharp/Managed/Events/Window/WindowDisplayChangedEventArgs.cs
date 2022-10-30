using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

[ExcludeFromCodeCoverage]
public sealed class WindowDisplayChangedEventArgs : WindowEventArgs
{

    public uint DisplayID { get; }
    public WindowDisplayChangedEventArgs(SDL.SDL_Event ev) : base(ev)
    {
        DisplayID = (uint)Data1;
    }
}
