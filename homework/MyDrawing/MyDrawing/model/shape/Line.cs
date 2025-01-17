using System;

namespace MyDrawing.model.shape
{
    public class Line : Shape
    {
        public (Shape shape, int index) StartPoint;
        public (Shape shape, int index) EndPoint;

        public Line(String note, int x, int y, int height, int width)
        {
            this.X = x;
            this.Y = y;
            this.Height = height;
            this.Width = width;
        }
        public override void Draw(IGraphics graphics)
        {
            if (StartPoint.shape != null)
            {
                (X, Y) = GetShapeConnectionPointCoordinates(StartPoint.shape, StartPoint.index);
            }
            if (EndPoint.shape != null)
            {
                (Width, Height) = GetShapeConnectionPointCoordinates(EndPoint.shape, EndPoint.index);
            }
            graphics.DrawStrongerLine(X, Y, Width, Height);
        }

        public override string GetShapeType()
        {
            return "Line";
        }

        public override bool IsPointInShape(int x, int y)
        {
            return false;
        }

        public (int x, int y) GetShapeConnectionPointCoordinates(Shape shape, int index)
        {
            switch (index)
            {
                case 0:
                    return (shape.X + shape.Width / 2, shape.Y);
                case 1:
                    return (shape.X, shape.Y + shape.Height / 2);
                case 2:
                    return (shape.X + shape.Width / 2, shape.Y + shape.Height);
                case 3:
                    return (shape.X + shape.Width, shape.Y + shape.Height / 2);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
