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
            File.Delete(args[1]);
        }
    }
}