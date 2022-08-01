namespace SDLTooSharp.Bindings;

/// <summary>
/// Attribute which annotates an imported SDL function with the version since it became available.
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class SDLVersion : Attribute
{
    /// <summary>
    /// The major component of the version.
    /// </summary>
    public int Major { get; }

    /// <summary>
    /// The minor component of the version.
    /// </summary>
    public int Minor { get; }

    /// <summary>
    /// The patch component of the version.
    /// </summary>
    public int Patch { get; }

    /// <summary>
    /// An integer representation of the version, used to facilitate calculations.
    /// </summary>
    private int Version => Major * 10000 + Minor * 100 + Patch;

    /// <summary>
    /// Defines since which version the function is available
    /// </summary>
    /// <param name="major">The major component of the version</param>
    /// <param name="minor">The minor component of the version</param>
    /// <param name="patch">The patch component of the version</param>
    public SDLVersion(int major, int minor, int patch)
    {
        Major = major;
        Minor = minor;
        Patch = patch;
    }

    /// <summary>
    /// Equality operator
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(SDLVersion left, SDLVersion right)
    {
        return (left.Version == right.Version);
    }

    /// <summary>
    /// Inequality operator
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(SDLVersion left, SDLVersion right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Less than operator 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <(SDLVersion left, SDLVersion right)
    {
        return left.Version < right.Version;
    }

    /// <summary>
    /// Greater than operator
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >(SDLVersion left, SDLVersion right)
    {
        return left.Version > right.Version;
    }

    /// <summary>
    /// Less than or equal
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <=(SDLVersion left, SDLVersion right)
    {
        return left < right || left == right;
    }

    /// <summary>
    /// Greater than or equal.
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >=(SDLVersion left, SDLVersion right)
    {
        return left > right || left == right;
    }
}