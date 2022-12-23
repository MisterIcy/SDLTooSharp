// See https://aka.ms/new-console-template for more information

using SDLTooSharp.Bindings.SDL2;
using SDLTooSharp.Managed.Common;
using SDLTooSharp.Managed.Video;
SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);

int displays = Display.NumDisplays;
Console.WriteLine($"Number of attached displays: {displays}" + Environment.NewLine);

for ( int i = 0; i < displays; i++ )
{
    Display display = new Display(i);
    Console.WriteLine($"Display ({display.DisplayId}): {display.Name}");

    DisplayDpi dpi = display.Dpi;
    Console.WriteLine($"DPI: Diagonal {dpi.Diagonal} / Horizontal {dpi.Horizontal} / Vertical {dpi.Vertical}");

    Rectangle bounds = display.Bounds;
    Rectangle usableBounds = display.UsableBounds;

    Console.WriteLine($"Desktop: {bounds.X},{bounds.Y} {bounds.Width}x{bounds.Height}");
    Console.WriteLine($"Usable: {usableBounds.X},{usableBounds.Y} {usableBounds.Width}x{usableBounds.Height}");
    Console.WriteLine($"Orientation: {display.Orientation}");

    foreach ( var mode in display.Modes )
    {
        Console.WriteLine($"{mode.PixelFormatName} - {mode.Width}x{mode.Height}x{mode.RefreshRate}Hz");
    }

    DisplayMode desktop = display.Desktop;
    Console.WriteLine($"Desktop is {desktop.PixelFormatName} - {desktop.Width}x{desktop.Height}x{desktop.RefreshRate}Hz");
}

SDL.SDL_Quit();
