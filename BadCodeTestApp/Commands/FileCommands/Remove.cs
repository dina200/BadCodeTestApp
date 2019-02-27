using System.IO;

namespace BadCodeTestApp.Commands.FileCommands
{
    class Remove : ICommand
    {
        private const string CommandPattern = @"^remove_[a-z]+$";

        public string GetCommandPattern()
        {
            return CommandPattern;
        }

        public void Execute(string command, string param)
        {
            File.Delete(param + GetExtension(command));
        }

        private static string GetExtension(string str)
        {
            return "." + (string)str.Split('_').GetValue(1);
        }
    }
}
