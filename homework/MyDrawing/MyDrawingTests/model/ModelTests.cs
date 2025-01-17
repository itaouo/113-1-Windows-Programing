using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.model.command;
using System;
namespace MyDrawing.Tests
{
    [TestClass()]
    public class ModelTests
    {
        private Model model;

        [TestInitialize()]
        public void Initialize()
        {
            Factory factory = new Factory();
            model = new Model(factory);
        }

        [TestMethod()]
        public void ModelTest()
        {
            Factory factory = new Factory();
            model = new Model(factory);
            Assert.IsNotNull(model);
        }

        [TestMethod()]
        public void NotifyObserverTest()
        {
            model.NotifyObserver();
            FormMock formMock = new FormMock(model);
            model.NotifyObserver();
        }

        [TestMethod()]
        public void CreateShapeTest()
        {
            Shape shape = model.CreateShape("Start", "note", "0", "0", "100", "100");
            Assert.AreEqual("Start", shape.GetShapeType());
        }

        [TestMethod()]
        public void AddShapeTest()
        {
            model.AddShape(model.CreateShape("Start", "note", "0", "0", "100", "100"));
            Assert.AreEqual(1, model.Shapes.Count);
            Assert.AreEqual("Start", model.Shapes[0].GetShapeType());
        }

        [TestMethod()]
        public void DeleteShapeByIndexTest()
        {
            model.AddShape(model.CreateShape("Start", "note", "0", "0", "100", "100"));
            model.AddShape(model.CreateShape("Terminator", "note", "0", "0", "100", "100"));
            model.DeleteShapeByIndex(0);
            Assert.AreEqual(1, model.Shapes.Count);
            Assert.AreEqual("Terminator", model.Shapes[0].GetShapeType());
        }

        [TestMethod()]
        public void DeleteAllShapeTest()
        {
            model.AddShape(model.CreateShape("Start", "note", "0", "0", "100", "100"));
            model.AddShape(model.CreateShape("Terminator", "note", "0", "0", "100", "100"));
            model.DeleteAllShape();
            Assert.AreEqual(0, model.Shapes.Count);
        }

        [TestMethod()]
        public void GetShapesOutputTest()
        {
            model.AddShape(model.CreateShape("Start", "note", "1", "2", "3", "4"));
            model.AddShape(model.CreateShape("Terminator", "note", "0", "0", "100", "100"));
            Assert.AreEqual("Start 1 2 3 4 0 0 0 note\nTerminator 0 0 100 100 1 0 0 note\n", model.GetShapesOutput());
        }

        internal class FormMock
        {
            private Model model;

            public FormMock(Model model)
            {
                this.model = model;
                CommandManager.Instance.CommandManagerChanged += foo;
            }
            private void foo()
            {
                Console.WriteLine("ModelChanged");
            }
        }
    }
}