using System.Linq;

namespace MyDrawing.model.command
{
    public class ShapeAddedCommand : ICommand
    {
        private Model model;
        private Shape shape;
        private int index;

        public ShapeAddedCommand(Model model, Shape shape)
        {
            this.model = model;
            this.shape = shape;
            this.index = model.Shapes.Count();
        }

        public void Execute()
        {
            model.Shapes.Add(shape);
            shape.Id = model.Order++;
        }

        public void UnExecute()
        {
            model.Shapes.RemoveAt(--model.Order);
        }
    }
}
