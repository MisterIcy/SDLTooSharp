using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;

namespace SDLTooSharp.Managed.Events.Window;

[ExcludeFromCodeCoverage]
public sealed class WindowResizedEventArgs : WindowEventArgs
{

    public Size Dimensions { get; }
    public WindowResizedEventArgs(SDL.SDL_Event ev) : base(ev)
    {
        Dimensions = new Size(Data1, Data2);
    }
}
