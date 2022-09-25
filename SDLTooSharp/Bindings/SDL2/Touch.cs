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

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetNumTouchDevices();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern long SDL_GetTouchDevice(int index);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl,EntryPoint = "SDL_GetTouchName")]
    private static extern IntPtr _SDL_GetTouchName(int index);

    public static string SDL_GetTouchName(int index) => PtrToManaged(_SDL_GetTouchName(index));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_TouchDeviceType SDL_GetTouchDeviceType(long touchId);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GetNumTouchFingers(long touchId);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GetTouchFinger(long touchId, int index);
}
