using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Direct3D9GetAdapterIndex")]
    private static extern int _SDL_Direct3D9GetAdapterIndex(int displayIndex);

    public static int SDL_Direct3D9GetAdapterIndex(int displayIndex)
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? _SDL_Direct3D9GetAdapterIndex(displayIndex) : 0;
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetD3D9Device")]
    private static extern IntPtr _SDL_RenderGetD3D9Device(IntPtr renderer);

    public static IntPtr SDL_RenderGetD3D9Device(IntPtr renderer)
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? _SDL_RenderGetD3D9Device(renderer) : IntPtr.Zero;
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetD3D11Device")]
    private static extern IntPtr _SDL_RenderGetD3D11Device(IntPtr renderer);

    public static IntPtr SDL_RenderGetD3D11Device(IntPtr renderer)
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? _SDL_RenderGetD3D11Device(renderer) : IntPtr.Zero;
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetD3D12Device")]
    private static extern IntPtr _SDL_RenderGetD3D12Device(IntPtr renderer);

    public static IntPtr SDL_RenderGetD3D12Device(IntPtr renderer)
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? _SDL_RenderGetD3D12Device(renderer) : IntPtr.Zero;
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DXGIGetOutputInfo")]
    private static extern bool _SDL_DXGIGetOutputInfo(int displayIndex, out int adapterIndex, out int outputIndex);

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

    public static int SDL_LinuxSetThreadPriority(long threadId, int priority)
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? _SDL_LinuxSetThreadPriority(threadId, priority) : -1;
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "SDL_LinuxSetThreadPriorityAndPolicy")]
    private static extern int _SDL_LinuxSetThreadPriorityAndPolicy(long threadId, int sdlPriority, int schedPriority);

    public static int SDL_LinuxSetThreadPriorityAndPolicy(long threadId, int sdlPriority, int schedPriority)
    {
        return RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
            ? _SDL_LinuxSetThreadPriorityAndPolicy(threadId, sdlPriority, schedPriority)
            : -1;
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IsTablet();
}
