using System.Runtime.InteropServices;
using SDLTooSharp.Managed.Events.Display;

namespace SDLTooSharp.Bindings;

public static partial class SDL2
{
    /// <summary>
    /// Value of a Released Key.
    /// </summary>
    public const int SDL_RELEASED = 0;

    /// <summary>
    /// Value of a Pressed Key.
    /// </summary>
    public const int SDL_PRESSED = 1;

    /// <summary>
    /// A list of event types that can be delivered.
    /// </summary>
    public enum SDL_EventType : uint
    {
        /// <summary>
        /// Unused
        /// </summary>
        SDL_FIRSTEVENT = 0,

        /// <summary>
        /// User-requested quit.
        /// </summary>
        SDL_QUIT = 0x100,

        /// <summary>
        /// The application is being terminated by the OS
        /// </summary>
        SDL_APP_TERMINATING,

        /// <summary>
        /// The application is low on memory.
        /// </summary>
        SDL_APP_LOWMEMORY,

        /// <summary>
        /// The application is about to enter the background.
        /// </summary>
        SDL_APP_WILLENTERBACKGROUND,

        /// <summary>
        /// The application entered the background and may not get CPU for some time.
        /// </summary>
        SDL_APP_DIDENTERBACKGROUND,

        /// <summary>
        /// The application is about to enter the foreground.
        /// </summary>
        SDL_APP_WILLENTERFOREGROUND,

        /// <summary>
        /// The application entered the foreground
        /// </summary>
        SDL_APP_DIDENTERFOREGROUND,

        /// <summary>
        /// The user's locale has changed.
        /// </summary>
        SDL_LOCALECHANGED,

        /// <summary>
        /// Display state change
        /// </summary>
        SDL_DISPLAYEVENT = 0x150,

        /// <summary>
        /// Window state change
        /// </summary>
        SDL_WINDOWEVENT = 0x200,

        /// <summary>
        /// System specific event
        /// </summary>
        SDL_SYSWMEVENT,

        /// <summary>
        /// Key pressed
        /// </summary>
        SDL_KEYDOWN = 0x300,

        /// <summary>
        /// Key released
        /// </summary>
        SDL_KEYUP,

        /// <summary>
        /// Keyboard text editing
        /// </summary>
        SDL_TEXTEDITING,

        /// <summary>
        /// Keyboard text input
        /// </summary>
        SDL_TEXTINPUT,

        /// <summary>
        /// Keymap changed (due to an input language or keyboard layout change)
        /// </summary>
        SDL_KEYMAPCHANGED,

        /// <summary>
        /// Extended keyboard text editing
        /// </summary>
        SDL_TEXTEDITING_EXT,

        /// <summary>
        /// Mouse moved
        /// </summary>
        SDL_MOUSEMOTION = 0x400,

        /// <summary>
        /// Mouse button pressed
        /// </summary>
        SDL_MOUSEBUTTONDOWN,

        /// <summary>
        /// Mouse button released
        /// </summary>
        SDL_MOUSEBUTTONUP,

        /// <summary>
        /// Mouse wheel motion
        /// </summary>
        SDL_MOUSEWHEEL,


        /// <summary>
        /// Joystick axis motion
        /// </summary>
        SDL_JOYAXISMOTION = 0x600,

        /// <summary>
        /// Joystick trackball motion
        /// </summary>
        SDL_JOYBALLMOTION,

        /// <summary>
        /// Joystick hat motion
        /// </summary>
        SDL_JOYHATMOTION,

        /// <summary>
        /// Joystick button pressed
        /// </summary>
        SDL_JOYBUTTONDOWN,

        /// <summary>
        /// Joystick button released
        /// </summary>
        SDL_JOYBUTTONUP,

        /// <summary>
        /// New joystick was connected
        /// </summary>
        SDL_JOYDEVICEADDED,

        /// <summary>
        /// An opened joystick has been removed
        /// </summary>
        SDL_JOYDEVICEREMOVED,

        /// <summary>
        /// Joystick battery level change
        /// </summary>
        SDL_JOYBATTERYUPDATED,

        /// <summary>
        /// Game controller axis motion
        /// </summary>
        SDL_CONTROLLERAXISMOTION = 0x650,

        /// <summary>
        /// Game controller button pressed
        /// </summary>
        SDL_CONTROLLERBUTTONDOWN,

        /// <summary>
        /// Game controller button released
        /// </summary>
        SDL_CONTROLLERBUTTONUP,

        /// <summary>
        /// A new game controller was connected.
        /// </summary>
        SDL_CONTROLLERDEVICEADDED,

        /// <summary>
        /// An opened game controller was removed.
        /// </summary>
        SDL_CONTROLLERDEVICEREMOVED,

