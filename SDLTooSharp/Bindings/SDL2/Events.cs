using System.Runtime.InteropServices;
#pragma warning disable CS1591
namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    public const int SDL_RELEASED = 0;
    public const int SDL_PRESSED = 1;

    public enum SDL_EventType : uint
    {
        SDL_FIRSTEVENT = 0,
        SDL_QUIT = 0x100,
        SDL_APP_TERMINATING,
        SDL_APP_LOWMEMORY,
        SDL_APP_WILLENTERBACKGROUND,
        SDL_APP_DIDENTERBACKGROUND,
        SDL_APP_WILLENTERFOREGROUND,
        SDL_APP_DIDENTERFOREGROUND,
        SDL_LOCALECHANGED,
        SDL_DISPLAYEVENT = 0x150,
        SDL_WINDOWEVENT = 0x200,
        SDL_SYSWMEVENT,
        SDL_KEYDOWN = 0x300,
        SDL_KEYUP,
        SDL_TEXTEDITING,
        SDL_TEXTINPUT,
        SDL_KEYMAPCHANGED,
        SDL_TEXTEDITING_EXT,
        SDL_MOUSEMOTION = 0x400,
        SDL_MOUSEBUTTONDOWN,
        SDL_MOUSEBUTTONUP,
        SDL_MOUSEWHEEL,
        SDL_JOYAXISMOTION = 0x600,
        SDL_JOYBALLMOTION,
        SDL_JOYHATMOTION,
        SDL_JOYBUTTONDOWN,
        SDL_JOYBUTTONUP,
        SDL_JOYDEVICEADDED,
        SDL_JOYDEVICEREMOVED,
        SDL_JOYBATTERYUPDATED,
        SDL_CONTROLLERAXISMOTION = 0x650,
        SDL_CONTROLLERBUTTONDOWN,
        SDL_CONTROLLERBUTTONUP,
        SDL_CONTROLLERDEVICEADDED,
        SDL_CONTROLLERDEVICEREMOVED,
        SDL_CONTROLLERDEVICEREMAPPED,
        SDL_CONTROLLERTOUCHPADDOWN,
        SDL_CONTROLLERTOUCHPADMOTION,
        SDL_CONTROLLERTOUCHPADUP,
        SDL_CONTROLLERSENSORUPDATE,
        SDL_FINGERDOWN = 0x700,
        SDL_FINGERUP,
        SDL_FINGERMOTION,
        SDL_DOLLARGESTURE = 0x800,
        SDL_DOLLARRECORD,
        SDL_MULTIGESTURE,
        SDL_CLIPBOARDUPDATE = 0x900,
        SDL_DROPFILE = 0x1000,
        SDL_DROPTEXT,
        SDL_DROPBEGIN,
        SDL_DROPCOMPLETE,
        SDL_AUDIODEVICEADDED = 0x1100,
        SDL_AUDIODEVICEREMOVED,
        SDL_SENSORUPDATE = 0x1200,
        SDL_RENDER_TARGETS_RESET = 0x2000,
        SDL_RENDER_DEVICE_RESET,
        SDL_POLLSENTINEL = 0x7F00,
        SDL_USEREVENT = 0x8000,
        SDL_LASTEVENT = 0xFFFF
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_CommonEvent
    {
        public uint Type;
        public uint Timestamp;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_DisplayEvent
    {
        public uint Type;
        public uint Timestamp;
        public uint Display;
        public byte Event;
        private byte Padding1;
        private byte Padding2;
        private byte Padding3;
        public int Data1;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_WindowEvent
    {
        public uint Type;
        public uint Timestamp;
        public uint WindowID;
        public byte Event;
        private byte Padding1;
        private byte Padding2;
        private byte Padding3;
        public int Data1;
        public int Data2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_KeyboardEvent
    {
        public uint Type;
        public uint Timestamp;
        public uint WindowID;
        public byte State;
        public byte Repeat;
        private byte Padding2;
        private byte Padding3;
        public SDL_Keysym KeySym;
    }

    public const int SDL_TEXTEDITINGEVENT_TEXT_SIZE = 32;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL_TextEditingEvent
    {
        public uint Type;
        public uint Timestamp;
        public uint WindowID;
        public fixed char Text[32];
        public int Start;
        public int Length;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_TextEditingExtEvent
    {
        public uint Type;
        public uint Timestamp;
        public uint WindowID;
        public IntPtr Text;
        public int Start;
        public int Length;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL_TextInputEvent
    {
        public uint Type;
        public uint Timestamp;
        public uint WindowID;
        public fixed char Text[32];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_MouseMotionEvent
    {
        public uint Type;
        public uint Timestamp;
        public uint WindowID;
        public uint Which;
        public uint State;
        public int X;
        public int Y;
        public int XRel;
        public int YRel;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_MouseButtonEvent
    {
        public uint Type;
        public uint Timestamp;
        public uint WindowID;
        public uint Which;
        public byte Button;
        public byte State;
        public byte Clicks;
        private byte Padding1;
        public int X;
        public int Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_MouseWheelEvent
    {
        public uint Type;
        public uint Timestamp;
        public uint WindowID;
        public uint Which;
        public int X;
        public int Y;
        public uint Direction;
        public float PreciseX;
        public float PreciseY;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_JoyAxisEvent
    {
        public uint Type;
        public uint Timestamp;
        public int Which;
        public byte Axis;
        public byte Padding1;
        public byte Padding2;
        public byte Padding3;
        public short Value;
        private short Padding4;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_JoyBallEvent
    {
        public uint Type;
        public uint Timestamp;
        public int Which;
        public byte Ball;
        private byte Padding1;
        private byte Padding2;
        private byte Padding3;
        public short XRel;
        public short YRel;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_JoyHatEvent
    {
        public uint Type;
        public uint Timestamp;
        public int Which;
        public byte Hat;
        public byte Value;
        private byte Padding1;
        private byte Padding2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_JoyButtonEvent
    {
        public uint Type;
        public uint Timestamp;
        public int Which;
        public byte Button;
        public byte State;
        private byte Padding1;
        private byte Padding2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_JoyDeviceEvent
    {
        public uint Type;
        public uint Timestamp;
        public int Which;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_JoyBatteryEvent
    {
        public uint Type;
        public uint Timestamp;
        public int Which;
        public SDL_JoystickPowerLevel Level;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_ControllerAxisEvent
    {
        public uint Type;
        public uint Timestamp;
        public int Which;
        public byte Axis;
        private byte Padding1;
        private byte Padding2;
        private byte Padding3;
        public short Value;
        private ushort Padding4;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_ControllerButtonEvent
    {
        public uint Type;
        public uint Timestamp;
        public int Which;
        public byte Button;
        public byte State;
        private byte Padding1;
        private byte Padding2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_ControllerDeviceEvent
    {
        public uint Type;
        public uint Timestamp;
        public int Which;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_ControllerTouchpadEvent
    {
        public uint Type;
        public uint Timestamp;
        public int Which;
        public int Touchpad;
        public int Finger;
        public float X;
        public float Y;
        public float Pressure;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL_ControllerSensorEvent
    {
        public uint Type;
        public uint Timestamp;
        public int Which;
        public int Sensor;
        public fixed float data[3];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_AudioDeviceEvent
    {
        public uint Type;
        public uint Timestamp;
        public uint Which;
        public byte IsCapture;
        private byte Padding1;
        private byte Padding2;
        private byte Padding3;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_TouchFingerEvent
    {
        public uint Type;
        public uint Timestamp;
        public long TouchID;
        public long FingerID;
        public float X;
        public float Y;
        public float dX;
        public float dY;
        public float Pressure;
        public uint WindowID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_MultiGestureEvent
    {
        public uint Type;
        public uint Timestamp;
        public long TouchID;
        public float dTheta;
        public float dDist;
        public float X;
        public float Y;
        public ushort NumFingers;
        private ushort Padding;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_DollarGestureEvent
    {
        public uint Type;
        public uint Timestamp;
        public long TouchID;
        public long GestureID;
        public uint NumFingers;
        public float Error;
        public float X;
        public float Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_DropEvent
    {
        public uint Type;
        public uint Timestamp;
        public IntPtr File;
        public uint WindowID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL_SensorEvent
    {
        public uint Type;
        public uint Timestamp;
        public int Which;
        public fixed float Data[6];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_QuitEvent
    {
        public uint Type;
        public uint Timestamp;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_OSEvent
    {
        public uint Type;
        public uint Timestamp;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_UserEvent
    {
        public uint Type;
        public uint Timestamp;
        public uint WindowID;
        public int Code;
        public IntPtr Data1;
        public IntPtr Data2;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct SDL_Event
    {
        [FieldOffset(0)] public uint Type;
        [FieldOffset(0)] public SDL_CommonEvent Common;
        [FieldOffset(0)] public SDL_DisplayEvent Display;
        [FieldOffset(0)] public SDL_WindowEvent Window;
        [FieldOffset(0)] public SDL_KeyboardEvent Key;
        [FieldOffset(0)] public SDL_TextEditingEvent Edit;
        [FieldOffset(0)] public SDL_TextEditingExtEvent EditExt;
        [FieldOffset(0)] public SDL_TextInputEvent Text;
        [FieldOffset(0)] public SDL_MouseMotionEvent Motion;
        [FieldOffset(0)] public SDL_MouseButtonEvent Button;
        [FieldOffset(0)] public SDL_MouseWheelEvent Wheel;
        [FieldOffset(0)] public SDL_JoyAxisEvent JAxis;
        [FieldOffset(0)] public SDL_JoyBallEvent JBall;
        [FieldOffset(0)] public SDL_JoyHatEvent JHat;
        [FieldOffset(0)] public SDL_JoyButtonEvent JButton;
        [FieldOffset(0)] public SDL_JoyDeviceEvent JDevice;
        [FieldOffset(0)] public SDL_JoyBatteryEvent JBattery;
        [FieldOffset(0)] public SDL_ControllerAxisEvent CAxis;
        [FieldOffset(0)] public SDL_ControllerButtonEvent CButton;
        [FieldOffset(0)] public SDL_ControllerDeviceEvent CDevice;
        [FieldOffset(0)] public SDL_ControllerTouchpadEvent CTouchPad;
        [FieldOffset(0)] public SDL_ControllerSensorEvent CSensor;
        [FieldOffset(0)] public SDL_AudioDeviceEvent ADevice;
        [FieldOffset(0)] public SDL_SensorEvent Sensor;
        [FieldOffset(0)] public SDL_QuitEvent Quit;
        [FieldOffset(0)] public SDL_UserEvent User;
        [FieldOffset(0)] public SDL_TouchFingerEvent TFinger;
        [FieldOffset(0)] public SDL_MultiGestureEvent MGesture;
        [FieldOffset(0)] public SDL_DollarGestureEvent DGesture;
        [FieldOffset(0)] public SDL_DropEvent Drop;
    }

    ///<summary>Pump the event loop, gathering events from the input devices.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_PumpEvents">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_PumpEvents();

    public enum SDL_eventaction
    {
        SDL_ADDEVENT,
        SDL_PEEKEVENT,
        SDL_GETEVENT
    }

    ///<summary>Check the event queue for messages and optionally return them.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_PeepEvents">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_PeepEvents(
        [Out][MarshalAs(( UnmanagedType.LPArray ))] SDL_Event[] events,
        int numEvents,
        SDL_eventaction action,
        uint minType,
        uint maxType
    );
    ///<summary>Check for the existence of a certain event type in the event queue.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasEvent">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasEvent(uint type);
    ///<summary>Check for the existence of certain event types in the event queue.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasEvents">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasEvents(uint minType, uint maxType);
    ///<summary>Clear events of a specific type from the event queue.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_FlushEvent">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_FlushEvent(uint type);
    ///<summary>Clear events of a range of types from the event queue.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_FlushEvents">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_FlushEvents(uint minType, uint maxType);
    ///<summary>Poll for currently pending events.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_PollEvent">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_PollEvent(out SDL_Event @event);
    ///<summary>Wait indefinitely for the next available event.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_WaitEvent">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_WaitEvent(out SDL_Event @event);
    ///<summary>Wait until the specified timeout (in milliseconds) for the next available event.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_WaitEventTimeout">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_WaitEventTimeout(out SDL_Event @event, int timeout);
    ///<summary>Add an event to the event queue.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_PushEvent">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_PushEvent(in SDL_Event @event);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int SDL_EventFilter(IntPtr userData, ref SDL_Event @event);

    ///<summary>Set up a filter to process all events before they change internal state and are posted to the internal event queue.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_SetEventFilter">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_SetEventFilter(
        [MarshalAs(UnmanagedType.FunctionPtr)] SDL_EventFilter filter,
        IntPtr userData
    );
    ///<summary>Query the current event filter.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetEventFilter">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_GetEventFilter(
        [MarshalAs(UnmanagedType.FunctionPtr)] out SDL_EventFilter filter,
        out IntPtr userData
    );
    ///<summary>Add a callback to be triggered when an event is added to the event queue.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_AddEventWatch">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_AddEventWatch(
        [MarshalAs(UnmanagedType.FunctionPtr)] SDL_EventFilter filter,
        IntPtr userData
    );
    ///<summary>Remove an event watch callback added with SDL_AddEventWatch().</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_DelEventWatch">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_DelEventWatch(
        [MarshalAs(UnmanagedType.FunctionPtr)] SDL_EventFilter filter,
        IntPtr userData
    );
    ///<summary>Run a specific filter function on the current event queue, removing any events for which the filter returns 0.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_FilterEvents">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_FilterEvents(
        [MarshalAs(UnmanagedType.FunctionPtr)] SDL_EventFilter filter,
        IntPtr userData
    );

    public const int SDL_QUERY = -1;
    public const int SDL_IGNORE = 0;
    public const int SDL_DISABLE = 0;
    public const int SDL_ENABLE = 1;
    ///<summary>Set the state of processing events by type.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_EventState">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern byte SDL_EventState(uint type, int state);
    ///<summary>Use this macro to query the current processing state of a specified SDL_EventType.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_GetEventState">SDL2 Documentation</a></remarks>
    public static byte SDL_GetEventState(uint type) => SDL_EventState(type, SDL_QUERY);
    ///<summary>Allocate a set of user-defined events, and return the beginning event number for that set of events.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RegisterEvents">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_RegisterEvents(int numEvents);
}
