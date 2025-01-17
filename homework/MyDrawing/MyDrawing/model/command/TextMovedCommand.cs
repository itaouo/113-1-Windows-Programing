namespace MyDrawing.model.command
{
    public class TextMovedCommand : ICommand
    {
        private Shape shape;
        private (double x, double y) cursorOffset;
        private (double x, double y) cursorEnd;

        public TextMovedCommand(Shape shape, (double x, double y) cursorOffset)
        {
            this.shape = shape;
            this.cursorEnd = (shape.TextOffsetX, shape.TextOffsetY);
            this.cursorOffset = cursorOffset;
        }

        public void Execute()
        {
            shape.TextOffsetX = cursorEnd.x;
            shape.TextOffsetY = cursorEnd.y;
        }

        public void UnExecute()
        {
            shape.TextOffsetX = cursorEnd.x - cursorOffset.x;
            shape.TextOffsetY = cursorEnd.y - cursorOffset.y;
        }
    }
}
