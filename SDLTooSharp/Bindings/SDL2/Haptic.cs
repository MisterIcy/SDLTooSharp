using System.Runtime.InteropServices;
#pragma warning disable CS1591
namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    public const uint SDL_HAPTIC_CONSTANT = ( 1u << 0 );

    public const uint SDL_HAPTIC_SINE = ( 1u << 1 );

    public const uint SDL_HAPTIC_LEFTRIGHT = ( 1u << 2 );

    public const uint SDL_HAPTIC_TRIANGLE = ( 1u << 3 );

    public const uint SDL_HAPTIC_SAWTOOTHUP = ( 1u << 4 );

    public const uint SDL_HAPTIC_SAWTOOTHDOWN = ( 1u << 5 );

    public const uint SDL_HAPTIC_RAMP = ( 1u << 6 );

    public const uint SDL_HAPTIC_SPRING = ( 1u << 7 );

    public const uint SDL_HAPTIC_DAMPER = ( 1u << 8 );

    public const uint SDL_HAPTIC_INERTIA = ( 1u << 9 );

    public const uint SDL_HAPTIC_FRICTION = ( 1u << 10 );

    public const uint SDL_HAPTIC_CUSTOM = ( 1u << 11 );

    public const uint SDL_HAPTIC_GAIN = ( 1u << 12 );

    public const uint SDL_HAPTIC_AUTOCENTER = ( 1u << 13 );

    public const uint SDL_HAPTIC_STATUS = ( 1u << 14 );

    public const uint SDL_HAPTIC_PAUSE = ( 1u << 15 );

    public const int SDL_HAPTIC_POLAR = 0;
    public const int SDL_HAPTIC_CARTESIAN = 1;
    public const int SDL_HAPTIC_SPHERICAL = 2;
    public const int SDL_HAPTIC_STEERING_AXIS = 3;

    public const uint SDL_HAPTIC_INFINITY = 4294967295U;


    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL_HapticDirection
    {
        public byte Type;
        public fixed int Dir[3];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_HapticConstant
    {
        public ushort Type;
        public SDL_HapticDirection Direction;
        public uint Langth;
        public ushort Delay;
        public ushort Button;
        public ushort Interval;
        public short Level;
        public ushort AttackLength;
        public ushort AttackLevel;
        public ushort FadeLength;
        public ushort FadeLevel;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_HapticPeriodic
    {
        public ushort Type;
        public SDL_HapticDirection Direction;
        public uint Length;
        public ushort Delay;
        public ushort Button;
        public ushort Interval;
        public ushort Period;
        public short Magitude;
        public short Offset;
        public ushort Phase;
        public ushort AttackLength;
        public ushort AttackLevel;
        public ushort FadeLength;
        public ushort FadeLevel;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SDL_HapticCondition
    {
        public ushort Type;
        public SDL_HapticDirection Direction;
        public uint Length;
        public ushort Delay;
        public ushort Button;
        public ushort Interval;
        public fixed ushort RightSat[3];
        public fixed ushort LeftSat[3];
        public fixed short RightCoeff[3];
        public fixed short LeftCoeff[3];
        public fixed ushort DeadBand[2];
        public fixed short Center[3];
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_HapticRamp
    {
        public ushort Type;
        public SDL_HapticDirection Direction;
        public uint Length;
        public ushort Delay;
        public ushort Button;
        public ushort Interval;
        public short Start;
        public short End;
        public ushort AttackLength;
        public ushort AttackLevel;
        public ushort FadeLength;
        public ushort FadeLevel;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_HapticLeftRight
    {
        public ushort Type;
        public uint Length;
        public ushort LargeMagnitude;
        public ushort SmallMagnitude;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_HapticCustom
    {
        public ushort Type;
        public SDL_HapticDirection Direction;
        public uint Length;
        public ushort Delay;
        public ushort Button;
        public ushort Interval;
        public byte Channels;
        public ushort Period;
        public ushort Samples;
        public IntPtr Data;
        public ushort AttackLength;
        public ushort AttackLevel;
        public ushort FadeLength;
        public ushort FadeLevel;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct SDL_HapticEffect
    {
        [FieldOffset(0)] public ushort Type;
        [FieldOffset(0)] public SDL_HapticConstant Constant;
        [FieldOffset(0)] public SDL_HapticPeriodic Periodic;
        [FieldOffset(0)] public SDL_HapticCondition Condition;
        [FieldOffset(0)] public SDL_HapticRamp Ramp;
        [FieldOffset(0)] public SDL_HapticLeftRight LeftRight;
        [FieldOffset(0)] public SDL_HapticCustom Custom;
    }

    ///<summary>Count the number of haptic devices attached to the system.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_NumHaptics">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_NumHaptics();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticName")]
    private static extern IntPtr _SDL_HapticName(int deviceName);
    ///<summary>Get the implementation dependent name of a haptic device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticName">SDL2 Documentation</a></remarks>
    public static string SDL_HapticName(int deviceName) => PtrToManaged(_SDL_HapticName(deviceName));
    ///<summary>Open a haptic device for use.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticOpen">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_HapticOpen(int deviceIndex);
    ///<summary>Check if the haptic device at the designated index has been opened.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticOpened">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticOpened(int deviceIndex);
    ///<summary>Get the index of a haptic device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticIndex">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticIndex(IntPtr haptic);
    ///<summary>Query whether or not the current mouse has haptic capabilities.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_MouseIsHaptic">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_MouseIsHaptic();
    ///<summary>Try to open a haptic device from the current mouse.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticOpenFromMouse">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_HapticOpenFromMouse();
    ///<summary>Query if a joystick has haptic features.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_JoystickIsHaptic">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickIsHaptic(IntPtr joystick);
    ///<summary>Open a haptic device for use from a joystick device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticOpenFromJoystick">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_HapticOpenFromJoystick(IntPtr joystick);
    ///<summary>Close a haptic device previously opened with SDL_HapticOpen().</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticClose">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_HapticClose(IntPtr haptic);
    ///<summary>Get the number of effects a haptic device can store.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticNumEffects">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticNumEffects(IntPtr haptic);
    ///<summary>Get the number of effects a haptic device can play at the same time.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticNumEffectsPlaying">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticNumEffectsPlaying(IntPtr haptic);
    ///<summary>Get the haptic device's supported features in bitwise manner.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticQuery">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_HapticQuery(IntPtr haptic);
    ///<summary>Get the number of haptic axes the device has.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticNumAxes">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticNumAxes(IntPtr haptic);
    ///<summary>Check to see if an effect is supported by a haptic device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticEffectSupported">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticEffectSupported(IntPtr haptic, in SDL_HapticEffect effect);
    ///<summary>Create a new haptic effect on a specified device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticNewEffect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticNewEffect(IntPtr haptic, in SDL_HapticEffect effect);
    ///<summary>Update the properties of an effect.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticUpdateEffect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticUpdateEffect(IntPtr haptic, int effect, in SDL_HapticEffect data);
    ///<summary>Run the haptic effect on its associated haptic device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticRunEffect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticRunEffect(IntPtr haptic, int effect, uint iterations);
    ///<summary>Stop the haptic effect on its associated haptic device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticStopEffect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticStopEffect(IntPtr haptic, int effect);
    ///<summary>Destroy a haptic effect on the device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticDestroyEffect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_HapticDestroyEffect(IntPtr haptic, int effect);
    ///<summary>Get the status of the current effect on the specified haptic device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticGetEffectStatus">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticGetEffectStatus(IntPtr haptic, int effect);
    ///<summary>Set the global gain of the specified haptic device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticSetGain">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticSetGain(IntPtr haptic, int gain);
    ///<summary>Set the global autocenter of the device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticSetAutocenter">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticSetAutocenter(IntPtr haptic, int autoCenter);
    ///<summary>Pause a haptic device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticPause">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticPause(IntPtr haptic);
    ///<summary>Unpause a haptic device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticUnpause">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticUnpause(IntPtr haptic);
    ///<summary>Stop all the currently playing effects on a haptic device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticStopAll">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticStopAll(IntPtr haptic);
    ///<summary>Check whether rumble is supported on a haptic device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticRumbleSupported">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticRumbleSupported(IntPtr haptic);
    ///<summary>Initialize a haptic device for simple rumble playback.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticRumbleInit">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticRumbleInit(IntPtr haptic);
    ///<summary>Run a simple rumble effect on a haptic device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticRumblePlay">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticRumblePlay(IntPtr haptic, float strength, uint length);
    ///<summary>Stop the simple rumble on a haptic device.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HapticRumbleStop">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticRumbleStop(IntPtr haptic);
}
