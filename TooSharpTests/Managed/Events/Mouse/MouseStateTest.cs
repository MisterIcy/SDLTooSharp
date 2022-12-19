using SDLTooSharp.Managed.Events.Mouse;

namespace TooSharpTests.Managed.Mouse;

public class MouseStateTest
{
    [Fact]
    public void TestAllButtons()
    {
        uint mask = 0x1F;
        var state = new MouseState(mask);

        Assert.True(state.Left);
        Assert.True(state.Middle);
        Assert.True(state.Right);
        Assert.True(state.X1);
        Assert.True(state.X2);
    }

    [Fact]
    public void TestOnlyLeft()
    {
        uint mask = 0b00000001;
        var state = new MouseState(mask);

        Assert.True(state.Left);
        Assert.False(state.Middle);
        Assert.False(state.Right);
        Assert.False(state.X1);
        Assert.False(state.X2);
    }

    [Fact]
    public void TestOnlyMiddle()
    {
        uint mask = 0b00000010;
        var state = new MouseState(mask);

        Assert.False(state.Left);
        Assert.True(state.Middle);
        Assert.False(state.Right);
        Assert.False(state.X1);
        Assert.False(state.X2);
    }

    [Fact]
    public void TestOnlyRight()
    {
        uint mask = 0b00000100;
        var state = new MouseState(mask);

        Assert.False(state.Left);
        Assert.False(state.Middle);
        Assert.True(state.Right);
        Assert.False(state.X1);
        Assert.False(state.X2);
    }

    [Fact]
    public void TestOnlyX1()
    {
        uint mask = 0b00001000;
        var state = new MouseState(mask);

        Assert.False(state.Left);
        Assert.False(state.Middle);
        Assert.False(state.Right);
        Assert.True(state.X1);
        Assert.False(state.X2);
    }

    [Fact]
    public void TestOnlyX2()
    {
        uint mask = 0b00010000;
        var state = new MouseState(mask);

        Assert.False(state.Left);
        Assert.False(state.Middle);
        Assert.False(state.Right);
        Assert.False(state.X1);
        Assert.True(state.X2);
    }
}
