using System.Text;

namespace SDLTooSharp.Bindings;

internal static class Marshaller
{
    internal static int GetStringLengthInBytes(string? str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return 0;
        }

        // 4 bytes per character, plus 1 extra for the trailing 0x00 character.
        return (str.Length * 4) + 1;
    }

    internal static unsafe string CharToManaged(IntPtr str, bool shouldFreeOriginal = false)
    {
        if (str == IntPtr.Zero)
        {
            return string.Empty;
        }

        var ptrCtr = (byte*)str;
        while (*ptrCtr != 0)
        {
            ptrCtr++;
        }

        var strlen = (int)(ptrCtr - (byte*)str);

        var managedStr = Encoding.UTF8.GetString((byte*)str, strlen);

        if (shouldFreeOriginal)
        {
            SDL2.SDL_free(str);
        }

        return managedStr;
    }

    internal static unsafe byte* ManagedToChar(string? str, byte* buffer, int length)
    {
        if (string.IsNullOrEmpty(str))
        {
            return (byte*) 0;
        }

        fixed (char* charPtr = str)
        {
            Encoding.UTF8.GetBytes(charPtr, str.Length + 1, buffer, length);
        }

        return buffer;
    }
}

