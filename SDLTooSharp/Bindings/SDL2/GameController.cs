using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    public enum SDL_GameControllerType
    {
        SDL_CONTROLLER_TYPE_UNKNOWN = 0,
        SDL_CONTROLLER_TYPE_XBOX360,
        SDL_CONTROLLER_TYPE_XBOXONE,
        SDL_CONTROLLER_TYPE_PS3,
        SDL_CONTROLLER_TYPE_PS4,
        SDL_CONTROLLER_TYPE_NINTENDO_SWITCH_PRO,
        SDL_CONTROLLER_TYPE_VIRTUAL,
        SDL_CONTROLLER_TYPE_PS5,
        SDL_CONTROLLER_TYPE_AMAZON_LUNA,
        SDL_CONTROLLER_TYPE_GOOGLE_STADIA,
        SDL_CONTROLLER_TYPE_NVIDIA_SHIELD,
        SDL_CONTROLLER_TYPE_NINTENDO_SWITCH_JOYCON_LEFT,
        SDL_CONTROLLER_TYPE_NINTENDO_SWITCH_JOYCON_RIGHT,
        SDL_CONTROLLER_TYPE_NINTENDO_SWITCH_JOYCON_PAIR
    }

    public enum SDL_GameControllerBindType
    {
        SDL_CONTROLLER_BINDTYPE_NONE = 0,
        SDL_CONTROLLER_BINDTYPE_BUTTON,
        SDL_CONTROLLER_BINDTYPE_AXIS,
        SDL_CONTROLLER_BINDTYPE_HAT
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_GameControllerButtonBindHat
    {
        public int Hat;
        public int HatMask;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct SDL_GameControllerButtonBindValue
    {
        [FieldOffset(0)] public int Button;
        [FieldOffset(0)] public int Axis;
        [FieldOffset(0)] public SDL_GameControllerButtonBindHat Hat;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_GameControllerButtonBind
    {
        public SDL_GameControllerBindType BindType;
        public SDL_GameControllerButtonBindValue Value;
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerAddMappingsFromRW(IntPtr rw, int freeRw);

    public static int SDL_GameControllerAddMappingsFromFile(string file) =>
        SDL_GameControllerAddMappingsFromRW(SDL_RWFromFile(file, "rb"), 1);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerAddMapping([MarshalAs(UnmanagedType.LPUTF8Str)] string mappingString);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerNumMappings();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerMappingForIndex")]
    private static extern IntPtr _SDL_GameControllerMappingForIndex(int mappingIndex);

    public static string SDL_GameControllerMappingForIndex(int mappingIndex) =>
        PtrToManaged(_SDL_GameControllerMappingForIndex(mappingIndex), true);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerMappingForGUID")]
    private static extern IntPtr _SDL_GameControllerMappingForGUID(Guid guid);

    public static string SDL_GameControllerMappingForGUID(Guid guid) =>
        PtrToManaged(_SDL_GameControllerMappingForGUID(guid), true);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerMapping")]
    private static extern IntPtr _SDL_GameControllerMapping(IntPtr gameController);

    public static string SDL_GameControllerMapping(IntPtr gameController) =>
        PtrToManaged(_SDL_GameControllerMapping(gameController), true);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IsGameController(int joystickIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerNameForIndex")]
    private static extern IntPtr _SDL_GameControllerNameForIndex(int joystickIndex);

    public static string SDL_GameControllerNameForIndex(int joystickIndex) =>
        PtrToManaged(_SDL_GameControllerNameForIndex(joystickIndex));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerPathForIndex")]
    private static extern IntPtr _SDL_GameControllerPathForIndex(int joystickIndex);

    public static string SDL_GameControllerPathForIndex(int joystickIndex) =>
        PtrToManaged(_SDL_GameControllerPathForIndex(joystickIndex));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_GameControllerType SDL_GameControllerTypeForIndex(int joystickIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "SDL_GameControllerMappingForDeviceIndex")]
    private static extern IntPtr _SDL_GameControllerMappingForDeviceIndex(int joystickIndex);

    public static string SDL_GameControllerMappingForDeviceIndex(int joystickIndex) =>
        PtrToManaged(_SDL_GameControllerMappingForDeviceIndex(joystickIndex), true);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GameControllerOpen(int joystickIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GameControllerFromInstanceID(int joystickId);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GameControllerFromPlayerIndex(int playerIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerName")]
    private static extern IntPtr _SDL_GameControllerName(IntPtr gameController);

    public static string SDL_GameControllerName(IntPtr gameController) =>
        PtrToManaged(_SDL_GameControllerName(gameController));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerPath")]
    private static extern IntPtr _SDL_GameControllerPath(IntPtr gameController);

    public static string SDL_GameControllerPath(IntPtr gameController) =>
        PtrToManaged(_SDL_GameControllerPath(gameController));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_GameControllerType SDL_GameControllerGetType(IntPtr gameController);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerGetPlayerIndex(IntPtr gameController);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GameControllerSetPlayerIndex(IntPtr gameController, int playerIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_GameControllerGetVendor(IntPtr gameController);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_GameControllerGetProduct(IntPtr gameController);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_GameControllerGetProductVersion(IntPtr gameController);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_GameControllerGetFirmwareVersion(IntPtr gameController);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetSerial")]
    private static extern IntPtr _SDL_GameControllerGetSerial(IntPtr gameController);

    public static string SDL_GameControllerGetSerial(IntPtr gameController) =>
        PtrToManaged(_SDL_GameControllerGetSerial(gameController));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GameControllerGetAttached(IntPtr gameController);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GameControllerGetJoystick(IntPtr gameController);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerEventState(int state);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GameControllerUpdate();

    public enum SDL_GameControllerAxis
    {
        SDL_CONTROLLER_AXIS_INVALID = -1,
        SDL_CONTROLLER_AXIS_LEFTX,
        SDL_CONTROLLER_AXIS_LEFTY,
        SDL_CONTROLLER_AXIS_RIGHTX,
        SDL_CONTROLLER_AXIS_RIGHTY,
        SDL_CONTROLLER_AXIS_TRIGGERLEFT,
        SDL_CONTROLLER_AXIS_TRIGGERRIGHT,
        SDL_CONTROLLER_AXIS_MAX
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_GameControllerAxis SDL_GameControllerGetAxisFromString(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string str);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetStringForAxis")]
    private static extern IntPtr _SDL_GameControllerGetStringForAxis(SDL_GameControllerAxis axis);

    public static string SDL_GameControllerGetStringForAxis(SDL_GameControllerAxis axis) =>
        PtrToManaged(_SDL_GameControllerGetStringForAxis(axis));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_GameControllerButtonBind SDL_GameControllerGetBindForAxis(IntPtr gameController,
        SDL_GameControllerAxis axis);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GameControllerHasAxis(IntPtr gameController, SDL_GameControllerAxis axis);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_GameControllerGetAxis(IntPtr gameController, SDL_GameControllerAxis axis);

    public enum SDL_GameControllerButton
    {
        SDL_CONTROLLER_BUTTON_INVALID = -1,
        SDL_CONTROLLER_BUTTON_A,
        SDL_CONTROLLER_BUTTON_B,
        SDL_CONTROLLER_BUTTON_X,
        SDL_CONTROLLER_BUTTON_Y,
        SDL_CONTROLLER_BUTTON_BACK,
        SDL_CONTROLLER_BUTTON_GUIDE,
        SDL_CONTROLLER_BUTTON_START,
        SDL_CONTROLLER_BUTTON_LEFTSTICK,
        SDL_CONTROLLER_BUTTON_RIGHTSTICK,
        SDL_CONTROLLER_BUTTON_LEFTSHOULDER,
        SDL_CONTROLLER_BUTTON_RIGHTSHOULDER,
        SDL_CONTROLLER_BUTTON_DPAD_UP,
        SDL_CONTROLLER_BUTTON_DPAD_DOWN,
        SDL_CONTROLLER_BUTTON_DPAD_LEFT,
        SDL_CONTROLLER_BUTTON_DPAD_RIGHT,

        /// <summary>
        /// Xbox Series X share button, PS5 microphone button, Nintendo Switch Pro capture button, Amazon Luna microphone button
        /// </summary>
        SDL_CONTROLLER_BUTTON_MISC1,

        /// <summary>
        /// Xbox Elite paddle P1
        /// </summary>
        SDL_CONTROLLER_BUTTON_PADDLE1,

        /// <summary>
        /// Xbox Elite paddle P3
        /// </summary>
        SDL_CONTROLLER_BUTTON_PADDLE2,

        /// <summary>
        /// Xbox Elite paddle P2
        /// </summary>
        SDL_CONTROLLER_BUTTON_PADDLE3,

        /// <summary>
        /// Xbox Elite paddle P4
        /// </summary>
        SDL_CONTROLLER_BUTTON_PADDLE4,

        /// <summary>
        /// PS4/PS5 touchpad button
        /// </summary>
        SDL_CONTROLLER_BUTTON_TOUCHPAD,
        SDL_CONTROLLER_BUTTON_MAX
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_GameControllerButton SDL_GameControllerGetButtonFromString(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string str);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "SDL_GameControllerGetStringForButton")]
    private static extern IntPtr _SDL_GameControllerGetStringForButton(SDL_GameControllerButton button);

    public static string SDL_GameControllerGetStringForButton(SDL_GameControllerButton button) =>
        PtrToManaged(_SDL_GameControllerGetStringForButton(button));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_GameControllerButtonBind SDL_GameControllerGetBindForButton(IntPtr gameController,
        SDL_GameControllerButton button);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GameControllerHasButton(IntPtr gameController, SDL_GameControllerButton button);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern byte SDL_GameControllerGetButton(IntPtr gameController, SDL_GameControllerButton button);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerGetNumTouchpads(IntPtr gameController);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerGetNumTouchpadFingers(IntPtr gameController, int touchpad);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerGetTouchpadFinger(IntPtr gameController, int touchpad, int finger,
        out byte state, out float x, out float y, out float pressure);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GameControllerHasSensor(IntPtr gameController, SDL_SensorType type);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerSetSensorEnabled(IntPtr gameController, SDL_SensorType type,
        bool enabled);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GameControllerIsSensorEnabled(IntPtr gameController, SDL_SensorType type);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float SDL_GameControllerGetSensorDataRate(IntPtr gameController, SDL_SensorType type);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerGetSensorData(IntPtr gameController, SDL_SensorType type, out float data,
        int numValues);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerRumble(IntPtr gameController, ushort lowFrequencyRumble,
        ushort highFrequencyRumble, uint durationMs);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerRumbleTriggers(IntPtr gameController, ushort leftRumble,
        ushort rightRumble, uint durationMs);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GameControllerHasLED(IntPtr gameController);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GameControllerHasRumble(IntPtr gameController);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GameControllerHasRumbleTriggers(IntPtr gameController);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerSetLED(IntPtr gameController, byte red, byte green, byte blue);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerSendEffect(IntPtr gameController, IntPtr data, int size);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GameControllerClose(IntPtr gameController);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForButton")]
    private static extern IntPtr _SDL_GameControllerGetAppleSFSymbolsNameForButton(IntPtr gameController,
        SDL_GameControllerButton button);

    public static string SDL_GameControllerGetAppleSFSymbolsNameForButton(IntPtr gameController,
        SDL_GameControllerButton button) =>
        PtrToManaged(_SDL_GameControllerGetAppleSFSymbolsNameForButton(gameController, button));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForAxis")]
    private static extern IntPtr _SDL_GameControllerGetAppleSFSymbolsNameForAxis(IntPtr gameController,
        SDL_GameControllerAxis axis);

    public static string SDL_GameControllerGetAppleSFSymbolsNameForAxis(IntPtr gameController,
        SDL_GameControllerAxis axis) =>
        PtrToManaged(_SDL_GameControllerGetAppleSFSymbolsNameForAxis(gameController, axis));
}