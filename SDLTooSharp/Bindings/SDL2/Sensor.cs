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
    ///<summary>Locking for multi-threaded access to the sensor API</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LockSensors">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LockSensors();
    ///<summary></summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_UnlockSensors">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_UnlockSensors();
    ///<summary>Count the number of sensors attached to the system right now.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_NumSensors">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_NumSensors();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetDeviceName")]
    private static extern IntPtr _SDL_SensorGetDeviceName(int deviceIndex);
    ///<summary>Get the implementation dependent name of a sensor.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SensorGetDeviceName">SDL2 Documentation</a></remarks>
    public static string SDL_SensorGetDeviceName(int deviceIndex) =>
            PtrToManaged(_SDL_SensorGetDeviceName(deviceIndex));
    ///<summary>Get the type of a sensor.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SensorGetDeviceType">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_SensorType SDL_SensorGetDeviceType(int deviceIndex);
    ///<summary>Get the platform dependent type of a sensor.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SensorGetDeviceNonPortableType">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SensorGetDeviceNonPortableType(int deviceIndex);
    ///<summary>Get the instance ID of a sensor.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SensorGetDeviceInstanceID">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SensorGetDeviceInstanceID(int deviceIndex);
    ///<summary>Open a sensor for use.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SensorOpen">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_SensorOpen(int deviceIndex);
    ///<summary>Return the SDL_Sensor associated with an instance id.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SensorFromInstanceID">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_SensorFromInstanceID(int instanceId);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetName")]
    private static extern IntPtr _SDL_SensorGetName(IntPtr sensor);
    ///<summary>Get the implementation dependent name of a sensor</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SensorGetName">SDL2 Documentation</a></remarks>
    public static string SDL_SensorGetName(IntPtr sensor) => PtrToManaged(_SDL_SensorGetName(sensor));
    ///<summary>Get the type of a sensor.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SensorGetType">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_SensorType SDL_SensorGetType(IntPtr sensor);
    ///<summary>Get the platform dependent type of a sensor.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SensorGetNonPortableType">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SensorGetNonPortableType(IntPtr sensor);
    ///<summary>Get the instance ID of a sensor.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SensorGetInstanceID">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SensorGetInstanceID(IntPtr sensor);
    ///<summary>Get the current state of an opened sensor.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SensorGetData">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_SensorGetData(IntPtr sensor, out float[] data, int numValues);
    ///<summary>Close a sensor previously opened with SDL_SensorOpen().</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SensorClose">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SensorClose(IntPtr sensor);
    ///<summary>Update the current state of the open sensors.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SensorUpdate">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SensorUpdate();
}
