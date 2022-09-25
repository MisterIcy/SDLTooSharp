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

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_LockJoysticks();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_UnlockJoysticks();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_NumJoysticks();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickNameForIndex")]
    private static extern IntPtr _SDL_JoystickNameForIndex(int deviceIndex);

    public static string SDL_JoystickNameForIndex(int deviceIndex) =>
        PtrToManaged(_SDL_JoystickNameForIndex(deviceIndex));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickPathForIndex")]
    private static extern IntPtr _SDL_JoystickPathForIndex(int deviceIndex);

    public static string SDL_JoystickPathForIndex(int deviceIndex) => PtrToManaged(
        _SDL_JoystickPathForIndex(deviceIndex));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickGetDevicePlayerIndex(int deviceIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Guid SDL_JoystickGetDeviceGUID(int deviceIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_JoystickGetDeviceVendor(int deviceIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_JoystickGetDeviceProduct(int deviceIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_JoystickGetDeviceProductVersion(int deviceIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_JoystickType SDL_JoystickGetDeviceType(int deviceIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickGetDeviceInstanceID(int deviceIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_JoystickOpen(int deviceIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_JoystickFromInstanceID(int instanceId);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_JoystickFromPlayerIndex(int playerIndex);

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

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickAttachVirtualEx(in SDL_VirtualJoystickDesc desc);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickDetachVirtual(int deviceIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_JoystickIsVirtual(int deviceIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickSetVirtualAxis(IntPtr joystick, int axis, ushort value);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickSetVirtualButton(IntPtr joystick, int button, byte value);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickSetVirtualHat(IntPtr joystick, int hat, byte value);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickName")]
    private static extern IntPtr _SDL_JoystickName(IntPtr joystick);

    public static string SDL_JoystickName(IntPtr joystick) => PtrToManaged(_SDL_JoystickName(joystick));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickPath")]
    private static extern IntPtr _SDL_JoystickPath(IntPtr joystick);

    public static string SDL_JoystickPath(IntPtr joystick) => PtrToManaged(_SDL_JoystickPath(joystick));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickGetPlayerIndex(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_JoystickSetPlayerIndex(IntPtr joystick, int playerIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern Guid SDL_JoystickGetGUID(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_JoystickGetVendor(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_JoystickGetProduct(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_JoystickGetProductVersion(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_JoystickGetFirmwareVersion(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_JoystickGetSerial")]
    private static extern IntPtr _SDL_JoystickGetSerial(IntPtr joystick);

    public static string SDL_JoystickGetSerial(IntPtr joystick) => PtrToManaged(_SDL_JoystickGetSerial(joystick));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_JoystickType SDL_JoystickGetType(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GetJoystickGUIDInfo(Guid guid, out ushort vendor, out ushort product,
        out ushort version, out ushort crc16);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_JoystickGetAttached(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickInstanceID(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickNumAxes(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickNumBalls(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickNumHats(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickNumButtons(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickEventState(int state);

    public const short SDL_JOYSTICK_AXIS_MAX = 32767;
    public const short SDL_JOYSTICK_AXIS_MIN = -32768;

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_JoystickGetAxis(IntPtr joystick, int axis);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_JoystickGetAxisInitialState(IntPtr joystick, int axis, out ushort state);

    public const byte SDL_HAT_CENTERED = 0x00;
    public const byte SDL_HAT_UP = 0x01;
    public const byte SDL_HAT_RIGHT = 0x02;
    public const byte SDL_HAT_DOWN = 0x04;
    public const byte SDL_HAT_LEFT = 0x08;
    public const byte SDL_HAT_RIGHTUP = (SDL_HAT_RIGHT | SDL_HAT_UP);
    public const byte SDL_HAT_RIGHTDOWN = (SDL_HAT_RIGHT | SDL_HAT_DOWN);
    public const byte SDL_HAT_LEFTUP = (SDL_HAT_LEFT | SDL_HAT_UP);
    public const byte SDL_HAT_LEFTDOWN = (SDL_HAT_LEFT | SDL_HAT_DOWN);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern byte SDL_JoystickGetHat(IntPtr joystick, int hat);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickGetBall(IntPtr joystick, int ball, out int dx, out int dy);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern byte SDL_JoystickGetButton(IntPtr joystick, int button);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickRumble(IntPtr joystick, ushort lowFrequencyRumble, ushort highFrequencyRumble);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickRumbleTriggers(IntPtr joystick, ushort leftRumble, ushort rightRumble);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_JoystickHasLED(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_JoystickHasRumble(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_JoystickHasRumbleTriggers(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickSetLED(IntPtr joystick, byte red, byte green, byte blue);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickSendEffect(IntPtr joystick, IntPtr data, int size);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_JoystickClose(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_JoystickPowerLevel SDL_JoystickCurrentPowerLevel(IntPtr joystick);
}