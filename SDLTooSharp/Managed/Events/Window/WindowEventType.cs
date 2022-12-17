using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Window;

public enum WindowEventType: byte
{
    None = SDL.SDL_WindowEventID.SDL_WINDOWEVENT_NONE,
    Shown = SDL.SDL_WindowEventID.SDL_WINDOWEVENT_SHOWN,
    Hidden = SDL.SDL_WindowEventID.SDL_WINDOWEVENT_HIDDEN,
    Exposed = SDL.SDL_WindowEventID.SDL_WINDOWEVENT_EXPOSED,
    Moved = SDL.SDL_WindowEventID.SDL_WINDOWEVENT_MOVED,
    Resized = SDL.SDL_WindowEventID.SDL_WINDOWEVENT_RESIZED,
    SizeChanged = SDL.SDL_WindowEventID.SDL_WINDOWEVENT_SIZE_CHANGED,
    Minimized = SDL.SDL_WindowEventID.SDL_WINDOWEVENT_MINIMIZED,
    Maximized = SDL.SDL_WindowEventID.SDL_WINDOWEVENT_MAXIMIZED,
    Restored = SDL.SDL_WindowEventID.SDL_WINDOWEVENT_RESTORED,
    Enter = SDL.SDL_WindowEventID.SDL_WINDOWEVENT_ENTER,
    Leave = SDL.SDL_WindowEventID.SDL_WINDOWEVENT_LEAVE,
    FocusGained = SDL.SDL_WindowEventID.SDL_WINDOWEVENT_FOCUS_GAINED,
    FocusLost = SDL.SDL_WindowEventID.SDL_WINDOWEVENT_FOCUS_LOST,
    Close = SDL.SDL_WindowEventID.SDL_WINDOWEVENT_CLOSE,
    TakeFocus = SDL.SDL_WindowEventID.SDL_WINDOWEVENT_TAKE_FOCUS,
    HitTest = SDL.SDL_WindowEventID.SDL_WINDOWEVENT_HIT_TEST,
    IccProfChanged = SDL.SDL_WindowEventID.SDL_WINDOWEVENT_ICCPROF_CHANGED,
    DisplayChanged = SDL.SDL_WindowEventID.SDL_WINDOWEVENT_DISPLAY_CHANGED
}
