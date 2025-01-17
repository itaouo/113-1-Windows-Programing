using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace MyDrawingUITests
{
    [TestClass()]
    public class BasicTests
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
        public void ToolStripButtonPressedTest()
        {
            robot.ClickButtonByName("DrawStart");
            robot.ClickButtonByName("DrawTerminator");
            robot.ClickButtonByName("DrawDecision");
            robot.ClickButtonByName("DrawProcess");
            robot.ClickButtonByName("Pointer");
            robot.ClickButtonByName("DrawLine");
            robot.ClickButtonByName("Undo");
            robot.ClickButtonByName("Redo");
            robot.ClickButtonByName("新增");
            robot.ClickButtonByName("Save");
            robot.ClickButtonByName("存檔(S)");
            robot.ClickButtonByName("Load");
            robot.ClickButtonByName("開啟(O)");
        }

        [TestMethod()]
        public void ComboBoxSelectedTest()
        {
            robot.SelectComboBoxBy("shapeComboBox", "Start");
            robot.SelectComboBoxBy("shapeComboBox", "Terminator");
            robot.SelectComboBoxBy("shapeComboBox", "Decision");
            robot.SelectComboBoxBy("shapeComboBox", "Process");
        }

        [TestMethod()]
        public void TextBoxInputTest()
        {
            robot.InputTextBoxBy("noteTextBox", "test");
            robot.InputTextBoxBy("xTextBox", "123");
            robot.InputTextBoxBy("yTextBox", "456");
            robot.InputTextBoxBy("heightTextBox", "789");
            robot.InputTextBoxBy("widthTextBox", "0");
            
        }

        [TestMethod()]
        public void DeleteButtonTest()
        {
            robot.SelectComboBoxBy("shapeComboBox", "Start");
            robot.InputTextBoxBy("noteTextBox", "test");
            robot.InputTextBoxBy("xTextBox", "123");
            robot.InputTextBoxBy("yTextBox", "456");
            robot.InputTextBoxBy("heightTextBox", "789");
            robot.InputTextBoxBy("widthTextBox", "0");
            robot.ClickButtonByName("新增");
            robot.ClickButtonByName("新增");
            robot.ClickButtonByName("新增");
            robot.ClickDeleteButtonBy(0);
        }

        [TestMethod()]
        public void TouchScreenTest() {
            robot.ClickButtonByName("DrawStart");
            robot.MouseScrollInDrawArea(100, 200, 300, 400);
            robot.Wait(1000);
        }
    }
}