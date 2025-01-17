using MyDrawing.model.command;
using System;
using System.Collections.Generic;

namespace MyDrawing
{
    public class Model
    {
        public event ModelChangedEventHandler ModelChanged;
        public delegate void ModelChangedEventHandler();
        private readonly Factory factory;
        public List<Shape> Shapes { private set; get; }
        public int Order = 0;

        public Model(Factory factory)
        {
            this.factory = factory;
            this.Shapes = new List<Shape>();
        }

        public void NotifyObserver()
        {
            ModelChanged?.Invoke();
        }

        public Shape CreateShape(String shapeType, String note, String x, String y, String height, String width)
        {
            return factory.GetShape(shapeType, note, x, y, height, width);
        }

        public void AddShape(Shape shape)
        {
            CommandManager.Instance.Execute(new ShapeAddedCommand(this, shape));
            NotifyObserver();
        }

        public void DeleteShapeByIndex(int index)
        {
            CommandManager.Instance.Execute(new ShapeDeletedCommand(this, index));
            NotifyObserver();
        }

        public void DeleteAllShape()
        {
            Shapes.Clear();
            NotifyObserver();
        }

        public string GetShapesOutput()
        {
            string result = "";
            foreach (Shape shape in Shapes)
            {
                result = result + shape.GetShapeType() + " "
                    + shape.X + " "
                    + shape.Y + " "
                    + shape.Height + " "
                    + shape.Width + " "
                    + shape.Id + " "
                    + shape.TextOffsetX + " "
                    + shape.TextOffsetY + " "
                    + shape.Note + "\n";
            }
            return result;
        }
    }
}
