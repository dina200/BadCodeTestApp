using System;
using System.Linq;
using System.Reflection;
using BadCodeTestApp.Commands;
using NLog;

namespace BadCodeTestApp
{
    class Program
    {
        public static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            var commands = from type in Assembly.GetExecutingAssembly().GetTypes()
                where type.GetInterfaces().Contains(typeof(ICommand))
                      && type.GetConstructor(Type.EmptyTypes) != null
                select Activator.CreateInstance(type) as ICommand;

            bool isExecute = false;
            foreach (var c in commands)
            {
                if (args[0].Equals(c.GetStringCommand()))
                {
                    c.Execute(args);
                    isExecute = true;
                    break;
                }
            }
            if (!isExecute)
            {
                Console.WriteLine("The command is incorrect, see documentation and try again.");   
            }
        }
    }
}