using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    public const uint SDL_HAPTIC_CONSTANT = (1u << 0);

    public const uint SDL_HAPTIC_SINE = (1u << 1);

    public const uint SDL_HAPTIC_LEFTRIGHT = (1u << 2);

    public const uint SDL_HAPTIC_TRIANGLE = (1u << 3);

    public const uint SDL_HAPTIC_SAWTOOTHUP = (1u << 4);

    public const uint SDL_HAPTIC_SAWTOOTHDOWN = (1u << 5);

    public const uint SDL_HAPTIC_RAMP = (1u << 6);

    public const uint SDL_HAPTIC_SPRING = (1u << 7);

    public const uint SDL_HAPTIC_DAMPER = (1u << 8);

    public const uint SDL_HAPTIC_INERTIA = (1u << 9);

    public const uint SDL_HAPTIC_FRICTION = (1u << 10);

    public const uint SDL_HAPTIC_CUSTOM = (1u << 11);

    public const uint SDL_HAPTIC_GAIN = (1u << 12);

    public const uint SDL_HAPTIC_AUTOCENTER = (1u << 13);

    public const uint SDL_HAPTIC_STATUS = (1u << 14);

    public const uint SDL_HAPTIC_PAUSE = (1u << 15);

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

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_NumHaptics();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HapticName")]
    private static extern IntPtr _SDL_HapticName(int deviceName);

    public static string SDL_HapticName(int deviceName) => PtrToManaged(_SDL_HapticName(deviceName));

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_HapticOpen(int deviceIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticOpened(int deviceIndex);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticIndex(IntPtr haptic);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_MouseIsHaptic();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_HapticOpenFromMouse();

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_JoystickIsHaptic(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SDL_HapticOpenFromJoystick(IntPtr joystick);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_HapticClose(IntPtr haptic);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticNumEffects(IntPtr haptic);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticNumEffectsPlaying(IntPtr haptic);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern uint SDL_HapticQuery(IntPtr haptic);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticNumAxes(IntPtr haptic);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticEffectSupported(IntPtr haptic, in SDL_HapticEffect effect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticNewEffect(IntPtr haptic, in SDL_HapticEffect effect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticUpdateEffect(IntPtr haptic, int effect, in SDL_HapticEffect data);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticRunEffect(IntPtr haptic, int effect, uint iterations);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticStopEffect(IntPtr haptic, int effect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_HapticDestroyEffect(IntPtr haptic, int effect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticGetEffectStatus(IntPtr haptic, int effect);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticSetGain(IntPtr haptic, int gain);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticSetAutocenter(IntPtr haptic, int autoCenter);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticPause(IntPtr haptic);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticUnpause(IntPtr haptic);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticStopAll(IntPtr haptic);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticRumbleSupported(IntPtr haptic);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticRumbleInit(IntPtr haptic);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticRumblePlay(IntPtr haptic, float strength, uint length);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern int SDL_HapticRumbleStop(IntPtr haptic);
}