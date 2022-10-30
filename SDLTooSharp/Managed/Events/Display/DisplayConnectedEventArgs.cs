using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Display;
[ExcludeFromCodeCoverage]
public sealed class DisplayConnectedEventArgs : DisplayEventArgs
{

    public DisplayConnectedEventArgs(SDL.SDL_Event ev) : base(ev)
    {

    }
}
