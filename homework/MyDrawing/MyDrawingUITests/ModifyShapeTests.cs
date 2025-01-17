using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace MyDrawingUITests
{
    [TestClass()]
    public class ModifyShapeTests
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
        public void DragShapeTest()
        {
            robot.ClickButtonByName("DrawStart");
            robot.MouseClickAndReleaseInDrawArea(100, 100, 200, 200);

            robot.MouseClickAndReleaseInDrawArea(150, 150, 250, 300);
            robot.AssertDisplayDrawingDataGridViewRowDataByShape(0, new[] { "Start" }, new[] { 200, 250, 100, 100 });
        }

        [TestMethod()]
        public void DragTextTest()
        {
            robot.ClickButtonByName("DrawStart");
            robot.MouseClickAndReleaseInDrawArea(100, 100, 200, 200);
            robot.MouseClickAndReleaseInDrawArea(150, 135, 200, 235);
            robot.AssertTextByAutomationId("textPositionLabel", "(50, 100)", "5");
        }

        [TestMethod()]
        public void ModifyTextTest()
        {
            robot.ClickButtonByName("DrawStart");
            robot.MouseClickAndReleaseInDrawArea(100, 100, 200, 200);

            robot.MousePress(150, 135);
            robot.MousePress(150, 135);

            robot.InputTextBoxBy("changeNoteTextBox", "start shape");
            robot.ClickButtonByName("Confirm");

            robot.AssertDisplayDrawingDataGridViewRowDataByShape(0, new[] { "Start", "start shape" }, new[] { 100, 100, 100, 100 });
        }
    }
}