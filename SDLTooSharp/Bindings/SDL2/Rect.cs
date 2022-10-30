using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SDLTooSharp.Bindings.SDL2;

public static partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_Point
    {
        public int X;
        public int Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_FPoint
    {
        public float X;
        public float Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_Rect
    {
        public int X;
        public int Y;
        public int W;
        public int H;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SDL_FRect
    {
        public float X;
        public float Y;
        public float W;
        public float H;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SDL_PointInRect(SDL_Point p, SDL_Rect r)
    {
        return ( p.X >= r.X ) && ( p.X < ( r.X + r.W ) ) &&
               ( p.Y >= r.Y ) && ( p.Y < ( r.Y + r.H ) );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SDL_RectEmpty(SDL_Rect r)
    {
        return ( r.W <= 0 || r.H <= 0 );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SDL_RectEquals(SDL_Rect a, SDL_Rect b)
    {
        return ( a.X == b.X && a.Y == b.Y && a.W == b.W && a.H == b.H );
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasIntersection(in SDL_Rect a, in SDL_Rect b);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IntersectRect(in SDL_Rect a, in SDL_Rect b, out SDL_Rect result);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_UnionRect(in SDL_Rect a, in SDL_Rect b, out SDL_Rect result);
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool
        SDL_EnclosePoints(in SDL_Point[] points, int count, in SDL_Rect clip, out SDL_Rect result);
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool
        SDL_IntersectRectAndLine(in SDL_Rect rect, ref int x1, ref int y1, ref int x2, ref int y2);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SDL_PointInFRect(SDL_FPoint p, SDL_FRect r)
    {
        return ( p.X >= r.X ) && ( p.X < ( r.X + r.W ) ) &&
               ( p.Y >= r.Y ) && ( p.Y < ( r.Y + r.H ) );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SDL_FRectEmpty(SDL_FRect r)
    {
        return ( r.W <= 0.0f || r.H <= 0.0f );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SDL_FRectEqualsEpsilon(SDL_Rect a, SDL_Rect b, float epsilon)
    {
        return Math.Abs(a.X - b.X) < epsilon &&
               Math.Abs(a.Y - b.Y) < epsilon &&
               Math.Abs(a.W - b.W) < epsilon &&
               Math.Abs(a.H - b.H) < epsilon;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SDL_FRectEquals(SDL_Rect a, SDL_Rect b)
    {
        return SDL_FRectEqualsEpsilon(a, b, float.Epsilon);
    }

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasIntersectionF(in SDL_FRect a, in SDL_FRect b);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IntersectFRect(in SDL_FRect a, in SDL_FRect b, out SDL_FRect result);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_UnionFRect(in SDL_FRect a, in SDL_FRect b, out SDL_FRect result);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_EncloseFPoints([In] SDL_FPoint[] points, int count, in SDL_FRect clip,
        out SDL_FRect result);

    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IntersectFRectAndLine(in SDL_FRect rect, ref float x1, ref float y1, ref float x2,
        ref float y2);
}
