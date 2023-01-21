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
    ///<summary>Use this function to check if a point resides inside a rectangle.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_PointInRect">SDL2 Documentation</a></remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SDL_PointInRect(SDL_Point p, SDL_Rect r)
    {
        return ( p.X >= r.X ) && ( p.X < ( r.X + r.W ) ) &&
               ( p.Y >= r.Y ) && ( p.Y < ( r.Y + r.H ) );
    }
    ///<summary>Use this function to check whether a rectangle has no area.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RectEmpty">SDL2 Documentation</a></remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SDL_RectEmpty(SDL_Rect r)
    {
        return ( r.W <= 0 || r.H <= 0 );
    }
    ///<summary>Use this function to check whether two rectangles are equal.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_RectEquals">SDL2 Documentation</a></remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SDL_RectEquals(SDL_Rect a, SDL_Rect b)
    {
        return ( a.X == b.X && a.Y == b.Y && a.W == b.W && a.H == b.H );
    }
    ///<summary>Determine whether two rectangles intersect.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasIntersection">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasIntersection(in SDL_Rect a, in SDL_Rect b);
    ///<summary>Calculate the intersection of two rectangles.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_IntersectRect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IntersectRect(in SDL_Rect a, in SDL_Rect b, out SDL_Rect result);
    ///<summary>Calculate the union of two rectangles.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_UnionRect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_UnionRect(in SDL_Rect a, in SDL_Rect b, out SDL_Rect result);
    ///<summary>Calculate a minimal rectangle enclosing a set of points.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_EnclosePoints">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool
            SDL_EnclosePoints(in SDL_Point[] points, int count, in SDL_Rect clip, out SDL_Rect result);
    ///<summary>Calculate the intersection of a rectangle and line segment.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_IntersectRectAndLine">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool
            SDL_IntersectRectAndLine(in SDL_Rect rect, ref int x1, ref int y1, ref int x2, ref int y2);
    ///<summary>Use this function to check if a point resides inside a rectangle.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_PointInFRect">SDL2 Documentation</a></remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SDL_PointInFRect(SDL_FPoint p, SDL_FRect r)
    {
        return ( p.X >= r.X ) && ( p.X < ( r.X + r.W ) ) &&
               ( p.Y >= r.Y ) && ( p.Y < ( r.Y + r.H ) );
    }
    ///<summary>Use this function to check whether a rectangle has no area.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_FRectEmpty">SDL2 Documentation</a></remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SDL_FRectEmpty(SDL_FRect r)
    {
        return ( r.W <= 0.0f || r.H <= 0.0f );
    }
    ///<summary></summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_FRectEqualsEpsilon">SDL2 Documentation</a></remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SDL_FRectEqualsEpsilon(SDL_Rect a, SDL_Rect b, float epsilon)
    {
        return Math.Abs(a.X - b.X) < epsilon &&
               Math.Abs(a.Y - b.Y) < epsilon &&
               Math.Abs(a.W - b.W) < epsilon &&
               Math.Abs(a.H - b.H) < epsilon;
    }
    ///<summary>Use this function to check whether two rectangles are equal.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_FRectEquals">SDL2 Documentation</a></remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool SDL_FRectEquals(SDL_Rect a, SDL_Rect b)
    {
        return SDL_FRectEqualsEpsilon(a, b, float.Epsilon);
    }
    ///<summary>Determine whether two rectangles intersect with float precision.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_HasIntersectionF">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_HasIntersectionF(in SDL_FRect a, in SDL_FRect b);
    ///<summary>Calculate the intersection of two rectangles with float precision.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_IntersectFRect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IntersectFRect(in SDL_FRect a, in SDL_FRect b, out SDL_FRect result);
    ///<summary>Calculate the union of two rectangles with float precision.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_UnionFRect">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void SDL_UnionFRect(in SDL_FRect a, in SDL_FRect b, out SDL_FRect result);
    ///<summary>Calculate a minimal rectangle enclosing a set of points with float precision.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_EncloseFPoints">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_EncloseFPoints([In] SDL_FPoint[] points, int count, in SDL_FRect clip,
            out SDL_FRect result);
    ///<summary>Calculate the intersection of a rectangle and line segment with float precision.</summary>
    ///<remarks><a href="https://wiki.libsdl.org/SDL2/SDL_IntersectFRectAndLine">SDL2 Documentation</a></remarks>
    [DllImport(dllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern bool SDL_IntersectFRectAndLine(in SDL_FRect rect, ref float x1, ref float y1, ref float x2,
            ref float y2);
}
