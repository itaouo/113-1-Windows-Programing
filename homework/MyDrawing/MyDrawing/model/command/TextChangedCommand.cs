namespace MyDrawing.model.command
{
    public class TextChangedCommand : ICommand
    {
        private Shape shape;
        private string startText;
        private string endText;
        public TextChangedCommand(Shape shape, string endText)
        {
            this.shape = shape;
            this.startText = shape.Note;
            this.endText = endText;
        }

        public void Execute()
        {
            shape.Note = endText;
        }

        public void UnExecute()
        {
            shape.Note = startText;
        }
    }
}
