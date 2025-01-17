namespace MyDrawing
{
    public interface IGraphics
    {
        void ClearAll();
        void DrawLine(double x1, double y1, double x2, double y2);
        void DrawRectangle(double x, double y, double width, double height);
        void DrawEllipse(double x, double y, double width, double height);
        void DrawArc(double x, double y, double width, double height, double startAngle, double sweepAngle);
        void DrawString(string text, double x, double y);
        void DrawPolygon((int x, int y)[] coordinates);
        void DrawColoredRectangle(double x, double y, double width, double height);
        void DrawDragPoint(double x, double y);

        void DrawStrongerLine(double x1, double y1, double x2, double y2);
        (float x, float y) MeasureTextSize(string text);
    }
}
