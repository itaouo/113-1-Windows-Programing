using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.shape;
using MyDrawing.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.shape.Tests
{
    [TestClass()]
    public class TerminatorTests
    {
        private Terminator terminator;

        [TestInitialize()]
        public void SetUp()
        {
            terminator = new Terminator("1", 50, 60, 80, 70);
        }

        [TestMethod()]
        public void TerminatorTest()
        {
            terminator = new Terminator("1", 50, 60, 80, 70);
            Assert.IsNotNull(terminator);
        }

        [TestMethod()]
        public void GetShapeTypeTest()
        {
            Assert.AreEqual("Terminator", terminator.GetShapeType());
        }

        [TestMethod()]
        public void DrawTest()
        {
            terminator.Draw(new GraphicsMock());
            Terminator terminator2 = new Terminator("1", 0, 0, 0, 0);
            terminator2.Draw(new GraphicsMock());
        }

        [TestMethod()]
        public void IsPointInShapeTest()
        {
            Assert.IsTrue(terminator.IsPointInShape(85, 100));
        }
    }
}
