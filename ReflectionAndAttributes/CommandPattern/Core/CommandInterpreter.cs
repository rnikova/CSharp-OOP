using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string POSTFFIX = "Command";


        public string Read(string inputLine)
        {
            string[] inputLineTokens = inputLine.Split();

            string commandName = inputLineTokens[0] + POSTFFIX;
            string[] commandArgs = inputLineTokens.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type[] types = assembly.GetTypes();

            var type = types.FirstOrDefault(t => t.Name == commandName);
           
            var instance = Activator.CreateInstance(type);

            ICommand command = (ICommand)instance;

            string result = command.Execute(commandArgs);
            
            return result;
        }
    }
}
