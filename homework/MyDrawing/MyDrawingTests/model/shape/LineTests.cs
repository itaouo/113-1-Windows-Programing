using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.model.shape;
using MyDrawing.Tests;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.model.shape.Tests
{
    [TestClass()]
    public class LineTests
    {
        private Line line;
        private Shape shape;
        [TestInitialize()]
        public void SetUp()
        {
            line = new Line("", 0, 0, 100, 100);
            shape = new Factory().GetShape("Process", "note", "0", "0", "100", "100");
        }


        [TestMethod()]
        public void LineTest()
        {
            line = new Line("", 0, 0, 100, 100);
            Assert.IsNotNull(line);
        }

        [TestMethod()]
        public void DrawTest()
        {
            GraphicsMock graphics = new GraphicsMock();
            line.Draw(graphics);
            line.StartPoint = (shape, 0);
            line.EndPoint = (shape, 1);
            line.Draw(graphics);
        }

        [TestMethod()]
        public void GetShapeTypeTest()
        {
            Assert.AreEqual("Line", line.GetShapeType());
        }

        [TestMethod()]
        public void IsPointInShapeTest()
        {
            Assert.IsFalse(line.IsPointInShape(0, 0));
        }

        [TestMethod()]
        public void GetShapeConnectionPointCoordinatesTest()
        {
            Assert.AreEqual((50, 0), line.GetShapeConnectionPointCoordinates(shape, 0));
            Assert.AreEqual((0, 50), line.GetShapeConnectionPointCoordinates(shape, 1));
            Assert.AreEqual((50, 100), line.GetShapeConnectionPointCoordinates(shape, 2));
            Assert.AreEqual((100, 50), line.GetShapeConnectionPointCoordinates(shape, 3));
            try { line.GetShapeConnectionPointCoordinates(shape, 4); } catch { }
        }
    }
}