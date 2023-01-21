using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    public enum SDL_TouchDeviceType
    {
        SDL_TOUCH_DEVICE_INVALID = -1,
        SDL_TOUCH_DEVICE_DIRECT,
        SDL_TOUCH_DEVICE_INDIRECT_ABSOLUTE,
        SDL_TOUCH_DEVICE_INDIRECT_RELATIVE
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_Finger
    {
        public long Id;
        public float X;
        public float Y;
        public float Pressure;
    }
    ///<summary>Get the number of registered touch devices.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetNumTouchDevices">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetNumTouchDevices();
    ///<summary>Get the touch ID with the given index.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetTouchDevice">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_GetTouchDevice(int index);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTouchName")]
    private static extern IntPtr _SDL_GetTouchName(int index);
    ///<summary>Get the touch device name as reported from the driver or NULL if the index is invalid.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetTouchName">SDL2 Documentation</a></remarks>
    public static string SDL_GetTouchName(int index) => PtrToManaged(_SDL_GetTouchName(index));
    ///<summary>Get the type of the given touch device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetTouchDeviceType">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_TouchDeviceType SDL_GetTouchDeviceType(long touchId);
    ///<summary>Get the number of active fingers for a given touch device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetNumTouchFingers">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetNumTouchFingers(long touchId);
    ///<summary>Get the finger object for specified touch device ID and finger index.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetTouchFinger">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetTouchFinger(long touchId, int index);
}
