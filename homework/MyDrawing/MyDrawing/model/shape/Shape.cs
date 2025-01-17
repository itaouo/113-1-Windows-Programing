namespace MyDrawing
{
    public abstract class Shape
    {
        public string Note;
        public int X;
        public int Y;
        public int Height;
        public int Width;
        public int Id = -1;
        public double TextOffsetX = 0;
        public double TextOffsetY = 0;
        public abstract string GetShapeType();
        public abstract void Draw(IGraphics graphics);
        public abstract bool IsPointInShape(int x, int y);
    }
}
