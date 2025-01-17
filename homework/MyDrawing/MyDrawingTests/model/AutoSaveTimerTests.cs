using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.model.command;
using MyDrawing.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyDrawing.Tests
{
    [TestClass()]
    public class AutoSaveTimerTests
    {
        private AutoSaveTimer autoSaveTimer;
        private FormMock formMock;

        [TestInitialize()]
        public void Initialize()
        {
            autoSaveTimer = new AutoSaveTimer(new Model(new Factory()));
            formMock = new FormMock(autoSaveTimer);
        }

        [TestMethod()]
        public async Task ChangeTimerTestAsync()
        {
            autoSaveTimer.ChangeTimer(3000);
            await Task.Delay(4000);
            Assert.IsTrue(formMock.IsStarted);
        }

        [TestMethod()]
        public void NotifyObserverStartAutoSaveTest()
        {
            autoSaveTimer.NotifyObserverStartAutoSave();
        }

        [TestMethod()]
        public void NotifyObserverFinishAutoSaveTest()
        {
            autoSaveTimer.NotifyObserverStartAutoSave();
        }

        [TestMethod()]
        public async Task OnTimedEventTest()
        {
            autoSaveTimer.ChangeTimer(3000);
            await Task.Delay(4000);
            Assert.IsTrue(formMock.IsStarted);
        }
    }

    internal class FormMock
    {
        public bool IsStarted = false;
        public bool IsFinished = false;
        public FormMock(AutoSaveTimer autoSaveTimer)
        {
            autoSaveTimer.AutoSaveStarted += start;
            autoSaveTimer.AutoSaveFinished += finish;
        }
        private void start()
        {
            IsStarted = true;
        }
        private void finish()
        {
            IsFinished = false;
        }
    }
}