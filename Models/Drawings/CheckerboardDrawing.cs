
namespace Fylth.Models.Drawings;

internal class CheckerboardDrawing : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        IPattern pattern;
            
        using (PictureCanvas picture = new PictureCanvas(0, 0, 200, 200))
        {
            picture.StrokeColor = Colors.Transparent;
            picture.StrokeSize = 0;
            picture.FillColor = GetColorResource("Gray950");
            picture.FillRectangle(0, 0, 100, 100);
            picture.FillRectangle(100, 100, 100, 100);
            pattern = new PicturePattern(picture.Picture, 200, 200);
        }

        PatternPaint patternPaint = new PatternPaint
        {
            Pattern = pattern
        };
            
        canvas.SetFillPaint(patternPaint, RectF.Zero);
        canvas.FillRectangle(dirtyRect);
    }
        
    private Color GetColorResource(string key)
    {
        var hasValue = App.Current.Resources.TryGetValue(key, out object tempColor);
        if (hasValue)
        {
            return (Color)tempColor;
        }

        return Colors.White;
    }
}
