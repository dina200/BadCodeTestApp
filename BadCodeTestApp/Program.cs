using System;
using System.Linq;
using System.Reflection;
using BadCodeTestApp.Commands;

namespace BadCodeTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = from type in Assembly.GetExecutingAssembly().GetTypes()
                where type.GetInterfaces().Contains(typeof(ICommand))
                      && type.GetConstructor(Type.EmptyTypes) != null
                select Activator.CreateInstance(type) as ICommand;

            foreach (var c in commands)
            {
                if (args[0].Equals(c.GetStringCommand()))
                {
                    c.Execute(args);
                    break;
                }
            }
        }
    }
}