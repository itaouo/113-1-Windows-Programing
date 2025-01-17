using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Management.Instrumentation;

namespace MyDrawingUITests
{
    [TestClass()]
    public class SaveAndLoadTests
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
        public void SaveAndLoadTest()
        {
            string fileName = GenerateRandomString();

            robot.ClickButtonByName("DrawStart");
            robot.MouseClickAndReleaseInDrawArea(100, 100, 200, 200);
            robot.ClickButtonByName("DrawTerminator");
            robot.MouseClickAndReleaseInDrawArea(300, 100, 400, 200);

            robot.ClickButtonByName("DrawLine");
            robot.MouseMove(150, 150);
            robot.MouseClickAndReleaseInDrawArea(200, 150, 300, 150);

            robot.ClickButtonByName("Save");
            robot.InputTextBox(fileName);
            robot.ClickButtonByName("存檔(S)");
            robot.AssertEnabled("Save", false);

            robot.ClickDeleteButtonBy(1);
            robot.AssertDisplayDrawingDataGridViewLength(2);

            robot.AssertEnabled("Save", true);

            robot.Wait(1000);
            robot.ClickButtonByName("Load");
            robot.ClickButtonByName("另存新檔");
            robot.InputTextBox(fileName);
            robot.ClickButtonByName("開啟(O)");
            robot.AssertDisplayDrawingDataGridViewLength(3);
        }

        [TestMethod()]
        public void AutoSaveTest()
        {
            robot.ClickButtonByName("DrawStart");
            robot.MouseClickAndReleaseInDrawArea(100, 100, 200, 200);

            robot.AssertTextByAutomationId("formLabel", "MyDrawing (Auto Saving...)", 30);
            string fileDirectory = FileHandler.Instance.GetAutoSaveFilePath();

            robot.ClickButtonByName("DrawTerminator");
            robot.MouseClickAndReleaseInDrawArea(300, 100, 400, 200);
            robot.Wait(30000);

            Assert.IsTrue(File.Exists(fileDirectory));
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