using SDLTooSharp.Managed.Common;

namespace TooSharpTests.Managed.Common;

public class SizeFTest
{
    [Fact]
    public void TestCreateSize()
    {
        SizeF s1 = new SizeF(1.2f, 2.2f);
        Assert.Equal(1.2f, s1.Width);
        Assert.Equal(2.2f, s1.Height);
        Assert.Equal(1.2f * 2.2f, s1.Area);
    }

    [Fact]
    public void TestCreateSizeWithZeroWidth()
    {
        SizeF s1 = new SizeF(0.0f, 2.2f);
        Assert.Equal(0.0f, s1.Width);
        Assert.Equal(2.2f, s1.Height);
        Assert.Equal(0, s1.Area);
    }

    [Fact]
    public void TestCreateSizeWithZeroHeight()
    {
        SizeF s1 = new SizeF(1.2f, 0.0f);
        Assert.Equal(1.2f, s1.Width);
        Assert.Equal(0.0f, s1.Height);
        Assert.Equal(0, s1.Area);
    }

    [Fact]
    public void TestCreateSizeWithEpsilonWidth()
    {
        SizeF s1 = new SizeF(float.Epsilon, 2.2f);
        Assert.Equal(float.Epsilon, s1.Width);
        Assert.Equal(2.2f, s1.Height);
        Assert.Equal(float.Epsilon * 2.2f, s1.Area);
    }

    [Fact]
    public void TestCreateSizeWithEpsilonHeight()
    {
        SizeF s1 = new SizeF(1.2f, float.Epsilon);
        Assert.Equal(1.2f, s1.Width);
        Assert.Equal(float.Epsilon, s1.Height);
        Assert.Equal(float.Epsilon * 1.2f, s1.Area);
    }

