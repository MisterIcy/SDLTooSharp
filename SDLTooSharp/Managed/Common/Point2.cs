using System.Drawing;
using System.Runtime.CompilerServices;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Common;

public class Point2 : IEquatable<Point2>
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point2(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point2(int v) : this(v, v)
    {
    }

    public Point2() : this(0)
    {
    }

#region Casting Operators

    public static explicit operator SDL.SDL_Point(Point2 pt)
    {
        SDL.SDL_Point point = default;
        point.X = pt.X;
        point.Y = pt.Y;
        return point;
    }

    public static implicit operator Point2(SDL.SDL_Point pt)
    {
        return new Point2(pt.X, pt.Y);
    }

    public static explicit operator Point(Point2 pt)
    {
        Point point = default;
        point.X = pt.X;
        point.Y = pt.Y;
        return point;
    }

    public static implicit operator Point2(Point pt)
    {
        return new Point2(pt.X, pt.Y);
    }

#endregion

#region Other Operators

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Point2 left, Point2 right)
    {
        return left.X == right.X && left.Y == right.Y;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Point2 left, Point2 right)
    {
        return !(left == right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2 operator -(Point2 pt)
    {
        unchecked
        {
            return new Point2(-1 * Math.Abs(pt.X), -1 * Math.Abs(pt.Y));
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2 operator +(Point2 pt)
    {
        return new Point2(Math.Abs(pt.X), Math.Abs(pt.Y));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2 operator +(Point2 left, Point2 right)
    {
        unchecked
        {
            return new Point2(left.X + right.X, left.Y + right.Y);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2 operator +(Point2 left, int right)
    {
        return left + new Point2(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2 operator +(int left, Point2 right)
    {
        return right + left;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2 operator -(Point2 left, Point2 right)
    {
        unchecked
        {
            return new Point2(left.X - right.X, left.Y - right.Y);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2 operator -(Point2 left, int right)
    {
        return left - new Point2(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2 operator -(int left, Point2 right)
    {
        return new Point2(left) - right;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2 operator *(Point2 left, Point2 right)
    {
        unchecked
        {
            return new Point2(left.X * right.X, left.Y * right.Y);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2 operator *(Point2 left, int right)
    {
        return left * new Point2(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2 operator *(int left, Point2 right)
    {
        return new Point2(left) * right;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2 operator /(Point2 left, Point2 right)
    {
        if (right.X == 0 || right.Y == 0)
        {
            throw new DivideByZeroException();
        }

        return new Point2(left.X / right.X, left.Y / right.Y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2 operator /(Point2 left, int right)
    {
        return left / new Point2(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Point2 operator /(int left, Point2 right)
    {
        return new Point2(left) / right;
    }

#endregion

    public bool Equals(Point2? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Point2)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}