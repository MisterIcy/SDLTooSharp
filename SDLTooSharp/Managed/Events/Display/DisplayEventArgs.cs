namespace SDLTooSharp.Managed.Events.Display;

public class DisplayEventArgs : EventArgs
{
    public DisplayEventArgs(Bindings.SDL.SDL_DisplayEvent evt)
    {
        Timestamp = evt.Timestamp;
        DisplayIndex = evt.DisplayIndex;
        EventType = evt.Type;
        Data1 = evt.Data1;

    }

    public int Data1 { get; }

    public Bindings.SDL.SDL_EventType EventType { get; }

    public uint DisplayIndex { get; }

    public uint Timestamp { get; }
}