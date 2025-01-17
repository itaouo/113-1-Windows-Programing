namespace MyDrawing.model.command
{
    public class ShapeMovedCommand : ICommand
    {
        Shape shape;
        private (int x, int y) cursorOffset;
        private (int x, int y) cursorEnd;

        public ShapeMovedCommand(Shape shape, (int x, int y) cursorOffset)
        {
            this.shape = shape;
            this.cursorEnd = (shape.X, shape.Y);
            this.cursorOffset = cursorOffset;
        }

        public void Execute()
        {
            shape.X = cursorEnd.x;
            shape.Y = cursorEnd.y;
        }

        public void UnExecute()
        {
            shape.X = cursorEnd.x - cursorOffset.x;
            shape.Y = cursorEnd.y - cursorOffset.y;
        }
    }
}
