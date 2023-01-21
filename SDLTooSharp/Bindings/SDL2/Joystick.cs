using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    public enum SDL_JoystickType
    {
        SDL_JOYSTICK_TYPE_UNKNOWN,
        SDL_JOYSTICK_TYPE_GAMECONTROLLER,
        SDL_JOYSTICK_TYPE_WHEEL,
        SDL_JOYSTICK_TYPE_ARCADE_STICK,
        SDL_JOYSTICK_TYPE_FLIGHT_STICK,
        SDL_JOYSTICK_TYPE_DANCE_PAD,
        SDL_JOYSTICK_TYPE_GUITAR,
        SDL_JOYSTICK_TYPE_DRUM_KIT,
        SDL_JOYSTICK_TYPE_ARCADE_PAD,
        SDL_JOYSTICK_TYPE_THROTTLE
    }

    public enum SDL_JoystickPowerLevel
    {
        SDL_JOYSTICK_POWER_UNKNOWN = -1,
        SDL_JOYSTICK_POWER_EMPTY, /* <= 5% */
        SDL_JOYSTICK_POWER_LOW, /* <= 20% */
        SDL_JOYSTICK_POWER_MEDIUM, /* <= 70% */
        SDL_JOYSTICK_POWER_FULL, /* <= 100% */
        SDL_JOYSTICK_POWER_WIRED,
        SDL_JOYSTICK_POWER_MAX
    }

    ///<summary>Locking for multi-threaded access to the joystick API</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LockJoysticks">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LockJoysticks();
    ///<summary>Unlocking for multi-threaded access to the joystick API</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_UnlockJoysticks">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_UnlockJoysticks();
    ///<summary>Count the number of joysticks attached to the system.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_NumJoysticks">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_NumJoysticks();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickNameForIndex")]
    private static extern IntPtr _SDL_JoystickNameForIndex(int deviceIndex);
    ///<summary>Get the implementation dependent name of a joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickNameForIndex">SDL2 Documentation</a></remarks>
    public static string SDL_JoystickNameForIndex(int deviceIndex) =>
        PtrToManaged(_SDL_JoystickNameForIndex(deviceIndex));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickPathForIndex")]
    private static extern IntPtr _SDL_JoystickPathForIndex(int deviceIndex);
    ///<summary>Get the implementation dependent path of a joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickPathForIndex">SDL2 Documentation</a></remarks>
    public static string SDL_JoystickPathForIndex(int deviceIndex) => PtrToManaged(
        _SDL_JoystickPathForIndex(deviceIndex));
    ///<summary>Get the player index of a joystick, or -1 if it's not available This can be called before any joysticks are opened.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetDevicePlayerIndex">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickGetDevicePlayerIndex(int deviceIndex);
    ///<summary>Get the implementation-dependent GUID for the joystick at a given device index.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetDeviceGUID">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Guid SDL_JoystickGetDeviceGUID(int deviceIndex);
    ///<summary>Get the USB vendor ID of a joystick, if available.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetDeviceVendor">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_JoystickGetDeviceVendor(int deviceIndex);
    ///<summary>Get the USB product ID of a joystick, if available.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetDeviceProduct">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_JoystickGetDeviceProduct(int deviceIndex);
    ///<summary>Get the product version of a joystick, if available.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetDeviceProductVersion">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_JoystickGetDeviceProductVersion(int deviceIndex);
    ///<summary>Get the type of a joystick, if available.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetDeviceType">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_JoystickType SDL_JoystickGetDeviceType(int deviceIndex);
    ///<summary>Get the instance ID of a joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetDeviceInstanceID">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickGetDeviceInstanceID(int deviceIndex);
    ///<summary>Open a joystick for use.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickOpen">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_JoystickOpen(int deviceIndex);
    ///<summary>Get the SDL_Joystick associated with an instance id.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickFromInstanceID">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_JoystickFromInstanceID(int instanceId);
    ///<summary>Get the SDL_Joystick associated with a player index.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickFromPlayerIndex">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_JoystickFromPlayerIndex(int playerIndex);
    ///<summary>Attach a new virtual joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickAttachVirtual">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickAttachVirtual(SDL_JoystickType type, int nAxes, int nButtons, int nHats);

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_VirtualJoystickDesc
    {
        public short Version;
        public short Type;
        public short NumAxes;
        public short NumButtons;
        public short NumHats;
        public short VendorId;
        public short ProductId;
        private short Padding;
        public int ButtonMask;
        public int AxisMask;
        public IntPtr Name;
        public IntPtr UserData;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void Update(IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SetPlayerIndex(IntPtr userData, int playerIndex);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int Rumble(IntPtr userData, ushort lowFrequencyRumble, ushort highFrequencyRumble);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int RumbleTriggers(IntPtr userData, ushort leftRumble, ushort rightRumble);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SetLed(IntPtr userData, byte red, byte green, byte blue);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SendEffect(IntPtr userData, IntPtr data, int size);
    }

    ///<summary>Attach a new virtual joystick with extended properties.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickAttachVirtualEx">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickAttachVirtualEx(in SDL_VirtualJoystickDesc desc);
    ///<summary>Detach a virtual joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickDetachVirtual">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickDetachVirtual(int deviceIndex);
    ///<summary>Query whether or not the joystick at a given device index is virtual.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickIsVirtual">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_JoystickIsVirtual(int deviceIndex);
    ///<summary>Set values on an opened, virtual-joystick's axis.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickSetVirtualAxis">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickSetVirtualAxis(IntPtr joystick, int axis, ushort value);
    ///<summary>Set values on an opened, virtual-joystick's button.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickSetVirtualButton">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickSetVirtualButton(IntPtr joystick, int button, byte value);
    ///<summary>Set values on an opened, virtual-joystick's hat.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickSetVirtualHat">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickSetVirtualHat(IntPtr joystick, int hat, byte value);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickName")]
    private static extern IntPtr _SDL_JoystickName(IntPtr joystick);
    ///<summary>Get the implementation dependent name of a joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickName">SDL2 Documentation</a></remarks>
    public static string SDL_JoystickName(IntPtr joystick) => PtrToManaged(_SDL_JoystickName(joystick));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickPath")]
    private static extern IntPtr _SDL_JoystickPath(IntPtr joystick);
    ///<summary>Get the implementation dependent path of a joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickPath">SDL2 Documentation</a></remarks>
    public static string SDL_JoystickPath(IntPtr joystick) => PtrToManaged(_SDL_JoystickPath(joystick));
    ///<summary>Get the player index of an opened joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetPlayerIndex">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickGetPlayerIndex(IntPtr joystick);
    ///<summary>Set the player index of an opened joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickSetPlayerIndex">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_JoystickSetPlayerIndex(IntPtr joystick, int playerIndex);
    ///<summary>Get the implementation-dependent GUID for the joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetGUID">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Guid SDL_JoystickGetGUID(IntPtr joystick);
    ///<summary>Get the USB vendor ID of an opened joystick, if available.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetVendor">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_JoystickGetVendor(IntPtr joystick);
    ///<summary>Get the USB product ID of an opened joystick, if available.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetProduct">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_JoystickGetProduct(IntPtr joystick);
    ///<summary>Get the product version of an opened joystick, if available.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetProductVersion">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_JoystickGetProductVersion(IntPtr joystick);
    ///<summary>Get the firmware version of an opened joystick, if available.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetFirmwareVersion">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_JoystickGetFirmwareVersion(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetSerial")]
    private static extern IntPtr _SDL_JoystickGetSerial(IntPtr joystick);
    ///<summary>Get the serial number of an opened joystick, if available.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetSerial">SDL2 Documentation</a></remarks>
    public static string SDL_JoystickGetSerial(IntPtr joystick) => PtrToManaged(_SDL_JoystickGetSerial(joystick));
    ///<summary>Get the type of an opened joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetType">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_JoystickType SDL_JoystickGetType(IntPtr joystick);
    ///<summary>Get the device information encoded in a SDL_JoystickGUID structure</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetJoystickGUIDInfo">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GetJoystickGUIDInfo(
        Guid guid,
        out ushort vendor,
        out ushort product,
        out ushort version,
        out ushort crc16
    );
    ///<summary>Get the status of a specified joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetAttached">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_JoystickGetAttached(IntPtr joystick);
    ///<summary>Get the instance ID of an opened joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickInstanceID">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickInstanceID(IntPtr joystick);
    ///<summary>Get the number of general axis controls on a joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickNumAxes">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickNumAxes(IntPtr joystick);
    ///<summary>Get the number of trackballs on a joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickNumBalls">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickNumBalls(IntPtr joystick);
    ///<summary>Get the number of POV hats on a joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickNumHats">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickNumHats(IntPtr joystick);
    ///<summary>Get the number of buttons on a joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickNumButtons">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickNumButtons(IntPtr joystick);
    ///<summary>Update the current state of the open joysticks.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickUpdate">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_JoystickUpdate();
    ///<summary>Enable/disable joystick event polling.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickEventState">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickEventState(int state);

    public const short SDL_JOYSTICK_AXIS_MAX = 32767;
    public const short SDL_JOYSTICK_AXIS_MIN = -32768;
    ///<summary>Get the current state of an axis control on a joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetAxis">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_JoystickGetAxis(IntPtr joystick, int axis);
    ///<summary>Get the initial state of an axis control on a joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetAxisInitialState">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_JoystickGetAxisInitialState(IntPtr joystick, int axis, out ushort state);

    public const byte SDL_HAT_CENTERED = 0x00;
    public const byte SDL_HAT_UP = 0x01;
    public const byte SDL_HAT_RIGHT = 0x02;
    public const byte SDL_HAT_DOWN = 0x04;
    public const byte SDL_HAT_LEFT = 0x08;
    public const byte SDL_HAT_RIGHTUP = ( SDL_HAT_RIGHT | SDL_HAT_UP );
    public const byte SDL_HAT_RIGHTDOWN = ( SDL_HAT_RIGHT | SDL_HAT_DOWN );
    public const byte SDL_HAT_LEFTUP = ( SDL_HAT_LEFT | SDL_HAT_UP );
    public const byte SDL_HAT_LEFTDOWN = ( SDL_HAT_LEFT | SDL_HAT_DOWN );
    ///<summary>Get the current state of a POV hat on a joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetHat">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern byte SDL_JoystickGetHat(IntPtr joystick, int hat);
    ///<summary>Get the ball axis change since the last poll.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetBall">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickGetBall(IntPtr joystick, int ball, out int dx, out int dy);
    ///<summary>Get the current state of a button on a joystick.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickGetButton">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern byte SDL_JoystickGetButton(IntPtr joystick, int button);
    ///<summary>Start a rumble effect.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickRumble">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickRumble(IntPtr joystick, ushort lowFrequencyRumble, ushort highFrequencyRumble);
    ///<summary>Start a rumble effect in the joystick's triggers</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickRumbleTriggers">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickRumbleTriggers(IntPtr joystick, ushort leftRumble, ushort rightRumble);
    ///<summary>Query whether a joystick has an LED.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickHasLED">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_JoystickHasLED(IntPtr joystick);
    ///<summary>Query whether a joystick has rumble support.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickHasRumble">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_JoystickHasRumble(IntPtr joystick);
    ///<summary>Query whether a joystick has rumble support on triggers.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickHasRumbleTriggers">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_JoystickHasRumbleTriggers(IntPtr joystick);
    ///<summary>Update a joystick's LED color.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickSetLED">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickSetLED(IntPtr joystick, byte red, byte green, byte blue);
    ///<summary>Send a joystick specific effect packet</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickSendEffect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickSendEffect(IntPtr joystick, IntPtr data, int size);
    ///<summary>Close a joystick previously opened with SDL_JoystickOpen().</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickClose">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_JoystickClose(IntPtr joystick);
    ///<summary>Get the battery level of a joystick as SDL_JoystickPowerLevel.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickCurrentPowerLevel">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_JoystickPowerLevel SDL_JoystickCurrentPowerLevel(IntPtr joystick);
}