        /// <summary>
        /// The controller mapping was updated
        /// </summary>
        SDL_CONTROLLERDEVICEREMAPPED,

        /// <summary>
        /// Game controller touchpad was touched
        /// </summary>
        SDL_CONTROLLERTOUCHPADDOWN,

        /// <summary>
        /// Game controller touchpad finger was moved
        /// </summary>
        SDL_CONTROLLERTOUCHPADMOTION,

        /// <summary>
        /// Game controller touchpad finger was lifted
        /// </summary>
        SDL_CONTROLLERTOUCHPADUP,

        /// <summary>
        ///  Game controller sensor was updated
        /// </summary>
        SDL_CONTROLLERSENSORUPDATE,

        /// <summary>
        /// Finger touched the touchpad
        /// </summary>
        SDL_FINGERDOWN = 0x700,

        /// <summary>
        /// Finger was lifted from touchpad
        /// </summary>
        SDL_FINGERUP,

        /// <summary>
        /// Finger was moved on the touchpad
        /// </summary>
        SDL_FINGERMOTION,

        SDL_DOLLARGESTURE = 0x800,
        SDL_DOLLARRECORD,
        SDL_MULTIGESTURE,

        /// <summary>
        /// The clipboard was updated
        /// </summary>
        SDL_CLIPBOARDUPDATE = 0x900,

        /// <summary>
        /// The ystem requests a file open
        /// </summary>
        SDL_DROPFILE = 0x1000,

        /// <summary>
        /// Plain test drag-ang-drop event
        /// </summary>
        SDL_DROPTEXT,

        /// <summary>
        /// A new set of drops is beginning (null filename)
        /// </summary>
        SDL_DROPBEGIN,

        /// <summary>
        /// Current set of drops is complete.
        /// </summary>
        SDL_DROPCOMPLETE,

        /// <summary>
        /// A new audio device is available
        /// </summary>
        SDL_AUDIODEVICEADDED = 0x1100,

        /// <summary>
        /// An audio device has been removed
        /// </summary>
        SDL_AUDIODEVICEREMOVED,

        /// <summary>
        /// A sensor was updated
        /// </summary>
        SDL_SENSORUPDATE = 0x1200,

        /// <summary>
        /// The render targets have been reset and their contents need to be updated
        /// </summary>
        SDL_RENDER_TARGETS_RESET = 0x2000,

        /// <summary>
        /// The device has been reset and all textures need to be recreated
        /// </summary>
        SDL_RENDER_DEVICE_RESET,

        /// <summary>
        /// Signals the end of an event poll cycle
        /// </summary>
        SDL_POLLSENTINEL = 0x7F00,
        SDL_USEREVENT = 0x8000,
        SDL_LASTEVENT = 0xFFFF
    }

    /// <summary>
    /// Fields shared by every event
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_CommonEvent
    {
        /// <summary>
        /// The event type
        /// </summary>
        public SDL_EventType Type;

        /// <summary>
        /// The timestamp the event occurred in milliseconds (from SDL_GetTicks())
        /// </summary>
        public uint Timestamp;
    }

    /// <summary>
    /// Display state change event data.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_DisplayEvent
    {
        /// <summary>
        /// The event type
        /// </summary>
        public SDL_EventType Type;

        /// <summary>
        /// The timestamp the event occurred in milliseconds (from SDL_GetTicks())
        /// </summary>
        public uint Timestamp;

        /// <summary>
        /// The associated display index
        /// </summary>
        public uint Display;

        /// <summary>
        /// Display Event ID
        /// </summary>
        public byte Event;

        private byte _padding1;
        private byte _padding2;
        private byte _padding3;

        /// <summary>
        /// Event dependent data
        /// </summary>
        public int Data1;
    }

    /// <summary>
    /// Window state change event data
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_WindowEvent
    {
        /// <summary>
        /// The event type
        /// </summary>
        public SDL_EventType Type;

        /// <summary>
        /// The timestamp the event occurred in milliseconds (from SDL_GetTicks())
        /// </summary>
        public uint Timestamp;

        /// <summary>
        /// The associated window
        /// </summary>
        public uint WindowId;

        /// <summary>
        /// Window Event Id
        /// </summary>
        public byte Event;

        private byte _padding1;
        private byte _padding2;
        private byte _padding3;

        /// <summary>
        /// Event dependend data
        /// </summary>
        public int Data1;

        /// <summary>
        /// Event dependent data
        /// </summary>
        public int Data2;
    }

    /// <summary>
    /// Keyboard button event structure
    /// </summary>
    public struct SDL_KeyboardEvent
    {
        /// <summary>
        /// The event type
        /// </summary>
        public SDL_EventType Type;

        /// <summary>
        /// The timestamp the event occurred in milliseconds (from SDL_GetTicks())
        /// </summary>
        public uint Timestamp;

