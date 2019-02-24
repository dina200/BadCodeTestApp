using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BadCodeTestApp.Commands.FileCommands
{
    class SearchByExt : Search
    {
        private const string CommandPattern = @"^[a-z]+_search$";        
        private string _command;

        public override string GetCommandPattern()
        {
            return CommandPattern;
        }

        public override void Execute(string command, string param)
        {
            this._command = command;
            Search(param).ToList<string>().ForEach(n => Console.WriteLine(n));
        }

        private IEnumerable<string> Search(string param)
        {
            List<string> res = GeneralSearch(param); 
            string ext = GetExtension(_command);
            foreach (string n in res)
            {
                if (n.EndsWith(ext, StringComparison.Ordinal))
                {
                    yield return n;
                }
            }
        }

        private string GetExtension(string str)
        {
            return "." + (string)str.Split('_').GetValue(0);
        }        
    }
}
