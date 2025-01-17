using MyDrawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.shape;

namespace MyDrawing.Tests
{
    [TestClass()]
    public class PointerStateTests
    {
        private PointerState pointerState;
        [TestInitialize()]
        public void SetUp()
        {
            Factory factory = new Factory();
            Model model = new Model(factory);
            model.AddShape(factory.GetShape("Start", "note", "0", "0", "100", "100"));
            PresentationModel presentationModel = new PresentationModel(model);
            pointerState = new PointerState(model, presentationModel);
            pointerState.Initialize();
        }

        [TestMethod()]
        public void PointerStateTest()
        {
            pointerState.Initialize();
            Assert.IsNotNull(pointerState);
        }

        [TestMethod()]
        public void InitializeTest()
        {
            pointerState.Initialize();
            Assert.IsFalse(pointerState.IsCursorPressed);
            Assert.IsNull(pointerState.SelectedShape);
        }

        [TestMethod()]
        public void InitializeTestWithShape()
        {
            Shape start = new Start("note", 0, 0, 0, 0);
            pointerState.Initialize(start);
            Assert.IsFalse(pointerState.IsCursorPressed);
            Assert.AreEqual(start, pointerState.SelectedShape);
        }

        [TestMethod()]
        public void DrawAreaMouseDownTest()
        {
            pointerState.DrawAreaMouseDown(101, 101);
            Assert.IsFalse(pointerState.IsCursorPressed);
        }

        [TestMethod()]
        public void DrawAreaMouseDownTestWhenCursorInShape()
        {
            pointerState.DrawAreaMouseDown(60, 60);
            Assert.IsTrue(pointerState.IsCursorPressed);
        }

        [TestMethod()]
        public void DrawAreaMouseDownTestWhenCursorInDragPoint()
        {
            pointerState.DrawAreaMouseDown(60, 60);
            pointerState.DrawAreaMouseDown(50, 50);
            Assert.IsTrue(pointerState.IsCursorPressed);
            Assert.IsTrue(pointerState.IsCursorInDragPoint);
        }

        [TestMethod()]
        public void DrawAreaMouseMoveTest()
        {
            pointerState.DrawAreaMouseMove(0, 0);
            Assert.IsFalse(pointerState.IsCursorPressed);
        }

        [TestMethod()]
        public void DrawAreaMouseMoveTestWhenChooseShape()
        {
            pointerState.DrawAreaMouseDown(60, 60);
            pointerState.DrawAreaMouseMove(20, 20);
            Assert.IsTrue(pointerState.IsCursorPressed);
            Assert.AreEqual(-40, pointerState.SelectedShape.X);
            Assert.AreEqual(-40, pointerState.SelectedShape.Y);
        }

        [TestMethod()]
        public void DrawAreaMouseMoveTestWhenChooseDragPoint()
        {
            pointerState.DrawAreaMouseDown(60, 60);
            pointerState.DrawAreaMouseDown(50, 50);
            pointerState.DrawAreaMouseMove(20, 20);
            Assert.IsTrue(pointerState.IsCursorPressed);
            Assert.AreEqual(-30, pointerState.SelectedShape.TextOffsetX);
            Assert.AreEqual(-30, pointerState.SelectedShape.TextOffsetY);
        }

        [TestMethod()]
        public void DrawAreaMouseUpTest()
        {
            pointerState.DrawAreaMouseUp(0, 0);
            Assert.IsFalse(pointerState.IsCursorPressed);
        }

        [TestMethod()]
        public void DrawAreaMouseUpTestInDragPoint()
        {
            pointerState.DrawAreaMouseDown(50, 50);
            Assert.IsFalse(pointerState.IsCursorPressDragPointOnce);
            Assert.IsTrue(pointerState.IsCursorPressed);
            Assert.IsTrue(pointerState.IsCursorInDragPoint);
            pointerState.DrawAreaMouseMove(30, 30);
            pointerState.DrawAreaMouseUp(0, 0);
            Assert.IsFalse(pointerState.IsCursorPressDragPointOnce);
        }

        [TestMethod()]
        public void DrawAreaMouseUpTestInDragPointTwice()
        {
            pointerState.DrawAreaMouseDown(50, 50);
            pointerState.DrawAreaMouseUp(50, 50);
            pointerState.DrawAreaMouseDown(50, 50);
            pointerState.DrawAreaMouseUp(50, 50);
            Assert.IsFalse(pointerState.IsCursorPressed);
        }

        [TestMethod()]
        public void DrawTest()
        {
            pointerState.Draw(new GraphicsMock());
        }

        [TestMethod()]
        public void DrawTestWithFormDataBinding()
        {
            pointerState.DrawAreaMouseDown(50, 50);
            pointerState.Draw(new GraphicsMock());
        }

        [TestMethod()]
        public void IsPointInDrawPointTest()
        {
            pointerState.DrawAreaMouseDown(70, 70); // 選中預設 Start
            Assert.IsFalse(pointerState.IsPointInDrawPoint(60, 60));
            Assert.IsTrue(pointerState.IsPointInDrawPoint(50, 50));
        }

        [TestMethod()]
        public void GetTextAnchorTest()
        {
            pointerState.DrawAreaMouseDown(70, 70); // 選中預設 Start
            Assert.AreEqual(50, pointerState.GetTextAnchor().textAnchorX);
            Assert.AreEqual(50, pointerState.GetTextAnchor().textAnchorY);
        }

        [TestMethod()]
        public void ChangeShapeTextTest()
        {
            pointerState.DrawAreaMouseDown(50, 50);
            pointerState.ChangeShapeText("text");
            Assert.AreEqual("text", pointerState.SelectedShape.Note);
        }
    }
}