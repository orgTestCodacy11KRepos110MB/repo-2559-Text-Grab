using System.Windows.Media;

namespace Text_Grab.Utilities;

public static class ColorHelper
{
    public static System.Windows.Media.Color MediaColorFromDrawingColor(System.Drawing.Color drawingColor)
    {
        return System.Windows.Media.Color.FromArgb(drawingColor.A, drawingColor.R, drawingColor.G, drawingColor.B);
    }

    public static SolidColorBrush SolidColorBrushFromDrawingColor(System.Drawing.Color drawingColor)
    {
        return new SolidColorBrush(MediaColorFromDrawingColor(drawingColor));
    }

    public static SolidColorBrush ContrastingWhiteOrBlack(this SolidColorBrush solidColorBrush)
    {
        byte r = solidColorBrush.Color.R;  // extract red
        byte g = solidColorBrush.Color.G;  // extract green
        byte b = solidColorBrush.Color.B;  // extract blue

        double luma = 0.2126 * r + 0.7152 * g + 0.0722 * b; // per ITU-R BT.709

        if (luma > 180)
            return new SolidColorBrush(Colors.Black);
        
        return new SolidColorBrush(Colors.White);
    }
}