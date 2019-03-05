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
                Program.Logger.Debug("A command \"{0}\" is ready to run. Args: {1}",args[0], string.Join(" ", args));
                ExCommand(args);
                Program.Logger.Debug("The command \"{0}\" completed successfully.",args[0]);
            }
            catch (IndexOutOfRangeException)
            {
                Program.Logger.Error("Not enough arguments for the command \"{0}\".", args[0]);
                Console.WriteLine("Not enough arguments for the command, see documentation and try again.");
            }
            catch (IOException e)
            {
                Program.Logger.Error("Input/output exception: {0}", e.Message );
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Program.Logger.Error("Unknown exception: {0}.", e.Message);
                Console.WriteLine("Unknown error. Please, contact technical support.");
            }
        }

        public abstract string GetStringCommand();
        protected abstract void ExCommand(string[] args);
    }
}