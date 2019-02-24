namespace BadCodeTestApp.Commands
{
    public interface ICommand
    {
        string GetCommandPattern();
        void Execute(string command, string param);
    }
}