using System.Runtime.InteropServices;

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

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GetVersion(out SDL_version ver);
}