        /// <summary>
        /// The window with keyboard focus, if any.
        /// </summary>
        public uint WindowId;

        /// <summary>
        /// Pressed or Released
        /// </summary>
        /// <seealso cref="SDL2.SDL_PRESSED"/>
        /// <see cref="SDL2.SDL_RELEASED"/>
        public byte State;

        /// <summary>
        /// Non-zero if this is a key repeat
        /// </summary>
        public byte Repeat;

        private byte padding2;
        private byte padding3;

        /// <summary>
        /// The key that was pressed or released.
        /// </summary>
        /// <returns></returns>
        public SDL_Keysym keysym;
    }

    /// <summary>
    /// Keyboard text editing event structure
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL_TextEditingEvent
    {
        /// <summary>
        /// The event type
        /// </summary>
        public SDL_EventType Type;

        /// <summary>
        /// The timestamp the event occurred in milliseconds (from SDL_GetTicks())
        /// </summary>
        public uint Timestamp;

        /// <summary>
        /// The ID of the Window with keyboard focus
        /// </summary>
        public uint WindowId;

        /// <summary>
        /// The editing text
        /// </summary>
        public fixed char Text[32];

        /// <summary>
        /// The start cursor of selected editing text
        /// </summary>
        public int Start;

        /// <summary>
        /// The length of selected editing text
        /// </summary>
        public int Length;
    }

    /// <summary>
    /// Extended keyboard text editing event structure
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_TextEditingExtEvent
    {
        /// <summary>
        /// The event type
        /// </summary>
        public SDL_EventType Type;

        /// <summary>
        /// The timestamp the event occurred in milliseconds (from SDL_GetTicks())
        /// </summary>
        public uint Timestamp;

        /// <summary>
        /// The ID of the Window with keyboard focus
        /// </summary>
        public uint WindowId;

        /// <summary>
        /// The editing text
        /// </summary>
        public IntPtr Text;

        /// <summary>
        /// The start cursor of selected editing text
        /// </summary>
        public int Start;

        /// <summary>
        /// The length of selected editing text
        /// </summary>
        public int Length;
    }

    /// <summary>
    /// Keyboard text input event structure
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL_TextInputEvent
    {
        /// <summary>
        /// The event type
        /// </summary>
        public SDL_EventType Type;

        /// <summary>
        /// The timestamp the event occurred in milliseconds (from SDL_GetTicks())
        /// </summary>
        public uint Timestamp;

        /// <summary>
        /// The ID of the Window with keyboard focus
        /// </summary>
        public uint WindowId;

        /// <summary>
        /// The editing text
        /// </summary>
        public fixed char Text[32];
    }

    /// <summary>
    /// Mouse motion structure
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_MouseMotionEvent
    {
        /// <summary>
        /// The event type
        /// </summary>
        public SDL_EventType Type;

        /// <summary>
        /// The timestamp the event occurred in milliseconds (from SDL_GetTicks())
        /// </summary>
        public uint Timestamp;

        /// <summary>
        /// The ID of the Window with keyboard focus
        /// </summary>
        public uint WindowId;

        /// <summary>
        /// The Mouse Instance id associated with the event
        /// </summary>
        public uint Which;

        /// <summary>
        /// The current button state
        /// </summary>
        public uint State;

        /// <summary>
        /// X coordinate, relative to the window
        /// </summary>
        public int X;

        /// <summary>
        /// Y coordinate, relative to the window
        /// </summary>
        public int Y;

        /// <summary>
        /// Relative motion in the X direction
        /// </summary>
        public int XRel;

        /// <summary>
        /// Relative motion in the Y direction
        /// </summary>
        public int YRel;
    }

    /// <summary>
    /// Mouse button structure
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_MouseButtonEvent
    {
        /// <summary>
        /// The event type
        /// </summary>
        public SDL_EventType Type;

        /// <summary>
        /// The timestamp the event occurred in milliseconds (from SDL_GetTicks())
        /// </summary>
        public uint Timestamp;

        /// <summary>
        /// The ID of the Window with keyboard focus
        /// </summary>
        public uint WindowId;

        /// <summary>
        /// The Mouse Instance id associated with the event
        /// </summary>
        public uint Which;

        /// <summary>
        /// The mouse button index
        /// </summary>
        public byte Button;

        /// <summary>
        /// Pressed or released
        /// </summary>
        /// <see cref="SDL2.SDL_PRESSED"/>
        /// <see cref="SDL2.SDL_RELEASED"/>
        public byte State;

        /// <summary>
        /// Number of clicks
        /// </summary>
        public byte Clicks;

        private byte _padding1;

        /// <summary>
        /// X coordinate, relative to the window
        /// </summary>
        public int X;

        /// <summary>
        /// Y coordinate, relative to the window
        /// </summary>
        public int Y;
    }

