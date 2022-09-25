using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    public enum SDL_SensorType
    {
        SDL_SENSOR_INVALID = -1,
        SDL_SENSOR_UNKNOWN,
        SDL_SENSOR_ACCEL,
        SDL_SENSOR_GYRO,
        SDL_SENSOR_ACCEL_L,
        SDL_SENSOR_GYRO_L,
        SDL_SENSOR_ACCEL_R,
        SDL_SENSOR_GYRO_R
    }

    public const float SDL_STANDARD_GRAVITY = 9.80665f;

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LockSensors();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_UnlockSensors();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_NumSensors();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetDeviceName")]
    private static extern IntPtr _SDL_SensorGetDeviceName(int deviceIndex);

    public static string SDL_SensorGetDeviceName(int deviceIndex) =>
        PtrToManaged(_SDL_SensorGetDeviceName(deviceIndex));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_SensorType SDL_SensorGetDeviceType(int deviceIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SensorGetDeviceNonPortableType(int deviceIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SensorGetDeviceInstanceID(int deviceIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_SensorOpen(int deviceIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_SensorFromInstanceID(int instanceId);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetName")]
    private static extern IntPtr _SDL_SensorGetName(IntPtr sensor);

    public static string SDL_SensorGetName(IntPtr sensor) => PtrToManaged(_SDL_SensorGetName(sensor));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_SensorType SDL_SensorGetType(IntPtr sensor);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SensorGetNonPortableType(IntPtr sensor);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SensorGetInstanceID(IntPtr sensor);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SensorGetData(IntPtr sensor, out float[] data, int numValues);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SensorClose(IntPtr sensor);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SensorUpdate();
}
