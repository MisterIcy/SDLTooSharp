using System.Runtime.InteropServices;
#pragma warning disable CS1591
namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Direct3D9GetAdapterIndex")]
    private static extern int _SDL_Direct3D9GetAdapterIndex(int displayIndex);
    ///<summary>Get the D3D9 adapter index that matches the specified display index.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_Direct3D9GetAdapterIndex">SDL2 Documentation</a></remarks>
    public static int SDL_Direct3D9GetAdapterIndex(int displayIndex)
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? _SDL_Direct3D9GetAdapterIndex(displayIndex) : 0;
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetD3D9Device")]
    private static extern IntPtr _SDL_RenderGetD3D9Device(IntPtr renderer);
    ///<summary>Get the D3D9 device associated with a renderer.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderGetD3D9Device">SDL2 Documentation</a></remarks>
    public static IntPtr SDL_RenderGetD3D9Device(IntPtr renderer)
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? _SDL_RenderGetD3D9Device(renderer) : IntPtr.Zero;
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetD3D11Device")]
    private static extern IntPtr _SDL_RenderGetD3D11Device(IntPtr renderer);
    ///<summary>Get the D3D11 device associated with a renderer.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderGetD3D11Device">SDL2 Documentation</a></remarks>
    public static IntPtr SDL_RenderGetD3D11Device(IntPtr renderer)
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? _SDL_RenderGetD3D11Device(renderer) : IntPtr.Zero;
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetD3D12Device")]
    private static extern IntPtr _SDL_RenderGetD3D12Device(IntPtr renderer);
    ///<summary>Get the D3D12 device associated with a renderer.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RenderGetD3D12Device">SDL2 Documentation</a></remarks>
    public static IntPtr SDL_RenderGetD3D12Device(IntPtr renderer)
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? _SDL_RenderGetD3D12Device(renderer) : IntPtr.Zero;
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DXGIGetOutputInfo")]
    private static extern bool _SDL_DXGIGetOutputInfo(int displayIndex, out int adapterIndex, out int outputIndex);
    ///<summary>Get the DXGI Adapter and Output indices for the specified display index.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_DXGIGetOutputInfo">SDL2 Documentation</a></remarks>
    public static bool SDL_DXGIGetOutputInfo(int displayIndex, out int adapterIndex, out int outputIndex)
    {
        adapterIndex = 0;
        outputIndex = 0;

        return RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? _SDL_DXGIGetOutputInfo(displayIndex, out adapterIndex, out outputIndex)
            : false;
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LinuxSetThreadPriority")]
    private static extern int _SDL_LinuxSetThreadPriority(long threadId, int priority);
    ///<summary>Sets the UNIX nice value for a thread.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LinuxSetThreadPriority">SDL2 Documentation</a></remarks>
    public static int SDL_LinuxSetThreadPriority(long threadId, int priority)
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? _SDL_LinuxSetThreadPriority(threadId, priority) : -1;
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "SDL_LinuxSetThreadPriorityAndPolicy")]
    private static extern int _SDL_LinuxSetThreadPriorityAndPolicy(long threadId, int sdlPriority, int schedPriority);
    ///<summary>Sets the priority (not nice level) and scheduling policy for a thread.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_LinuxSetThreadPriorityAndPolicy">SDL2 Documentation</a></remarks>
    public static int SDL_LinuxSetThreadPriorityAndPolicy(long threadId, int sdlPriority, int schedPriority)
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
            ? _SDL_LinuxSetThreadPriorityAndPolicy(threadId, sdlPriority, schedPriority)
            : -1;
    }
    ///<summary>Query if the current device is a tablet.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_IsTablet">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IsTablet();
}
