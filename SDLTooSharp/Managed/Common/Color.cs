namespace SDLTooSharp.Managed.Common;

public class Color
{
    private float _red;
    private float _green;
    private float _blue;
    private float _alpha;
    private float _hue;
    private float _saturation;
    private float _lightness;

    public float Red
    {
        get => _red;
        set {
            _red = Math.Clamp(value, 0.0f, 1.0f);
            RgbToHsl();
        }
    }

    public float Green
    {
        get => _green;
        set {
            _green = Math.Clamp(value, 0.0f, 1.0f);
            RgbToHsl();
        }
    }

    public float Blue
    {
        get => _blue;
        set {
            _blue = Math.Clamp(value, 0.0f, 1.0f);
            RgbToHsl();
        }
    }

    public float Alpha
    {
        get => _alpha;
        set => _alpha = Math.Clamp(value, 0.0f, 1.0f);
    }

    public byte R
    {
        get => (byte)( _red * 255 );
        set => Red = value / 255.0f;
    }

    public byte G
    {
        get => (byte)( _green * 255 );
        set => Green = value / 255.0f;
    }

    public byte B
    {
        get => (byte)( _blue * 255 );
        set => Blue = value / 255.0f;
    }

    public byte A
    {
        get => (byte)( _alpha * 255 );
        set => Alpha = value / 255.0f;
    }

    public float Hue
    {
        get => _hue;
        set {
            _hue = Math.Clamp(value, 0f, 360f);
            HslToRgb();
        }
    }

    public float Saturation
    {
        get => _saturation;
        set {
            _saturation = Math.Clamp(value, 0f, 1f);
            HslToRgb();
        }
    }

    public float Lightness
    {
        get => _lightness;
        set {
            _lightness = Math.Clamp(value, 0f, 1f);
            HslToRgb();
        }
    }

    public Color(float r, float g, float b, float a = 1.0f)
    {
        Red = r;
        Green = g;
        Blue = b;
        Alpha = a;
    }

    public Color(byte r, byte g, byte b, byte a = 255)
    {
        R = r;
        G = g;
        B = b;
        A = a;
    }

    public Color(uint color)
    {
        R = (byte)( ( color & 0xff000000 ) >> 24 );
        G = (byte)( ( color & 0x00ff0000 ) >> 16 );
        B = (byte)( ( color & 0x0000ff00 ) >> 8 );
        A = (byte)( color & 0x000000ff );
    }

    private void RgbToHsl()
    {
        float hue = 0f, saturation = 0f, luminance = 0f;
        float max = Math.Max(_red, Math.Max(_green, _blue));
        float min = Math.Min(_red, Math.Min(_green, _blue));

        luminance = ( min + max ) / 2;
        if ( Math.Abs(min - max) < float.Epsilon )
        {
            saturation = 0;
            hue = 0;
            _lightness = luminance;
            _saturation = saturation;
            _hue = hue;
            return;
        }

        if ( luminance <= 0.5f )
        {
            saturation = ( max - min ) / ( max + min );
        } else
        {
            saturation = ( max - min ) / ( 2.0f - max - min );
        }

        if ( Math.Abs(max - _red) < float.Epsilon )
        {
            hue = ( _green - _blue ) / ( max - min );
        } else if ( Math.Abs(max - _green) < float.Epsilon )
        {
            hue = 2f + ( _blue - _red ) / ( max - min );
        } else
        {
            hue = 4f + ( _red - _green ) / ( max - min );
        }

        hue = hue * 60f;
        if ( hue < 0 )
        {
            hue += 360f;
        }

        _lightness = luminance;
        _saturation = saturation;
        _hue = hue;
    }

    private void HslToRgb()
    {
        if ( _saturation == 0f )
        {
            _red = _lightness;
            _green = _lightness;
            _blue = _lightness;
            return;
        }

        float t1 = 0f, t2 = 0f;
        if ( _lightness < 0.5f )
        {
            t1 = _lightness * ( 1f + _saturation );
        } else
        {
            t1 = _lightness + _saturation - _lightness * _saturation;
        }

        t2 = 2f * _lightness - t1;

        float tHue = _hue / 360f;

        float tr = tHue + ( 1 / 3f );
        float tg = tHue;
        float tb = tHue - ( 1 / 3f );

        tr = NormalizeComponent(tr);
        tg = NormalizeComponent(tg);
        tb = NormalizeComponent(tb);

        _red = CalculateChannelFromHsl(tr, t1, t2);
        _green = CalculateChannelFromHsl(tg, t1, t2);
        _blue = CalculateChannelFromHsl(tb, t1, t2);
    }

    public float CalculateChannelFromHsl(float channel, float t1, float t2)
    {
        // Test 1

        var tC1 = 6f * channel;
        var tC2 = 2f * channel;
        var tC3 = 3f * channel;
        if ( tC1 < 1 )
        {
            return t2 + ( t1 - t2 ) * 6 * channel;
        }

        if ( tC2 < 1 )
        {
            return t1;
        }

        if ( tC3 < 2 )
        {
            return t2 + ( t1 - t2 ) * ( 2 / 3f - channel ) * 6;
        }

        return t2;
    }

    public float NormalizeComponent(float component)
    {
        return component switch {
            < 0f => component + 1f,
            > 1f => component - 1f,
            _ => component
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static explicit operator uint(Color color)
    {
        return (uint)( color.R << 24 | color.G << 16 | color.B << 8 | color.A );
    }
}
