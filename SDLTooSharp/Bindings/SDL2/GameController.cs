using System.Runtime.InteropServices;
#pragma warning disable CS1591
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

    ///<summary>Load a set of Game Controller mappings from a seekable SDL data stream.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerAddMappingsFromRW">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerAddMappingsFromRW(IntPtr rw, int freeRw);
    ///<summary>Use this function to load a set of Game Controller mappings from a file, filtered by the current SDL_GetPlatform(). A community sourced database of controllers is available here|target="_blank" (on GitHub).</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerAddMappingsFromFile">SDL2 Documentation</a></remarks>
    public static int SDL_GameControllerAddMappingsFromFile(string file) =>
        SDL_GameControllerAddMappingsFromRW(SDL_RWFromFile(file, "rb"), 1);
    ///<summary>Add support for controllers that SDL is unaware of or to cause an existing controller to have a different binding.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerAddMapping">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerAddMapping([MarshalAs(UnmanagedType.LPUTF8Str)] string mappingString);
    ///<summary>Get the number of mappings installed.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerNumMappings">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerNumMappings();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerMappingForIndex")]
    private static extern IntPtr _SDL_GameControllerMappingForIndex(int mappingIndex);
    ///<summary>Get the mapping at a particular index.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerMappingForIndex">SDL2 Documentation</a></remarks>
    public static string SDL_GameControllerMappingForIndex(int mappingIndex) =>
        PtrToManaged(_SDL_GameControllerMappingForIndex(mappingIndex), true);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerMappingForGUID")]
    private static extern IntPtr _SDL_GameControllerMappingForGUID(Guid guid);
    ///<summary>Get the game controller mapping string for a given GUID.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerMappingForGUID">SDL2 Documentation</a></remarks>
    public static string SDL_GameControllerMappingForGUID(Guid guid) =>
        PtrToManaged(_SDL_GameControllerMappingForGUID(guid), true);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerMapping")]
    private static extern IntPtr _SDL_GameControllerMapping(IntPtr gameController);
    ///<summary>Get the current mapping of a Game Controller.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerMapping">SDL2 Documentation</a></remarks>
    public static string SDL_GameControllerMapping(IntPtr gameController) =>
        PtrToManaged(_SDL_GameControllerMapping(gameController), true);
    ///<summary>Check if the given joystick is supported by the game controller interface.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_IsGameController">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IsGameController(int joystickIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerNameForIndex")]
    private static extern IntPtr _SDL_GameControllerNameForIndex(int joystickIndex);
    ///<summary>Get the implementation dependent name for the game controller.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerNameForIndex">SDL2 Documentation</a></remarks>
    public static string SDL_GameControllerNameForIndex(int joystickIndex) =>
        PtrToManaged(_SDL_GameControllerNameForIndex(joystickIndex));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerPathForIndex")]
    private static extern IntPtr _SDL_GameControllerPathForIndex(int joystickIndex);
    ///<summary>Get the implementation dependent path for the game controller.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerPathForIndex">SDL2 Documentation</a></remarks>
    public static string SDL_GameControllerPathForIndex(int joystickIndex) =>
        PtrToManaged(_SDL_GameControllerPathForIndex(joystickIndex));
    ///<summary>Get the type of a game controller.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerTypeForIndex">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_GameControllerType SDL_GameControllerTypeForIndex(int joystickIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "SDL_GameControllerMappingForDeviceIndex")]
    private static extern IntPtr _SDL_GameControllerMappingForDeviceIndex(int joystickIndex);
    ///<summary>Get the mapping of a game controller.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerMappingForDeviceIndex">SDL2 Documentation</a></remarks>
    public static string SDL_GameControllerMappingForDeviceIndex(int joystickIndex) =>
        PtrToManaged(_SDL_GameControllerMappingForDeviceIndex(joystickIndex), true);
    ///<summary>Open a game controller for use.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerOpen">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GameControllerOpen(int joystickIndex);
    ///<summary>Get the SDL_GameController associated with an instance id.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerFromInstanceID">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GameControllerFromInstanceID(int joystickId);
    ///<summary>Get the SDL_GameController associated with a player index.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerFromPlayerIndex">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GameControllerFromPlayerIndex(int playerIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerName")]
    private static extern IntPtr _SDL_GameControllerName(IntPtr gameController);
    ///<summary>Get the implementation-dependent name for an opened game controller.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerName">SDL2 Documentation</a></remarks>
    public static string SDL_GameControllerName(IntPtr gameController) =>
        PtrToManaged(_SDL_GameControllerName(gameController));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerPath")]
    private static extern IntPtr _SDL_GameControllerPath(IntPtr gameController);
    ///<summary>Get the implementation-dependent path for an opened game controller.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerPath">SDL2 Documentation</a></remarks>
    public static string SDL_GameControllerPath(IntPtr gameController) =>
        PtrToManaged(_SDL_GameControllerPath(gameController));
    ///<summary>Get the type of this currently opened controller</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetType">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_GameControllerType SDL_GameControllerGetType(IntPtr gameController);
    ///<summary>Get the player index of an opened game controller.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetPlayerIndex">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerGetPlayerIndex(IntPtr gameController);
    ///<summary>Set the player index of an opened game controller.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerSetPlayerIndex">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GameControllerSetPlayerIndex(IntPtr gameController, int playerIndex);
    ///<summary>Get the USB vendor ID of an opened controller, if available.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetVendor">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_GameControllerGetVendor(IntPtr gameController);
    ///<summary>Get the USB product ID of an opened controller, if available.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetProduct">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_GameControllerGetProduct(IntPtr gameController);
    ///<summary>Get the product version of an opened controller, if available.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetProductVersion">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_GameControllerGetProductVersion(IntPtr gameController);
    ///<summary>Get the firmware version of an opened controller, if available.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetFirmwareVersion">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern ushort SDL_GameControllerGetFirmwareVersion(IntPtr gameController);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetSerial")]
    private static extern IntPtr _SDL_GameControllerGetSerial(IntPtr gameController);
    ///<summary>Get the serial number of an opened controller, if available.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetSerial">SDL2 Documentation</a></remarks>
    public static string SDL_GameControllerGetSerial(IntPtr gameController) =>
        PtrToManaged(_SDL_GameControllerGetSerial(gameController));
    ///<summary>Check if a controller has been opened and is currently connected.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetAttached">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GameControllerGetAttached(IntPtr gameController);
    ///<summary>Get the Joystick ID from a Game Controller.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetJoystick">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_GameControllerGetJoystick(IntPtr gameController);
    ///<summary>Query or change current state of Game Controller events.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerEventState">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerEventState(int state);
    ///<summary>Manually pump game controller updates if not using the loop.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerUpdate">SDL2 Documentation</a></remarks>
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

    ///<summary>Convert a string into SDL_GameControllerAxis enum.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetAxisFromString">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_GameControllerAxis SDL_GameControllerGetAxisFromString(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string str
    );

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GameControllerGetStringForAxis")]
    private static extern IntPtr _SDL_GameControllerGetStringForAxis(SDL_GameControllerAxis axis);
    ///<summary>Convert from an SDL_GameControllerAxis enum to a string.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetStringForAxis">SDL2 Documentation</a></remarks>
    public static string SDL_GameControllerGetStringForAxis(SDL_GameControllerAxis axis) =>
        PtrToManaged(_SDL_GameControllerGetStringForAxis(axis));
    ///<summary>Get the SDL joystick layer binding for a controller axis mapping.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetBindForAxis">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_GameControllerButtonBind SDL_GameControllerGetBindForAxis(
        IntPtr gameController,
        SDL_GameControllerAxis axis
    );
    ///<summary>Query whether a game controller has a given axis.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerHasAxis">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GameControllerHasAxis(IntPtr gameController, SDL_GameControllerAxis axis);
    ///<summary>Get the current state of an axis control on a game controller.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetAxis">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern short SDL_GameControllerGetAxis(IntPtr gameController, SDL_GameControllerAxis axis);

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

    ///<summary>Convert a string into an SDL_GameControllerButton enum.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetButtonFromString">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_GameControllerButton SDL_GameControllerGetButtonFromString(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string str
    );

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "SDL_GameControllerGetStringForButton")]
    private static extern IntPtr _SDL_GameControllerGetStringForButton(SDL_GameControllerButton button);
    ///<summary>Convert from an SDL_GameControllerButton enum to a string.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetStringForButton">SDL2 Documentation</a></remarks>
    public static string SDL_GameControllerGetStringForButton(SDL_GameControllerButton button) =>
        PtrToManaged(_SDL_GameControllerGetStringForButton(button));
    ///<summary>Get the SDL joystick layer binding for a controller button mapping.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetBindForButton">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern SDL_GameControllerButtonBind SDL_GameControllerGetBindForButton(
        IntPtr gameController,
        SDL_GameControllerButton button
    );
    ///<summary>Query whether a game controller has a given button.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerHasButton">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GameControllerHasButton(IntPtr gameController, SDL_GameControllerButton button);
    ///<summary>Get the current state of a button on a game controller.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetButton">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern byte SDL_GameControllerGetButton(IntPtr gameController, SDL_GameControllerButton button);
    ///<summary>Get the number of touchpads on a game controller.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetNumTouchpads">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerGetNumTouchpads(IntPtr gameController);
    ///<summary>Get the number of supported simultaneous fingers on a touchpad on a game controller.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetNumTouchpadFingers">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerGetNumTouchpadFingers(IntPtr gameController, int touchpad);
    ///<summary>Get the current state of a finger on a touchpad on a game controller.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetTouchpadFinger">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerGetTouchpadFinger(
        IntPtr gameController,
        int touchpad,
        int finger,
        out byte state,
        out float x,
        out float y,
        out float pressure
    );
    ///<summary>Return whether a game controller has a particular sensor.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerHasSensor">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GameControllerHasSensor(IntPtr gameController, SDL_SensorType type);
    ///<summary>Set whether data reporting for a game controller sensor is enabled.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerSetSensorEnabled">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerSetSensorEnabled(
        IntPtr gameController,
        SDL_SensorType type,
        bool enabled
    );
    ///<summary>Query whether sensor data reporting is enabled for a game controller.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerIsSensorEnabled">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GameControllerIsSensorEnabled(IntPtr gameController, SDL_SensorType type);
    ///<summary>Get the data rate (number of events per second) of a game controller sensor.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetSensorDataRate">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern float SDL_GameControllerGetSensorDataRate(IntPtr gameController, SDL_SensorType type);
    ///<summary>Get the current state of a game controller sensor.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetSensorData">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerGetSensorData(
        IntPtr gameController,
        SDL_SensorType type,
        out float[] data,
        int numValues
    );
    ///<summary>Start a rumble effect on a game controller.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerRumble">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerRumble(
        IntPtr gameController,
        ushort lowFrequencyRumble,
        ushort highFrequencyRumble,
        uint durationMs
    );
    ///<summary>Start a rumble effect in the game controller's triggers.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerRumbleTriggers">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerRumbleTriggers(
        IntPtr gameController,
        ushort leftRumble,
        ushort rightRumble,
        uint durationMs
    );
    ///<summary>Query whether a game controller has an LED.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerHasLED">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GameControllerHasLED(IntPtr gameController);
    ///<summary>Query whether a game controller has rumble support.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerHasRumble">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GameControllerHasRumble(IntPtr gameController);
    ///<summary>Query whether a game controller has rumble support on triggers.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerHasRumbleTriggers">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GameControllerHasRumbleTriggers(IntPtr gameController);
    ///<summary>Update a game controller's LED color.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerSetLED">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerSetLED(IntPtr gameController, byte red, byte green, byte blue);
    ///<summary>Send a controller specific effect packet</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerSendEffect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_GameControllerSendEffect(IntPtr gameController, IntPtr data, int size);
    ///<summary>Close a game controller previously opened with SDL_GameControllerOpen().</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerClose">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_GameControllerClose(IntPtr gameController);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForButton")]
    private static extern IntPtr _SDL_GameControllerGetAppleSFSymbolsNameForButton(
        IntPtr gameController,
        SDL_GameControllerButton button
    );
    ///<summary>Return the sfSymbolsName for a given button on a game controller on Apple platforms.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetAppleSFSymbolsNameForButton">SDL2 Documentation</a></remarks>
    public static string SDL_GameControllerGetAppleSFSymbolsNameForButton(
        IntPtr gameController,
        SDL_GameControllerButton button
    ) =>
        PtrToManaged(_SDL_GameControllerGetAppleSFSymbolsNameForButton(gameController, button));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForAxis")]
    private static extern IntPtr _SDL_GameControllerGetAppleSFSymbolsNameForAxis(
        IntPtr gameController,
        SDL_GameControllerAxis axis
    );
    ///<summary>Return the sfSymbolsName for a given axis on a game controller on Apple platforms.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GameControllerGetAppleSFSymbolsNameForAxis">SDL2 Documentation</a></remarks>
    public static string SDL_GameControllerGetAppleSFSymbolsNameForAxis(
        IntPtr gameController,
        SDL_GameControllerAxis axis
    ) =>
        PtrToManaged(_SDL_GameControllerGetAppleSFSymbolsNameForAxis(gameController, axis));
}
