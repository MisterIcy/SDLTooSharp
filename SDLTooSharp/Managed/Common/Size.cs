using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace SDLTooSharp.Managed.Common;

public class Size : IEquatable<Size>
{
    private int _width;

    public int Width
    {
        get => _width;
        set {
            if ( value < 0 )
            {
                throw new ArgumentOutOfRangeException(nameof(value), value,
                    "Width must be greater than or equal to zero");
            }

            _width = value;
        }
    }

    private int _height;

    public int Height
    {
        get => _height;
        set {
            if ( value < 0 )
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    value,
                    "Height must be greater than or equal to zero"
                );
            }

            _height = value;
        }
    }

    public int Area
    {
        get {
            unchecked
            {
                return Width * Height;
            }
        }
    }

    public Size(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public Size(int value) : this(value, value)
    {
    }

    public Size() : this(0)
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(Size left, Size right)
    {
        return left.Width == right.Width && left.Height == right.Height;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Size left, Size right)
    {
        return !( left == right );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Size operator +(Size left, Size right)
    {
        return new Size(left.Width + right.Width, left.Height + right.Height);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Size operator +(Size left, int right)
    {
        return left + new Size(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Size operator +(int left, Size right)
    {
        return right + left;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Size operator -(Size left, Size right)
    {
        return new Size(left.Width - right.Width, left.Height - right.Height);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Size operator -(Size left, int right)
    {
        return left - new Size(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Size operator -(int left, Size right)
    {
        return new Size(left) - right;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Size operator *(Size left, Size right)
    {
        return new Size(left.Width * right.Width, left.Height * right.Height);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Size operator *(Size left, int right)
    {
        return left * new Size(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Size operator *(int left, Size right)
    {
        return right * left;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Size operator /(Size left, Size right)
    {
        if ( right.Width == 0 || right.Height == 0 )
        {
            throw new DivideByZeroException();
        }

        return new Size(left.Width / right.Width, left.Height / right.Height);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Size operator /(Size left, int right)
    {
        return left / new Size(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Size operator /(int left, Size right)
    {
        return new Size(left) / right;
    }

    public bool Equals(Size? other)
    {
        if ( ReferenceEquals(null, other) )
            return false;
        if ( ReferenceEquals(this, other) )
            return true;
        return _width == other._width && _height == other._height;
    }

    public override bool Equals(object? obj)
    {
        if ( ReferenceEquals(null, obj) )
            return false;
        if ( ReferenceEquals(this, obj) )
            return true;
        if ( obj.GetType() != this.GetType() )
            return false;
        return Equals((Size)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_width, _height);
    }
}
