using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using BadCodeTestApp.Commands;
using NLog;
using static System.String;

namespace BadCodeTestApp
{
    class Program
    {
        private static string _command;
        private static string _param;
        public static void Main(string[] args)
        {
            try
            {
               _command = args[0];
               _param = args[1];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The params (args[0], args[1]) can't be empty, try again...");
                return;
            }
            
            var commands = from type in Assembly.GetExecutingAssembly().GetTypes()
                where type.GetInterfaces().Contains(typeof(ICommand))
                      && type.GetConstructor(Type.EmptyTypes) != null
                select Activator.CreateInstance(type) as ICommand;

            foreach (var c in commands)
            {
                if (!Regex.IsMatch(_command, c.GetCommandPattern(), RegexOptions.IgnoreCase)) continue;
                c.Execute(_command, _param);
                break;
            }
        }
    }
}