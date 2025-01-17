using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MyDrawing.shape
{
    public class Process : Shape
    {
        public Process(String note, int x, int y, int height, int width)
        {
            this.Note = note;
            this.X = x;
            this.Y = y;
            this.Height = height;
            this.Width = width;
        }
        public override string GetShapeType()
        {
            return "Process";
        }
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(X, Y, Width, Height);
        }
        public override bool IsPointInShape(int x, int y)
        {
            GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddRectangle(new Rectangle(X, Y, Width, Height));
            return path.IsVisible(new Point(x, y));
        }
    }
}
