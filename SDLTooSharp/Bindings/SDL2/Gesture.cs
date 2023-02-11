using System.Runtime.InteropServices;
#pragma warning disable CS1591
namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    ///<summary>Begin recording a gesture on a specified touch device or all touch devices.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RecordGesture">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_RecordGesture(long touchId);
    ///<summary>Save all currently loaded Dollar Gesture templates.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SaveAllDollarTemplates">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SaveAllDollarTemplates(IntPtr dst);
    ///<summary>Save a currently loaded Dollar Gesture template.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SaveDollarTemplate">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SaveDollarTemplate(long gestureId, IntPtr dst);
    ///<summary>Load Dollar Gesture templates from a file.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LoadDollarTemplates">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_LoadDollarTemplates(long touchId, IntPtr src);
}
