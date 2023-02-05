using SDLTooSharp.Managed.Exception.Video.Window;

namespace TooSharpTests.Managed.Exception.Video.Window;

public class WindowMinimumSizeExceptionTest
{
    [Fact]
    public void CreateException()
    {
        var ex = new WindowMinimumSizeException();
        Assert.Same("The specified size has at least one dimension lower than the window's minimum size", ex.Message);
    }
}
