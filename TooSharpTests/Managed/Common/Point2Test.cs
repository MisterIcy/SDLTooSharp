using System.Drawing;
using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;

namespace TooSharpTests.Managed.Common;

public class Point2Test
{
    [Fact]
    public void TestUnaryPlus()
    {
        var point = new Point2(-1, -2);
        var test = +point;

        Assert.Equal(1, test.X);
        Assert.Equal(2, test.Y);
    }

    [Fact]
    public void TestUnaryMinus()
    {
        var pt = new Point2(42, -12);
        var test = -pt;

        Assert.Equal(-42, test.X);
        Assert.Equal(-12, test.Y);
    }

    [Fact]
    public void TestEqualPoints()
    {
        var pt1 = new Point2(10, 10);
        var pt2 = new Point2(5, 5);
        pt2 += 5;

        Assert.True(pt1 == pt2);
    }

    [Fact]
    public void TestUnequalPoints()
    {
        var pt1 = new Point2(2);
        var pt2 = new Point2(3);

        Assert.True(pt1 != pt2);
    }

    [Fact]
    public void TestAddPoints()
    {
        var pt1 = new Point2(3, 4);
        var pt2 = new Point2(4, 5);

        var testPoint = new Point2(3 + 4, 4 + 5);
        Assert.Equal(testPoint, ( pt1 + pt2 ));
    }

    [Fact]
    public void TestAddPointWithInt()
    {
        var pt1 = new Point2(3, 4);
        var testPoint = new Point2(3 + 5, 4 + 5);

        Assert.Equal(testPoint, ( pt1 + 5 ));
    }

    [Fact]
    public void TestAddIntWithPoint()
    {
        var pt1 = new Point2(3, 4);
        var testPoint = new Point2(3 + 8, 4 + 8);

        Assert.Equal(testPoint, ( 8 + pt1 ));
    }

    [Fact]
    public void TestSubtractPoints()
    {
        var pt1 = new Point2(3);
        var pt2 = new Point2(2);

        var testPoint = new Point2(3 - 2);
        Assert.Equal(testPoint, ( pt1 - pt2 ));
    }

    [Fact]
    public void TestSubtractIntFromPoint()
    {
        var pt1 = new Point2(4, 5);

        var testPoint = new Point2(4 - 4, 5 - 4);
        Assert.Equal(testPoint, ( pt1 - 4 ));
    }

    [Fact]
    public void TestSubtractPointFromInt()
    {
        var pt1 = new Point2(8, 5);

        var testPoint = new Point2(3 - 8, 3 - 5);
        Assert.Equal(testPoint, ( 3 - pt1 ));
    }

    [Fact]
    public void TestCastSDLPointToPoint2()
    {
        SDL.SDL_Point pt = default;
        pt.X = 2;
        pt.Y = 3;

        var point = (Point2)pt;
        Assert.Equal(2, point.X);
        Assert.Equal(3, point.Y);
    }

    [Fact]
    public void TestCastPoint2ToSDLPoint()
    {
        var pt = new Point2(3, 6);
        var sdlPoint = (SDL.SDL_Point)pt;

        Assert.Equal(3, sdlPoint.X);
        Assert.Equal(6, sdlPoint.Y);
    }

    [Fact]
    public void TestCastSystemPointToPoint2()
    {
        Point pt = default;
        pt.X = 2;
        pt.Y = 3;

        var point = (Point2)pt;
        Assert.Equal(2, point.X);
        Assert.Equal(3, point.Y);
    }

    [Fact]
    public void TestCastPoint2ToSystemPoint()
    {
        var pt = new Point2(3, 6);
        var sdlPoint = (Point)pt;

        Assert.Equal(3, sdlPoint.X);
        Assert.Equal(6, sdlPoint.Y);
    }

    [Fact]
    public void TestMultiplyPoints()
    {
        var pt1 = new Point2(3, 4);
        var pt2 = new Point2(4, 5);

        var testPoint = new Point2(3 * 4, 4 * 5);
        Assert.Equal(testPoint, ( pt1 * pt2 ));
    }

    [Fact]
    public void TestMultiplyPointWithInt()
    {
        var pt1 = new Point2(3, 4);
        var testPoint = new Point2(3 * 9, 4 * 9);

        Assert.Equal(testPoint, ( pt1 * 9 ));
    }

    [Fact]
    public void TestMultiplyIntWithPoint()
    {
        var pt1 = new Point2(3, 4);
        var testPoint = new Point2(3 * 3, 3 * 4);

        Assert.Equal(testPoint, ( 3 * pt1 ));
    }

    [Fact]
    public void TestDivideByPoint()
    {
        var pt1 = new Point2(20, 10);
        var pt2 = new Point2(4, 2);

        var testPoint = new Point2(5, 5);

        Assert.Equal(testPoint, ( pt1 / pt2 ));
    }

    [Fact]
    public void TestDividePointByInt()
    {
        var pt1 = new Point2(20, 10);

        var testPoint = new Point2(10, 5);

        Assert.Equal(testPoint, ( pt1 / 2 ));
    }

    [Fact]
    public void TestDividePointByZeroInt()
    {
        var pt1 = new Point2(10, 20);
        Assert.Throws<DivideByZeroException>(() => {
            var result = pt1 / 0;
        });
    }

    [Fact]
    public void TestDivideByZeroPoint()
    {
        var pt1 = new Point2(3);
        var pt2 = new Point2();

        Assert.Throws<DivideByZeroException>(() => {
            var result = pt1 / pt2;
        });
    }

    [Fact]
    public void TestDivideIntByPoint()
    {
        var pt1 = new Point2(5, 10);

        var testPoint = new Point2(20, 10);
        Assert.Equal(testPoint, ( 100 / pt1 ));

    }
}
