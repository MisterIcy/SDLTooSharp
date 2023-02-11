using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Video.Surface;
using SDLTooSharp.Managed.Video.Window;

namespace SDLTooSharp.Managed.Video.Renderer;

public abstract partial class SDLRenderer : IRenderer, IDisposable
{
    public IntPtr RendererPtr { get; protected set; }

    public Size OutputSize
    {
        get {
            var result = SDL.SDL_GetRendererOutputSize(RendererPtr, out int w, out int h);
            if ( result != 0 )
            {
                //TODO: Throw
            }

            return new Size(w, h);
        }
    }

    public bool RenderTargetSupported => SDL.SDL_RenderTargetSupported(RendererPtr);

    public Size LogicalSize
    {
        get {
            SDL.SDL_RenderGetLogicalSize(RendererPtr, out int w, out int h);
            return new Size(w, h);
        }
        set {
            int result = SDL.SDL_RenderSetLogicalSize(RendererPtr, value.Width, value.Height);
            if ( result != 0 )
            {
                //TODO: Throw
            }
        }
    }

    public bool IntegerScale
    {
        get => SDL.SDL_RenderGetIntegerScale(RendererPtr);
        set {
            int result = SDL.SDL_RenderSetIntegerScale(RendererPtr, value);
            if ( result != 0 )
            {
                //TODO: Throw
            }
        }
    }

    public Rectangle Viewport
    {
        get {
            SDL.SDL_RenderGetViewport(RendererPtr, out var rect);
            return rect;
        }
        set {
            int result = SDL.SDL_RenderSetViewport(RendererPtr, (SDL.SDL_Rect)value);
            if ( result != 0 )
            {
                //TODO: Throw
            }
        }
    }

    public Rectangle Clip
    {
        get {
            SDL.SDL_RenderGetClipRect(RendererPtr, out var rect);
            return rect;
        }
        set {
            int result = SDL.SDL_RenderSetClipRect(RendererPtr, (SDL.SDL_Rect)value);
            if ( result != 0 )
            {
                // TODO: Throw
            }
        }
    }

    public bool IsClipEnabled => SDL.SDL_RenderIsClipEnabled(RendererPtr);

    public Point2F Scale
    {
        get {
            SDL.SDL_RenderGetScale(RendererPtr, out float x, out float y);
            return new Point2F(x, y);
        }
        set {
            int result = SDL.SDL_RenderSetScale(RendererPtr, value.X, value.Y);
            if ( result != 0 )
            {
                //TODO: Throw
            }
        }
    }

    public bool IsIntegerScale
    {
        get =>
            SDL.SDL_RenderGetIntegerScale(RendererPtr);
        set {
            int result = SDL.SDL_RenderSetIntegerScale(RendererPtr, value);
            if ( result != 0 )
            {
                //TODO: Throw
            }
        }
    }

    public Point2F WindowToLogicalCoords(Point2 windowCoords)
    {
        SDL.SDL_RenderWindowToLogical(RendererPtr, windowCoords.X, windowCoords.Y, out float x, out float y);
        return new Point2F(x, y);
    }

    public Point2 LogicalToWindowCoords(Point2F logicalCoords)
    {
        SDL.SDL_RenderLogicalToWindow(RendererPtr, logicalCoords.X, logicalCoords.Y, out int x, out int y);
        return new Point2(x, y);
    }

    public Color DrawColor
    {
        get {
            int result = SDL.SDL_GetRenderDrawColor(RendererPtr, out var r, out var g, out var b, out var a);
            if ( result != 0 )
            {
                //TODO: throw
            }

            return new Color(r, g, b, a);
        }
        set {
            int result = SDL.SDL_SetRenderDrawColor(RendererPtr, value.R, value.G, value.B, value.A);
            if ( result != 0 )
            {
                //TODO: throw
            }
        }
    }

    public SDL.SDL_BlendMode BlendMode
    {
        get {
            int result = SDL.SDL_GetRenderDrawBlendMode(RendererPtr, out var blendMode);
            if ( result != 0 )
            {
                //TODO: Throw
            }

            return blendMode;
        }
        set {
            int result = SDL.SDL_SetRenderDrawBlendMode(RendererPtr, value);

            if ( result != 0 )
            {
                //TODO: Throw
            }
        }
    }

    public void Clear()
    {
        SDL.SDL_RenderClear(RendererPtr);
    }

    public void Present()
    {
        SDL.SDL_RenderPresent(RendererPtr);
    }

    public void Flush()
    {
        SDL.SDL_RenderFlush(RendererPtr);
    }

    private void ReleaseUnmanagedResources()
    {
        if ( RendererPtr == IntPtr.Zero )
        {
            return;
        }

        SDL.SDL_DestroyRenderer(RendererPtr);
    }

    protected virtual void Dispose(bool disposing)
    {
        ReleaseUnmanagedResources();
        if ( disposing )
        {
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~SDLRenderer()
    {
        Dispose(false);
    }
}
