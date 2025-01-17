using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.Tests;

namespace MyDrawing.state.Tests
{
    [TestClass()]
    public class DrawingLineStateTests
    {
        private DrawingLineState drawingLineState;

        [TestInitialize()]
        public void SetUp()
        {
            Factory factory = new Factory();
            Model model = new Model(factory);
            model.AddShape(factory.GetShape("Process", "note", "0", "0", "100", "100"));
            PresentationModel presentationModel = new PresentationModel(model);
            drawingLineState = new DrawingLineState(model, presentationModel);
        }

        [TestMethod()]
        public void DrawLineStateTest()
        {
            Assert.IsNotNull(drawingLineState);
        }

        [TestMethod()]
        public void InitializeTest()
        {
            drawingLineState.Initialize();
            Assert.IsNull(drawingLineState.SelectedShape);
            Assert.IsNull(drawingLineState.TempLine);
        }

        [TestMethod()]
        public void DrawAreaMouseDownTest()
        {
            drawingLineState.DrawAreaMouseDown(200, 200);
            Assert.IsNull(drawingLineState.SelectedShape);
            Assert.IsNull(drawingLineState.TempLine);
        }

        [TestMethod()]
        public void DrawAreaMouseDownTestWithShape()
        {
            drawingLineState.DrawAreaMouseDown(50, 0);
            Assert.IsNotNull(drawingLineState.SelectedShape);
            Assert.AreEqual(0, drawingLineState.CursorInShapeConnectionPoint(50, 0));
            Assert.IsNotNull(drawingLineState.TempLine);
        }

        [TestMethod()]
        public void DrawAreaMouseMoveTest()
        {
            drawingLineState.DrawAreaMouseMove(200, 200);
            Assert.IsNull(drawingLineState.SelectedShape);
        }

        [TestMethod()]
        public void DrawAreaMouseMoveTestWithSelectedShape()
        {
            drawingLineState.DrawAreaMouseDown(50, 50);
            drawingLineState.DrawAreaMouseMove(200, 200);
            Assert.IsNull(drawingLineState.SelectedShape);
            drawingLineState.DrawAreaMouseDown(50, 50);
            drawingLineState.DrawAreaMouseMove(0, 50);
            Assert.IsNotNull(drawingLineState.SelectedShape);
        }

        [TestMethod()]
        public void DrawAreaMouseMoveTestWithTempShape()
        {
            drawingLineState.DrawAreaMouseDown(0, 50);
            drawingLineState.DrawAreaMouseMove(200, 200);
            Assert.IsNotNull(drawingLineState.TempLine);
        }

        [TestMethod()]
        public void DrawAreaMouseMoveTestWithoutShape()
        {
            drawingLineState.DrawAreaMouseMove(50, 50);
            Assert.IsNotNull(drawingLineState.SelectedShape);
        }

        [TestMethod()]
        public void DrawAreaMouseMoveTestWhenCursorInShape()
        {
            drawingLineState.DrawAreaMouseMove(50, 50);
            Assert.IsNotNull(drawingLineState.SelectedShape);
        }

        [TestMethod()]
        public void DrawAreaMouseUpTest()
        {
            drawingLineState.DrawAreaMouseDown(0, 50);
            drawingLineState.DrawAreaMouseUp(50, 0);
            drawingLineState.DrawAreaMouseDown(0, 50);
            drawingLineState.DrawAreaMouseUp(0, 0);
            Assert.IsNull(drawingLineState.SelectedShape);
            Assert.IsNull(drawingLineState.TempLine);
        }

        [TestMethod()]
        public void DrawTest()
        {
            GraphicsMock mock = new GraphicsMock();
            drawingLineState.Draw(mock);
        }

        [TestMethod()]
        public void DrawTestWithShape()
        {
            drawingLineState.DrawAreaMouseDown(50, 50);
            GraphicsMock mock = new GraphicsMock();
            drawingLineState.Draw(mock);
        }

        [TestMethod()]
        public void DrawTestWithTempLine()
        {
            drawingLineState.DrawAreaMouseDown(0, 50);
            drawingLineState.DrawAreaMouseMove(200, 200);
            GraphicsMock mock = new GraphicsMock();
            drawingLineState.Draw(mock);
        }

        [TestMethod()]
        public void CursorInShapeConnectionPointTest()
        {
            drawingLineState.DrawAreaMouseDown(50, 50);
            Assert.IsNotNull(drawingLineState.SelectedShape);
            Assert.AreEqual(0, drawingLineState.CursorInShapeConnectionPoint(50, 0));
            Assert.AreEqual(1, drawingLineState.CursorInShapeConnectionPoint(0, 50));
            Assert.AreEqual(2, drawingLineState.CursorInShapeConnectionPoint(50, 100));
            Assert.AreEqual(3, drawingLineState.CursorInShapeConnectionPoint(100, 50));
        }

        [TestMethod()]
        public void IsCursorInDrawPointTest()
        {
            Assert.IsTrue(drawingLineState.IsCursorInDrawPoint(30, 40, 30, 40));
            Assert.IsFalse(drawingLineState.IsCursorInDrawPoint(30, 40, 50, 60));
        }
    }
}