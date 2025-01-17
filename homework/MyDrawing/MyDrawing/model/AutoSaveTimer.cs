using System.Timers;

namespace MyDrawing
{
    public class AutoSaveTimer
    {
        public event StartAutoSaveEventHandler AutoSaveStarted;
        public delegate void StartAutoSaveEventHandler();
        public event FinishAutoSaveEventHandler AutoSaveFinished;
        public delegate void FinishAutoSaveEventHandler();

        private Model model;
        private static Timer timer;

        public AutoSaveTimer(Model model)
        {
            this.model = model;
            ChangeTimer(30000);
        }

        public void ChangeTimer(int millisecond)
        {
            timer = new Timer(millisecond);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void NotifyObserverStartAutoSave()
        {
            AutoSaveStarted?.Invoke();
        }

        public void NotifyObserverFinishAutoSave()
        {
            AutoSaveFinished?.Invoke();
        }

        public async void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            NotifyObserverStartAutoSave();
            await FileHandler.Instance.Save(FileHandler.Instance.GetAutoSaveFilePath(), model.GetShapesOutput());
            NotifyObserverFinishAutoSave();
        }
    }
}
