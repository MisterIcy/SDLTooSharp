using System.Diagnostics.CodeAnalysis;
using SDLTooSharp.Managed.Exception.Video.Window;

namespace TooSharpTests.Managed.Exception.Video.Window;
[ExcludeFromCodeCoverage]
public class WindowMaximumSizeExceptionTest
{
    [Fact]
    public void CreateException()
    {
        var ex = new WindowMaximumSizeException();
        Assert.Same("The specified size has at least one dimension greater than the window's maximum size", ex.Message);
    }
}
