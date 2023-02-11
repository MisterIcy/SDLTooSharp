using System.Runtime.InteropServices;

#pragma warning disable CS1591
namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    ///<summary>Create a CAMetalLayer-backed NSView/UIView and attach it to the specified window.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_Metal_CreateView">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_Metal_CreateView(IntPtr window);

    ///<summary>Destroy an existing SDL_MetalView object.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_Metal_DestroyView">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_Metal_DestroyView(IntPtr metalView);

    ///<summary>Get a pointer to the backing CAMetalLayer for the given view.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_Metal_GetLayer">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_Metal_GetLayer(IntPtr metalView);

    ///<summary>Get the size of a window's underlying drawable in pixels (for use with setting viewport, scissor &amp; etc).</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_Metal_GetDrawableSize">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_Metal_GetDrawableSize(IntPtr window, out int w, out int h);
}
