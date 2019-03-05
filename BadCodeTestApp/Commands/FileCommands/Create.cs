using System;
using System.IO;

namespace BadCodeTestApp.Commands.FileCommands
{
    class Create : BaseCommand
    {
        public override string GetStringCommand()
        {
            return "create";
        }

        protected override void ExCommand(string[] args)
        {
            if (File.Exists(args[1]))
            {
                Program.Logger.Debug("File " + args[1] + " is already exist.");
                Console.WriteLine("The file is already exist.");
                return;
            }

            Program.Logger.Debug("File " + args[1] + " create.");
            File.Create(args[1]);
        }
    }
}