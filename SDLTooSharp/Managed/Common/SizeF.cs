using System.Runtime.CompilerServices;
#pragma warning disable CS1591
namespace SDLTooSharp.Managed.Common;

public class SizeF : IEquatable<SizeF>
{
    private float _width;

    public float Width
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

    private float _height;

    public float Height
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

    public float Area => Width * Height;

    public SizeF(float width, float height)
    {
        Width = width;
        Height = height;
    }

    public SizeF(float value) : this(value, value)
    {
    }

    public SizeF() : this(0)
    {
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(SizeF left, SizeF right)
    {
        return Math.Abs(left.Width - right._width) < float.Epsilon &&
               Math.Abs(left.Height - right.Height) < float.Epsilon;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(SizeF left, SizeF right)
    {
        return !( left == right );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SizeF operator +(SizeF left, SizeF right)
    {
        return new SizeF(left.Width + right.Width, left.Height + right.Height);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SizeF operator +(SizeF left, float right)
    {
        return left + new SizeF(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SizeF operator +(float left, SizeF right)
    {
        return right + left;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SizeF operator -(SizeF left, SizeF right)
    {
        return new SizeF(left.Width - right.Width, left.Height - right.Height);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SizeF operator -(SizeF left, float right)
    {
        return left - new SizeF(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SizeF operator -(float left, SizeF right)
    {
        return new SizeF(left) - right;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SizeF operator *(SizeF left, SizeF right)
    {
        return new SizeF(left.Width * right.Width, left.Height * right.Height);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SizeF operator *(SizeF left, float right)
    {
        return left * new SizeF(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SizeF operator *(float left, SizeF right)
    {
        return right * left;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SizeF operator /(SizeF left, SizeF right)
    {
        if ( right.Width == 0 || right.Height == 0 )
        {
            throw new DivideByZeroException();
        }

        return new SizeF(left.Width / right.Width, left.Height / right.Height);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SizeF operator /(SizeF left, float right)
    {
        return left / new SizeF(right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static SizeF operator /(float left, SizeF right)
    {
        return new SizeF(left) / right;
    }

    public bool Equals(SizeF? other)
    {
        if ( ReferenceEquals(null, other) )
            return false;
        if ( ReferenceEquals(this, other) )
            return true;
        return _width.Equals(other._width) && _height.Equals(other._height);
    }

    public override bool Equals(object? obj)
    {
        if ( ReferenceEquals(null, obj) )
            return false;
        if ( ReferenceEquals(this, obj) )
            return true;
        if ( obj.GetType() != this.GetType() )
            return false;
        return Equals((SizeF)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_width, _height);
    }
}
