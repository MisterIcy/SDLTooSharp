using System.Runtime.InteropServices;
#pragma warning disable CS1591
namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_version
    {
        public byte Major;
        public byte Minor;
        public byte Patch;
    }
    ///<summary>Get the version of SDL that is linked against your program.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetVersion">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GetVersion(out SDL_version ver);
}
