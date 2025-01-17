using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace MyDrawingUITests
{
    [TestClass()]
    public class DrawShapeTests
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
        public void DrawButtonCheckedTest()
        {
            robot.ClickButtonByName("DrawStart");
            robot.ClickButtonByName("新增");
            robot.AssertChecked("DrawStart", true);
            robot.AssertChecked("DrawTerminator", false);
            robot.AssertChecked("DrawDecision", false);
            robot.AssertChecked("DrawProcess", false);
            robot.AssertChecked("Pointer", false);
            robot.AssertChecked("DrawLine", false);

            robot.ClickButtonByName("DrawTerminator");
            robot.ClickButtonByName("新增");
            robot.AssertChecked("DrawStart", false);
            robot.AssertChecked("DrawTerminator", true);
            robot.AssertChecked("DrawDecision", false);
            robot.AssertChecked("DrawProcess", false);
            robot.AssertChecked("Pointer", false);
            robot.AssertChecked("DrawLine", false);

            robot.ClickButtonByName("DrawDecision");
            robot.ClickButtonByName("新增");
            robot.AssertChecked("DrawStart", false);
            robot.AssertChecked("DrawTerminator", false);
            robot.AssertChecked("DrawDecision", true);
            robot.AssertChecked("DrawProcess", false);
            robot.AssertChecked("Pointer", false);
            robot.AssertChecked("DrawLine", false);

            robot.ClickButtonByName("DrawProcess");
            robot.ClickButtonByName("新增");
            robot.AssertChecked("DrawStart", false);
            robot.AssertChecked("DrawTerminator", false);
            robot.AssertChecked("DrawDecision", false);
            robot.AssertChecked("DrawProcess", true);
            robot.AssertChecked("Pointer", false);
            robot.AssertChecked("DrawLine", false);

            robot.ClickButtonByName("Pointer");
            robot.ClickButtonByName("新增");
            robot.AssertChecked("DrawStart", false);
            robot.AssertChecked("DrawTerminator", false);
            robot.AssertChecked("DrawDecision", false);
            robot.AssertChecked("DrawProcess", false);
            robot.AssertChecked("Pointer", true);
            robot.AssertChecked("DrawLine", false);

            robot.ClickButtonByName("DrawLine");
            robot.ClickButtonByName("新增");
            robot.AssertChecked("DrawStart", false);
            robot.AssertChecked("DrawTerminator", false);
            robot.AssertChecked("DrawDecision", false);
            robot.AssertChecked("DrawProcess", false);
            robot.AssertChecked("Pointer", false);
            robot.AssertChecked("DrawLine", true);
        }

        [TestMethod()]
        public void DrawShapeTest()
        {
            robot.ClickButtonByName("DrawStart");
            robot.MouseClickAndReleaseInDrawArea(100, 100, 200, 200);
            robot.AssertDisplayDrawingDataGridViewRowDataByShape(0, new[] {"Start"}, new[] { 100, 100, 100, 100 });

            robot.ClickButtonByName("DrawDecision");
            robot.MouseClickAndReleaseInDrawArea(100, 300, 200, 400);
            robot.AssertDisplayDrawingDataGridViewRowDataByShape(1, new[] { "Decision" }, new[] { 100, 300, 100, 100 });

            robot.ClickButtonByName("DrawTerminator");
            robot.MouseClickAndReleaseInDrawArea(300, 100, 400, 200);
            robot.AssertDisplayDrawingDataGridViewRowDataByShape(2, new[] { "Terminator" }, new[] { 300, 100, 100, 100 });

            robot.ClickButtonByName("DrawProcess");
            robot.MouseClickAndReleaseInDrawArea(300, 300, 400, 400);
            robot.AssertDisplayDrawingDataGridViewRowDataByShape(3, new[] { "Process" }, new[] { 300, 300, 100, 100 });

            robot.ClickButtonByName("DrawLine");
            robot.MouseMove(150, 150);
            robot.MouseClickAndReleaseInDrawArea(200, 150, 300, 150);
            robot.AssertDisplayDrawingDataGridViewRowDataByShape(4, new[] { "Line" }, new[] { 200, 150, 300, 150 });
        }
    }
}