using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Windows.Input;
using System.Windows.Forms;
using OpenQA.Selenium.Support.UI;
using Keys = OpenQA.Selenium.Keys;
using System.IO;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace MyDrawingUITests
{
    public class Robot
    {
        private AppiumDriver<WindowsElement> _driver;
        private Dictionary<string, string> _windowHandles;
        private string _root;

        private const string CONTROL_NOT_FOUND_EXCEPTION = "The specific control is not found!!";
        private const string WIN_APP_DRIVER_URI = "http://127.0.0.1:4723";
        private const string ROOT = "MyDrawing";
        private const string PROJECT_NAME = "MyDrawing";

        // constructor
        public Robot()
        {
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            string targetAppPath = Path.Combine(solutionPath, PROJECT_NAME, "bin", "Debug", "MyDrawing.exe");
            Initialize(targetAppPath, ROOT);
        }

        // initialize
        public void Initialize(string targetAppPath, string root)
        {
            _root = root;
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", targetAppPath);
            options.AddAdditionalCapability("platformName", "Windows");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            _driver = new WindowsDriver<WindowsElement>(new Uri(WIN_APP_DRIVER_URI), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _windowHandles = new Dictionary<string, string>
            {
                { _root, _driver.CurrentWindowHandle }
            };
        }

        // clean up
        public void CleanUp()
        {
            SwitchTo(_root);
            _driver.CloseApp();
            _driver.Dispose();
        }

        // test
        public void SwitchTo(string formName)
        {
            if (_windowHandles.ContainsKey(formName))
            {
                _driver.SwitchTo().Window(_windowHandles[formName]);
            }
            else
            {
                foreach (var windowHandle in _driver.WindowHandles)
                {
                    _driver.SwitchTo().Window(windowHandle);
                    try
                    {
                        _driver.FindElementByAccessibilityId(formName);
                        _windowHandles.Add(formName, windowHandle);
                        return;
                    }
                    catch
                    {

                    }
                }
            }
        }

        // test
        public void Sleep(Double time)
        {
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }

        // test
        public void Wait(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        // test
        public void ClickButtonByName(string name)
        {
            _driver.FindElementByName(name).Click();
        }

        // test
        public void ClickDeleteButtonBy(int index)
        {
            _driver.FindElementByName("刪除 資料列 " + index).Click();
        }

        // test
        public void SelectComboBoxBy(string automationId, string option)
        {
            _driver.FindElementByAccessibilityId(automationId).Click();
            _driver.FindElementByName(option).Click();
        }

        // test
        public void InputTextBoxBy(string automationId, string text)
        {
            _driver.FindElementByAccessibilityId(automationId).Clear();
            _driver.FindElementByAccessibilityId(automationId).SendKeys(text);
        }

        // test
        public void InputTextBox(string text)
        {
            new Actions(_driver).KeyDown(Keys.Alt)
           .SendKeys("n")
           .KeyUp(Keys.Alt)
           .Perform();
            new Actions(_driver).SendKeys(text).Perform();
        }

        // test
        public void ClickTabControl(string name)
        {
            var elements = _driver.FindElementsByName(name);
            foreach (var element in elements)
            {
                if ("ControlType.TabItem" == element.TagName)
                    element.Click();
            }
        }

        // test
        public void CloseWindow()
        {
            SendKeys.SendWait("%{F4}");
        }

        // test
        public void CloseMessageBox()
        {
            _driver.FindElementByName("確定").Click();
        }

        // test
        public void ClickDataGridViewCellBy(string name, int rowIndex, string columnName)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            _driver.FindElementByName($"{columnName} 資料列 {rowIndex}").Click();
        }

        // test
        public void MouseClickAndReleaseInDrawArea(int x1, int y1, int x2, int y2)
        {
            new Actions(_driver)
                .MoveToElement(_driver.FindElementByName("anchor"), x1, y1)
                .Perform();
            new Actions(_driver)
                .MoveToElement(_driver.FindElementByName("anchor"), x1, y1)
                .ClickAndHold()
                .MoveByOffset(x2 - x1 + 2, y2 - y1 + 2)
                .Release()
                .Perform();
        }

        // test
        public void MouseMove(int x1, int y1)
        {
            new Actions(_driver)
                .MoveToElement(_driver.FindElementByName("anchor"), x1, y1)
                .Perform();
        }

        // test
        public void MousePress(int x1, int y1)
        {
            new Actions(_driver)
                .MoveToElement(_driver.FindElementByName("anchor"), x1, y1)
                .Click()
                .Perform();
        }

        // test
        public void AssertEnabled(string name, bool state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(state, element.Enabled);
        }

        // test
        public void AssertChecked(string name, bool state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            if (state) { Assert.AreEqual("1048592", element.GetAttribute("LegacyState")); }
            else { Assert.AreEqual("1048576", element.GetAttribute("LegacyState")); }


        }

        // test
        public void AssertTextByAutomationId(string automationId, string expected)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(automationId);
            Assert.AreEqual(expected, element.Text);
        }

        // test
        public void AssertTextByAutomationId(string automationId, string expected, string interval)
        {
            WindowsElement element = _driver.FindElementByAccessibilityId(automationId);
            string[] actuals = element.Text.Trim('(', ')').Split(',');
            string[] expects = expected.Trim('(', ')').Split(',');

            Assert.AreEqual(int.Parse(expects[0].Trim()), int.Parse(actuals[0].Trim()), int.Parse(interval));
            Assert.AreEqual(int.Parse(expects[1].Trim()), int.Parse(actuals[1].Trim()), int.Parse(interval));
        }

        // test
        public void AssertTextByAutomationId(string automationId, string expected, int interval)
        {
            for (int i = 0; i < 100; i++) {
                if (_driver.FindElementByAccessibilityId(automationId).Text == expected)
                {
                    Assert.AreEqual(i, interval, 10);
                    return;
                }
                Thread.Sleep(900);
            }
            Assert.Fail("Timeout.");
        }

        // test
        public void AssertTextByName(string name, string expected)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(expected, element.Text);
        }

        // test
        public void AssertDataGridViewRowDataBy(string name, int rowIndex, string[] data)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            var rowDatas = dataGridView.FindElementByName($"資料列 {rowIndex}").FindElementsByXPath("//*");

            // FindElementsByXPath("//*") 會把 "row" node 也抓出來，因此 i 要從 1 開始以跳過 "row" node
            for (int i = 1; i < rowDatas.Count; i++)
            {
                Assert.AreEqual(data[i - 1], rowDatas[i].Text.Replace("(null)", ""));
            }
        }

        // test
        public void AssertDataGridViewCell(string dataGridViewName, int i, string j, string expected)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(dataGridViewName);
            var actual = dataGridView.FindElementByName($"{j} 資料列 {i}").Text;
            Assert.AreEqual(expected, actual);
        }

        // test
        public void AssertDataGridViewCell(string dataGridViewName, int i, string j, int expected)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(dataGridViewName);
            var actual = Int32.Parse(dataGridView.FindElementByName($"{j} 資料列 {i}").Text);
            Assert.AreEqual(expected, actual, 10);
        }

        // test
        public void AssertDataGridViewRowCountBy(string name, int rowCount)
        {
            var dataGridView = _driver.FindElementByAccessibilityId(name);
            Point point = new Point(dataGridView.Location.X, dataGridView.Location.Y);
            AutomationElement element = AutomationElement.FromPoint(point);

            while (element != null && element.Current.LocalizedControlType.Contains("datagrid") == false)
            {
                element = TreeWalker.RawViewWalker.GetParent(element);
            }

            if (element != null)
            {
                GridPattern gridPattern = element.GetCurrentPattern(GridPattern.Pattern) as GridPattern;

                if (gridPattern != null)
                {
                    Assert.AreEqual(rowCount, gridPattern.Current.RowCount);
                }
            }
        }

        // test
        public void AssertDisplayDrawingDataGridViewRowDataByShape(int rowIndex, string[] expectStrings, int[] expectIntegers)
        {
            var dataGridView = _driver.FindElementByAccessibilityId("displayDrawingDataGridView");
            var rowDatas = dataGridView.FindElementByName($"資料列 {rowIndex}").FindElementsByXPath("//*");

            for (int i = 0; i < expectStrings.Length; i++)
            {
                Assert.AreEqual(expectStrings[i], rowDatas[i + 3].Text);
            }
            for (int i = 0; i < expectStrings.Length; i++)
            {
                Assert.AreEqual(expectIntegers[i], Int32.Parse(rowDatas[i + 5].Text), 10);
            }
        }

        // test
        public void AssertDisplayDrawingDataGridViewLength(int columns)
        {
            try
            {
                if (columns > 0)
                {
                    _driver.FindElementByAccessibilityId("displayDrawingDataGridView").FindElementByName($"資料列 {columns - 1}").FindElementsByXPath("//*");
                }
            }
            catch
            {
                Assert.Fail("DisplayDrawingDataDataGridView Length < " + columns);
            }
            try
            {
                var dataGridView = _driver.FindElementByAccessibilityId("displayDrawingDataGridView");
                var rowDatas = dataGridView.FindElementByName($"資料列 {columns}").FindElementsByXPath("//*");
                Assert.Fail("DisplayDrawingDataDataGridView Length > " + columns);
            }
            catch { }
        }
    }
}
