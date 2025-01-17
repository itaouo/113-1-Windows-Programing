using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyDrawing.Tests
{
    [TestClass()]
    public class DrawingStateTests
    {
        private DrawingState drawingState;
        [TestInitialize()]
        public void SetUp()
        {
            Factory factory = new Factory();
            Model model = new Model(factory);
            PresentationModel presentationModel = new PresentationModel(model);
            presentationModel.ToolStripButtonClick("Start");
            PointerState pointerState = new PointerState(model, presentationModel);
            drawingState = new DrawingState(model, presentationModel, pointerState);
        }

        [TestMethod()]
        public void DrawingStateTest()
        {
            Assert.IsNotNull(drawingState);
        }

        [TestMethod()]
        public void InitializeTest()
        {
            drawingState.Initialize();
            Assert.IsFalse(drawingState.IsCursorPressed);
            Assert.AreEqual((-1, -1), drawingState.CursorStart);
            Assert.AreEqual((-1, -1), drawingState.CursorNow);
            Assert.AreEqual("", drawingState.TempShapeType);
        }

        [TestMethod()]
        public void DrawAreaMouseDownTest()
        {
            int x = 10;
            int y = 20;
            drawingState.DrawAreaMouseDown(x, y);
            Assert.IsTrue(drawingState.IsCursorPressed);
            Assert.AreEqual((x, y), drawingState.CursorStart);
        }

        [TestMethod()]
        public void DrawAreaMouseMoveTest()
        {
            int moveX = 30;
            int moveY = 40;
            drawingState.DrawAreaMouseMove(moveX, moveY);
            Assert.IsFalse(drawingState.IsCursorPressed);
            Assert.AreEqual((-1, -1), drawingState.CursorStart);
            Assert.AreEqual((-1, -1), drawingState.CursorNow);
        }

        [TestMethod()]
        public void DrawAreaMouseMoveTestAfterMouseDownInShape()
        {
            int startX = 10;
            int startY = 20;
            int moveX = 30;
            int moveY = 40;
            drawingState.DrawAreaMouseDown(startX, startY);
            drawingState.DrawAreaMouseMove(moveX, moveY);
            Assert.IsTrue(drawingState.IsCursorPressed);
            Assert.AreEqual((startX, startY), drawingState.CursorStart);
            Assert.AreEqual((moveX, moveY), drawingState.CursorNow);
        }

        [TestMethod()]
        public void DrawAreaMouseUpTest()
        {

            drawingState.DrawAreaMouseDown(10, 20);
            drawingState.DrawAreaMouseMove(20, 30);
            drawingState.DrawAreaMouseUp(20, 30);
            Assert.IsFalse(drawingState.IsCursorPressed);
            Assert.AreEqual((-1, -1), drawingState.CursorStart);
            Assert.AreEqual((-1, -1), drawingState.CursorNow);
            Assert.AreEqual("", drawingState.TempShapeType);
            Assert.IsNull(drawingState.TempShape);
        }

        [TestMethod()]
        public void DrawAreaMouseUpTestwhenTempShapeNull()
        {
            drawingState.DrawAreaMouseUp(10, 20);
            Assert.IsFalse(drawingState.IsCursorPressed);
            Assert.AreEqual((-1, -1), drawingState.CursorStart);
            Assert.AreEqual((-1, -1), drawingState.CursorNow);
            Assert.AreEqual("", drawingState.TempShapeType);
            Assert.IsNull(drawingState.TempShape);
        }

        [TestMethod()]
        public void DrawTest()
        {
            drawingState.Draw(new GraphicsMock());
        }

        [TestMethod()]
        public void DrawTestWithFormDataBinding()
        {
            drawingState.DrawAreaMouseDown(50, 50);
            drawingState.DrawAreaMouseMove(70, 90);
            drawingState.Draw(new GraphicsMock());
        }

        [TestMethod()]
        public void GetShapeCoordinates()
        {
            drawingState.DrawAreaMouseDown(50, 50);
            drawingState.DrawAreaMouseMove(0, 50);
            Assert.IsTrue((0, 50, 0, 50) == drawingState.GetShapeCoordinates());
            drawingState.DrawAreaMouseMove(20, 20);
            Assert.IsTrue((20, 20, 30, 30) == drawingState.GetShapeCoordinates());
            drawingState.DrawAreaMouseMove(20, 80);
            Assert.IsTrue((20, 50, 30, 30) == drawingState.GetShapeCoordinates());
            drawingState.DrawAreaMouseMove(80, 20);
            Assert.IsTrue((50, 20, 30, 30) == drawingState.GetShapeCoordinates());
            drawingState.DrawAreaMouseMove(80, 80);
            Assert.IsTrue((50, 50, 30, 30) == drawingState.GetShapeCoordinates());
        }

        [TestMethod()]
        public void SetTempShapeTest()
        {
            drawingState.DrawAreaMouseDown(50, 50);
            drawingState.DrawAreaMouseMove(70, 90);
            drawingState.SetTempShape();
            Assert.AreEqual("Start", drawingState.TempShape.GetShapeType());
            Assert.AreEqual(50, drawingState.TempShape.X);
            Assert.AreEqual(50, drawingState.TempShape.Y);
            Assert.AreEqual(20, drawingState.TempShape.Width);
            Assert.AreEqual(40, drawingState.TempShape.Height);
        }

        [TestMethod()]
        public void GenerateRandomStringTest()
        {
            String randomString = drawingState.GenerateRandomString();
            Assert.IsNotNull(randomString);
        }
    }

    internal class GraphicsMock : IGraphics
    {
        public void ClearAll()
        {

        }

        public void DrawArc(double x, double y, double width, double height, double startAngle, double sweepAngle)
        {

        }

        public void DrawColoredRectangle(double x, double y, double width, double height)
        {

        }

        public void DrawDragPoint(double x, double y)
        {

        }

        public void DrawEllipse(double x, double y, double width, double height)
        {

        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {

        }

        public void DrawPolygon((int x, int y)[] coordinates)
        {

        }

        public void DrawRectangle(double x, double y, double width, double height)
        {

        }

        public void DrawString(string text, double x, double y)
        {

        }

        public void DrawStrongerLine(double x1, double y1, double x2, double y2)
        {

        }

        public (float x, float y) MeasureAnchor(string text, int x, int y, int height, int width)
        {
            return (0, 0);
        }

        public (float x, float y) MeasureTextSize(string text)
        {
            return (100, 100);
        }
    }
}