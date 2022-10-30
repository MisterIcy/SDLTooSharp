using System.Runtime.InteropServices;

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

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetNumRenderDrivers();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetRenderDriverInfo(int index, out SDL_RendererInfo info);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_CreateWindowAndRenderer(int width, int height, uint windowFlags, out IntPtr window,
        out IntPtr renderer);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateRenderer(IntPtr window, int index, uint flags);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateSoftwareRenderer(IntPtr surface);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetRenderer(IntPtr window);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_RenderGetWindow(IntPtr renderer);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetRendererInfo(IntPtr renderer, ref SDL_RendererInfo info);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetRendererOutputSize(IntPtr renderer, out int w, out int h);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateTexture(IntPtr renderer, uint format, int access, int w, int h);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_CreateTextureFromSurface(IntPtr renderer, IntPtr surface);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_QueryTexture(IntPtr texture, out uint format, out int access, out int w, out int h);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetTextureColorMod(IntPtr texture, byte r, byte g, byte b);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetTextureColorMod(IntPtr texture, out byte r, out byte g, out byte b);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetTextureAlphaMod(IntPtr texture, byte alpha);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetTextureAlphaMod(IntPtr texture, out byte alpha);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetTextureBlendMode(IntPtr texture, SDL_BlendMode blendMode);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetTextureBlendMode(IntPtr texture, out SDL_BlendMode blendMode);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetTextureScaleMode(IntPtr texture, SDL_ScaleMode scaleMode);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetTextureScaleMode(IntPtr texture, out SDL_ScaleMode scaleMode);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetTextureUserData(IntPtr texture, IntPtr userData);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetTextureUserData(IntPtr texture);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_UpdateTexture(IntPtr texture, in SDL_Rect rect, IntPtr pixels, int pitch);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_UpdateYUVTexture(IntPtr texture, in SDL_Rect rect, in byte[] yPlane, int yPitch,
        in byte[] uPlane, int uPitch, in byte[] vPlane, int vPitch);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_UpdateNVTexture(IntPtr texture, in SDL_Rect rect, in byte[] yPlane, int yPitch,
        in byte[] uvPlane, int uvPitch);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_LockTexture(IntPtr texture, in SDL_Rect rect, out IntPtr pixels, out int pitch);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_LockTextureToSurface(IntPtr texture, in SDL_Rect rect, out IntPtr surface);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_UnlockTexture(IntPtr texture);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_RenderTargetSupported(IntPtr renderer);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetRenderTarget(IntPtr renderer, IntPtr texture);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetRenderTarget(IntPtr renderer);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderSetLogicalSize(IntPtr renderer, int w, int h);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_RenderGetLogicalSize(IntPtr renderer, out int w, out int h);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderSetIntegerScale(IntPtr renderer, bool enable);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_RenderGetIntegerScale(IntPtr renderer);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderSetViewport(IntPtr renderer, in SDL_Rect rect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_RenderGetViewport(IntPtr renderer, out SDL_Rect rect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderSetClipRect(IntPtr renderer, in SDL_Rect rect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_RenderGetClipRect(IntPtr renderer, out SDL_Rect rect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_RenderIsClipEnabled(IntPtr renderer);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderSetScale(IntPtr renderer, float scaleX, float scaleY);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_RenderGetScale(IntPtr renderer, out float scaleX, out float scaleY);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_RenderWindowToLogical(IntPtr renderer, int windowX, int windowY, out float logicalX,
        out float logicalY);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_RenderLogicalToWindow(IntPtr renderer, float logicalX, float logicalY,
        out int windowX, out int windowY);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetRenderDrawColor(IntPtr renderer, byte r, byte g, byte b, byte a);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetRenderDrawColor(IntPtr renderer, out byte r, out byte g, out byte b, out byte a);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SetRenderDrawBlendMode(IntPtr renderer, SDL_BlendMode blendMode);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetRenderDrawBlendMode(IntPtr renderer, out SDL_BlendMode blendMode);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderClear(IntPtr renderer);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawPoint(IntPtr renderer, int x, int y);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawPoints(IntPtr renderer, in SDL_Point[] points, int count);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawLine(IntPtr renderer, int x1, int y1, int x2, int y2);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawLines(IntPtr renderer, in SDL_Point[] points, int count);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawRect(IntPtr renderer, in SDL_Rect rect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawRects(IntPtr renderer, in SDL_Rect[] rects, int count);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderFillRect(IntPtr renderer, in SDL_Rect rect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderFillRects(IntPtr renderer, in SDL_Rect[] rects, int count);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderCopy(IntPtr renderer, IntPtr texture, in SDL_Rect srcRect, in SDL_Rect dstRect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderCopyEx(IntPtr renderer, IntPtr texture, in SDL_Rect srcRect, in SDL_Rect dstRect,
        double angle, in SDL_Point center, SDL_RendererFlip flip);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawPointF(IntPtr renderer, float x, float y);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawPointsF(IntPtr renderer, in SDL_FPoint[] points, int count);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawLineF(IntPtr renderer, float x1, float y1, float x2, float y2);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawLinesF(IntPtr renderer, in SDL_FPoint[] points, int count);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawRectF(IntPtr renderer, in SDL_FRect rect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderDrawRectsF(IntPtr renderer, in SDL_FRect[] rects, int count);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderFillRectF(IntPtr renderer, in SDL_FRect rect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderFillRectsF(IntPtr renderer, in SDL_FRect[] rects, int count);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderCopyF(IntPtr renderer, IntPtr texture, in SDL_Rect srcRect,
        in SDL_FRect dstRect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderCopyExF(IntPtr renderer, IntPtr texture, in SDL_Rect srcRect,
        in SDL_FRect dstRect, double angle, in SDL_FPoint center, SDL_RendererFlip flip);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderGeometry(IntPtr renderer, IntPtr texture, in SDL_Vertex[] vertices,
        int numVertices, in int[] indices, int numIndices);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderGeometryRaw(IntPtr renderer, IntPtr texture, in float[] xy, int xyStride,
        in SDL_Color[] colors, int colorStride, in float[] uv, int uvStride, int numVertices, IntPtr indices,
        int numIndices, int sizeIndices);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderReadPixels(IntPtr renderer, in SDL_Rect rect, uint format, IntPtr pixels,
        int pitch);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_RenderPresent(IntPtr renderer);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_DestroyTexture(IntPtr texture);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_DestroyRenderer(IntPtr renderer);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderFlush(IntPtr renderer);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GL_BindTexture(IntPtr texture, out float texW, out float texH);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GL_UnbindTexture(IntPtr texture);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_RenderGetMetalLayer(IntPtr renderer);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_RenderGetMetalCommandEncoder(IntPtr renderer);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RenderSetVSync(IntPtr renderer, int vSync);
}
