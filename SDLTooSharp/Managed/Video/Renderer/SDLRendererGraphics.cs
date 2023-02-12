using System.Collections;
using System.Reflection.Metadata.Ecma335;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Exception.Video.Renderer;

namespace SDLTooSharp.Managed.Video.Renderer;

/// <summary>
/// Drawing methods for SDLRenderer
/// </summary>
public abstract partial class SDLRenderer
{
    #region Pixel

    /// <summary>
    /// Draws a pixel on the renderer.
    /// </summary>
    /// <param name="pt">The point to be drawn</param>
    /// <exception cref="DrawOperationFailedException">In case the operation fails</exception>
    public void DrawPixel(Point2 pt)
    {
        int result = SDL.SDL_RenderDrawPoint(RendererPtr, pt.X, pt.Y);
        if ( result != 0 )
        {
            throw new DrawOperationFailedException("Pixel");
        }
    }

    /// <summary>
    /// Draws a pixel on the renderer.
    /// </summary>
    /// <param name="x">The x-coordinate of the pixel</param>
    /// <param name="y">The y-coordinate of the pixel</param>
    /// <exception cref="DrawOperationFailedException">In case the operation fails</exception>
    public void DrawPixel(int x, int y) => DrawPixel(new Point2(x, y));

    /// <summary>
    /// Draws a pixel with a specific color and alpha blending
    /// </summary>
    /// <param name="point2">The pixel to be drawn</param>
    /// <param name="color">The color of the pixel</param>
    /// <param name="resetState">Whether to reset the renderer's state after the operation</param>
    public void DrawBlendedPixel(Point2 point2, Color color, bool resetState = false)
    {
        var currentColor = DrawColor;
        var currentBlendMode = BlendMode;

        DrawColor = color;
        BlendMode = color.A == 255 ? SDL.SDL_BlendMode.SDL_BLENDMODE_NONE : SDL.SDL_BlendMode.SDL_BLENDMODE_BLEND;

        DrawPixel(point2);

        if ( !resetState )
        {
            return;
        }

        DrawColor = currentColor;
        BlendMode = currentBlendMode;
    }

    /// <summary>
    /// Draws a pixel with specific color and alpha blending.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="color"></param>
    /// <param name="resetState"></param>
    public void DrawBlendedPixel(int x, int y, Color color, bool resetState = false) =>
        DrawBlendedPixel(new Point2(x, y), color, resetState);

    #endregion

    #region Points

    /// <summary>
    /// Draws pixels on the renderer.
    /// </summary>
    /// <param name="points">An enumeration of points to be drawn</param>
    /// <exception cref="DrawOperationFailedException">In case the operation fails</exception>
    public void DrawPixels(IEnumerable<Point2> points)
    {
        var pixels = points.Select(pt => (SDL.SDL_Point)pt)
            .ToArray();

        int result = SDL.SDL_RenderDrawPoints(RendererPtr, pixels, pixels.Length);
        if ( result != 0 )
        {
            throw new DrawOperationFailedException("Pixels");
        }

        pixels = null;
        GC.Collect();
    }

    /// <summary>
    /// Draws pixels on the renderer, with a color and alpha blending
    /// </summary>
    /// <param name="points"></param>
    /// <param name="color"></param>
    /// <param name="resetState"></param>
    public void DrawBlendedPixels(IEnumerable<Point2> points, Color color, bool resetState = false)
    {
        var currentColor = DrawColor;
        var currentBlendMode = BlendMode;

        DrawColor = color;
        BlendMode = color.A == 255 ? SDL.SDL_BlendMode.SDL_BLENDMODE_NONE : SDL.SDL_BlendMode.SDL_BLENDMODE_BLEND;

        DrawPixels(points);

        if ( !resetState )
        {
            return;
        }

        DrawColor = currentColor;
        BlendMode = currentBlendMode;
    }

    #endregion

    #region Line

    public void DrawLine(Point2 origin, Point2 destination)
    {
        if ( origin == destination )
        {
            DrawPixel(origin);
        }

        int result = SDL.SDL_RenderDrawLine(RendererPtr, origin.X, origin.Y, destination.X, destination.Y);
        if ( result != 0 )
        {
            throw new DrawOperationFailedException("Line");
        }
    }

    public void DrawLine(int x1, int y1, int x2, int y2)
    {
        DrawLine(new Point2(x1, y1), new Point2(x2, y2));
    }

    public void DrawHorizontalLine(Point2 origin, int length)
    {
        DrawLine(origin, new Point2(origin.X + length, origin.Y));
    }

    public void DrawHorizontalLine(int x, int y, int length)
    {
        DrawHorizontalLine(new Point2(x, y), length);
    }

    public void DrawVerticalLine(Point2 origin, int length)
    {
        DrawLine(origin, new Point2(origin.X, origin.Y + length));
    }

    public void DrawVerticalLine(int x, int y, int length)
    {
        DrawVerticalLine(new Point2(x, y), length);
    }

    public void DrawBlendedLine(Point2 origin, Point2 destination, Color color, bool resetState = false)
    {
        var currentColor = DrawColor;
        var currentBlendMode = BlendMode;

        DrawColor = color;
        BlendMode = color.A == 255 ? SDL.SDL_BlendMode.SDL_BLENDMODE_NONE : SDL.SDL_BlendMode.SDL_BLENDMODE_BLEND;

        DrawLine(origin, destination);

        if ( !resetState )
        {
            return;
        }

        DrawColor = currentColor;
        BlendMode = currentBlendMode;
    }

