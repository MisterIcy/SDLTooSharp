using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings;

public static partial class SDL2
{
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetBasePath")]
    private static extern IntPtr _SDL_GetBasePath();

    /// <summary>
    /// Get the directory where the application was run from
    /// </summary>
    /// <returns></returns>
    public static string SDL_GetBasePath()
    {
        return Marshaller.CharToManaged(
            _SDL_GetBasePath()
        );
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPrefPath")]
    private static extern unsafe IntPtr _SDL_GetPrefPath(byte* org, byte* app);

    /// <summary>
    /// Get the user-and-app-specific path where files can be written
    /// </summary>
    /// <param name="org"></param>
    /// <param name="app"></param>
    /// <returns></returns>
    public static unsafe string SDL_GetPrefPath(string org, string app)
    {
        var orgLen = Marshaller.GetStringLengthInBytes(org);
        var orgBuf = stackalloc byte[orgLen];
        var appLen = Marshaller.GetStringLengthInBytes(app);
        var appBuf = stackalloc byte[appLen];

        return Marshaller.CharToManaged(
            _SDL_GetPrefPath(
                Marshaller.ManagedToChar(org, orgBuf, orgLen),
                Marshaller.ManagedToChar(app, appBuf, appLen)));
    }
}