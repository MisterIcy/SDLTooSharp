using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Managed.Common;

namespace TooSharpTests.Managed.Common;
[ExcludeFromCodeCoverage]
public class SizeTest
{
    [Fact]
    public void TestCreateSize()
    {
        Size sz = new Size(2, 2);
        Assert.Equal(2, sz.Width);
        Assert.Equal(2, sz.Height);
        Assert.Equal(2 * 2, sz.Area);
    }

    [Fact]
    public void TestCreateSizeWithZeroWidth()
    {
        Size sz = new Size(0, 2);
        Assert.Equal(0, sz.Width);
        Assert.Equal(2, sz.Height);
        Assert.Equal(0, sz.Area);
    }

    [Fact]
    public void TestCreateSizeWithZeroHeight()
    {
        Size sw = new Size(2, 0);
        Assert.Equal(2, sw.Width);
        Assert.Equal(0, sw.Height);
        Assert.Equal(0, sw.Area);
    }

    [Fact]
    public void TestCreateSizeWithNegativeWidth()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => {
            var sz = new Size(-2, 2);
        });
    }

    [Fact]
    public void TestCreateSizeWithNegativeHeight()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => {
            var sz = new Size(2, -2);
        });
    }

    [Fact]
    public void TestSizeEquality()
    {
        Size s1 = new Size(2, 3);
        Size s2 = new Size(2, 3);

        Assert.True(s1 == s2);
    }

    [Fact]
    public void TestInequality()
    {
        Size s1 = new Size(2, 3);
        Size s2 = new Size(3, 2);

        Assert.True(s1 != s2);
    }

    [Fact]
    public void TestAddSizes()
    {
        Size s1 = new Size(2, 3);
        Size s2 = new Size(3, 4);

        Size s3 = s1 + s2;
        Assert.Equal(5, s3.Width);
        Assert.Equal(7, s3.Height);
    }

    [Fact]
    public void TestAddSizeWithPositiveScalar()
    {
        Size s1 = new Size(2, 3);
        int v = 3;

        Size s2 = s1 + v;
        Assert.Equal(5, s2.Width);
        Assert.Equal(6, s2.Height);
    }

    [Fact]
    public void TestAddSizeWithNegativeScalar()
    {
        Size s1 = new Size(2, 3);
        int v = -1;
        Assert.Throws<ArgumentOutOfRangeException>(() => {
            Size s2 = s1 + v;
        });
    }

    [Fact]
    public void TestAddSizeWithNegativeScalarDimensionBelowZero()
    {
        Size s1 = new Size(2, 3);
        int v = -3;

        Assert.Throws<ArgumentOutOfRangeException>(() => {
            Size s2 = s1 + v;
        });
    }

    [Fact]
    public void TestSubtractSizeBySize()
    {
        Size s1 = new Size(3, 4);
        Size s2 = new Size(2, 3);

        Size s3 = s1 - s2;
        Assert.Equal(1, s3.Width);
        Assert.Equal(1, s3.Height);
    }

    [Fact]
    public void TestSubtractSizeBySizeResultInNegativeDimension()
    {
        Size s1 = new Size(3, 4);
        Size s2 = new Size(2, 3);

        Assert.Throws<ArgumentOutOfRangeException>(() => {
            Size s3 = s2 - s1;
        });
    }

    [Fact]
    public void TestSubtractSizeByScalar()
    {
        Size s1 = new Size(2, 3);
        int v = 2;

        Size s2 = s1 - v;
        Assert.Equal(0, s2.Width);
        Assert.Equal(1, s2.Height);
    }

    [Fact]
    public void TestSubtractSizeByNegativeScalar()
    {
        Size s1 = new Size(2, 3);
        int v = -12;

        Assert.Throws<ArgumentOutOfRangeException>(() => {
            Size s2 = s1 - v;
        });
    }

    [Fact]
    public void TestSubtractSizeByScalarResultingInNegativeDimension()
    {
        Size s1 = new Size(4, 1);
        int v = 2;

        Assert.Throws<ArgumentOutOfRangeException>(() => {
            Size s2 = s1 - v;
        });
    }

    [Fact]
    public void TestSubtractScalarBySize()
    {
        Size s1 = new Size(2, 3);
        int v = 12;

        Size s2 = v - s1;
        Assert.Equal(10, s2.Width);
        Assert.Equal(9, s2.Height);
    }

    [Fact]
    public void TestMultiplySizeBySize()
    {
        Size s1 = new Size(2, 2);
        Size s2 = new Size(4, 3);

        Size s3 = s1 * s2;
        Assert.Equal(8, s3.Width);
        Assert.Equal(6, s3.Height);
    }

    [Fact]
    public void TestMultiplySizeByScalar()
    {
        Size s1 = new Size(2, 4);
        int v = 4;

        Size s2 = s1 * v;
        Assert.Equal(8, s2.Width);
        Assert.Equal(16, s2.Height);
    }

    [Fact]
    public void TestMultiplyScalarBySize()
    {
        Size s1 = new Size(2, 4);
        int v = 4;

        Size s2 = v * s1;
        Assert.Equal(8, s2.Width);
        Assert.Equal(16, s2.Height);
    }

    [Fact]
    public void TestDivideSizeBySize()
    {
        Size s1 = new Size(20, 10);
        Size s2 = new Size(4, 2);

        Size s3 = s1 / s2;
        Assert.Equal(5, s3.Width);
        Assert.Equal(5, s3.Height);
    }

    [Fact]
    public void TestDivideSizeBySizeWithZeroDimension()
    {
        Size s1 = new Size(20, 10);
        Size s2 = new Size(4, 0);

        Assert.Throws<DivideByZeroException>(() => {
            Size s3 = s1 / s2;
        });
    }

    [Fact]
    public void TestDivideSizeByScalar()
    {
        Size s1 = new Size(20, 10);
        int v = 2;

        Size s2 = s1 / v;
        Assert.Equal(10, s2.Width);
        Assert.Equal(5, s2.Height);
    }

    [Fact]
    public void TestDivideSizeByScalarZero()
    {
        Size s1 = new Size(20, 10);
        int v = 0;

        Assert.Throws<DivideByZeroException>(() => {
            Size s2 = s1 / v;
        });
    }

    [Fact]
    public void TestDivideScalarBySize()
    {
        Size s1 = new Size(20, 10);
        int v = 100;

        Size s2 = v / s1;
        Assert.Equal(5, s2.Width);
        Assert.Equal(10, s2.Height);
    }

    [Fact]
    public void TestDivideScalarByZeroSize()
    {
        Size s1 = new Size(20, 0);
        int v = 20;

        Assert.Throws<DivideByZeroException>(() => {
            Size s2 = v / s1;
        });
    }
}
