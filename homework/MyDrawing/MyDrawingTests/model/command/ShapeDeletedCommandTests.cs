using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MyDrawing.model.command.Tests
{
    [TestClass()]
    public class ShapeDeletedCommandTests
    {
        private Model model;
        private Shape shape;

        [TestInitialize()]
        public void SetUp()
        {
            model = new Model(new Factory());
            shape = model.CreateShape("Process", "note", "0", "0", "100", "100");
            model.AddShape(shape);
        }

        [TestMethod()]
        public void ShapeDeletedCommandTest()
        {
            ShapeDeletedCommand shapeDeletedCommand = new ShapeDeletedCommand(model, 0);
            Assert.IsNotNull(shapeDeletedCommand);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            ShapeDeletedCommand shapeDeletedCommand = new ShapeDeletedCommand(model, 0);
            shapeDeletedCommand.Execute();
            Assert.AreEqual(0, model.Shapes.Count());
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            ShapeDeletedCommand shapeDeletedCommand = new ShapeDeletedCommand(model, 0);
            shapeDeletedCommand.Execute();
            shapeDeletedCommand.UnExecute();
            Assert.AreEqual(1, model.Shapes.Count());
        }
    }
}