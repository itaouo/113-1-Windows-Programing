using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;

namespace MyDrawing.model.command.Tests
{
    [TestClass()]
    public class TextMoveCommandTests
    {
        private Shape shape;
        private (double x, double y) cursorOffset;

        [TestInitialize()]
        public void SetUp()
        {
            Factory factory = new Factory();
            shape = factory.GetShape("Process", "note", "0", "0", "100", "100");
            cursorOffset = (50, 60);
        }

        [TestMethod()]
        public void TextMoveCommandTest()
        {
            TextMovedCommand textMoveCommand = new TextMovedCommand(shape, cursorOffset);
            Assert.IsNotNull(textMoveCommand);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            TextMovedCommand textMoveCommand = new TextMovedCommand(shape, cursorOffset);
            textMoveCommand.Execute();
            Assert.AreEqual((0, 0), (shape.TextOffsetX, shape.TextOffsetY));
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            TextMovedCommand textMoveCommand = new TextMovedCommand(shape, cursorOffset);
            textMoveCommand.UnExecute();
            (double x, double y) offsetNow = (shape.TextOffsetX, shape.TextOffsetY);
            Assert.AreEqual((-50, -60), offsetNow);
        }
    }
}