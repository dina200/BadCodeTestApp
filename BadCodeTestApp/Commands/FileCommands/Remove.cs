using System;
using System.IO;

namespace BadCodeTestApp.Commands.FileCommands
{
    public class Remove : BaseCommand
    {
        public override string GetStringCommand()
        {
            return "remove";
        }

        protected override void ExCommand(string[] args)
        {
            if (!File.Exists(args[1]))
            {
                Program.Logger.Debug("File {0} isn't exist in the directory and can't be removed.", args[1]);
                Console.WriteLine("The file isn't exist in the directory, use command \"search\" to find path to your file and try again.");
                return;
            }
            Program.Logger.Debug("File {0} is exist and can be removed.", args[1]);
            File.Delete(args[1]);
            Console.WriteLine("The file is removed.");
            Program.Logger.Debug("File {0} is removed.", args[1]);
        }
    }
}