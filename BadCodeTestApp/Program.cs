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
            if (args.Length.Equals(0))
            {
                Logger.Debug("A command and args are empty.");
                Console.WriteLine("Please, enter a command and arguments for it (see documentation).");
                return;
            }

            var commands = from type in Assembly.GetExecutingAssembly().GetTypes()
                where type.GetInterfaces().Contains(typeof(ICommand))
                      && type.GetConstructor(Type.EmptyTypes) != null
                select Activator.CreateInstance(type) as ICommand;

            var isExecute = false;
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
                Logger.Debug("A command \"{0}\" is incorrect.", args[0]);
                Console.WriteLine("The command is incorrect, see documentation and try again.");
            }
        }
    }
}