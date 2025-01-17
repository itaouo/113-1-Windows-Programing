namespace MyDrawing.model.command
{
    public interface ICommand
    {
        void Execute();
        void UnExecute();
    }
}
