using System;
using System.Collections.Generic;

namespace MyDrawing.model.command
{
    public class CommandManager
    {
        private static CommandManager instance;
        private Stack<ICommand> undo = new Stack<ICommand>();
        private Stack<ICommand> redo = new Stack<ICommand>();
        public event CommandManagerChangedEventHandler CommandManagerChanged;
        public delegate void CommandManagerChangedEventHandler();

        private CommandManager() { }

        public static CommandManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommandManager();
                }
                return instance;
            }
        }

        public void Execute(ICommand cmd)
        {
            cmd.Execute();
            undo.Push(cmd);
            redo.Clear();
            NotifyCommandManagerObserver();
        }

        public void Undo()
        {
            if (undo.Count <= 0)
                throw new InvalidOperationException("Cannot Undo exception.");
            ICommand cmd = undo.Pop();
            redo.Push(cmd);
            cmd.UnExecute();
            NotifyCommandManagerObserver();
        }

        public void Redo()
        {
            if (redo.Count <= 0)
                throw new InvalidOperationException("Cannot Redo exception.");
            ICommand cmd = redo.Pop();
            undo.Push(cmd);
            cmd.Execute();
            NotifyCommandManagerObserver();
        }

        public void ClearAll()
        {
            undo.Clear();
            redo.Clear();
            NotifyCommandManagerObserver();
        }

        public void NotifyCommandManagerObserver()
        {
            CommandManagerChanged?.Invoke();
        }

        public bool IsRedoEnabled
        {
            get
            {
                return redo.Count != 0;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return undo.Count != 0;
            }
        }
    }
}
