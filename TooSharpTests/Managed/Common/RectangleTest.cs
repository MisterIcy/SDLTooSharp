using System.Security.Cryptography;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;

namespace TooSharpTests.Managed.Common;

public class RectangleTest
{
    [Fact]
    public void CreateRectangleWithOriginAndDimensions()
    {
        Point2 origin = new Point2(1, 2);
        Size dimensions = new Size(2, 2);
        Rectangle r = new Rectangle(origin, dimensions);

        Assert.Equal(origin.X, r.X);
        Assert.Equal(origin.X, r.Left);
        Assert.Equal(origin.Y, r.Y);
        Assert.Equal(origin.Y, r.Top);
        Assert.Equal(dimensions.Width, r.Width);
        Assert.Equal(dimensions.Height, r.Height);
        Assert.Equal(dimensions.Area, r.Area);
        Assert.Equal(origin.X + dimensions.Width, r.Right);
        Assert.Equal(origin.Y + dimensions.Height, r.Bottom);
    }

    [Fact]
    public void CreateRectangleWithCoordinatesAndIntegerDimensions()
    {
        Rectangle r = new Rectangle(1, 2, 2, 2);

        Assert.Equal(1, r.X);
        Assert.Equal(2, r.Y);
        Assert.Equal(2, r.Width);
        Assert.Equal(2, r.Height);
        Assert.Equal(4, r.Area);
        Assert.Equal(3, r.Right);
        Assert.Equal(4, r.Bottom);
    }

    [Fact]
    public void CreateEmptyRectangle()
    {
        Rectangle r = new Rectangle();

        Assert.Equal(0, r.X);
        Assert.Equal(0, r.Y);
        Assert.Equal(0, r.Width);
        Assert.Equal(0, r.Height);
        Assert.Equal(0, r.Area);
        Assert.True(r.IsEmpty);
    }

    [Fact]
    public void TestCastSDLRectToRectangle()
    {
        SDL.SDL_Rect rect = default;
        rect.X = 2;
        rect.Y = 3;
        rect.W = 10;
        rect.H = 20;

        Rectangle cvt = rect;
        Assert.Equal(rect.X, cvt.X);
        Assert.Equal(rect.Y, cvt.Y);
        Assert.Equal(rect.W, cvt.Width);
        Assert.Equal(rect.H, cvt.Height);
    }

    [Fact]
    public void TestCastRectangleToSDLRect()
    {
        Rectangle rect = new Rectangle(2, 3, 10, 20);
        SDL.SDL_Rect cvt = (SDL.SDL_Rect)rect;

        Assert.Equal(rect.X, cvt.X);
        Assert.Equal(rect.Y, cvt.Y);
        Assert.Equal(rect.Width, cvt.W);
        Assert.Equal(rect.Height, cvt.H);
    }

    [Fact]
    public void TestCastSystemRectToRectangle()
    {
        System.Drawing.Rectangle rect = default;
        rect.X = 2;
        rect.Y = 3;
        rect.Width = 10;
        rect.Height = 20;

        Rectangle cvt = rect;
        Assert.Equal(rect.X, cvt.X);
        Assert.Equal(rect.Y, cvt.Y);
        Assert.Equal(rect.Width, cvt.Width);
        Assert.Equal(rect.Height, cvt.Height);
    }

    [Fact]
    public void TestCastRectangleToSystemRectangle()
    {
        Rectangle rect = new Rectangle(2, 3, 10, 20);
        System.Drawing.Rectangle cvt = (System.Drawing.Rectangle)rect;

        Assert.Equal(rect.X, cvt.X);
        Assert.Equal(rect.Y, cvt.Y);
        Assert.Equal(rect.Width, cvt.Width);
        Assert.Equal(rect.Height, cvt.Height);
    }

    [Fact]
    public void TestEqualityOperator()
    {
        Rectangle r1 = new Rectangle(1, 2, 3, 4);
        Rectangle r2 = new Rectangle(
            new Point2(1, 2),
            new Size(3, 4));

        Assert.True(r1 == r2);
    }

    [Fact]
    public void TestInequalityOperator()
    {
        Rectangle r1 = new Rectangle(1, 2, 3, 4);
        Rectangle r2 = new Rectangle(
            new Point2(4, 5),
            new Size(5, 6)
        );

        Assert.True(r1 != r2);
    }

    [Fact]
    public void TestContainsPoint()
    {
        Rectangle rect = new Rectangle(1, 1, 4, 4);
        Point2 pt = new Point2(3, 3);

        Assert.True(rect.ContainsPoint(pt));
    }

