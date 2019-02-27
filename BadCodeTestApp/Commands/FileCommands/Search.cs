using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BadCodeTestApp.Commands.FileCommands
{
    class Search : ICommand
    {
        private const string CommandPattern = @"^search$";

        public virtual string GetCommandPattern()
        {
            return CommandPattern;
        }

        public void Execute(string command, string param)
        {
            try
            {
                TemplateMethod(command, param);
            }
            catch (IOException)
            {
                Console.WriteLine("Incorrect args or file doesn't exist");
            }
        }

        protected virtual void TemplateMethod(string command, string param)
        {
            GeneralSearch(param).ForEach(n => Console.WriteLine(n));
        }

        protected List<string> GeneralSearch(string param)
        {
            return Directory.GetFiles(param, "*", SearchOption.AllDirectories).ToList();
        }
    }
}
