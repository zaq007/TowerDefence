namespace XNAGameConsole.Commands
{
    using System;
    using XNAGameConsole;

    internal class ClearScreenCommand : IConsoleCommand
    {
        private InputProcessor processor;

        public ClearScreenCommand(InputProcessor processor)
        {
            this.processor = processor;
        }

        public string Execute(string[] arguments)
        {
            this.processor.Out.Clear();
            return "";
        }

        public string Description
        {
            get
            {
                return "Clears the console output";
            }
        }

        public string Name
        {
            get
            {
                return "clear";
            }
        }
    }
}

