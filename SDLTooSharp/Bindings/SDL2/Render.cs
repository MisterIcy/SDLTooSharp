using System.Runtime.InteropServices;
#pragma warning disable CS1591
namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    public enum SDL_RendererFlags
    {
        SDL_RENDERER_SOFTWARE = 0x00000001,
        SDL_RENDERER_ACCELERATED = 0x00000002,
        SDL_RENDERER_PRESENTVSYNC = 0x00000004,
        SDL_RENDERER_TARGETTEXTURE = 0x00000008
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL_RendererInfo
    {
        public IntPtr name;
        public uint Flags;
        public uint NumTextureFormats;
        public fixed uint TextureFormats[16];
        public int MaxTextureWidth;
        public int MaxTextureHeight;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_Vertex
    {
        public SDL_FPoint Position;
        public SDL_Color Color;
        public SDL_FPoint TexCoord;
    }

    public enum SDL_ScaleMode
    {
        SDL_ScaleModeNearest,
        SDL_ScaleModeLinear,
        SDL_ScaleModeBest
    }

    public enum SDL_TextureAccess
    {
        SDL_TEXTUREACCESS_STATIC,
        SDL_TEXTUREACCESS_STREAMING,
        SDL_TEXTUREACCESS_TARGET
    }

    public enum SDL_TextureModulate
    {
        SDL_TEXTUREMODULATE_NONE = 0x00000000,
        SDL_TEXTUREMODULATE_COLOR = 0x00000001,
        SDL_TEXTUREMODULATE_ALPHA = 0x00000002
    }

    public enum SDL_RendererFlip
    {
        SDL_FLIP_NONE = 0x00000000,
        SDL_FLIP_HORIZONTAL = 0x00000001,
        SDL_FLIP_VERTICAL = 0x00000002
    }

    ///<summary>Get the number of 2D rendering drivers available for the current display.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetNumRenderDrivers">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetNumRenderDrivers();
    ///<summary>Get info about a specific 2D rendering driver for the current display.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetRenderDriverInfo">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetRenderDriverInfo(int index, out SDL_RendererInfo info);
    ///<summary>Create a window and default renderer.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_CreateWindowAndRenderer">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_CreateWindowAndRenderer(
        int width,
        int height,
        uint windowFlags,
        out IntPtr window,
        out IntPtr renderer
    );
    ///<summary>Create a 2D rendering context for a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_CreateRenderer">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateRenderer(IntPtr window, int index, uint flags);
    ///<summary>Create a 2D software rendering context for a surface.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_CreateSoftwareRenderer">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateSoftwareRenderer(IntPtr surface);
    ///<summary>Get the renderer associated with a window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetRenderer">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetRenderer(IntPtr window);
    ///<summary>Get the window associated with a renderer.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderGetWindow">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_RenderGetWindow(IntPtr renderer);
    ///<summary>Get information about a rendering context.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetRendererInfo">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetRendererInfo(IntPtr renderer, ref SDL_RendererInfo info);
    ///<summary>Get the output size in pixels of a rendering context.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetRendererOutputSize">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetRendererOutputSize(IntPtr renderer, out int w, out int h);
    ///<summary>Create a texture for a rendering context.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_CreateTexture">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateTexture(IntPtr renderer, uint format, int access, int w, int h);
    ///<summary>Create a texture from an existing surface.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_CreateTextureFromSurface">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateTextureFromSurface(IntPtr renderer, IntPtr surface);
    ///<summary>Query the attributes of a texture.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_QueryTexture">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_QueryTexture(IntPtr texture, out uint format, out int access, out int w, out int h);
    ///<summary>Set an additional color value multiplied into render copy operations.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetTextureColorMod">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetTextureColorMod(IntPtr texture, byte r, byte g, byte b);
    ///<summary>Get the additional color value multiplied into render copy operations.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetTextureColorMod">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetTextureColorMod(IntPtr texture, out byte r, out byte g, out byte b);
    ///<summary>Set an additional alpha value multiplied into render copy operations.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetTextureAlphaMod">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetTextureAlphaMod(IntPtr texture, byte alpha);
    ///<summary>Get the additional alpha value multiplied into render copy operations.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetTextureAlphaMod">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetTextureAlphaMod(IntPtr texture, out byte alpha);
    ///<summary>Set the blend mode for a texture, used by SDL_RenderCopy().</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetTextureBlendMode">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetTextureBlendMode(IntPtr texture, SDL_BlendMode blendMode);
    ///<summary>Get the blend mode used for texture copy operations.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetTextureBlendMode">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetTextureBlendMode(IntPtr texture, out SDL_BlendMode blendMode);
    ///<summary>Set the scale mode used for texture scale operations.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetTextureScaleMode">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetTextureScaleMode(IntPtr texture, SDL_ScaleMode scaleMode);
    ///<summary>Get the scale mode used for texture scale operations.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetTextureScaleMode">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetTextureScaleMode(IntPtr texture, out SDL_ScaleMode scaleMode);
    ///<summary>Associate a user-specified pointer with a texture.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetTextureUserData">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetTextureUserData(IntPtr texture, IntPtr userData);
    ///<summary>Get the user-specified pointer associated with a texture</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetTextureUserData">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetTextureUserData(IntPtr texture);
    ///<summary>Update the given texture rectangle with new pixel data.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_UpdateTexture">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_UpdateTexture(IntPtr texture, in SDL_Rect rect, IntPtr pixels, int pitch);
    ///<summary>Update a rectangle within a planar YV12 or IYUV texture with new pixel data.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_UpdateYUVTexture">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_UpdateYUVTexture(
        IntPtr texture,
        in SDL_Rect rect,
        [In][MarshalAs(UnmanagedType.LPArray)] byte[] yPlane,
        int yPitch,
        [In][MarshalAs(UnmanagedType.LPArray)] byte[] uPlane,
        int uPitch,
        [In][MarshalAs(UnmanagedType.LPArray)] byte[] vPlane,
        int vPitch
    );
    ///<summary>Update a rectangle within a planar NV12 or NV21 texture with new pixels.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_UpdateNVTexture">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_UpdateNVTexture(
        IntPtr texture,
        in SDL_Rect rect,
        [In][MarshalAs(UnmanagedType.LPArray)] byte[] yPlane,
        int yPitch,
        [In][MarshalAs(UnmanagedType.LPArray)] byte[] uvPlane,
        int uvPitch
    );
    ///<summary>Lock a portion of the texture for write-only pixel access.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LockTexture">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_LockTexture(IntPtr texture, in SDL_Rect rect, out IntPtr pixels, out int pitch);
    ///<summary>Lock a portion of the texture for write-only pixel access, and expose it as a SDL surface.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LockTextureToSurface">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_LockTextureToSurface(IntPtr texture, in SDL_Rect rect, out IntPtr surface);
    ///<summary>Unlock a texture, uploading the changes to video memory, if needed.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_UnlockTexture">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_UnlockTexture(IntPtr texture);
    ///<summary>Determine whether a renderer supports the use of render targets.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderTargetSupported">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_RenderTargetSupported(IntPtr renderer);
    ///<summary>Set a texture as the current rendering target.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetRenderTarget">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetRenderTarget(IntPtr renderer, IntPtr texture);
    ///<summary>Get the current render target.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetRenderTarget">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetRenderTarget(IntPtr renderer);
    ///<summary>Set a device independent resolution for rendering.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderSetLogicalSize">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderSetLogicalSize(IntPtr renderer, int w, int h);
    ///<summary>Get device independent resolution for rendering.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderGetLogicalSize">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_RenderGetLogicalSize(IntPtr renderer, out int w, out int h);
    ///<summary>Set whether to force integer scales for resolution-independent rendering.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderSetIntegerScale">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderSetIntegerScale(IntPtr renderer, bool enable);
    ///<summary>Get whether integer scales are forced for resolution-independent rendering.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderGetIntegerScale">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_RenderGetIntegerScale(IntPtr renderer);
    ///<summary>Set the drawing area for rendering on the current target.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderSetViewport">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderSetViewport(IntPtr renderer, in SDL_Rect rect);
    ///<summary>Get the drawing area for the current target.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderGetViewport">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_RenderGetViewport(IntPtr renderer, out SDL_Rect rect);
    ///<summary>Set the clip rectangle for rendering on the specified target.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderSetClipRect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderSetClipRect(IntPtr renderer, in SDL_Rect rect);
    ///<summary>Get the clip rectangle for the current target.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderGetClipRect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_RenderGetClipRect(IntPtr renderer, out SDL_Rect rect);
    ///<summary>Get whether clipping is enabled on the given renderer.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderIsClipEnabled">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_RenderIsClipEnabled(IntPtr renderer);
    ///<summary>Set the drawing scale for rendering on the current target.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderSetScale">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderSetScale(IntPtr renderer, float scaleX, float scaleY);
    ///<summary>Get the drawing scale for the current target.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderGetScale">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_RenderGetScale(IntPtr renderer, out float scaleX, out float scaleY);
    ///<summary>Get logical coordinates of point in renderer when given real coordinates of point in window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderWindowToLogical">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_RenderWindowToLogical(
        IntPtr renderer,
        int windowX,
        int windowY,
        out float logicalX,
        out float logicalY
    );
    ///<summary>Get real coordinates of point in window when given logical coordinates of point in renderer.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderLogicalToWindow">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_RenderLogicalToWindow(
        IntPtr renderer,
        float logicalX,
        float logicalY,
        out int windowX,
        out int windowY
    );
    ///<summary>Set the color used for drawing operations (Rect, Line and Clear).</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetRenderDrawColor">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetRenderDrawColor(IntPtr renderer, byte r, byte g, byte b, byte a);
    ///<summary>Get the color used for drawing operations (Rect, Line and Clear).</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetRenderDrawColor">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetRenderDrawColor(IntPtr renderer, out byte r, out byte g, out byte b, out byte a);
    ///<summary>Set the blend mode used for drawing operations (Fill and Line).</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetRenderDrawBlendMode">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetRenderDrawBlendMode(IntPtr renderer, SDL_BlendMode blendMode);
    ///<summary>Get the blend mode used for drawing operations.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetRenderDrawBlendMode">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetRenderDrawBlendMode(IntPtr renderer, out SDL_BlendMode blendMode);
    ///<summary>Clear the current rendering target with the drawing color.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderClear">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderClear(IntPtr renderer);
    ///<summary>Draw a point on the current rendering target.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderDrawPoint">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawPoint(IntPtr renderer, int x, int y);
    ///<summary>Draw multiple points on the current rendering target.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderDrawPoints">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawPoints(
        IntPtr renderer,
        [In][MarshalAs(UnmanagedType.LPArray)] SDL_Point[] points,
        int count
    );
    ///<summary>Draw a line on the current rendering target.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderDrawLine">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawLine(IntPtr renderer, int x1, int y1, int x2, int y2);
    ///<summary>Draw a series of connected lines on the current rendering target.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderDrawLines">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawLines(
        IntPtr renderer,
        [In][MarshalAs(UnmanagedType.LPArray)] SDL_Point[] points,
        int count
    );
    ///<summary>Draw a rectangle on the current rendering target.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderDrawRect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawRect(IntPtr renderer, in SDL_Rect rect);
    ///<summary>Draw some number of rectangles on the current rendering target.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderDrawRects">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawRects(
        IntPtr renderer,
        [In][MarshalAs(UnmanagedType.LPArray)] SDL_Rect[] rects,
        int count
    );
    ///<summary>Fill a rectangle on the current rendering target with the drawing color.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderFillRect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderFillRect(IntPtr renderer, in SDL_Rect rect);
    ///<summary>Fill some number of rectangles on the current rendering target with the drawing color.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderFillRects">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderFillRects(
        IntPtr renderer,
        [In][MarshalAs(UnmanagedType.LPArray)] SDL_Rect[] rects,
        int count
    );
    ///<summary>Copy a portion of the texture to the current rendering target.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderCopy">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderCopy(IntPtr renderer, IntPtr texture, in SDL_Rect srcRect, in SDL_Rect dstRect);
    ///<summary>Copy a portion of the texture to the current rendering, with optional rotation and flipping.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderCopyEx">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderCopyEx(
        IntPtr renderer,
        IntPtr texture,
        in SDL_Rect srcRect,
        in SDL_Rect dstRect,
        double angle,
        in SDL_Point center,
        SDL_RendererFlip flip
    );
    ///<summary>Draw a point on the current rendering target at subpixel precision.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderDrawPointF">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawPointF(IntPtr renderer, float x, float y);
    ///<summary>Draw multiple points on the current rendering target at subpixel precision.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderDrawPointsF">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawPointsF(
        IntPtr renderer,
        [In][MarshalAs(UnmanagedType.LPArray)] SDL_FPoint[] points,
        int count
    );
    ///<summary>Draw a line on the current rendering target at subpixel precision.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderDrawLineF">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawLineF(IntPtr renderer, float x1, float y1, float x2, float y2);
    ///<summary>Draw a series of connected lines on the current rendering target at subpixel precision.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderDrawLinesF">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawLinesF(
        IntPtr renderer,
        [In][MarshalAs(UnmanagedType.LPArray)] SDL_FPoint[] points,
        int count
    );
    ///<summary>Draw a rectangle on the current rendering target at subpixel precision.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderDrawRectF">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawRectF(IntPtr renderer, in SDL_FRect rect);
    ///<summary>Draw some number of rectangles on the current rendering target at subpixel precision.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderDrawRectsF">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawRectsF(
        IntPtr renderer,
        [In][MarshalAs(UnmanagedType.LPArray)] SDL_FRect[] rects,
        int count
    );
    ///<summary>Fill a rectangle on the current rendering target with the drawing color at subpixel precision.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderFillRectF">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderFillRectF(IntPtr renderer, in SDL_FRect rect);
    ///<summary>Fill some number of rectangles on the current rendering target with the drawing color at subpixel precision.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderFillRectsF">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderFillRectsF(
        IntPtr renderer,
        [In][MarshalAs(UnmanagedType.LPArray)] SDL_FRect[] rects,
        int count
    );
    ///<summary>Copy a portion of the texture to the current rendering target at subpixel precision.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderCopyF">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderCopyF(
        IntPtr renderer,
        IntPtr texture,
        in SDL_Rect srcRect,
        in SDL_FRect dstRect
    );
    ///<summary>Copy a portion of the source texture to the current rendering target, with rotation and flipping, at subpixel precision.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderCopyExF">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderCopyExF(
        IntPtr renderer,
        IntPtr texture,
        in SDL_Rect srcRect,
        in SDL_FRect dstRect,
        double angle,
        in SDL_FPoint center,
        SDL_RendererFlip flip
    );
    ///<summary>Render a list of triangles, optionally using a texture and indices into the vertex array Color and alpha modulation is done per vertex (SDL_SetTextureColorMod and SDL_SetTextureAlphaMod are ignored).</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderGeometry">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderGeometry(
        IntPtr renderer,
        IntPtr texture,
        [In][MarshalAs(UnmanagedType.LPArray)] SDL_Vertex[] vertices,
        int numVertices,
        [In][MarshalAs(UnmanagedType.LPArray)] int[] indices,
        int numIndices
    );
    ///<summary>Render a list of triangles, optionally using a texture and indices into the vertex arrays Color and alpha modulation is done per vertex (SDL_SetTextureColorMod and SDL_SetTextureAlphaMod are ignored).</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderGeometryRaw">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderGeometryRaw(
        IntPtr renderer,
        IntPtr texture,
        [In][MarshalAs(UnmanagedType.LPArray)] float[] xy,
        int xyStride,
        [In][MarshalAs(UnmanagedType.LPArray)] SDL_Color[] colors,
        int colorStride,
        [In][MarshalAs(UnmanagedType.LPArray)] float[] uv,
        int uvStride,
        int numVertices,
        IntPtr indices,
        int numIndices,
        int sizeIndices
    );
    ///<summary>Read pixels from the current rendering target to an array of pixels.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderReadPixels">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderReadPixels(
        IntPtr renderer,
        in SDL_Rect rect,
        uint format,
        IntPtr pixels,
        int pitch
    );
    ///<summary>Update the screen with any rendering performed since the previous call.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderPresent">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_RenderPresent(IntPtr renderer);
    ///<summary>Destroy the specified texture.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_DestroyTexture">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_DestroyTexture(IntPtr texture);
    ///<summary>Destroy the rendering context for a window and free associated textures.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_DestroyRenderer">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_DestroyRenderer(IntPtr renderer);
    ///<summary>Force the rendering context to flush any pending commands to the underlying rendering API.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderFlush">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderFlush(IntPtr renderer);
    ///<summary>Bind an OpenGL/ES/ES2 texture to the current context.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GL_BindTexture">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GL_BindTexture(IntPtr texture, out float texW, out float texH);
    ///<summary>Unbind an OpenGL/ES/ES2 texture from the current context.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GL_UnbindTexture">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GL_UnbindTexture(IntPtr texture);
    ///<summary>Get the CAMetalLayer associated with the given Metal renderer.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderGetMetalLayer">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_RenderGetMetalLayer(IntPtr renderer);
    ///<summary>Get the Metal command encoder for the current frame</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderGetMetalCommandEncoder">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_RenderGetMetalCommandEncoder(IntPtr renderer);
    ///<summary>Toggle VSync of the given renderer.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderSetVSync">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderSetVSync(IntPtr renderer, int vSync);
}
