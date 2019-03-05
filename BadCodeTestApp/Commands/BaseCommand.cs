using System.IO;

namespace BadCodeTestApp.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public void Execute(string[] args)
        {
            try
            {
                //
                ExCommand(args);
                //
            }
            catch (IOException)
            {
                //
            }
        }

        public abstract string GetStringCommand();
        protected abstract void ExCommand(string[] args);
    }
}