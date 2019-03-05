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
            File.Create(args[1]);
        }
    }
}