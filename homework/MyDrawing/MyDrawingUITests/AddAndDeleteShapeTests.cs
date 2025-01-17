using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace MyDrawingUITests
{
    [TestClass()]
    public class AddAndDeleteShapeTests
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
            robot.SelectComboBoxBy("shapeComboBox", "Start");
            robot.InputTextBoxBy("noteTextBox", "start shape");
            robot.InputTextBoxBy("xTextBox", "100");
            robot.InputTextBoxBy("yTextBox", "100");
            robot.InputTextBoxBy("heightTextBox", "200");
            robot.InputTextBoxBy("widthTextBox", "200");
            robot.ClickButtonByName("新增");
            robot.AssertDisplayDrawingDataGridViewRowDataByShape(0, new[] { "Start", "start shape" }, new[] { 100, 100, 100, 100 });

            robot.SelectComboBoxBy("shapeComboBox", "Decision");
            robot.InputTextBoxBy("noteTextBox", "decision shape");
            robot.InputTextBoxBy("xTextBox", "100");
            robot.InputTextBoxBy("yTextBox", "300");
            robot.InputTextBoxBy("heightTextBox", "200");
            robot.InputTextBoxBy("widthTextBox", "400");
            robot.ClickButtonByName("新增");
            robot.AssertDisplayDrawingDataGridViewRowDataByShape(1, new[] { "Decision", "decision shape" }, new[] { 100, 300, 100, 100 });

            robot.SelectComboBoxBy("shapeComboBox", "Terminator");
            robot.InputTextBoxBy("noteTextBox", "terminator shape");
            robot.InputTextBoxBy("xTextBox", "300");
            robot.InputTextBoxBy("yTextBox", "100");
            robot.InputTextBoxBy("heightTextBox", "400");
            robot.InputTextBoxBy("widthTextBox", "200");
            robot.ClickButtonByName("新增");
            robot.AssertDisplayDrawingDataGridViewRowDataByShape(2, new[] { "Terminator", "terminator shape" }, new[] { 300, 100, 100, 100 });

            robot.SelectComboBoxBy("shapeComboBox", "Process");
            robot.InputTextBoxBy("noteTextBox", "process shape");
            robot.InputTextBoxBy("xTextBox", "300");
            robot.InputTextBoxBy("yTextBox", "300");
            robot.InputTextBoxBy("heightTextBox", "400");
            robot.InputTextBoxBy("widthTextBox", "400");
            robot.MouseClickAndReleaseInDrawArea(300, 300, 400, 400);
            robot.ClickButtonByName("新增");
            robot.AssertDisplayDrawingDataGridViewRowDataByShape(3, new[] { "Process", "process shape" }, new[] { 300, 300, 100, 100 });
        }

        [TestMethod()]
        public void DeleteShapeTest()
        {
            robot.SelectComboBoxBy("shapeComboBox", "Start");
            robot.InputTextBoxBy("noteTextBox", "start shape0");
            robot.InputTextBoxBy("xTextBox", "100");
            robot.InputTextBoxBy("yTextBox", "100");
            robot.InputTextBoxBy("heightTextBox", "200");
            robot.InputTextBoxBy("widthTextBox", "200");
            robot.ClickButtonByName("新增");

            robot.InputTextBoxBy("noteTextBox", "start shape1");
            robot.ClickButtonByName("新增");

            robot.InputTextBoxBy("noteTextBox", "start shape2");
            robot.ClickButtonByName("新增");

            robot.InputTextBoxBy("noteTextBox", "start shape3");
            robot.ClickButtonByName("新增");

            robot.ClickDeleteButtonBy(2);
            robot.AssertDisplayDrawingDataGridViewRowDataByShape(0, new[] { "Start", "start shape0" }, new[] { 100, 100, 100, 100 });
            robot.AssertDisplayDrawingDataGridViewRowDataByShape(1, new[] { "Start", "start shape1" }, new[] { 100, 100, 100, 100 });
            robot.AssertDisplayDrawingDataGridViewRowDataByShape(2, new[] { "Start", "start shape3" }, new[] { 100, 100, 100, 100 });

        }
    }
}