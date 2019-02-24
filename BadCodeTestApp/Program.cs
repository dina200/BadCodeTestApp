using BadCodeTestApp.Commands;
using BadCodeTestApp.Commands.FileCommands;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BadCodeTestApp
{
    class Program
    {
        private static List<ICommand> Commands = new List<ICommand>();

        static Program()
        {
            Register();
        }

        static void Register()
        {
            Commands.Add(new Search());
            Commands.Add(new SearchByExt());
            Commands.Add(new Delete());
            Commands.Add(new Create());
        }

        public static void Main(string[] args)
        {
            string command = args[0];
            string param = args[1];
            foreach (ICommand n in Commands)
            {
                if (Regex.IsMatch(command, n.GetCommandPattern(), RegexOptions.IgnoreCase))
                {
                    n.Execute(command, param);
                    break;
                }
            }

            Console.ReadLine();
        }
    }
}
