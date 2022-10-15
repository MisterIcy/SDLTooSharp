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

    [Fact(Skip = "Needs to be implemented")]
    public void TestSubtractScalarFromPoint()
    {
    }

    [Fact(Skip = "Needs to be implemented")]
    public void TestSubtractPointFromScalar()
    {
    }

    [Fact(Skip = "Needs to be implemented")]
    public void TestMultiplyPoints()
    {
    }

    [Fact(Skip = "Needs to be implemented")]
    public void TestMultiplyPointWithScalar()
    {
    }

    [Fact(Skip = "Needs to be implemented")]
    public void TestMultiplyScalarWithPoint()
    {
    }

    [Fact(Skip = "Needs to be implemented")]
    public void TestDividePoints()
    {
    }

    [Fact(Skip = "Needs to be implemented")]
    public void TestDividePointsWithZero()
    {
    }

    [Fact(Skip = "Needs to be implemented")]
    public void TestDividePointWithScalar()
    {
    }

    [Fact(Skip = "Needs to be implemented")]
    public void TestDividePointWithZeroScalar()
    {
    }

    [Fact(Skip = "Needs to be implemented")]
    public void TestDivideScalarWithZeroPoint()
    {
    }

    [Fact(Skip = "Needs to be implemented")]
    public void TestDivideScalarWithPoint()
    {
    }
}