    [Fact]
    public void TestDoesNotContainPoint()
    {
        Rectangle rect = new Rectangle(1, 1, 4, 4);
        Point2 pt = new Point2(0, 0);

        Assert.False(rect.ContainsPoint(pt));
    }

    [Fact]
    public void TestRectangleContainsRectangle()
    {
        Rectangle r1 = new Rectangle(10, 10, 20, 20);
        Rectangle r2 = new Rectangle(12, 12, 4, 4);

        Assert.True(r1.ContainsRectangle(r2));
    }

    [Fact]
    public void TestRectangleDoesNotContainRectangleDueToIntersect()
    {
        Rectangle r1 = new Rectangle(10, 10, 20, 20);
        Rectangle r2 = new Rectangle(12, 12, 40, 40);

        Assert.False(r1.ContainsRectangle(r2));
    }

    [Fact]
    public void TestIntersectingRectangles()
    {
        Rectangle r1 = new Rectangle(10, 10, 10, 10);
        Rectangle r2 = new Rectangle(5, 5, 10, 50);

        Assert.True(r1.IntersectsWith(r2));
        Assert.True(Rectangle.Intersects(r1, r2));
    }

    [Fact]
    public void TestNonIntersectingRectangles()
    {
        Rectangle r1 = new Rectangle(10, 10, 10, 10);
        Rectangle r2 = new Rectangle(40, 40, 5, 5);

        Assert.False(r1.IntersectsWith(r2));
        Assert.False(Rectangle.Intersects(r1, r2));
    }

    [Fact]
    public void TestIntersectWithEmptyRectangle()
    {
        Rectangle r1 = new Rectangle(10, 10, 10, 10);
        Rectangle r2 = new Rectangle(0, 0, 0, 0);

        Assert.False(r1.IntersectsWith(r2));
        Assert.False(Rectangle.Intersects(r1, r2));
    }

    [Fact]
    public void TestNotEqualRectangles()
    {
        Rectangle r1 = new Rectangle(10, 10, 10, 10);
        Rectangle r2 = new Rectangle(0, 0, 0, 0);
        
        Assert.False(r1.Equals(r2));
    }

    [Fact]
    public void TestEqualRectangles()
    {
        Rectangle r1 = new Rectangle(10, 10, 10, 10);
        Rectangle r2 = new Rectangle(10, 10, 10, 10);
        
        Assert.True(r1.Equals(r2));
    }

    [Fact]
    public void TestIntersectionRectangleForIntersectingRects()
    {
        Rectangle r1 = new Rectangle(10, 10, 10, 10);
        Rectangle r2 = new Rectangle(18, 18, 20, 20);

        Rectangle intersection = new Rectangle(18, 18, 2, 2);
        
        Assert.Equal(intersection, r1.Intersection(r2));
    }

    [Fact]
    public void TestIntersectionRectangleForNonIntersectingRects()
    {
        Rectangle r1 = new Rectangle(10, 10, 10, 10);
        Rectangle r2 = new Rectangle(0, 0, 2, 3);

        Rectangle intersection = new Rectangle(0, 0, 0, 0);
        
        Assert.Equal(intersection, r1.Intersection(r2));
    }

    [Fact]
    public void TestOffset()
    {
        Rectangle r1 = new Rectangle(5, 2, 2, 2);
        Point2 pt = new Point2(3, 7);
        
        r1.Offset(pt);
        
        Assert.Equal(8, r1.Origin.X);
        Assert.Equal(9, r1.Origin.Y);
    }

    [Fact]
    public void TestInflate()
    {
        Rectangle r1 = new Rectangle(10, 10, 10, 10);
        Size sz = new Size(4, 4);

        Rectangle inflated = r1.Inflate(sz);
        
        Assert.Equal(8, inflated.X);
        Assert.Equal(8, inflated.Y);
        Assert.Equal(14, inflated.Width);
        Assert.Equal(14, inflated.Height);
    }

    [Fact]
    public void TestFromLTRB()
    {
        Rectangle r1 = Rectangle.FromLTRB(10, 10, 20, 20);
        Assert.Equal(10, r1.Left);
        Assert.Equal(10, r1.Top);
        Assert.Equal(10, r1.Width);
        Assert.Equal(10, r1.Height);
    }

    [Fact]
    public void TestUnionRectangle()
    {
        Rectangle r1 = new Rectangle(2, 3, 10, 12);
        Rectangle r2 = new Rectangle(5, 1, 21, 8);

        Rectangle union = r1.Union(r2);
        
        Assert.Equal(2, union.Left);
        Assert.Equal(1, union.Top);
        Assert.Equal(26, union.Right);
        Assert.Equal(15, union.Bottom);
    }
}