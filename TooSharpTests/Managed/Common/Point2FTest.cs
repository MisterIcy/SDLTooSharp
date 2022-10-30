using System.Drawing;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using SDLTooSharp.Managed.Common;

namespace TooSharpTests.Managed.Common;

public class Point2FTest
{
    [Fact]
    public void testEqualityOperator()
    {
        Point2F p1 = new Point2F(1.3f, 2.4f);
        Point2F p2 = new Point2F(1.3f, 2.4f);

        Assert.True(p1 == p2);
    }

    [Fact]
    public void testInequalityOperator()
    {
        Point2F p1 = new Point2F(1.34f, 3.14f);
        Point2F p2 = new Point2F(1.34f, 3.14159f);

        Assert.True(p1 != p2);
    }

    [Fact]
    public void testUnaryMinusOperator()
    {
        Point2F p1 = new Point2F(3.14159f, -12.4f);
        Point2F p2 = -p1;

        Assert.Equal(-3.14159f, p2.X);
        Assert.Equal(-12.4f, p2.Y);
    }

    [Fact]
    public void TestUnaryPlusOperator()
    {
        Point2F p1 = new Point2F(3.14159f, -12.4f);
        Point2F p2 = +p1;

        Assert.Equal(3.14159f, p2.X);
        Assert.Equal(12.4f, p2.Y);
    }

    [Fact]
    public void TestAddTwoPoints()
    {
        Point2F p1 = new Point2F(1.3f, 2.2f);
        Point2F p2 = new Point2F(1.4f, 3.9f);

        Point2F p3 = p1 + p2;
        Assert.Equal(1.3f + 1.4f, p3.X);
        Assert.Equal(2.2f + 3.9f, p3.Y);
    }

    [Fact]
    public void TestAddPointAndScalar()
    {
        Point2F p1 = new Point2F(1.3f, 2.2f);
        float v = 3.4f;

        Point2F p2 = p1 + v;
        Assert.Equal(1.3f + 3.4f, p2.X);
        Assert.Equal(2.2f + 3.4f, p2.Y);
    }

    [Fact]
    public void TestAddScalarAndPoint()
    {
        Point2F p1 = new Point2F(1.3f, 2.2f);
        float v = 4.9f;

        Point2F p2 = v + p1;
        Assert.Equal(1.3f + 4.9f, p2.X);
        Assert.Equal(2.2f + 4.9f, p2.Y);
    }

    [Fact]
    public void TestSubtractPointFromPoint()
    {
        Point2F p1 = new Point2F(1.3f, 3.2f);
        Point2F p2 = new Point2F(4.1f, 0.9f);

        Point2F p3 = p1 - p2;
        Point2F p4 = p2 - p1;

        Assert.Equal(1.3f - 4.1f, p3.X);
        Assert.Equal(3.2f - 0.9f, p3.Y);
        Assert.Equal(4.1f - 1.3f, p4.X);
        Assert.Equal(0.9f - 3.2f, p4.Y);
    }

    [Fact]
    public void TestSubtractScalarFromPoint()
    {
        Point2F p1 = new Point2F(2.3f, 4.29f);
        float v = 3.14159f;

        Point2F p2 = p1 - v;
        Assert.Equal(2.3f - 3.14159f, p2.X);
        Assert.Equal(4.29f - 3.14159f, p2.Y);
    }

    [Fact]
    public void TestSubtractPointFromScalar()
    {
        Point2F p1 = new Point2F(2.3f, 4.29f);
        float v = 3.14159f;

        Point2F p2 = v - p1;
        Assert.Equal(3.14159f - 2.3f, p2.X);
        Assert.Equal(3.14159f - 4.29f, p2.Y);
    }

    [Fact]
    public void TestMultiplyPoints()
    {
        Point2F p1 = new Point2F(2.2f, 3.3f);
        Point2F p2 = new Point2F(3.2f, 2.3f);

        Point2F p3 = p1 * p2;
        Assert.Equal(2.2f * 3.2f, p3.X);
        Assert.Equal(3.3f * 2.3f, p3.Y);
    }

    [Fact]
    public void TestMultiplyPointWithScalar()
    {
        Point2F p1 = new Point2F(2.2f, 3.3f);
        float v = 3.14159f;

        Point2F p2 = p1 * v;
        Assert.Equal(2.2f * v, p2.X);
        Assert.Equal(3.3f * v, p2.Y);
    }

    [Fact]
    public void TestMultiplyScalarWithPoint()
    {
        Point2F p1 = new Point2F(2.2f, 3.3f);
        float v = 3.14159f;

        Point2F p2 = v * p1;
        Assert.Equal(v * 2.2f, p2.X);
        Assert.Equal(v * 3.3f, p2.Y);
    }

    [Fact]
    public void TestDividePoints()
    {
        Point2F p1 = new Point2F(2.2f, 3.3f);
        Point2F p2 = new Point2F(3.2f, 2.3f);

        Point2F p3 = p1 / p2;
        Assert.Equal(2.2f / 3.2f, p3.X);
        Assert.Equal(3.3f / 2.3f, p3.Y);
    }

    [Fact]
    public void TestDividePointsWithZero()
    {
        Point2F p1 = new Point2F(2.2f, 3.3f);
        Point2F p2 = new Point2F(3.2f, 0.0f);

        Assert.Throws<DivideByZeroException>(() => {
            Point2F p3 = p1 / p2;
        });
    }

    [Fact]
    public void TestDividePointWithScalar()
    {
        Point2F p1 = new Point2F(2.2f, 3.3f);
        float v = 3.14159f;

        Point2F p2 = p1 / v;
        Assert.Equal(2.2f / v, p2.X);
        Assert.Equal(3.3f / v, p2.Y);
    }

    [Fact]
    public void TestDividePointWithZeroScalar()
    {
        Point2F p1 = new Point2F(2.2f, 3.3f);
        float v = 0;

        Assert.Throws<DivideByZeroException>(() => {
            Point2F pt2 = p1 / v;
        });
    }

    [Fact]
    public void TestDivideScalarWithZeroPoint()
    {
        Point2F p1 = new Point2F(2.2f, 0);
        float v = 3.14159f;

        Assert.Throws<DivideByZeroException>(() => {
            Point2F pt2 = v / p1;
        });
    }

    [Fact]
    public void TestDivideScalarWithPoint()
    {
        Point2F p1 = new Point2F(2.2f, 3.3f);
        float v = 3.14159f;

        Point2F p2 = v / p1;
        Assert.Equal(v / 2.2f, p2.X);
        Assert.Equal(v / 3.3f, p2.Y);
    }
}
