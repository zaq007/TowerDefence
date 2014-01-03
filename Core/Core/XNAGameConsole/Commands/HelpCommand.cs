namespace XNAGameConsole.Commands
{
    using System;
    using System.Linq;
    using System.Text;
    using XNAGameConsole;

    internal class HelpCommand : IConsoleCommand
    {
        public string Execute(string[] arguments)
        {
            Func<IConsoleCommand, bool> func = null;
            if ((arguments != null) && (arguments.Length >= 1))
            {
                if (func == null)
                {
                    func = c => (c.Name != null) && (c.Name == arguments[0]);
                }
                IConsoleCommand command = Enumerable.Where<IConsoleCommand>(GameConsoleOptions.Commands, func).FirstOrDefault<IConsoleCommand>();
                if (command != null)
                {
                    return string.Format("{0}: {1}\n", command.Name, command.Description);
                }
                return ("ERROR: Invalid command '" + arguments[0] + "'");
            }
            StringBuilder builder = new StringBuilder();
            GameConsoleOptions.Commands.Sort(new CommandComparer());
            foreach (IConsoleCommand command2 in GameConsoleOptions.Commands)
            {
                builder.Append(string.Format("{0}: {1}\n", command2.Name, command2.Description));
            }
            return builder.ToString();
        }

        public string Description
        {
            get
            {
                return "Displays the list of commands";
            }
        }

        public string Name
        {
            get
            {
                return "help";
            }
        }
    }
}

