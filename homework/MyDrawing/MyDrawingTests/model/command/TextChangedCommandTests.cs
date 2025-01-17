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
    public class TextChangedCommandTests
    {
        private Shape shape;
        private string startText;
        private string endText;

        [TestInitialize()]
        public void SetUp()
        {
            Factory factory = new Factory();
            startText = "start";
            shape = factory.GetShape("Process", startText, "0", "0", "100", "100");
            endText = "end";
        }

        [TestMethod()]
        public void TextChangedCommandTest()
        {
            TextChangedCommand textChangedCommand = new TextChangedCommand(shape, endText);
            Assert.IsNotNull(textChangedCommand);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            TextChangedCommand textChangedCommand = new TextChangedCommand(shape, endText);
            textChangedCommand.Execute();
            Assert.AreEqual(endText, shape.Note);
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            TextChangedCommand textChangedCommand = new TextChangedCommand(shape, endText);
            textChangedCommand.Execute();
            textChangedCommand.UnExecute();
            Assert.AreEqual(startText, shape.Note);
        }
    }
}