using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Video.Renderer;
/// <summary>
/// A Hardware SDL Renderer
/// </summary>
public class SDLHardwareRenderer : SDLRenderer
{
    /// <summary>
    /// Gets or sets the window with which the renderer is associated
    /// </summary>
    public SDLWindow Window { get; protected set; }

    /// <summary>
    /// Creates a new SDLHardwareRenderer
    /// </summary>
    /// <param name="window"></param>
    /// <param name="index"></param>
    /// <param name="flags"></param>
    public SDLHardwareRenderer(
        SDLWindow window, int index = -1, uint flags = (uint)SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED)
    {
        RendererPtr = SDL.SDL_CreateRenderer(window.WindowPtr, index, flags);
        if ( RendererPtr == IntPtr.Zero )
        {
            //TODO: Throw
        }

        Window = window;
    }
}
