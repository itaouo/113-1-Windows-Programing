using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.shape;

namespace MyDrawing.Tests
{
    [TestClass()]
    public class ShapeTests
    {
        private Shape start;
        private Shape terminator;
        private Shape decision;
        private Shape process;
        [TestInitialize()]
        public void SetUp()
        {
            start = new Start("note", 50, 60, 80, 70);
            terminator = new Terminator("note", 50, 60, 80, 70);
            decision = new Decision("note", 50, 60, 80, 70);
            process = new Process("note", 50, 60, 80, 70);
        }

        [TestMethod()]
        public void GetShapeTypeTest()
        {
            Assert.AreEqual("Start", start.GetShapeType());
            Assert.AreEqual("Terminator", terminator.GetShapeType());
            Assert.AreEqual("Decision", decision.GetShapeType());
            Assert.AreEqual("Process", process.GetShapeType());
        }

        [TestMethod()]
        public void DrawTest()
        {
            start.Draw(new GraphicsMock());
            terminator.Draw(new GraphicsMock());
            decision.Draw(new GraphicsMock());
            process.Draw(new GraphicsMock());
        }

        [TestMethod()]
        public void IsPointInShapeTest()
        {
            Assert.IsTrue(start.IsPointInShape(85, 100));
            Assert.IsTrue(terminator.IsPointInShape(85, 100));
            Assert.IsTrue(decision.IsPointInShape(85, 100));
            Assert.IsTrue(process.IsPointInShape(85, 100));
        }
    }
}