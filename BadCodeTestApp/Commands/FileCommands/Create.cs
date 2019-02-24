using System.IO;

namespace BadCodeTestApp.Commands.FileCommands
{
    class Create : ICommand
    {
        private const string CommandPattern = @"^create_[a-z]+$";

        public string GetCommandPattern()
        {
            return CommandPattern;
        }

        public void Execute(string command, string param)
        {
            File.Create(param + GetExtension(command));
        }

        private static string GetExtension(string str)
        {
            return "." + (string)str.Split('_').GetValue(1);
        }
    }
}
