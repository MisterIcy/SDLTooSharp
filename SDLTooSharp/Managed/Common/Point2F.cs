using System.Drawing;
using System.Runtime.CompilerServices;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Common;

public class Point2F : IEquatable<Point2F>
{
    public float X { get; set; }
    public float Y { get; set; }

    public Point2F(float x, float y)
    {
        X = x;
        Y = y;
    }

    public Point2F(float v) : this(v, v)
    {
    }

    public Point2F() : this(0)
    {
    }

#region Casting Operators

    public static explicit operator SDL.SDL_FPoint(Point2F pt)
    {
        SDL.SDL_FPoint point = default;
        point.X = pt.X;
        point.Y = pt.Y;

        return point;
    }

    public static implicit operator Point2F(SDL.SDL_FPoint pt)
    {
        return new Point2F(pt.X, pt.Y);
    }

    public static explicit operator PointF(Point2F pt)
    {
        PointF point = default;
        point.X = pt.X;
        point.Y = pt.Y;
        return point;
    }

    public static implicit operator Point2F(PointF pt)
    {
        return new Point2F(pt.X, pt.Y);
    }

    public static explicit operator Point2(Point2F pt)
    {
        return new Point2((int)Math.Round(pt.X), (int)Math.Round(pt.Y));
    }

    public static explicit operator Point2F(Point2 pt)
    {
        return new Point2F(pt.X, pt.Y);
    }

#endregion

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Point2F left, Point2F right)
    {
        return Math.Abs(left.X - right.X) < float.Epsilon &&
               Math.Abs(left.Y - right.Y) < float.Epsilon;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Point2F left, Point2F right)
    {
        return !(left == right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2F operator -(Point2F pt)
    {
        unchecked
        {
            return new Point2F(-1 * Math.Abs(pt.X), -1 * Math.Abs(pt.Y));
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2F operator +(Point2F pt)
    {
        return new Point2F(Math.Abs(pt.X), Math.Abs(pt.Y));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2F operator +(Point2F left, Point2F right)
    {
        unchecked
        {
            return new Point2F(left.X + right.X, left.Y + right.Y);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2F operator +(Point2F left, float right)
    {
        return left + new Point2F(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2F operator +(float left, Point2F right)
    {
        return right + left;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2F operator -(Point2F left, Point2F right)
    {
        return new Point2F(left.X - right.X, left.Y - right.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2F operator -(Point2F left, float right)
    {
        return left - new Point2F(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2F operator -(float left, Point2F right)
    {
        return new Point2F(left) - right;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2F operator *(Point2F left, Point2F right)
    {
        return new Point2F(left.X * right.X, left.Y * right.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2F operator *(Point2F left, float right)
    {
        return left * new Point2F(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2F operator *(float left, Point2F right)
    {
        return right * left;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2F operator /(Point2F left, Point2F right)
    {
        if (right.X == 0 || right.Y == 0)
        {
            throw new DivideByZeroException();
        }

        return new Point2F(left.X / right.X, left.Y / right.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2F operator /(Point2F left, float right)
    {
        return left / new Point2F(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2F operator /(float left, Point2F right)
    {
        return new Point2F(left) / right;
    }


    public bool Equals(Point2F? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return X.Equals(other.X) && Y.Equals(other.Y);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Point2F)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}