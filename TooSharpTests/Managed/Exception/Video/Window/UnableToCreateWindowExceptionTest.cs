using SDLTooSharp.Managed.Exception.Video.Window;

namespace TooSharpTests.Managed.Exception.Video.Window;

public class UnableToCreateWindowExceptionTest
{
    [Fact]
    public void CreateException()
    {
        var ex = new UnableToCreateWindowException();
        Assert.Same("Unable to create a window!", ex.Message);
    }
}
