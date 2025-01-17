using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing;
using MyDrawing.model.command;
using OpenQA.Selenium.DevTools.V129.Audits;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Tests
{
    [TestClass()]
    public class FileHandlerTests
    {
        private string mockPath;
        private string mockFolderPath;

        [TestInitialize()]
        public void Initialize()
        {
            mockPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test", "MyDrawing");
            mockFolderPath = Path.Combine(mockPath, "MyDrawing", "bin", "Debug", "drawing_backup");
            FileHandler.Instance.rootPath = mockPath;
        }

        [TestCleanup()]
        public void Cleanup()
        {
            FileHandler.Instance.rootPath = "";
            Directory.Delete(mockFolderPath, true);
        }

        [TestMethod()]
        public void GetAutoSaveFolderPathTest()
        {
            Assert.AreEqual(mockFolderPath, FileHandler.Instance.GetAutoSaveFolderPath());
        }

        [TestMethod()]
        public void GetAutoSaveFilePathTest()
        {
            string actualPath = FileHandler.Instance.GetAutoSaveFilePath();

            Assert.IsTrue(actualPath.StartsWith(mockFolderPath));
            Assert.IsTrue(actualPath.EndsWith("_bak.mydrawing"));
        }

        [TestMethod()]
        public void RemoveExtraAutosavesTest()
        {
            Directory.CreateDirectory(mockFolderPath);
            string[] fileNames = {
                "20250110225329_bak.mydrawing",
                "20250110225359_bak.mydrawing",
                "20250110225429_bak.mydrawing",
                "20250110225459_bak.mydrawing",
                "20250110225529_bak.mydrawing",
                "20250110225559_bak.mydrawing"
            };
            foreach (var fileName in fileNames)
            {
                string filePath = Path.Combine(mockFolderPath, fileName);
                File.WriteAllText(filePath, "");
            }
            Assert.AreEqual(6, Directory.GetFiles(mockFolderPath).Length);

            FileHandler.Instance.RemoveExtraAutosaves();
            Assert.AreEqual(5, Directory.GetFiles(mockFolderPath).Length);
        }

        [TestMethod()]
        public async Task SaveTestAsync()
        {
            string filePath = FileHandler.Instance.GetAutoSaveFilePath();
            var directoryInfo = new DirectoryInfo(mockFolderPath);
            directoryInfo.Attributes &= ~FileAttributes.ReadOnly;
            await FileHandler.Instance.Save(filePath, "Start 95 100 100 100 0 0 0 jiLefqpDZk");
            Assert.AreEqual("Start 95 100 100 100 0 0 0 jiLefqpDZk", File.ReadAllText(filePath));
        }

        [TestMethod()]
        public async Task LoadTestAsync()
        {
            string filePath = FileHandler.Instance.GetAutoSaveFilePath();
            var directoryInfo = new DirectoryInfo(mockFolderPath);
            directoryInfo.Attributes &= ~FileAttributes.ReadOnly;
            await FileHandler.Instance.Save(filePath, "Start 95 100 100 100 0 0 0 jiLefqpDZk");

            Model model = new Model(new Factory());
            FileHandler.Instance.Load(model, null);
            FileHandler.Instance.Load(model, filePath);
            Assert.AreEqual(model.Shapes.Count, 1);
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

        [TestMethod()]
        public void NotifySaveErrorTest()
        {
            FileHandler.Instance.GetAutoSaveFolderPath();
            FileHandler.Instance.NotifySaveError();
        }

        [TestMethod()]
        public void NotifyLoadErrorTest()
        {
            FileHandler.Instance.GetAutoSaveFolderPath();
            FileHandler.Instance.NotifyLoadError();
        }
    }

    //internal class FormMock
    //{
    //    public FormMock()
    //    {
    //        FileHandler.Instance.FileHandlerSaveErrorChanged += foo;
    //        FileHandler.Instance.FileHandlerLoadErrorChanged += foo;
    //    }
    //    private void foo()
    //    {
    //        Console.WriteLine("ModelChanged");
    //    }
    //}
}