    /// <summary>
    /// Mouse wheel structure
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_MouseWheelEvent
    {
        /// <summary>
        /// The event type
        /// </summary>
        public SDL_EventType Type;

        /// <summary>
        /// The timestamp the event occurred in milliseconds (from SDL_GetTicks())
        /// </summary>
        public uint Timestamp;

        /// <summary>
        /// The ID of the Window with keyboard focus
        /// </summary>
        public uint WindowId;

        /// <summary>
        /// The Mouse Instance id associated with the event
        /// </summary>
        public uint Which;

        /// <summary>
        /// The amount scrolled horizontally
        /// </summary>
        public int X;

        /// <summary>
        /// The amount scrolled vertically
        /// </summary>
        public int Y;

        /// <summary>
        /// The direction
        /// </summary>
        /// <see cref="SDL_MouseWheelDirection"/>
        public uint Direction;

        /// <summary>
        /// The amount scrolled horizontally
        /// </summary>
        public float PreciseX;

        /// <summary>
        /// The amount scrolled vertically
        /// </summary>
        public float PreciseY;
    }

    /// <summary>
    /// Drop event strcture
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_DropEvent
    {
        /// <summary>
        /// The event type
        /// </summary>
        public SDL_EventType Type;

        /// <summary>
        /// The timestamp the event occurred in milliseconds (from SDL_GetTicks())
        /// </summary>
        public uint Timestamp;

        /// <summary>
        /// The filename
        /// </summary>
        public IntPtr File;

        /// <summary>
        /// The window that was dropped on
        /// </summary>
        public uint WindowId;
    }

    /// <summary>
    /// Quit event structure
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_QuitEvent
    {
        /// <summary>
        /// The event type
        /// </summary>
        public SDL_EventType Type;

        /// <summary>
        /// The timestamp the event occurred in milliseconds (from SDL_GetTicks())
        /// </summary>
        public uint Timestamp;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct SDL_Event
    {
        /// <summary>
        /// The event type
        /// </summary>
        [FieldOffset(0)] public SDL_EventType Type;

        /// <summary>
        /// Common event data
        /// </summary>
        [FieldOffset(0)] public SDL_CommonEvent Common;

        /// <summary>
        /// Display event data
        /// </summary>
        [FieldOffset(0)] public SDL_DisplayEvent Display;

        /// <summary>
        /// Window event data
        /// </summary>
        [FieldOffset(0)] public SDL_WindowEvent Window;

        /// <summary>
        /// Keyboard event data
        /// </summary>
        [FieldOffset(0)] public SDL_KeyboardEvent Key;

        /// <summary>
        /// Text editing event data
        /// </summary>
        [FieldOffset(0)] public SDL_TextEditingEvent Edit;

        /// <summary>
        /// Extended text editing event data
        /// </summary>
        [FieldOffset(0)] public SDL_TextEditingExtEvent EditExt;

        /// <summary>
        /// Text input event data
        /// </summary>
        [FieldOffset(0)] public SDL_TextInputEvent Text;

        /// <summary>
        /// Mouse motion event data
        /// </summary>
        [FieldOffset(0)] public SDL_MouseMotionEvent Motion;

        /// <summary>
        /// Mouse button event data
        /// </summary>
        [FieldOffset(0)] public SDL_MouseButtonEvent Button;

        /// <summary>
        /// Mouse wheel event data
        /// </summary>
        [FieldOffset(0)] public SDL_MouseWheelEvent Wheel;

        /// <summary>
        /// Quit event data
        /// </summary>
        [FieldOffset(0)] public SDL_QuitEvent Quit;

        /// <summary>
        /// Drop event data.
        /// </summary>
        [FieldOffset(0)] public SDL_DropEvent Drop;
    }

    public enum SDL_eventaction
    {
        SDL_ADDEVENT,
        SDL_PEEKEVENT,
        SDL_GETEVENT
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_PumpEvents();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_PeepEvents([In] SDL_Event[] events, int numEvents, SDL_eventaction action,
        uint minType, uint maxType);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasEvent(uint type);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasEvents(uint minType, uint maxType);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_FlushEvent(uint type);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_FlushEvents(uint minType, uint maxType);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_PollEvent(ref SDL_Event @event);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_WaitEvent(ref SDL_Event @event);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_WaitEventTimeout(ref SDL_Event @event, int timeout);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_PushEvent(ref SDL_Event @event);

    public const int SDL_QUERY = -1;
    public const int SDL_IGNORE = 0;
    public const int SDL_DISABLE = 0;
    public const int SDL_ENABLE = 1;

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern byte SDL_EventState(uint type, int state);

    public static byte SDL_GetEventState(uint type)
    {
        return SDL_EventState(type, SDL_QUERY);
    }
}