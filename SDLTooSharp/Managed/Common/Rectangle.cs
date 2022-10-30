using System.Drawing;
using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Common;

/// <summary>
/// Represents a Rectangle
/// </summary>
public class Rectangle : IEquatable<Rectangle>
{
    private Point2 _origin;

    public Point2 Origin
    {
        get => _origin;
        set => _origin = value;
    }

    private Size _dimensions;

    public Size Dimensions
    {
        get => _dimensions;
        set => _dimensions = value;
    }

    public int Area => Dimensions.Area;

    public int X => Origin.X;
    public int Y => Origin.Y;
    public int Width => Dimensions.Width;
    public int Height => Dimensions.Height;

    public bool IsEmpty => Width == 0 || Height == 0;

    public int Left => Origin.X;
    public int Top => Origin.Y;
    public int Right => Origin.X + Dimensions.Width;
    public int Bottom => Origin.Y + Dimensions.Height;

    public Rectangle(Point2 origin, Size dimensions)
    {
        Origin = origin;
        Dimensions = dimensions;
    }

    public Rectangle(int x, int y, int width, int height) : this(new Point2(x, y), new Size(width, height))
    {
    }

    public Rectangle() : this(0, 0, 0, 0)
    {
    }

    public static Rectangle FromLTRB(int left, int top, int right, int bottom)
    {
        return new Rectangle(left, top, right - left, bottom - top);
    }

    #region Casting Operators

    public static explicit operator SDL.SDL_Rect(Rectangle r)
    {
        SDL.SDL_Rect rect = new SDL.SDL_Rect() {
            X = r.X,
            Y = r.Y,
            W = r.Width,
            H = r.Height
        };
        return rect;
    }

    public static implicit operator Rectangle(SDL.SDL_Rect r)
    {
        return new Rectangle(r.X, r.Y, r.W, r.H);
    }

    public static explicit operator System.Drawing.Rectangle(Rectangle r)
    {
        System.Drawing.Rectangle rect = new System.Drawing.Rectangle() {
            X = r.X,
            Y = r.Y,
            Width = r.Width,
            Height = r.Height
        };

        return rect;
    }

    public static implicit operator Rectangle(System.Drawing.Rectangle r)
    {
        return new Rectangle(r.X, r.Y, r.Width, r.Height);
    }

    #endregion

    public static bool operator ==(Rectangle left, Rectangle right)
    {
        return left.X == right.X &&
               left.Y == right.Y &&
               left.Width == right.Width &&
               left.Height == right.Height;
    }

    public static bool operator !=(Rectangle left, Rectangle right)
    {
        return !( left == right );
    }

    public bool ContainsPoint(Point2 pt)
    {
        return pt.X >= Left && pt.X <= Right &&
               pt.Y >= Top && pt.Y <= Bottom;
    }

    public bool ContainsRectangle(Rectangle other)
    {
        bool v1 = ContainsPoint(other.Origin);
        bool v2 =
            ContainsPoint(other.Origin + new Point2(other.Width, other.Height));

        return v1 && v2;
    }

    public static bool Intersects(Rectangle r1, Rectangle r2)
    {
        return r1.IntersectsWith(r2);
    }

    public bool IntersectsWith(Rectangle other)
    {
        if ( IsEmpty || other.IsEmpty )
        {
            return false;
        }


        return Math.Max(Left, other.Left) < Math.Min(Right, other.Right) &&
               Math.Max(Top, other.Top) < Math.Min(Bottom, other.Bottom);
    }

    public Rectangle Intersection(Rectangle other)
    {
        if ( !IntersectsWith(other) )
        {
            return new Rectangle();
        }

        int left = Math.Max(Left, other.Left);
        int right = Math.Min(Right, other.Right);
        int top = Math.Max(Top, other.Top);
        int bottom = Math.Min(Bottom, other.Bottom);

        return new Rectangle(left, top, right - left, bottom - top);
    }

    public Rectangle Union(Rectangle other)
    {
        var left = Math.Min(Left, other.Left);
        var top = Math.Min(Top, other.Top);
        var right = Math.Max(Right, other.Right);
        var bottom = Math.Max(Bottom, other.Bottom);

        return Rectangle.FromLTRB(left, top, right, bottom);
    }

    public void Offset(Point2 offset)
    {
        Origin += offset;
    }

    public Rectangle Inflate(Size size)
    {
        return new Rectangle(
            X - ( size.Width / 2 ),
            Y - ( size.Height / 2 ),
            Width + size.Width,
            Height + size.Height
        );
    }

    public bool Equals(Rectangle? other)
    {
        if ( ReferenceEquals(null, other) )
            return false;
        if ( ReferenceEquals(this, other) )
            return true;
        return _origin.Equals(other._origin) && _dimensions.Equals(other._dimensions);
    }

    public override bool Equals(object? obj)
    {
        if ( ReferenceEquals(null, obj) )
            return false;
        if ( ReferenceEquals(this, obj) )
            return true;
        if ( obj.GetType() != this.GetType() )
            return false;
        return Equals((Rectangle)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_origin, _dimensions);
    }
}
