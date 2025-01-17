using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MyDrawing.shape
{
    public class Terminator : Shape
    {
        public Terminator(String note, int x, int y, int height, int width)
        {
            this.Note = note;
            this.X = x;
            this.Y = y;
            this.Height = height;
            this.Width = width;
        }
        public override string GetShapeType()
        {
            return "Terminator";
        }
        public override void Draw(IGraphics graphics)
        {
            if (Width > 0.1 && Height > 0.1)
            {
                graphics.DrawArc(X, Y, 0.2 * Width, Height, 90, 180);
                graphics.DrawArc(X + 0.8 * Width, Y, 0.2 * Width, Height, 270, 180);
                graphics.DrawLine(X + 0.1 * Width, Y, X + 0.9 * Width, Y);
                graphics.DrawLine(X + 0.1 * Width, Y + Height, X + 0.9 * Width, Y + Height);
            }
        }
        public override bool IsPointInShape(int x, int y)
        {
            GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(X, Y, (float)(0.2 * Width), Height, 90, 180);
            path.AddArc((float)(X + 0.81 * Width), Y, (float)(0.2 * Width), Height, 270, 180);
            path.AddLine(X + Width, Y, X + Width, Y);
            path.AddLine(X + Width, Y + Height, X + Width, Y + Height);
            return path.IsVisible(new Point(x, y));
        }
    }
}
