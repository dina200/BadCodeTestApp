using System;
using System.Collections.Generic;
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

        protected override void TemplateMethod(string command, string param)
        {
            _command = command;
            Search(param).ToList().ForEach(n => Console.WriteLine(n));
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
