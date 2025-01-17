using System;

namespace MyDrawing
{
    public class DrawingState : IState
    {
        private readonly Model model;
        private readonly PresentationModel presentationModel;
        private readonly PointerState pointerState;
        public bool IsCursorPressed { get; private set; }
        public (int x, int y) CursorStart { get; private set; }
        public (int x, int y) CursorNow { get; private set; }
        public string TempShapeType { get; private set; }
        public string TempShapeNote { get; private set; }
        public Shape TempShape { get; private set; }

        public DrawingState(Model model, PresentationModel presentationModel, PointerState pointerState)
        {
            this.model = model;
            this.presentationModel = presentationModel;
            this.pointerState = pointerState;
            Initialize();
        }

        public void Initialize()
        {
            IsCursorPressed = false;
            CursorStart = (-1, -1);
            CursorNow = (-1, -1);
            TempShapeType = "";
            TempShapeNote = "";
            TempShape = null;
        }

        public void DrawAreaMouseDown(int x, int y)
        {
            IsCursorPressed = true;
            CursorStart = (x, y);
            TempShapeType = presentationModel.ShapeType;
            TempShapeNote = GenerateRandomString();
        }

        public void DrawAreaMouseMove(int x, int y)
        {
            if (IsCursorPressed)
            {
                CursorNow = (x, y);
                TempShape = SetTempShape();
                presentationModel.NotifyDrawAreaChange();
            }
        }

        public void DrawAreaMouseUp(int x, int y)
        {
            DrawAreaMouseMove(x, y);
            if (TempShape != null)
            {
                model.AddShape(TempShape);
            }
            pointerState.Initialize(TempShape);
            presentationModel.EnterPointerState();
            Initialize();
        }

        public void Draw(IGraphics graphics)
        {
            if (IsCursorPressed && TempShape != null)
            {
                TempShape.Draw(graphics);
            }
        }

        public (int x, int y, int height, int width) GetShapeCoordinates()
        {
            int x, y, height, width;
            if (CursorNow.x - CursorStart.x > 0)
            {
                width = CursorNow.x - CursorStart.x;
                x = CursorStart.x;
            }
            else
            {
                width = CursorStart.x - CursorNow.x;
                x = CursorNow.x;
            }
            if (CursorNow.y - CursorStart.y > 0)
            {
                height = CursorNow.y - CursorStart.y;
                y = CursorStart.y;
            }
            else
            {
                height = CursorStart.y - CursorNow.y;
                y = CursorNow.y;
            }
            return (x, y, height, width);
        }

        public Shape SetTempShape()
        {
            var (x, y, height, width) = GetShapeCoordinates();
            if (height == 0 || width == 0)
            {
                return null;
            }
            return model.CreateShape(TempShapeType, TempShapeNote, x.ToString(), y.ToString(), height.ToString(), width.ToString());
        }

        public string GenerateRandomString()
        {
            Random random = new Random();
            int length = random.Next(3, 11);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            char[] stringChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new string(stringChars);
        }
    }
}
