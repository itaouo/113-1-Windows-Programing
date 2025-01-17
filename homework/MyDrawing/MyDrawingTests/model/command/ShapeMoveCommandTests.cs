using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.model.command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.model.command.Tests
{
    [TestClass()]
    public class ShapeMoveCommandTests
    {
        private ICommand shapeMoveCommand;
        private Shape shape;
        private (int x, int y) cursorOffset;

        [TestInitialize()]
        public void SetUp()
        {
            Factory factory = new Factory();
            shape = factory.GetShape("Process", "note", "70", "80", "100", "100");
            cursorOffset = (20, 20);
        }

        [TestMethod()]
        public void TextMoveCommandTest()
        {
            shapeMoveCommand = new ShapeMovedCommand(shape, cursorOffset);
            Assert.IsNotNull(shapeMoveCommand);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            shapeMoveCommand = new ShapeMovedCommand(shape, cursorOffset);
            shapeMoveCommand.Execute();
            Assert.AreEqual((70, 80), (shape.X, shape.Y));
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            shapeMoveCommand = new ShapeMovedCommand(shape, cursorOffset);
            shapeMoveCommand.UnExecute();
            Assert.AreEqual((50, 60), (shape.X, shape.Y));
        }

        [TestMethod()]
        public void ExecutesTest()
        {
            shapeMoveCommand = new ShapeMovedCommand(shape, cursorOffset);
            shapeMoveCommand.Execute();
            shapeMoveCommand.UnExecute();
            (double x, double y) cursorNow = (shape.X, shape.Y);
            Assert.AreEqual((50, 60), cursorNow);
        }
    }
}