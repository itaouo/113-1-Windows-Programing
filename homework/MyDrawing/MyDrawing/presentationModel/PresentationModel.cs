using MyDrawing.state;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyDrawing
{
    public class PresentationModel : INotifyPropertyChanged
    {
        private readonly Model model;
        public event PropertyChangedEventHandler PropertyChanged;
        public event PresentationModelToolStripChangedEventHandler PresentationModelToolStripChanged;
        public delegate void PresentationModelToolStripChangedEventHandler();
        public event PresentationModelDrawAreaChangedEventHandler PresentationModelDrawAreaChanged;
        public delegate void PresentationModelDrawAreaChangedEventHandler();
        public event PresentationModelShapeLegalChangedEventHandler PresentationModelShapeLegalChanged;
        public delegate void PresentationModelShapeLegalChangedEventHandler();
        public event PresentationModelTextDialogChangedEventHandler PresentationModeTextDialogChanged;
        public delegate void PresentationModelTextDialogChangedEventHandler();
        public event PresentationModelTextDialogChangedEventHandler PresentationModeTextPositionChanged;
        public delegate void PresentationModeTextPositionChangedEventHandler();

        public IState currentState;
        public PointerState pointerState;
        public DrawingState drawingState;
        public DrawingLineState drawingLineState;

        public string ShapeType { get; private set; }
        public string ChangeText;
        public (int x, int y) textPosition;
        public bool IsStartChecked { get; private set; }
        public bool IsTerminatorChecked { get; private set; }
        public bool IsDecisionChecked { get; private set; }
        public bool IsProcessChecked { get; private set; }
        public bool IsPointerChecked { get; private set; }
        public bool IsLineChecked { get; private set; }
        public bool IsShapeTypeLegal { get; private set; }
        public bool IsShapeNoteLegal { get; private set; }
        public bool IsShapeXLegal { get; private set; }
        public bool IsShapeYLegal { get; private set; }
        public bool IsShapeHeightLegal { get; private set; }
        public bool IsShapeWidthLegal { get; private set; }
        public bool IsAddDrawingButtonEnabled { get; private set; }

        public PresentationModel(Model model)
        {
            this.model = model;
            pointerState = new PointerState(model, this);
            drawingState = new DrawingState(model, this, pointerState);
            drawingLineState = new DrawingLineState(model, this);
            EnterPointerState();
            OnPropertyChanged("isAddDrawingButtonEnabled");
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NotifyToolStripChange()
        {
            PresentationModelToolStripChanged?.Invoke();
        }

        public void NotifyDrawAreaChange()
        {
            PresentationModelDrawAreaChanged?.Invoke();
        }

        public void NotifyTextDialogShow()
        {
            PresentationModeTextDialogChanged?.Invoke();
        }

        public void NotifyTextPositionShow()
        {
            PresentationModeTextPositionChanged?.Invoke();
        }

        public void NotifyShapeLegalChange()
        {
            PresentationModelShapeLegalChanged?.Invoke();
            IsAddDrawingButtonEnabled = (IsShapeTypeLegal && IsShapeNoteLegal && IsShapeXLegal && IsShapeYLegal && IsShapeHeightLegal && IsShapeWidthLegal);
            OnPropertyChanged("isAddDrawingButtonEnabled");
        }

        public void EnterPointerState()
        {
            currentState = pointerState;
            ToolStripButtonClick("Pointer");
        }

        public void EnterDrawingState()
        {
            currentState = drawingState;
            IsPointerChecked = false;
        }

        public void EnterDrawingLineState()
        {
            currentState = drawingLineState;
            IsPointerChecked = false;
        }

        public void DrawAreaMouseDown(int x, int y)
        {
            currentState.DrawAreaMouseDown(x, y);
        }

        public void DrawAreaMouseMove(int x, int y)
        {
            currentState.DrawAreaMouseMove(x, y);
        }

        public void DrawAreaMouseUp(int x, int y)
        {
            currentState.DrawAreaMouseUp(x, y);
        }

        public void ToolStripClearButtonChecked()
        {
            IsStartChecked = false;
            IsTerminatorChecked = false;
            IsDecisionChecked = false;
            IsProcessChecked = false;
            IsPointerChecked = false;
            IsLineChecked = false;
            currentState = drawingState;
            ShapeType = "";
        }

        public void ToolStripButtonClick(String buttonName)
        {
            ToolStripClearButtonChecked();
            ShapeType = buttonName;
            switch (buttonName)
            {
                case "Start":
                    IsStartChecked = true;
                    break;
                case "Terminator":
                    IsTerminatorChecked = true;
                    break;
                case "Decision":
                    IsDecisionChecked = true;
                    break;
                case "Process":
                    IsProcessChecked = true;
                    break;
                case "Pointer":
                    IsPointerChecked = true;
                    ShapeType = "";
                    currentState = pointerState;
                    break;
                case "Line":
                    IsLineChecked = true;
                    currentState = drawingLineState;
                    break;
            }
            NotifyToolStripChange();
        }

        public void Draw(IGraphics graphics)
        {
            List<Shape> shapes = model.Shapes;
            foreach (Shape shape in shapes)
            {
                shape.Draw(graphics);
                DrawText(graphics, shape);
            }
            currentState.Draw(graphics);
        }

        public void DrawText(IGraphics graphics, Shape shape)
        {
            var (textSizeWidth, textSizeHeight) = graphics.MeasureTextSize(shape.Note);
            var (textAnchorX, textAnchorY) = ((shape.X + (shape.Width - textSizeWidth) / 2), (shape.Y + (shape.Height - textSizeHeight) / 2));
            graphics.DrawString(shape.Note, textAnchorX + shape.TextOffsetX, textAnchorY + shape.TextOffsetY);
        }

        public void SetShapeType(int typeIndex)
        {
            IsShapeTypeLegal = typeIndex != -1;
            NotifyShapeLegalChange();
        }

        public void SetShapeNote(string note)
        {
            IsShapeNoteLegal = note != "";
            NotifyShapeLegalChange();
        }

        public void SetShapeX(string x)
        {
            IsShapeXLegal = int.TryParse(x, out _) && x != "";
            NotifyShapeLegalChange();
        }

        public void SetShapeY(string y)
        {
            IsShapeYLegal = int.TryParse(y, out _) && y != "";
            NotifyShapeLegalChange();
        }

        public void SetShapeHeight(string height)
        {
            IsShapeHeightLegal = int.TryParse(height, out _) && height != "";
            NotifyShapeLegalChange();
        }

        public void SetShapeWidth(string width)
        {
            IsShapeWidthLegal = int.TryParse(width, out _) && width != "";
            NotifyShapeLegalChange();
        }
    }
}
