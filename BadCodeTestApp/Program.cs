using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using BadCodeTestApp.Commands;

namespace BadCodeTestApp
{
    class Program
    {

        public static void Main(string[] args)
        {
            string command = args[0];
            string param = args[1];
            
            var commands = from type in Assembly.GetExecutingAssembly().GetTypes()
                where type.GetInterfaces().Contains(typeof(ICommand))
                      && type.GetConstructor(Type.EmptyTypes) != null
                select Activator.CreateInstance(type) as ICommand;

            foreach (var c in commands)
            {
                if (Regex.IsMatch(command, c.GetCommandPattern(), RegexOptions.IgnoreCase))
                {
                    c.Execute(command, param);
                    break;
                }
            }
            
        }
    }
}