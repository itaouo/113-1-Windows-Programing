using MyDrawing.model.command;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyDrawing
{
    public class FileHandler
    {
        private static FileHandler instance;
        public event FileHandlerSaveErrorEventHandler FileHandlerSaveErrorChanged;
        public delegate void FileHandlerSaveErrorEventHandler();
        public event FileHandlerLoadErrorEventHandler FileHandlerLoadErrorChanged;
        public delegate void FileHandlerLoadErrorEventHandler();
        public string rootPath = "";
        
        private FileHandler() { }
        public static FileHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FileHandler();
                }
                return instance;
            }
        }
        public string GetAutoSaveFolderPath()
        {
            
            if (rootPath == "")
            {
                rootPath = AppDomain.CurrentDomain.BaseDirectory;
                rootPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            }
            string folderPath = Path.Combine(rootPath, "MyDrawing", "bin", "Debug", "drawing_backup");
            if (!Directory.Exists(folderPath)) { Directory.CreateDirectory(folderPath); }
            return folderPath;
        }

        public string GetAutoSaveFilePath()
        {
            string folderPath = GetAutoSaveFolderPath();
            string now = DateTime.Now.Year.ToString()
                        + DateTime.Now.Month.ToString("D2")
                        + DateTime.Now.Day.ToString("D2")
                        + DateTime.Now.Hour.ToString("D2")
                        + DateTime.Now.Minute.ToString("D2")
                        + DateTime.Now.Second.ToString("D2");
            string fileName = Path.Combine(folderPath, now + "_bak.mydrawing");
            return fileName;
        }

        public void RemoveExtraAutosaves()
        {
            string folderPath = GetAutoSaveFolderPath();
            var autosaveFiles = Directory.GetFiles(folderPath)
                                     .Select(file => new FileInfo(file))
                                     .OrderByDescending(file => file.LastWriteTime) // Sort by last modified time, newest first
                                     .ToList();
            if (autosaveFiles.Count > 5)
            {
                var filesToDelete = autosaveFiles.Skip(5);
                foreach (var file in filesToDelete)
                {
                    file.Delete();
                }
            }
        }

        public async Task Save(string filePath, string content)
        {
            await Task.Run(() =>
            {
                Task.Delay(3000).Wait();
                try
                {
                    File.WriteAllText(filePath, content);
                    FileHandler.Instance.RemoveExtraAutosaves();
                } catch {
                    NotifySaveError();
                }
            });
        }

        public void Load(Model model, string filePath)
        {
            try {
                string[] lines = File.ReadAllLines(filePath);
                model.DeleteAllShape();
                CommandManager.Instance.ClearAll();
                foreach (var line in lines)
                {
                    string[] strings = line.Split(' ');
                    string note = string.Join(" ", strings.Skip(8));
                    Shape shape = model.CreateShape(strings[0], note, strings[1], strings[2], strings[3], strings[4]);
                    model.Shapes.Add(shape);
                    shape.Id = Int32.Parse(strings[5]);
                    shape.TextOffsetX = Int32.Parse(strings[6]);
                    shape.TextOffsetY = Int32.Parse(strings[7]);
                }
                model.NotifyObserver();
            }
            catch { NotifyLoadError(); }
        }

        public void NotifySaveError()
        {
            FileHandlerSaveErrorChanged?.Invoke();
        }

        public void NotifyLoadError()
        {
            FileHandlerLoadErrorChanged?.Invoke();
        }
    }
}
