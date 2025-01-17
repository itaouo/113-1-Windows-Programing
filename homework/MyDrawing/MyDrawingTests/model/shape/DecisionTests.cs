using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.Tests;

namespace MyDrawing.shape.Tests
{
    [TestClass()]
    public class DecisionTests
    {
        private Decision decision;

        [TestInitialize]
        public void SetUp()
        {
            decision = new Decision("1", 50, 60, 80, 70);
        }

        [TestMethod()]
        public void DecisionTest()
        {
            decision = new Decision("1", 50, 60, 80, 70);
            Assert.IsNotNull(decision);
        }

        [TestMethod()]
        public void GetShapeTypeTest()
        {
            Assert.AreEqual("Decision", decision.GetShapeType());
        }

        [TestMethod()]
        public void DrawTest()
        {
            decision.Draw(new GraphicsMock());
        }

        [TestMethod()]
        public void IsPointInShapeTest()
        {
            Assert.IsTrue(decision.IsPointInShape(85, 100));
        }
    }
}