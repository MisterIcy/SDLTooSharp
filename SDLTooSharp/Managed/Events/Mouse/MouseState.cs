using SDLTooSharp.Bindings.SDL2;

namespace SDLTooSharp.Managed.Events.Mouse;

public class MouseState
{
    public bool Left
    {
        get;
    }

    public bool Middle
    {
        get;
    }

    public bool Right
    {
        get;
    }

    public bool X1
    {
        get;
    }

    public bool X2
    {
        get;
    }

    public MouseState(uint mask)
    {
        Left = ( mask & SDL.SDL_BUTTON_LMASK ) != 0;
        Middle = ( mask & SDL.SDL_BUTTON_MMASK ) != 0;
        Right = ( mask & SDL.SDL_BUTTON_RMASK ) != 0;
        X1 = ( mask & SDL.SDL_BUTTON_X1MASK ) != 0;
        X2 = ( mask & SDL.SDL_BUTTON_X2MASK ) != 0;
    }

    public bool Equals(MouseState other)
    {
        return other.Left == Left &&
               other.Middle == Middle &&
               other.Right == Right &&
               other.X1 == X1 &&
               other.X2 == X2;
    }
    public override bool Equals(object? obj)
    {
        return obj is MouseState state && Equals(state);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
