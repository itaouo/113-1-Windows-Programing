using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyDrawing.Tests
{
    [TestClass()]
    public class FactoryTests
    {
        private Factory factory;

        [TestInitialize()]
        public void Initialize()
        {
            factory = new Factory();
            Assert.IsNotNull(factory);
        }

        [TestMethod()]
        public void FactoryTest()
        {
            Shape shape = factory.GetShape("Start", "note", "1", "2", "3", "4");
            Assert.AreEqual("Start", shape.GetShapeType());
            Assert.AreEqual("note", shape.Note);
            Assert.AreEqual(1, shape.X);
            Assert.AreEqual(2, shape.Y);
            Assert.AreEqual(3, shape.Height);
            Assert.AreEqual(4, shape.Width);
        }

        [TestMethod()]
        public void GetShapeTest()
        {
            Shape shape = factory.GetShape("Start", "note", "0", "0", "100", "100");
            Assert.AreEqual("Start", shape.GetShapeType());
            shape = factory.GetShape("Terminator", "note", "0", "0", "100", "100");
            Assert.AreEqual("Terminator", shape.GetShapeType());
            shape = factory.GetShape("Decision", "note", "0", "0", "100", "100");
            Assert.AreEqual("Decision", shape.GetShapeType());
            shape = factory.GetShape("Process", "note", "0", "0", "100", "100");
            Assert.AreEqual("Process", shape.GetShapeType());
            shape = factory.GetShape("", "note", "0", "0", "100", "100");
            Assert.IsNull(shape);
        }
    }
}