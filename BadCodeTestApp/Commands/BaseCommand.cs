using System;
using System.IO;

namespace BadCodeTestApp.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public void Execute(string[] args)
        {
            try
            {
                Program.Logger.Debug("A command \"" + args[0] + "\" is ready to run. Args: " + string.Join(" ", args));
                ExCommand(args);
                Program.Logger.Debug("The command \"" + args[0] + "\" completed successfully.");
            }
            catch (IndexOutOfRangeException)
            {
                Program.Logger.Error("Error. Not enough arguments for the command \"" + args[0] + "\".");
                Console.WriteLine("Not enough arguments for the command, see documentation and try again.");
            }
            catch (Exception e)
            {
                Program.Logger.Error("Error. Unknown exception: " + e.StackTrace);
                Console.WriteLine("Unknown error. Please, contact technical support.");
            }
        }

        public abstract string GetStringCommand();
        protected abstract void ExCommand(string[] args);
    }
}