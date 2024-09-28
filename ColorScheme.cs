using Raylib_CSharp.Colors;

namespace image_go_whatever;

public static class ColorScheme
{
    private static readonly int NumberOfColors = Enum.GetNames(typeof(ColorFor)).Length;
    private static Theme _currentTheme = Theme.Light;
    private static Color[] _currentColors =  GetLightColors();

    private static Color[] GetLightColors()
    {
        Color[] colors = new Color[NumberOfColors];
        colors[(int)ColorFor.Background] = new Color(0xFF, 0xFC, 0xF0, byte.MaxValue);
        colors[(int)ColorFor.Text] = new Color(0x10, 0x0F, 0x0F, byte.MaxValue);
        return colors;
    }
        
    private static Color[] GetDarkColors()
    {
        Color[] colors = new Color[NumberOfColors];
        colors[(int)ColorFor.Background] = new Color(0x10, 0x0F, 0x0F, byte.MaxValue);
        colors[(int)ColorFor.Text] = new Color(0xCE, 0xCD, 0xC3, byte.MaxValue);
        return colors;
    }

    private static void ApplyTheme()
    {
        _currentColors = _currentTheme switch
        {
            Theme.Light => GetLightColors(),
            Theme.Dark => GetDarkColors(),
            _ => throw new ArgumentException("Invalid theme.")
        };
    }
        

    public enum Theme
    {
        Light,
        Dark
    }

    public enum ColorFor
    {
        Background,
        Text,
    }

    public static void SetTheme(Theme theme)
    {
        _currentTheme = theme;
        ApplyTheme();
    }

    public static void ToggleTheme()
    {
        _currentTheme = _currentTheme == Theme.Light ? Theme.Dark : Theme.Light;
        ApplyTheme();
    }
    
    public static Color GetColor (ColorFor colorFor) => _currentColors[(int)colorFor];
}