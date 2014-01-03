namespace XNAGameConsole.Commands
{
    using System;
    using System.Runtime.CompilerServices;
    using XNAGameConsole;

    internal class CustomCommand : IConsoleCommand
    {
        private Func<string[], string> action;

        public CustomCommand(string name, Func<string[], string> action, string description)
        {
            this.Name = name;
            this.Description = description;
            this.action = action;
        }

        public string Execute(string[] arguments)
        {
            return this.action(arguments);
        }

        public string Description { get; private set; }

        public string Name { get; private set; }
    }
}

