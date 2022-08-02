using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings;

public static partial class SDL2
{
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetError")]
    [SDLVersion(2, 0, 0)]
    private static extern unsafe int _SDL_SetError(byte* errorText);

    /// <summary>
    /// Sets the SDL error message for the current thread.
    /// </summary>
    /// <param name="error">The error string to be set.</param>
    /// <returns>Always -1</returns>
    /// <see cref="SDL_GetError"/>
    /// <see cref="SDL_ClearError"/>
    public static unsafe int SDL_SetError(string error)
    {
        var len = Marshaller.GetStringLengthInBytes(error);
        var buf = stackalloc byte[len];
        return _SDL_SetError(
            Marshaller.ManagedToChar(error, buf, len));
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetError")]
    [SDLVersion(2, 0, 0)]
    private static extern IntPtr _SDL_GetError();

    /// <summary>
    /// Retrieves a message about the last error that occurred on the current thread.
    /// </summary>
    /// <returns>An error message, or an empty string if no error exists</returns>
    /// <see cref="SDL_SetError"/>
    /// <see cref="SDL_ClearError"/>
    public static string SDL_GetError()
    {
        return Marshaller.CharToManaged(
            _SDL_GetError(), true
        );
    }

    /// <summary>
    /// Clear any previous error message for this thread
    /// </summary>
    /// <seealso cref="SDL_GetError"/>
    /// <seealso cref="SDL_SetError"/>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    [SDLVersion(2, 0, 0)]
    public static extern void SDL_ClearError();
}