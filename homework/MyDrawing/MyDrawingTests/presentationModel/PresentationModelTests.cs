using MyDrawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using MyDrawing.shape;

namespace MyDrawing.Tests
{
    [TestClass()]
    public class PresentationModelTests
    {
        private PresentationModel presentationModel;

        [TestInitialize()]
        public void SetUp()
        {
            Factory factory = new Factory();
            Model model = new Model(factory);
            presentationModel = new PresentationModel(model);
            model.AddShape(factory.GetShape("Decision", "note", "50", "50", "50", "50"));
        }

        [TestMethod()]
        public void PresentationModelTest()
        {
            presentationModel = new PresentationModel(new Model(new Factory()));
            Assert.IsNotNull(presentationModel);
        }

        [TestMethod()]
        public void OnPropertyChangedTest()
        {
            presentationModel.OnPropertyChanged("test");
        }

        [TestMethod()]
        public void NotifyToolStripChangeTest()
        {
            presentationModel.NotifyToolStripChange();
        }

        [TestMethod()]
        public void NotifyToolStripChangeTestWithFormDataBinding()
        {
            FormMock formMock = new FormMock(presentationModel);
            presentationModel.NotifyToolStripChange();
        }

        [TestMethod()]
        public void NotifyDrawAreaChangeTest()
        {
            presentationModel.NotifyDrawAreaChange();
        }

        [TestMethod()]
        public void NotifyDrawAreaChangeTestWithFormDataBinding()
        {
            FormMock formMock = new FormMock(presentationModel);
            presentationModel.NotifyDrawAreaChange();
        }

        [TestMethod()]
        public void NotifyShapeLegalChangeTest()
        {
            presentationModel.NotifyShapeLegalChange();
        }

        [TestMethod()]
        public void NotifyShapeLegalChangeTestWithFormDataBinding()
        {
            FormMock formMock = new FormMock(presentationModel);
            presentationModel.NotifyShapeLegalChange();
        }

        [TestMethod()]
        public void NotifyShapeLegalChangeTestWithCompleteShape()
        {
            FormMock formMock = new FormMock(presentationModel);
            presentationModel.SetShapeNote("note");
            presentationModel.SetShapeType(0);
            presentationModel.SetShapeX("1");
            presentationModel.SetShapeY("1");
            presentationModel.SetShapeHeight("1");
            presentationModel.SetShapeWidth("1");
            presentationModel.NotifyShapeLegalChange();
        }

        [TestMethod()]
        public void NotifyTextDialogShow()
        {
            presentationModel.NotifyTextDialogShow();
            FormMock formMock = new FormMock(presentationModel);
            presentationModel.NotifyTextDialogShow();
        }

        [TestMethod()]
        public void NotifyTextPositionShow()
        {
            FormMock formMock = new FormMock(presentationModel);
            presentationModel.NotifyTextPositionShow();
        }

        [TestMethod()]
        public void EnterPointerStateTest()
        {
            presentationModel.EnterPointerState();
            Assert.IsTrue(presentationModel.IsPointerChecked);
        }

        [TestMethod()]
        public void EnterDrawingStateTest()
        {
            presentationModel.EnterDrawingState();
            Assert.IsFalse(presentationModel.IsPointerChecked);
        }

        [TestMethod()]
        public void EnterDrawingLineStateTest()
        {
            presentationModel.EnterDrawingLineState();
            Assert.IsFalse(presentationModel.IsPointerChecked);
        }

        [TestMethod()]
        public void DrawAreaMouseDownTest()
        {
            presentationModel.EnterPointerState();
            presentationModel.DrawAreaMouseDown(90, 80);
            Assert.IsTrue((90, 80) == presentationModel.pointerState.CursorStart);
            Assert.IsTrue(presentationModel.pointerState.IsCursorPressed);
            presentationModel.EnterDrawingState();
            presentationModel.DrawAreaMouseDown(70, 60);
            Assert.IsTrue((70, 60) == presentationModel.drawingState.CursorStart);
            Assert.IsTrue(presentationModel.drawingState.IsCursorPressed);
        }

        [TestMethod()]
        public void DrawAreaMouseMoveTest()
        {
            presentationModel.EnterPointerState();
            presentationModel.DrawAreaMouseDown(90, 80);
            presentationModel.DrawAreaMouseMove(9, 8);
            Assert.IsTrue((9, 8) == presentationModel.pointerState.CursorNow);
            presentationModel.EnterDrawingState();
            presentationModel.DrawAreaMouseDown(70, 60);
            presentationModel.DrawAreaMouseMove(7, 6);
            Assert.IsTrue((70, 60) == presentationModel.drawingState.CursorStart);
            Assert.IsTrue((7, 6) == presentationModel.drawingState.CursorNow);
        }

