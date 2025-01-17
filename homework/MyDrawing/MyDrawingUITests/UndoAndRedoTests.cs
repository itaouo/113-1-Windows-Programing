using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace MyDrawingUITests
{
    [TestClass()]
    public class UndoAndRedoTests
    {
        private Robot robot;

        [TestInitialize()]
        public void Initialize()
        {
            robot = new Robot();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            robot.CleanUp();
        }

        [TestMethod()]
        public void AddShapeTest()
        {
            robot.ClickButtonByName("DrawStart");
            robot.MouseClickAndReleaseInDrawArea(100, 100, 200, 200);
            robot.ClickButtonByName("Undo");
            robot.AssertDisplayDrawingDataGridViewLength(0);
            robot.ClickButtonByName("Redo");
            robot.AssertDisplayDrawingDataGridViewLength(1);
        }

        [TestMethod()]
        public void AddShapeByDataGridViewTest()
        {
            robot.SelectComboBoxBy("shapeComboBox", "Start");
            robot.InputTextBoxBy("noteTextBox", "start shape");
            robot.InputTextBoxBy("xTextBox", "100");
            robot.InputTextBoxBy("yTextBox", "100");
            robot.InputTextBoxBy("heightTextBox", "200");
            robot.InputTextBoxBy("widthTextBox", "200");
            robot.ClickButtonByName("新增");
            robot.ClickButtonByName("Undo");
            robot.AssertDisplayDrawingDataGridViewLength(0);
            robot.ClickButtonByName("Redo");
            robot.AssertDisplayDrawingDataGridViewLength(1);
        }

        [TestMethod()]
        public void AddLineTest()
        {
            robot.ClickButtonByName("DrawStart");
            robot.MouseClickAndReleaseInDrawArea(100, 20, 300, 80);

            robot.ClickButtonByName("DrawProcess");
            robot.MouseClickAndReleaseInDrawArea(100, 100, 300, 160);

            robot.ClickButtonByName("DrawLine");
            robot.MouseMove(200, 50);
            robot.MouseClickAndReleaseInDrawArea(200, 80, 200, 100);

            robot.ClickButtonByName("Undo");
            robot.AssertDisplayDrawingDataGridViewLength(2);
            robot.ClickButtonByName("Redo");
            robot.AssertDisplayDrawingDataGridViewLength(3);
        }

        [TestMethod()]
        public void DeleteShapeTest()
        {
            robot.ClickButtonByName("DrawStart");
            robot.MouseClickAndReleaseInDrawArea(100, 100, 200, 200);
            robot.ClickDeleteButtonBy(0);
            robot.ClickButtonByName("Undo");
            robot.AssertDisplayDrawingDataGridViewLength(1);
            robot.ClickButtonByName("Redo");
            robot.AssertDisplayDrawingDataGridViewLength(0);
        }

        [TestMethod()]
        public void MoveShapeTest()
        {
            robot.ClickButtonByName("DrawStart");
            robot.MouseClickAndReleaseInDrawArea(100, 100, 200, 200);
            robot.MouseClickAndReleaseInDrawArea(150, 150, 500, 500);
            robot.ClickButtonByName("Undo");
            robot.AssertDisplayDrawingDataGridViewRowDataByShape(0, new[] { "Start" }, new[] { 100, 100, 100, 100 });
            robot.ClickButtonByName("Redo");
            robot.AssertDisplayDrawingDataGridViewRowDataByShape(0, new[] { "Start" }, new[] { 450, 450, 100, 100 });
        }

        [TestMethod()]
        public void ChangeTextShapeTest()
        {
            robot.SelectComboBoxBy("shapeComboBox", "Start");
            robot.InputTextBoxBy("noteTextBox", "start shape");
            robot.InputTextBoxBy("xTextBox", "100");
            robot.InputTextBoxBy("yTextBox", "100");
            robot.InputTextBoxBy("heightTextBox", "100");
            robot.InputTextBoxBy("widthTextBox", "100");
            robot.ClickButtonByName("新增");

            robot.MousePress(150, 150);
            robot.MousePress(150, 135);
            robot.MousePress(150, 135);
            robot.InputTextBoxBy("changeNoteTextBox", "test note");
            robot.ClickButtonByName("Confirm");

            robot.ClickButtonByName("Undo");
            robot.AssertDisplayDrawingDataGridViewRowDataByShape(0, new[] { "Start", "start shape" }, new[] { 100, 100, 100, 100 });
            robot.ClickButtonByName("Redo");
            robot.AssertDisplayDrawingDataGridViewRowDataByShape(0, new[] { "Start", "test note" }, new[] { 100, 100, 100, 100 });
        }

        [TestMethod()]
        public void MoveTextShapeTest()
        {
            robot.ClickButtonByName("DrawStart");
            robot.MouseClickAndReleaseInDrawArea(100, 100, 200, 200);
            robot.MouseClickAndReleaseInDrawArea(150, 135, 200, 235);

            robot.ClickButtonByName("Undo");
            robot.ClickButtonByName("Redo");
            robot.AssertTextByAutomationId("textPositionLabel", "(50, 100)", "5");
        }
    }
}