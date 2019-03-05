namespace BadCodeTestApp.Commands
{
    public interface ICommand
    {
        string GetStringCommand();
        void Execute(string[] args);
    }
}