        [TestMethod()]
        public void DrawAreaMouseUpTest()
        {
            presentationModel.EnterPointerState();
            presentationModel.DrawAreaMouseDown(90, 80);
            presentationModel.DrawAreaMouseMove(70, 60);
            presentationModel.DrawAreaMouseUp(50, 40);
            Assert.IsFalse(presentationModel.pointerState.IsCursorPressed);
            presentationModel.EnterDrawingState();
            presentationModel.DrawAreaMouseDown(90, 80);
            presentationModel.DrawAreaMouseMove(70, 60);
            presentationModel.DrawAreaMouseUp(50, 40);
            Assert.IsFalse(presentationModel.drawingState.IsCursorPressed);
        }

        [TestMethod()]
        public void ToolStripClearButtonCheckedTest()
        {
            presentationModel.ToolStripClearButtonChecked();
            Assert.IsFalse(presentationModel.IsStartChecked);
            Assert.IsFalse(presentationModel.IsTerminatorChecked);
            Assert.IsFalse(presentationModel.IsDecisionChecked);
            Assert.IsFalse(presentationModel.IsProcessChecked);
            Assert.IsFalse(presentationModel.IsPointerChecked);
        }

        [TestMethod()]
        public void ToolStripButtonClickTest()
        {
            presentationModel.ToolStripButtonClick("Start");
            Assert.IsTrue(presentationModel.IsStartChecked);
            presentationModel.ToolStripButtonClick("Terminator");
            Assert.IsTrue(presentationModel.IsTerminatorChecked);
            presentationModel.ToolStripButtonClick("Decision");
            Assert.IsTrue(presentationModel.IsDecisionChecked);
            presentationModel.ToolStripButtonClick("Process");
            Assert.IsTrue(presentationModel.IsProcessChecked);
            presentationModel.ToolStripButtonClick("Pointer");
            Assert.IsTrue(presentationModel.IsPointerChecked);
            presentationModel.ToolStripButtonClick("Line");
            Assert.IsTrue(presentationModel.IsLineChecked);
            presentationModel.ToolStripButtonClick("test");
            Assert.IsFalse(presentationModel.IsStartChecked);
            Assert.IsFalse(presentationModel.IsTerminatorChecked);
            Assert.IsFalse(presentationModel.IsDecisionChecked);
            Assert.IsFalse(presentationModel.IsProcessChecked);
            Assert.IsFalse(presentationModel.IsPointerChecked);
        }

        [TestMethod()]
        public void DrawTest()
        {
            presentationModel.Draw(new GraphicsMock());
        }

        [TestMethod()]
        public void DrawTextTest()
        {
            Shape shape = new Start("note", 50, 50, 50, 50);
            presentationModel.DrawText(new GraphicsMock(), shape);
        }

        [TestMethod()]
        public void SetShapeTypeTest()
        {
            presentationModel.SetShapeType(-1);
            Assert.IsFalse(presentationModel.IsShapeTypeLegal);
            presentationModel.SetShapeType(0);
            Assert.IsTrue(presentationModel.IsShapeTypeLegal);
        }

        [TestMethod()]
        public void SetShapeNoteTest()
        {
            presentationModel.SetShapeNote("");
            Assert.IsFalse(presentationModel.IsShapeNoteLegal);
            presentationModel.SetShapeNote("note");
            Assert.IsTrue(presentationModel.IsShapeNoteLegal);
        }

        [TestMethod()]
        public void SetShapeXTest()
        {
            presentationModel.SetShapeX("a");
            Assert.IsFalse(presentationModel.IsShapeXLegal);
            presentationModel.SetShapeX("1");
            Assert.IsTrue(presentationModel.IsShapeXLegal);
        }

        [TestMethod()]
        public void SetShapeYTest()
        {
            presentationModel.SetShapeY("b");
            Assert.IsFalse(presentationModel.IsShapeYLegal);
            presentationModel.SetShapeY("1");
            Assert.IsTrue(presentationModel.IsShapeYLegal);
        }

        [TestMethod()]
        public void SetShapeHeightTest()
        {
            presentationModel.SetShapeHeight("c");
            Assert.IsFalse(presentationModel.IsShapeHeightLegal);
            presentationModel.SetShapeHeight("1");
            Assert.IsTrue(presentationModel.IsShapeHeightLegal);
        }

        [TestMethod()]
        public void SetShapeWidthTest()
        {
            presentationModel.SetShapeWidth("d");
            Assert.IsFalse(presentationModel.IsShapeWidthLegal);
            presentationModel.SetShapeWidth("1");
            Assert.IsTrue(presentationModel.IsShapeWidthLegal);
        }
        internal class FormMock
        {
            private PresentationModel presentationModel;

            public FormMock(PresentationModel presentationModel)
            {
                this.presentationModel = presentationModel;
                presentationModel.PresentationModelToolStripChanged += Foo;
                presentationModel.PresentationModelShapeLegalChanged += Foo;
                presentationModel.PresentationModelDrawAreaChanged += Foo;
                presentationModel.PresentationModeTextDialogChanged += Foo;
                presentationModel.PropertyChanged += Foo;
            }

            private void Foo(object sender, PropertyChangedEventArgs e)
            {
                Console.WriteLine("PresentationModelChanged");
            }

            private void Foo()
            {
                Console.WriteLine("PresentationModelChanged");
            }
        }
    }
}