using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;


namespace MyDrawing.model.command.Tests
{
    [TestClass()]
    public class ShapeAddedCommandTests
    {
        private Model model;
        private Shape shape;

        [TestInitialize()]
        public void SetUp()
        {
            model = new Model(new Factory());
            shape = model.CreateShape("Process", "note", "0", "0", "100", "100");
        }

        [TestMethod()]
        public void ShapeAddedCommandTest()
        {
            ShapeAddedCommand shapeAddedCommand = new ShapeAddedCommand(model, shape);
            Assert.IsNotNull(shapeAddedCommand);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            ShapeAddedCommand shapeAddedCommand = new ShapeAddedCommand(model, shape);
            shapeAddedCommand.Execute();
            Assert.AreEqual(1, model.Shapes.Count());
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            ShapeAddedCommand shapeAddedCommand = new ShapeAddedCommand(model, shape);
            shapeAddedCommand.Execute();
            shapeAddedCommand.UnExecute();
            Assert.AreEqual(0, model.Shapes.Count());
        }
    }
}