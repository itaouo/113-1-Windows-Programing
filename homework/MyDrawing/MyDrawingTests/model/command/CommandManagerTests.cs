using MyDrawing.model.command;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyDrawing.model.command.Tests
{
    [TestClass()]
    public class CommandManagerTests
    {
        private Shape shape;

        [TestInitialize()]
        public void SetUp()
        {
            shape = new Factory().GetShape("Process", "note", "0", "0", "100", "100");
        }

        [TestMethod()]
        public void SingletonTest()
        {
            CommandManager commandManager1 = CommandManager.Instance;
            CommandManager commandManager2 = CommandManager.Instance;
            Assert.AreEqual(commandManager1, commandManager2);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            CommandManager.Instance.Execute(new TextChangedCommand(shape, "text"));
            Assert.AreEqual("text", shape.Note);
            Assert.IsTrue(CommandManager.Instance.IsUndoEnabled);
            Assert.IsFalse(CommandManager.Instance.IsRedoEnabled);
        }

        [TestMethod()]
        public void UndoTest()
        {
            CommandManager.Instance.Execute(new TextChangedCommand(shape, "text"));
            CommandManager.Instance.Undo();
            Assert.AreEqual("note", shape.Note);
        }

        [TestMethod()]
        public void UndoExceptionTest()
        {
            CommandManager.Instance.ClearAll();
            try
            {
                CommandManager.Instance.Undo();
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Cannot Undo exception.", ex.Message);
            }
        }

        [TestMethod()]
        public void RedoTest()
        {
            CommandManager.Instance.Execute(new TextChangedCommand(shape, "text"));
            CommandManager.Instance.Undo();
            CommandManager.Instance.Redo();
            Assert.AreEqual("text", shape.Note);
        }

        [TestMethod()]
        public void RedoExceptionTest()
        {
            CommandManager.Instance.ClearAll();
            try
            {
                CommandManager.Instance.Redo();
                Assert.Fail();
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Cannot Redo exception.", ex.Message);
            }
        }

        [TestMethod()]
        public void ClearAllTest()
        {
            CommandManager.Instance.Execute(new TextChangedCommand(shape, "text"));
            CommandManager.Instance.ClearAll();
        }

        [TestMethod()]
        public void NotifyCommandManagerObserverTest()
        {
            FormMock formMock = new FormMock();
            CommandManager.Instance.NotifyCommandManagerObserver();
        }

        internal class FormMock
        {
            public FormMock()
            {
                CommandManager.Instance.CommandManagerChanged += foo;
            }
            private void foo()
            {
                Console.WriteLine("ModelChanged");
            }
        }
    }
}