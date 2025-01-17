using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.Tests;

namespace MyDrawing.shape.Tests
{
    [TestClass()]
    public class ProcessTests
    {
        private Process process;

        [TestInitialize()]
        public void SetUp()
        {
            process = new Process("1", 50, 60, 80, 70);
        }

        [TestMethod()]
        public void ProcessTest()
        {
            process = new Process("1", 50, 60, 80, 70);
            Assert.IsNotNull(process);
        }

        [TestMethod()]
        public void GetShapeTypeTest()
        {
            Assert.AreEqual("Process", process.GetShapeType());
        }

        [TestMethod()]
        public void DrawTest()
        {
            process.Draw(new GraphicsMock());
        }

        [TestMethod()]
        public void IsPointInShapeTest()
        {
            Assert.IsTrue(process.IsPointInShape(85, 100));
        }
    }
}