namespace SDLTooSharp.Managed.Event.Attributes;

/// <summary>
/// Declares that the class performs the event checks internally and as
/// such we must not perform any automatic checks.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class InternalEventChecksAttribute : Attribute
{

}
