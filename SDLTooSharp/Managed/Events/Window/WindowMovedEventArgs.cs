using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;

namespace SDLTooSharp.Managed.Events.Window;

[ExcludeFromCodeCoverage]
public sealed class WindowMovedEventArgs : WindowEventArgs
{

    public Point2 Position { get; }
    public WindowMovedEventArgs(SDL.SDL_Event ev) : base(ev)
    {
        Position = new Point2(Data1, Data2);
    }
}
