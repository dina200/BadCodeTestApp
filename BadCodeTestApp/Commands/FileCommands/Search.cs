using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BadCodeTestApp.Commands.FileCommands
{
    public class Search : BaseCommand
    {
        public override string GetStringCommand()
        {
            return "search";
        }

        protected override void ExCommand(string[] args)
        {
            string path = args[1];
            string searchMask = "*";
            if (args.Count() > 2)
            {
                searchMask = args[2];
            }

            GeneralSearch(path, searchMask).ForEach(n => Console.WriteLine(n));
        }

        protected List<string> GeneralSearch(string param, string mask)
        {
            return Directory.GetFiles(param, mask, SearchOption.AllDirectories).ToList();
        }
    }
}