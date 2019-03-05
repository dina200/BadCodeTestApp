using System;
using System.Linq;

namespace BadCodeTestApp.Commands.FileCommands
{
    public class SearchByExt : Search
    {
        public override string GetStringCommand()
        {
            return "search_by_ext";
        }

        protected override void ExCommand(string[] args)
        {
            string path = args[1];
            string searchMask = args[2];
            GeneralSearch(path, "*." + searchMask).ToList().ForEach(n => Console.WriteLine(n));
        }
    }
}