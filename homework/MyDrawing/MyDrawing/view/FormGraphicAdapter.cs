using System.Drawing;
using System.Linq;

namespace MyDrawing
{
    public class FormGraphicAdapter : IGraphics
    {
        private Graphics _graphics;
        private Pen pen = new Pen(Color.Black, 2);

        public FormGraphicAdapter(Graphics graphics)
        {
            this._graphics = graphics;
        }

        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            pen = new Pen(Color.Black, 2);
            _graphics.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        public void DrawRectangle(double x, double y, double width, double height)
        {
            pen = new Pen(Color.Black, 2);
            _graphics.DrawRectangle(pen, (float)x, (float)y, (float)width, (float)height);
        }

        public void DrawEllipse(double x, double y, double width, double height)
        {
            pen = new Pen(Color.Black, 2);
            _graphics.DrawEllipse(pen, (float)x, (float)y, (float)width, (float)height);
        }

        public void DrawArc(double x, double y, double width, double height, double startAngle, double sweepAngle)
        {
            pen = new Pen(Color.Black, 2);
            _graphics.DrawArc(pen, (float)x, (float)y, (float)width, (float)height, (float)startAngle, (float)sweepAngle);
        }

        public void DrawString(string text, double x, double y)
        {
            pen = new Pen(Color.Black, 2);
            _graphics.DrawString(text, new Font("Arial", 16), Brushes.Black, (float)x, (float)y);
        }

        public void DrawPolygon((int x, int y)[] coordinates)
        {
            pen = new Pen(Color.Black, 2);
            var points = coordinates.Select(coord => new Point(coord.x, coord.y)).ToArray();
            _graphics.DrawPolygon(pen, points);
        }
        public void DrawColoredRectangle(double x, double y, double width, double height)
        {
            pen = new Pen(Color.Red, 2);
            _graphics.DrawRectangle(pen, (float)x, (float)y, (float)width, (float)height);
        }

        public void DrawDragPoint(double x, double y)
        {
            pen = new Pen(Color.Orange, 6);
            _graphics.DrawEllipse(pen, (float)x - 3, (float)y - 3, 6, 6);
        }

        public void DrawStrongerLine(double x1, double y1, double x2, double y2)
        {
            pen = new Pen(Color.Black, 5);
            _graphics.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        public (float x, float y) MeasureTextSize(string text)
        {
            SizeF textSize = _graphics.MeasureString(text, new Font("Arial", 16));
            return (textSize.Width, textSize.Height);
        }
    }
}
