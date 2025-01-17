namespace MyDrawing.model.command
{
    public class ShapeDeletedCommand : ICommand
    {
        private Model model;
        private Shape shape;
        private int index;

        public ShapeDeletedCommand(Model model, int index)
        {
            this.model = model;
            this.index = index;
        }

        public void Execute()
        {
            shape = model.Shapes[index];
            model.Shapes.RemoveAt(index);
        }

        public void UnExecute()
        {
            model.Shapes.Insert(index, shape);
        }
    }
}
