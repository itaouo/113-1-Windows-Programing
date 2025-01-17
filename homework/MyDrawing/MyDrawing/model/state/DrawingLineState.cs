using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;

namespace MyDrawing.state
{
    public class DrawingLineState : IState
    {
        private Model model;
        private PresentationModel presentationModel;
        public Shape SelectedShape { private set; get; }
        public model.shape.Line TempLine { private set; get; }
        public (float Width, float Height) textSize;

        public DrawingLineState(Model model, PresentationModel presentationModel)
        {
            this.model = model;
            this.presentationModel = presentationModel;
        }

        public void Initialize()
        {
            SelectedShape = null;
            TempLine = null;
        }

        public void DrawAreaMouseDown(int x, int y)
        {
            DrawAreaMouseMove(x, y);
            if (SelectedShape != null && CursorInShapeConnectionPoint(x, y) != -1)
            {
                TempLine = (model.shape.Line)model.CreateShape("Line", "", x.ToString(), y.ToString(), y.ToString(), x.ToString());
                TempLine.StartPoint = (SelectedShape, CursorInShapeConnectionPoint(x, y));
            }
        }

        public void DrawAreaMouseMove(int x, int y)
        {
            if(SelectedShape != null)
            {
                if (CursorInShapeConnectionPoint(x, y) != -1)
                {
                    return;
                }
            }
            SelectedShape = null;
            foreach (Shape shape in Enumerable.Reverse(model.Shapes))
            {
                if (shape.IsPointInShape(x, y))
                {
                    SelectedShape = shape;
                    break;
                }
            }
            if (TempLine != null)
            {
                TempLine.Width = x;
                TempLine.Height = y;
            }
            presentationModel.NotifyDrawAreaChange();
        }

        public void DrawAreaMouseUp(int x, int y)
        {
            if (SelectedShape != null && TempLine != null && CursorInShapeConnectionPoint(x, y) != -1)
            {
                TempLine.EndPoint = (SelectedShape, CursorInShapeConnectionPoint(x, y));
                model.AddShape(TempLine);
                model.NotifyObserver();
            }
            Initialize();
            presentationModel.NotifyDrawAreaChange();
            presentationModel.EnterPointerState();
        }

        public void Draw(IGraphics graphics)
        {
            if (SelectedShape != null)
            {
                graphics.DrawColoredRectangle(SelectedShape.X, SelectedShape.Y, SelectedShape.Width, SelectedShape.Height);
                graphics.DrawDragPoint(SelectedShape.X + SelectedShape.Width / 2, SelectedShape.Y);
                graphics.DrawDragPoint(SelectedShape.X, SelectedShape.Y + SelectedShape.Height / 2);
                graphics.DrawDragPoint(SelectedShape.X + SelectedShape.Width / 2, SelectedShape.Y + SelectedShape.Height);
                graphics.DrawDragPoint(SelectedShape.X + SelectedShape.Width, SelectedShape.Y + SelectedShape.Height / 2);
            }
            if (TempLine != null)
            {
                TempLine.Draw(graphics);
            }
        }

        public int CursorInShapeConnectionPoint(int x, int y)
        {
            if (IsCursorInDrawPoint(x, y, SelectedShape.X + SelectedShape.Width / 2, SelectedShape.Y)) { return 0; }
            if (IsCursorInDrawPoint(x, y, SelectedShape.X, SelectedShape.Y + SelectedShape.Height / 2)) { return 1; }
            if (IsCursorInDrawPoint(x, y, SelectedShape.X + SelectedShape.Width / 2, SelectedShape.Y + SelectedShape.Height)) { return 2; }
            if (IsCursorInDrawPoint(x, y, SelectedShape.X + SelectedShape.Width, SelectedShape.Y + SelectedShape.Height / 2)) { return 3; }
            return -1;
        }

        public bool IsCursorInDrawPoint(int x, int y, int pointX, int pointY)
        {
            GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(pointX - 4, pointY - 4, 8, 8);
            return path.IsVisible(new Point(x, y));
        }
    }
}
