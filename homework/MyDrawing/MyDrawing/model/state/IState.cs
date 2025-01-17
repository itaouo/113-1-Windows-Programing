namespace MyDrawing
{
    public interface IState
    {
        void DrawAreaMouseDown(int x, int y);
        void DrawAreaMouseMove(int x, int y);
        void DrawAreaMouseUp(int x, int y);
        void Draw(IGraphics graphics);
    }
}
