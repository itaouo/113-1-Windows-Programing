using MyDrawing.model.command;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace MyDrawing
{
    public class PointerState : IState
    {
        private Model model;
        private PresentationModel presentationModel;
        public (int x, int y) CursorStart { private set; get; }
        public (int x, int y) CursorNow { private set; get; }
        public bool IsCursorPressed { private set; get; }
        public bool IsCursorInDragPoint { private set; get; }
        public bool IsCursorPressDragPointOnce { private set; get; }

        public Shape SelectedShape { private set; get; }
        public (float Width, float Height) textSize;

        public PointerState(Model model, PresentationModel presentationModel)
        {
            this.model = model;
            this.presentationModel = presentationModel;
        }
        public void Initialize()
        {
            IsCursorPressed = false;
            IsCursorInDragPoint = false;
            IsCursorPressDragPointOnce = false;
            SelectedShape = null;
        }
        public void Initialize(Shape shape)
        {
            IsCursorPressed = false;
            IsCursorInDragPoint = false;
            IsCursorPressDragPointOnce = false;
            SelectedShape = shape;
        }

        public void DrawAreaMouseDown(int x, int y)
        {
            if (IsCursorPressDragPointOnce)
            {
                return;
            }
            else if (SelectedShape != null && IsPointInDrawPoint(x, y))
            {
                IsCursorPressed = true;
                CursorStart = (x, y);
                CursorNow = (x, y);
                IsCursorInDragPoint = true;
                return;
            }
            Initialize();
            foreach (Shape shape in Enumerable.Reverse(model.Shapes))
            {
                if (shape.IsPointInShape(x, y))
                {
                    SelectedShape = shape;
                    IsCursorPressed = true;
                    CursorStart = (x, y);
                    CursorNow = (x, y);
                    IsCursorInDragPoint = IsPointInDrawPoint(x, y);
                    return;
                }
                presentationModel.NotifyDrawAreaChange();
            }
        }

        public void DrawAreaMouseMove(int x, int y)
        {
            if (IsCursorPressed && IsCursorInDragPoint)
            {
                SelectedShape.TextOffsetX += x - CursorNow.x;
                SelectedShape.TextOffsetY += y - CursorNow.y;
                CursorNow = (x, y);
            }
            else if (IsCursorPressed)
            {
                SelectedShape.X += x - CursorNow.x;
                SelectedShape.Y += y - CursorNow.y;
                CursorNow = (x, y);
            }
            presentationModel.NotifyDrawAreaChange();
        }

        public void DrawAreaMouseUp(int x, int y)
        {
            if (IsCursorPressDragPointOnce)
            {
                presentationModel.NotifyTextDialogShow();
                IsCursorPressDragPointOnce = false;
            }
            else if (IsCursorPressed && IsCursorInDragPoint)
            {
                if(Math.Abs(CursorNow.x - CursorStart.x) < 3 && Math.Abs(CursorNow.y - CursorStart.y) < 3){
                    IsCursorPressDragPointOnce = true;
                }
                else
                {
                    CommandManager.Instance.Execute(new TextMovedCommand(SelectedShape, (CursorNow.x - CursorStart.x, CursorNow.y - CursorStart.y)));
                    presentationModel.textPosition = (CursorNow.x - CursorStart.x, CursorNow.y - CursorStart.y);
                    presentationModel.NotifyTextPositionShow();
                }
            }
            else if (IsCursorPressed && CursorNow != CursorStart)
            {
                CommandManager.Instance.Execute(new ShapeMovedCommand(SelectedShape, (CursorNow.x - CursorStart.x, CursorNow.y - CursorStart.y)));
            }
            IsCursorPressed = false;
            IsCursorInDragPoint = false;
            model.NotifyObserver();
        }

        public void Draw(IGraphics graphics)
        {
            if (SelectedShape != null && model.Shapes.Contains(SelectedShape))
            {
                (textSize.Width, textSize.Height) = graphics.MeasureTextSize(SelectedShape.Note);
                var (textAnchorX, textAnchorY) = GetTextAnchor();
                graphics.DrawColoredRectangle(SelectedShape.X, SelectedShape.Y, SelectedShape.Width, SelectedShape.Height); // shape 外框
                graphics.DrawColoredRectangle(textAnchorX + SelectedShape.TextOffsetX - 1, textAnchorY + SelectedShape.TextOffsetY - 1, textSize.Width, textSize.Height); // text 外框
                graphics.DrawDragPoint(textAnchorX + SelectedShape.TextOffsetX + textSize.Width / 2 - 1, textAnchorY + SelectedShape.TextOffsetY - 3); // text 拖曳點
            }
        }

        public bool IsPointInDrawPoint(int x, int y)
        {
            var (textAnchorX, textAnchorY) = GetTextAnchor();
            GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse((float)(textAnchorX + SelectedShape.TextOffsetX + textSize.Width / 2 - 1 - 5), (float)(textAnchorY + SelectedShape.TextOffsetY - 3 - 5), 10, 10);
            return path.IsVisible(new Point(x, y));
        }

        public (float textAnchorX, float textAnchorY) GetTextAnchor()
        {
            return ((SelectedShape.X + (SelectedShape.Width - textSize.Width) / 2), (SelectedShape.Y + (SelectedShape.Height - textSize.Height) / 2));
        }

        public void ChangeShapeText(string text)
        {
            CommandManager.Instance.Execute(new TextChangedCommand(SelectedShape, text));
        }
    }
}
