using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Exception.Video.Renderer;

namespace SDLTooSharp.Managed.Video.Renderer;

/// <summary>
/// SDL Renderer
/// </summary>
public abstract partial class SDLRenderer : IRenderer, IDisposable
{
    /// <summary>
    /// Gets a value that indicates the actual SDL_Renderer pointer.
    /// </summary>
    public IntPtr RendererPtr { get; protected set; }

    /// <summary>
    /// Gets the Renderer's Output Size
    /// </summary>
    /// <exception cref="UnableToGetRendererOutputSizeException">In case we cannot get the renderer's output size</exception>
    public Size OutputSize
    {
        get {
            int result = SDL.SDL_GetRendererOutputSize(RendererPtr, out int w, out int h);
            if ( result != 0 )
            {
                throw new UnableToGetRendererOutputSizeException();
            }

            return new Size(w, h);
        }
    }

    /// <summary>
    /// Gets a value that indicates whether the renderer supports the use of render targets
    /// </summary>
    public bool RenderTargetSupported => SDL.SDL_RenderTargetSupported(RendererPtr);

    /// <summary>
    /// Gets or sets the renderer's logical size.
    /// </summary>
    /// <exception cref="UnableToSetLogicalSizeException"/>
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
                throw new UnableToSetLogicalSizeException();
            }
        }
    }

    /// <summary>
    /// Gets or sets a value that indicates whether we use integer scales for resolution-independent rendering.
    /// </summary>
    /// <exception cref="UnableToSetIntegerScaleException"/>
    public bool IsIntegerScale
    {
        get => SDL.SDL_RenderGetIntegerScale(RendererPtr);
        set {
            int result = SDL.SDL_RenderSetIntegerScale(RendererPtr, value);
            if ( result != 0 )
            {
                throw new UnableToSetIntegerScaleException();
            }
        }
    }

    /// <summary>
    /// Gets or sets the renderer's viewport
    /// </summary>
    /// <exception cref="UnableToSetRendererViewportException"></exception>
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
                throw new UnableToSetRendererViewportException();
            }
        }
    }

    /// <summary>
    /// Gets or sets the renderer's clip rectangle
    /// </summary>
    /// <exception cref="UnableToSetRendererClipException"></exception>
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
                throw new UnableToSetRendererClipException();
            }
        }
    }

    /// <summary>
    /// Gets a value indicating whether clipping is enabled.
    /// </summary>
    public bool IsClipEnabled => SDL.SDL_RenderIsClipEnabled(RendererPtr);

    /// <summary>
    /// Gets or sets the renderer's scale.
    /// </summary>
    /// <exception cref="UnableToSetRenderScaleException"></exception>
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
                throw new UnableToSetRenderScaleException();
            }
        }
    }

    /// <summary>
    /// Converts window coordinates to logical coordinates.
    /// </summary>
    /// <param name="windowCoords"></param>
    /// <returns></returns>
    public Point2F WindowToLogicalCoords(Point2 windowCoords)
    {
        SDL.SDL_RenderWindowToLogical(RendererPtr, windowCoords.X, windowCoords.Y, out float x, out float y);
        return new Point2F(x, y);
    }

    /// <summary>
    /// Converts logical coordinates to window Coordinates
    /// </summary>
    /// <param name="logicalCoords"></param>
    /// <returns></returns>
    public Point2 LogicalToWindowCoords(Point2F logicalCoords)
    {
        SDL.SDL_RenderLogicalToWindow(RendererPtr, logicalCoords.X, logicalCoords.Y, out int x, out int y);
        return new Point2(x, y);
    }

    private Color? _drawColor;
    /// <summary>
    /// Gets or sets the renderer's draw color
    /// </summary>
    /// <exception cref="UnableToGetDrawColorException"></exception>
    /// <exception cref="UnableToSetDrawColorException"></exception>
    public Color DrawColor
    {
        get {
            if ( _drawColor != null )
            {
                return _drawColor;
            }

            int result = SDL.SDL_GetRenderDrawColor(RendererPtr, out var r, out var g, out var b, out var a);
            if ( result != 0 )
            {
                throw new UnableToGetDrawColorException();
            }
            _drawColor = new Color(r, g, b, a);
            return _drawColor;
        }
        set {
            if ( _drawColor == value )
            {
                return;
            }

            int result = SDL.SDL_SetRenderDrawColor(RendererPtr, value.R, value.G, value.B, value.A);
            if ( result != 0 )
            {
                throw new UnableToSetDrawColorException();
            }
        }
    }

    /// <summary>
    /// Gets or sets the Renderer's blend mode.
    /// </summary>
    /// <exception cref="UnableToGetBlendModeException"></exception>
    /// <exception cref="UnableToSetBlendModeException"></exception>
    public SDL.SDL_BlendMode BlendMode
    {
        get {
            int result = SDL.SDL_GetRenderDrawBlendMode(RendererPtr, out var blendMode);
            if ( result != 0 )
            {
                throw new UnableToGetBlendModeException();
            }

            return blendMode;
        }
        set {
            int result = SDL.SDL_SetRenderDrawBlendMode(RendererPtr, value);

            if ( result != 0 )
            {
                throw new UnableToSetBlendModeException();
            }
        }
    }

    /// <summary>
    /// Clears the renderer
    /// </summary>
    public void Clear()
    {
        SDL.SDL_RenderClear(RendererPtr);
    }

    /// <summary>
    /// Presets the renderer
    /// </summary>
    public void Present()
    {
        SDL.SDL_RenderPresent(RendererPtr);
    }

    /// <summary>
    /// Flushes the renderer
    /// </summary>
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

    /// <inheritdoc cref="IDisposable.Dispose"/>
    protected virtual void Dispose(bool disposing)
    {
        ReleaseUnmanagedResources();
        if ( disposing )
        {
        }
    }
    /// <inheritdoc cref="IDisposable.Dispose"/>
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
