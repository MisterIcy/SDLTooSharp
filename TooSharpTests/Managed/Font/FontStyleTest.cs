using SDLTooSharp.Managed.Font;

namespace TooSharpTests.Managed.Font;

public class FontStyleTest
{
    [Fact]
    public void TestNormalFontStyle()
    {
        var style = new FontStyle();
        Assert.True(style.Normal);
        Assert.False(style.Bold);
        Assert.False(style.Italic);
        Assert.False(style.Underline);
        Assert.False(style.Strikethrough);
        Assert.Equal(0, style.GetIntegerStyle());
    }

    [Fact]
    public void TestBoldFontStyle()
    {
        var style = new FontStyle(isBold: true);
        Assert.True(style.Bold);
        Assert.False(style.Normal);
        Assert.False(style.Italic);
        Assert.False(style.Underline);
        Assert.False(style.Strikethrough);
        Assert.Equal(1, style.GetIntegerStyle());
    }

    [Fact]
    public void TestItalicFontStyle()
    {
        var style = new FontStyle(isItalic: true);
        Assert.True(style.Italic);
        Assert.False(style.Normal);
        Assert.False(style.Bold);
        Assert.False(style.Underline);
        Assert.False(style.Strikethrough);
        Assert.Equal(2, style.GetIntegerStyle());
    }

    [Fact]
    public void TestUnderlineFontTest()
    {
        var style = new FontStyle(isUnderline: true);
        Assert.True(style.Underline);
        Assert.False(style.Normal);
        Assert.False(style.Bold);
        Assert.False(style.Italic);
        Assert.False(style.Strikethrough);
        Assert.Equal(4, style.GetIntegerStyle());
    }

    [Fact]
    public void TestStrikethroughFontStyle()
    {
        var style = new FontStyle(isStrikethrough: true);
        Assert.True(style.Strikethrough);
        Assert.False(style.Normal);
        Assert.False(style.Bold);
        Assert.False(style.Underline);
        Assert.False(style.Italic);
        Assert.Equal(8, style.GetIntegerStyle());
    }

    [Fact]
    public void TestResetToNormal()
    {
        var style = new FontStyle(isBold: true);
        Assert.False(style.Normal);

        style.Normal = true;
        Assert.True(style.Normal);
        Assert.False(style.Bold);
        Assert.False(style.Italic);
        Assert.False(style.Underline);
        Assert.False(style.Strikethrough);
    }

    [Fact]
    public void TestComboStyle()
    {
        var style = new FontStyle(true, true, true, true);
        Assert.False(style.Normal);
        Assert.True(style.Bold);
        Assert.True(style.Italic);
        Assert.True(style.Underline);
        Assert.True(style.Strikethrough);
        Assert.Equal(15, style.GetIntegerStyle());
    }

    [Fact]
    public void TestStyleFromInteger()
    {
        var style = FontStyle.FromIntegerStyle(13);
        Assert.False(style.Normal);
        Assert.True(style.Bold);
        Assert.True(style.Underline);
        Assert.True(style.Strikethrough);
        Assert.False(style.Italic);

    }
}
