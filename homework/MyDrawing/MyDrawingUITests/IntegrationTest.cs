using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace MyDrawingUITests
{
    [TestClass()]
    public class IntergrationTests
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
        public void IntergrationTest()
        {
            string filePath1 = "flowchart_" + GenerateRandomString();
            string filePath2 = "flowchart_" + GenerateRandomString();

            robot.ClickButtonByName("DrawStart");
            robot.MouseClickAndReleaseInDrawArea(100, 20, 300, 80);
            robot.MousePress(200, 35);
            robot.MousePress(200, 35);
            robot.InputTextBoxBy("changeNoteTextBox", "write homework");
            robot.ClickButtonByName("Confirm");
            robot.MousePress(50, 50);

            robot.ClickButtonByName("DrawProcess");
            robot.MouseClickAndReleaseInDrawArea(100, 100, 300, 160);
            robot.MousePress(200, 115);
            robot.MousePress(200, 115);
            robot.InputTextBoxBy("changeNoteTextBox", "use chatgpt");
            robot.ClickButtonByName("Confirm");
            robot.MousePress(50, 50);

            robot.ClickButtonByName("DrawTerminator");
            robot.MouseClickAndReleaseInDrawArea(100, 180, 300, 240);
            robot.MousePress(200, 195);
            robot.MousePress(200, 195);
            robot.InputTextBoxBy("changeNoteTextBox", "submit homework");
            robot.ClickButtonByName("Confirm");
            robot.MousePress(50, 50);

            robot.ClickButtonByName("DrawLine");
            robot.MouseMove(200, 50);
            robot.MouseClickAndReleaseInDrawArea(200, 80, 200, 100);

            robot.ClickButtonByName("DrawLine");
            robot.MouseMove(200, 130);
            robot.MouseClickAndReleaseInDrawArea(200, 160, 200, 180);

            robot.AssertDisplayDrawingDataGridViewLength(5);

            robot.ClickButtonByName("Save");
            robot.InputTextBox(filePath1);
            robot.ClickButtonByName("存檔(S)");
            robot.AssertEnabled("Save", false);

            robot.ClickButtonByName("Undo");
            robot.AssertDisplayDrawingDataGridViewLength(4);

            robot.ClickDeleteButtonBy(2);
            robot.AssertDisplayDrawingDataGridViewLength(3);

            robot.MousePress(200, 115);
            robot.MousePress(200, 115);
            robot.InputTextBoxBy("changeNoteTextBox", "design by myself");
            robot.ClickButtonByName("Confirm");
            robot.MousePress(50, 50);

            robot.SelectComboBoxBy("shapeComboBox", "Process");
            robot.InputTextBoxBy("noteTextBox", "write tests");
            robot.InputTextBoxBy("xTextBox", "100");
            robot.InputTextBoxBy("yTextBox", "180");
            robot.InputTextBoxBy("heightTextBox", "60");
            robot.InputTextBoxBy("widthTextBox", "200");
            robot.ClickButtonByName("新增");

            robot.SelectComboBoxBy("shapeComboBox", "Decision");
            robot.InputTextBoxBy("noteTextBox", "finish tests?");
            robot.InputTextBoxBy("yTextBox", "260");
            robot.ClickButtonByName("新增");

            robot.SelectComboBoxBy("shapeComboBox", "Process");
            robot.InputTextBoxBy("noteTextBox", "write production code");
            robot.InputTextBoxBy("yTextBox", "340");
            robot.ClickButtonByName("新增");

            robot.SelectComboBoxBy("shapeComboBox", "Terminator");
            robot.InputTextBoxBy("noteTextBox", "submit homework");
            robot.InputTextBoxBy("yTextBox", "420");
            robot.ClickButtonByName("新增");

            robot.ClickButtonByName("DrawLine");
            robot.MouseMove(200, 50);
            robot.MouseClickAndReleaseInDrawArea(200, 80, 200, 100);

            robot.ClickButtonByName("DrawLine");
            robot.MouseMove(200, 130);
            robot.MouseClickAndReleaseInDrawArea(200, 160, 200, 180);

            robot.ClickButtonByName("DrawLine");
            robot.MouseMove(200, 210);
            robot.MouseClickAndReleaseInDrawArea(200, 240, 200, 260);

            robot.ClickButtonByName("DrawLine");
            robot.MouseMove(200, 290);
            robot.MouseClickAndReleaseInDrawArea(200, 320, 200, 340);

            robot.ClickButtonByName("DrawLine");
            robot.MouseMove(200, 370);
            robot.MouseClickAndReleaseInDrawArea(200, 400, 200, 420);

            robot.ClickButtonByName("DrawTerminator");
            robot.MouseClickAndReleaseInDrawArea(350, 260, 550, 320);
            robot.MousePress(450, 275);
            robot.MousePress(450, 275);
            robot.InputTextBoxBy("changeNoteTextBox", "give up");
            robot.ClickButtonByName("Confirm");

            robot.ClickButtonByName("DrawLine");
            robot.MouseMove(200, 290);
            robot.MouseClickAndReleaseInDrawArea(300, 290, 350, 290);

            robot.AssertDisplayDrawingDataGridViewLength(12);

            robot.MouseClickAndReleaseInDrawArea(200, 435, 150, 450);
            robot.MouseClickAndReleaseInDrawArea(200, 435, 150, 450);

            robot.ClickButtonByName("Load");
            robot.ClickButtonByName("另存新檔");
            robot.InputTextBox(filePath1);
            robot.ClickButtonByName("開啟(O)");
            robot.AssertDisplayDrawingDataGridViewLength(5);
        }

        public string GenerateRandomString()
        {
            Random random = new Random();
            int length = random.Next(3, 11);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            char[] stringChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new string(stringChars);
        }
    }
}