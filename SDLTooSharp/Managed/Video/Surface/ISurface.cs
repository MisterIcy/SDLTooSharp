using SDLTooSharp.Managed.Common;

namespace SDLTooSharp.Managed.Video.Surface;

public interface ISurface
{
    public Size Dimensions { get; }
    public int Pitch { get; }
    public IntPtr Pixels { get; }

    public void Lock();
    public void Unlock();


}
