using MyDrawing.model.shape;
using MyDrawing.shape;
using System;

namespace MyDrawing
{
    public class Factory
    {
        public Factory() { }
        public Shape GetShape(String shape, String note, String x, String y, String height, String width)
        {
            switch (shape)
            {
                case "Start":
                    return new Start(note, Int32.Parse(x), Int32.Parse(y), Int32.Parse(height), Int32.Parse(width));
                case "Terminator":
                    return new Terminator(note, Int32.Parse(x), Int32.Parse(y), Int32.Parse(height), Int32.Parse(width));
                case "Process":
                    return new Process(note, Int32.Parse(x), Int32.Parse(y), Int32.Parse(height), Int32.Parse(width));
                case "Decision":
                    return new Decision(note, Int32.Parse(x), Int32.Parse(y), Int32.Parse(height), Int32.Parse(width));
                case "Line":
                    return new Line(note, Int32.Parse(x), Int32.Parse(y), Int32.Parse(height), Int32.Parse(width));
                default:
                    return null;
            }
        }
    }
}