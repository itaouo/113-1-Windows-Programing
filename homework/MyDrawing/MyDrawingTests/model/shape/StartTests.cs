using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.Tests;

namespace MyDrawing.shape.Tests
{
    [TestClass()]
    public class StartTests
    {
        private Start start;
        [TestInitialize()]
        public void SetUp()
        {
            start = new Start("1", 50, 60, 80, 70);
        }

        [TestMethod()]
        public void StartTest()
        {
            start = new Start("1", 50, 60, 80, 70);
            Assert.IsNotNull(start);
        }

        [TestMethod()]
        public void GetShapeTypeTest()
        {
            start.GetShapeType();
        }

        [TestMethod()]
        public void DrawTest()
        {
            start.Draw(new GraphicsMock());
        }

        [TestMethod()]
        public void IsPointInShapeTest()
        {
            Assert.IsTrue(start.IsPointInShape(85, 100));
        }
    }
}