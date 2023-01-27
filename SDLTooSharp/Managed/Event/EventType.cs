using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Event;

/// <summary>
/// Enumeration of SDL Event Types
/// </summary>
public enum EventType : uint
{
    /// <summary>
    /// Unused event
    /// </summary>
    FirstEvent = SDL.SDL_EventType.SDL_FIRSTEVENT,
    /// <summary>
    /// User requested quit
    /// </summary>
    /// <remarks>
    /// SDL_QUIT events are generated for a variety of reasons. An application can choose to ignore the event,
    /// for example, if it wants to offer a prompt asking the user to save the current work.
    ///
    /// An SDL_QUIT event is generated when the user clicks on the close button of the last existing window.
    /// This happens in addition to the SDL_WINDOWEVENT/SDL_WINDOWEVENT_CLOSE event, so the application can
    /// check whichever is appropriate, or both, or neither. If the application ignores this event and
    /// creates another window, SDL_QUIT will be sent again the next time the user clicks on the last remaining
    /// window's close button.
    ///
    /// SDL_QUIT is not limited to window closing. On Mac OS X, pressing Command-Q (the standard keyboard shortcut
    /// for "Quit this application") will cause SDL to generate an SDL_QUIT event, regardless of what windows exist
    /// at the time. The application is still responsible for terminating itself properly, however. Applications
    /// that completely ignore Command-Q will fail Mac App Store certification.
    ///
    /// On POSIX systems, SDL_Init() installs signal handlers for SIGINT (keyboard interrupt)
    /// and SIGTERM (system termination request), if handlers do not already exist, that generate SDL_QUIT
    /// events as well. There is no way to determine the cause of an SDL_QUIT event, but setting a signal
    /// handler in your application will override the default generation of quit events for that signal.
    /// </remarks>
    Quit = SDL.SDL_EventType.SDL_QUIT,
    /// <summary>
    /// OS is terminating the application
    /// </summary>
    AppTerminating = SDL.SDL_EventType.SDL_APP_TERMINATING,
    /// <summary>
    /// OS is low on memory, free some
    /// </summary>
    AppLowMemory = SDL.SDL_EventType.SDL_APP_LOWMEMORY,
    /// <summary>
    /// The application is entering the background
    /// </summary>
    AppWillEnterBackground = SDL.SDL_EventType.SDL_APP_WILLENTERBACKGROUND,
    /// <summary>
    /// The application has entered the background
    /// </summary>
    AppDidEnterBackground = SDL.SDL_EventType.SDL_APP_DIDENTERBACKGROUND,
    /// <summary>
    /// The application is entering the foreground
    /// </summary>
    AppWillEnterForeground = SDL.SDL_EventType.SDL_APP_WILLENTERFOREGROUND,
    /// <summary>
    /// The aplication hs entered the foreground
    /// </summary>
    AppDidEnterForeground = SDL.SDL_EventType.SDL_APP_DIDENTERFOREGROUND,
    /// <summary>
    /// The user's locale preferences have changed
    /// </summary>
    AppLocaleChanged = SDL.SDL_EventType.SDL_LOCALECHANGED,
    /// <summary>
    /// The display state was changed
    /// </summary>
    DisplayEvent = SDL.SDL_EventType.SDL_DISPLAYEVENT,
    /// <summary>
    /// The window state has changed.
    /// </summary>
    WindowEvent = SDL.SDL_EventType.SDL_WINDOWEVENT,
    /// <summary>
    /// System Window Manager specific event
    /// </summary>
    SysWMEvent = SDL.SDL_EventType.SDL_SYSWMEVENT,
    /// <summary>
    /// A key was pressed
    /// </summary>
    KeyDown = SDL.SDL_EventType.SDL_KEYDOWN,
    /// <summary>
    /// A key was released
    /// </summary>
    KeyUp = SDL.SDL_EventType.SDL_KEYUP,
    /// <summary>
    /// Keyboard text editing.
    /// </summary>
    TextEditing = SDL.SDL_EventType.SDL_TEXTEDITING,
    /// <summary>
    /// Keyboard text input
    /// </summary>
    TextInput = SDL.SDL_EventType.SDL_TEXTINPUT,
    /// <summary>
    /// Keymap has changed due to a system event
    /// </summary>
    KeymapChanged = SDL.SDL_EventType.SDL_KEYMAPCHANGED,
    /// <summary>
    /// Keyboard text editing (extended composition)
    /// </summary>
    TextEditingExt = SDL.SDL_EventType.SDL_TEXTEDITING_EXT,
    /// <summary>
    /// The mouse was moved
    /// </summary>
    MouseMotion = SDL.SDL_EventType.SDL_MOUSEMOTION,
    /// <summary>
    /// A mouse button was pressed
    /// </summary>
    MouseButtonDown = SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN,
    /// <summary>
    /// A mouse button was released
    /// </summary>
    MouseButtonUp = SDL.SDL_EventType.SDL_MOUSEBUTTONUP,
    /// <summary>
    /// The mouse wheel was scrolled
    /// </summary>
    MouseWheel = SDL.SDL_EventType.SDL_MOUSEWHEEL,
    /// <summary>
    /// A joystick axis was moved
    /// </summary>
    JoyAxisMotion = SDL.SDL_EventType.SDL_JOYAXISMOTION,
    /// <summary>
    /// A joystick ball was moved
    /// </summary>
    JoyBallMotion = SDL.SDL_EventType.SDL_JOYBALLMOTION,
    /// <summary>
    /// A joystick hat was moved
    /// </summary>
    JoyHatMotion = SDL.SDL_EventType.SDL_JOYHATMOTION,
    /// <summary>
    /// A joystick button was pressed
    /// </summary>
    JoyButtonDown = SDL.SDL_EventType.SDL_JOYBUTTONDOWN,
    /// <summary>
    /// A joystick button was released
    /// </summary>
    JoyButtonUp = SDL.SDL_EventType.SDL_JOYBUTTONUP,
    /// <summary>
    /// A joystick was added
    /// </summary>
    JoyDeviceAdded = SDL.SDL_EventType.SDL_JOYDEVICEADDED,
    /// <summary>
    /// A joystick was released
    /// </summary>
    JoyDeviceRemoved = SDL.SDL_EventType.SDL_JOYDEVICEREMOVED,
    /// <summary>
    /// The battery status of the joystick was updated
    /// </summary>
    JoyBatteryUpdated = SDL.SDL_EventType.SDL_JOYBATTERYUPDATED,
    /// <summary>
    /// A controller axis was moved
    /// </summary>
    ControllerAxisMotion = SDL.SDL_EventType.SDL_CONTROLLERAXISMOTION,
    /// <summary>
    /// A controller button was pressed
    /// </summary>
    ControllerButtonDown = SDL.SDL_EventType.SDL_CONTROLLERBUTTONDOWN,
    /// <summary>
    /// A controller button was released
    /// </summary>
    ControllerButtonUp = SDL.SDL_EventType.SDL_CONTROLLERBUTTONUP,
    /// <summary>
    /// A controller was added
    /// </summary>
    ControllerDeviceAdded = SDL.SDL_EventType.SDL_CONTROLLERDEVICEADDED,
    /// <summary>
    /// A controller was removed
    /// </summary>
    ControllerDeviceRemoved = SDL.SDL_EventType.SDL_CONTROLLERDEVICEREMOVED,
    /// <summary>
    /// A controller's mapping was updated
    /// </summary>
    ControllerDeviceRemapped = SDL.SDL_EventType.SDL_CONTROLLERDEVICEREMAPPED,
    /// <summary>
    /// A controller's touchpad was touched
    /// </summary>
    ControllerTouchPadDown = SDL.SDL_EventType.SDL_CONTROLLERTOUCHPADDOWN,
    /// <summary>
    /// A controller's touchpad has a motion event (e.g. swiping a finger)
    /// </summary>
    ControllerTouchPadMotion = SDL.SDL_EventType.SDL_CONTROLLERTOUCHPADMOTION,
    /// <summary>
    /// A controller's touchpad was untouched
    /// </summary>
    ControllerTouchPadUp = SDL.SDL_EventType.SDL_CONTROLLERTOUCHPADUP,
    /// <summary>
    /// A controller's sensor was updated
    /// </summary>
    ControllerSensorUpdate = SDL.SDL_EventType.SDL_CONTROLLERSENSORUPDATE,
    /// <summary>
    /// The user has touched the input device.
    /// </summary>
    FingerDown = SDL.SDL_EventType.SDL_FINGERDOWN,
    /// <summary>
    /// The user stopped touching the input device
    /// </summary>
    FingerUp = SDL.SDL_EventType.SDL_FINGERUP,
    /// <summary>
    /// The user is dragging a finger on the input device.
    /// </summary>
    FingerMotion = SDL.SDL_EventType.SDL_FINGERMOTION,
    /// <summary>
    /// 
    /// </summary>
    DollarGesture = SDL.SDL_EventType.SDL_DOLLARGESTURE,
    /// <summary>
    /// 
    /// </summary>
    DollarRecord = SDL.SDL_EventType.SDL_DOLLARRECORD,
    /// <summary>
    /// 
    /// </summary>
    Multigesture = SDL.SDL_EventType.SDL_MULTIGESTURE,
    /// <summary>
    /// The clipboard was updated
    /// </summary>
    ClipboardUpdate = SDL.SDL_EventType.SDL_CLIPBOARDUPDATE,
    /// <summary>
    /// The system requests a file open
    /// </summary>
    DropFile = SDL.SDL_EventType.SDL_DROPFILE,
    /// <summary>
    /// Plain drag and drop event
    /// </summary>
    DropText = SDL.SDL_EventType.SDL_DROPTEXT,
    /// <summary>
    /// A new set of drops is beginning
    /// </summary>
    DropBegin = SDL.SDL_EventType.SDL_DROPBEGIN,
    /// <summary>
    /// Current set of drops is complete
    /// </summary>
    DropComplete = SDL.SDL_EventType.SDL_DROPCOMPLETE,
    /// <summary>
    /// An audio device is added
    /// </summary>
    AudioDeviceAdded = SDL.SDL_EventType.SDL_AUDIODEVICEADDED,
    /// <summary>
    /// An audio device is removed
    /// </summary>
    AudioDeviceRemoved = SDL.SDL_EventType.SDL_AUDIODEVICEREMOVED,
    /// <summary>
    /// A sensor was updated
    /// </summary>
    SensorUpdate = SDL.SDL_EventType.SDL_SENSORUPDATE,
    /// <summary>
    /// the render targets have been reset and their contents need to be updated
    /// </summary>
    RenderTargetsReset = SDL.SDL_EventType.SDL_RENDER_TARGETS_RESET,
    /// <summary>
    /// the device has been reset and all textures need to be recreated
    /// </summary>
    RenderDeviceReset = SDL.SDL_EventType.SDL_RENDER_DEVICE_RESET,
    /// <summary>
    /// 
    /// </summary>
    PollSentinel = SDL.SDL_EventType.SDL_POLLSENTINEL,
    /// <summary>
    /// 
    /// </summary>
    UserEvent = SDL.SDL_EventType.SDL_USEREVENT,
    /// <summary>
    /// 
    /// </summary>
    LastEvent = SDL.SDL_EventType.SDL_LASTEVENT,
}