    public void DrawBlendedLine(int x1, int y1, int x2, int y2, Color color, bool resetState = false)
    {
        DrawBlendedLine(new Point2(x1, y1), new Point2(x2, y2), color, resetState);
    }

    public void DrawBlendedHorizontalLine(Point2 origin, int length, Color color, bool resetState = false)
    {
        DrawBlendedLine(origin, new Point2(origin.X + length, origin.Y), color, resetState);
    }

    public void DrawBlendedHorizontalLine(int x, int y, int length, Color color, bool resetState = false)
    {
        DrawBlendedHorizontalLine(new Point2(x, y), length, color, resetState);
    }

    public void DrawBlendedVerticalLine(Point2 origin, int length, Color color, bool resetState = false)
    {
        DrawBlendedLine(origin, new Point2(origin.X, origin.Y + length), color, resetState);
    }

    public void DrawBlendedVerticalLine(int x, int y, int length, Color color, bool resetState = false)
    {
        DrawBlendedVerticalLine(new Point2(x, y), length, color, resetState);
    }

    #endregion

    #region Lines

    public void DrawLines(IEnumerable<Point2> points)
    {
        var pixels = points.Select(pt => (SDL.SDL_Point)pt)
            .ToArray();

        int result = SDL.SDL_RenderDrawLines(RendererPtr, pixels, pixels.Length);
        if ( result != 0 )
        {
            throw new DrawOperationFailedException("Lines");
        }

        pixels = null;
        GC.Collect();
    }

    public void DrawBlendedLines(IEnumerable<Point2> points, Color color, bool resetState = false)
    {
        var currentColor = DrawColor;
        var currentBlendMode = BlendMode;

        DrawColor = color;
        BlendMode = color.A == 255 ? SDL.SDL_BlendMode.SDL_BLENDMODE_NONE : SDL.SDL_BlendMode.SDL_BLENDMODE_BLEND;

        DrawLines(points);

        if ( !resetState )
        {
            return;
        }

        DrawColor = currentColor;
        BlendMode = currentBlendMode;
    }

    #endregion

    #region Rectangle

    public void DrawRectangle(Rectangle rect)
    {
        switch ( rect.Width )
        {
            case 0 when rect.Height == 0:
                DrawPixel(rect.Origin);
                return;
            case 0:
                DrawHorizontalLine(rect.Origin, rect.Height);
                return;
        }

        if ( rect.Height == 0 )
        {
            DrawVerticalLine(rect.Origin, rect.Width);
            return;
        }

        int result = SDL.SDL_RenderDrawRect(RendererPtr, (SDL.SDL_Rect)rect);
        if ( result != 0 )
        {
            throw new DrawOperationFailedException("Rectangle");
        }
    }

    public void DrawRectangle(int x, int y, int w, int h)
    {
        DrawRectangle(new Rectangle(x, y, w, h));
    }

    public void DrawBlendedRectangle(Rectangle rect, Color color, bool resetState = false)
    {
        var currentColor = DrawColor;
        var currentBlendMode = BlendMode;

        DrawColor = color;
        BlendMode = color.A == 255 ? SDL.SDL_BlendMode.SDL_BLENDMODE_NONE : SDL.SDL_BlendMode.SDL_BLENDMODE_BLEND;

        DrawRectangle(rect);

        if ( !resetState )
        {
            return;
        }

        DrawColor = currentColor;
        BlendMode = currentBlendMode;
    }

    public void DrawBlendedRectangle(int x, int y, int w, int h, Color color, bool resetState = false)
    {
        DrawBlendedRectangle(new Rectangle(x, y, w, h), color, resetState);
    }

    #endregion

    #region Rectangles

    public void DrawRectangles(IEnumerable<Rectangle> rects)
    {
        var rectangles = rects.Select(r => (SDL.SDL_Rect)r)
            .ToArray();

        int result = SDL.SDL_RenderDrawRects(RendererPtr, rectangles, rectangles.Length);
        if ( result != 0 )
        {
            throw new DrawOperationFailedException("Rectangles");
        }

        rectangles = null;
        GC.Collect();
    }

    public void DrawBlendedRectangles(IEnumerable<Rectangle> rects, Color color, bool resetState = false)
    {
        var currentColor = DrawColor;
        var currentBlendMode = BlendMode;

        DrawColor = color;
        BlendMode = color.A == 255 ? SDL.SDL_BlendMode.SDL_BLENDMODE_NONE : SDL.SDL_BlendMode.SDL_BLENDMODE_BLEND;

        DrawRectangles(rects);

        if ( !resetState )
        {
            return;
        }

        DrawColor = currentColor;
        BlendMode = currentBlendMode;
    }
    #endregion

    #region Filled Rectangle

        public void FilledRectangle(Rectangle rect)
        {
            var rectangle = (SDL.SDL_Rect)rect;
            int result = SDL.SDL_RenderFillRect(RendererPtr, in rectangle);
            if ( result != 0 )
            {
                throw new DrawOperationFailedException("Filled Rectangle");
            }
        }
        

    #endregion
}
