namespace SDLTooSharp.Managed.Font;

public struct GlyphMetrics
{
    public readonly int MinX;
    public readonly int MaxX;
    public readonly int MinY;
    public readonly int MaxY;
    public readonly int Advance;

    public GlyphMetrics(int minX, int maxX, int minY, int maxY, int advance)
    {
        MinX = minX;
        MaxX = maxX;
        MinY = minY;
        MaxY = maxY;
        Advance = advance;
    }
}