    [Fact]
    public void TestCreateSizeWithNegativeWidth()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => { new SizeF(-1.2f, 1.2f); }
        );
    }

    [Fact]
    public void TestCreateSizeWIthNegativeHeight()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => { new SizeF(1.2f, -1.2f); });
    }

    [Fact]
    public void TestEquality()
    {
        SizeF s1 = new SizeF(1.34f, 3.29f);
        SizeF s2 = new SizeF(1.34f, 3.29f);

        Assert.True(s1 == s2);
    }

    [Fact]
    public void TestInequality()
    {
        SizeF s1 = new SizeF(1.34f, 3.29f);
        SizeF s2 = new SizeF(1.34f, 3.23f);

        Assert.True(s1 != s2);
    }

    [Fact]
    public void TestAddSizeWithSize()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        SizeF s2 = new SizeF(1.3f, 1.9f);

        SizeF s3 = s1 + s2;

        Assert.Equal(s1.Width + s2.Width, s3.Width);
        Assert.Equal(s1.Height + s2.Height, s3.Height);
    }

    [Fact]
    public void TestAddSizeWithScalar()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        float v = 1.9f;

        SizeF s3 = s1 + v;

        Assert.Equal(s1.Width + v, s3.Width);
        Assert.Equal(s1.Height + v, s3.Height);
    }

    [Fact]
    public void TestAddSizeWithNegativeScalar()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        float v = -1.9f;
        Assert.Throws<ArgumentOutOfRangeException>(() => {
            SizeF s3 = s1 + v;
        });
    }

    [Fact]
    public void TestAddScalarWithSize()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        float v = 1.9f;

        SizeF s3 = v + s1;

        Assert.Equal(s1.Width + v, s3.Width);
        Assert.Equal(s1.Height + v, s3.Height);
    }

    [Fact]
    public void TestAddNegativeScalarWithSize()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        float v = -1.9f;

        Assert.Throws<ArgumentOutOfRangeException>(() => {
            SizeF s3 = v + s1;
        });
    }

    [Fact]
    public void TestSubtractSizeFromSize()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        SizeF s2 = new SizeF(1.3f, 1.9f);

        SizeF s3 = s1 - s2;

        Assert.Equal(s1.Width - s2.Width, s3.Width);
        Assert.Equal(s1.Height - s2.Height, s3.Height);
    }

    [Fact]
    public void TestSubtractScalarFromSize()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        float v = 1.9f;

        SizeF s3 = s1 - v;

        Assert.Equal(s1.Width - v, s3.Width);
        Assert.Equal(s1.Height - v, s3.Height);
    }

    [Fact]
    public void TestSubtractNegativeScalarFromSize()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        float v = -1.9f;
        Assert.Throws<ArgumentOutOfRangeException>(() => {
            SizeF s3 = s1 - v;
        });
    }

    [Fact]
    public void TestSubtractScalarFromSizeResultingInNegativeDimension()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        float v = 2.3f;
        Assert.Throws<ArgumentOutOfRangeException>(() => {
            SizeF s3 = s1 - v;
        });
    }

    [Fact]
    public void TestSubtractSizeFromScalar()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        float v = 8.9f;

        SizeF s3 = v - s1;

        Assert.Equal(v - s1.Width, s3.Width);
        Assert.Equal(v - s1.Height, s3.Height);
    }

    [Fact]
    public void TestSubtractSizeFromNegativeScalar()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        float v = -8.9f;
        Assert.Throws<ArgumentOutOfRangeException>(() => {
            SizeF s3 = v - s1;
        });
    }

    [Fact]
    public void TestSubtractSizeFromScalarResultingInNegativeDimension()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        float v = 1.9f;
        Assert.Throws<ArgumentOutOfRangeException>(() => {
            SizeF s3 = v - s1;
        });
    }

    [Fact]
    public void TestMultiplySizeBySize()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        SizeF s2 = new SizeF(1.3f, 1.9f);

        SizeF s3 = s1 * s2;

        Assert.Equal(s1.Width * s2.Width, s3.Width);
        Assert.Equal(s1.Height * s2.Height, s3.Height);
    }

    [Fact]
    public void TestMultiplySizeByScalar()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        float v = 2.3f;

        SizeF s3 = s1 * v;

        Assert.Equal(s1.Width * v, s3.Width);
        Assert.Equal(s1.Height * v, s3.Height);
    }

    [Fact]
    public void TestMultiplyScalarBySize()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        float v = 2.3f;

        SizeF s3 = v * s1;

        Assert.Equal(s1.Width * v, s3.Width);
        Assert.Equal(s1.Height * v, s3.Height);
    }

    [Fact]
    public void TestDivideSizeBySize()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        SizeF s2 = new SizeF(1.3f, 1.9f);

        SizeF s3 = s1 / s2;

        Assert.Equal(s1.Width / s2.Width, s3.Width);
        Assert.Equal(s1.Height / s2.Height, s3.Height);
    }

    [Fact]
    public void TestDivideSizeBySizeWithZeroDimension()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        SizeF s2 = new SizeF(1.3f, 0.0f);

        Assert.Throws<DivideByZeroException>(() => {
            SizeF s3 = s1 / s2;
        });
    }

    [Fact]
    public void TestDivideSizeByScalar()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        float v = 3.49f;

        SizeF s3 = s1 / v;

        Assert.Equal(s1.Width / v, s3.Width);
        Assert.Equal(s1.Height / v, s3.Height);
    }

    [Fact]
    public void TestDivideSizeByZero()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        SizeF s2 = new SizeF(1.3f, 0.0f);

        Assert.Throws<DivideByZeroException>(() => {
            SizeF s3 = s1 / 0;
        });
    }

    [Fact]
    public void TestDivideScalarBySize()
    {
        SizeF s1 = new SizeF(2.2f, 3.3f);
        float v = 3.49f;

        SizeF s3 = v / s1;

        Assert.Equal(v / s1.Width, s3.Width);
        Assert.Equal(v / s1.Height, s3.Height);
    }

    [Fact]
    public void TestDivideScalarBySizeWithZeroDimensions()
    {
        SizeF s1 = new SizeF(2.2f, 0.0f);


        Assert.Throws<DivideByZeroException>(() => {
            SizeF s3 = 4.92f / s1;
        });
    }
}
