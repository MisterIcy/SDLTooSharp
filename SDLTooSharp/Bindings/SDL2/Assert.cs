using System.Diagnostics;
#pragma warning disable CS1591

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    /// <summary>
    /// C# almost equivalent to Triggering a Breakpoint
    /// </summary>
    [DebuggerHidden]
    [Conditional("DEBUG")]
    public static void SDL_TriggerBreakpoint()
    {
        if ( Debugger.IsAttached )
        {
            Debugger.Break();
        }
    }
}
