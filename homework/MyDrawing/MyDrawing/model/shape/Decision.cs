using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MyDrawing.shape
{
    public class Decision : Shape
    {
        public Decision(String note, int x, int y, int height, int width)
        {
            this.Note = note;
            this.X = x;
            this.Y = y;
            this.Height = height;
            this.Width = width;
        }
        public override string GetShapeType()
        {
            return "Decision";
        }
        public override void Draw(IGraphics graphics)
        {
            (int x, int y)[] coordinates = new (int x, int y)[]
            {
                (X + Width / 2, Y),
                (X + Width, Y + Height / 2),
                (X + Width / 2, Y + Height),
                (X, Y + Height / 2)
            };
            graphics.DrawPolygon(coordinates);
        }
        public override bool IsPointInShape(int x, int y)
        {
            GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddPolygon(
                new Point[]
                {
                    new Point(X + Width / 2, Y),
                    new Point(X + Width, Y + Height / 2),
                    new Point(X + Width / 2, Y + Height),
                    new Point(X, Y + Height / 2)
                }
            );
            return path.IsVisible(new Point(x, y));
        }
    }
}


