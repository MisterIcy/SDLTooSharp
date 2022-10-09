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
}