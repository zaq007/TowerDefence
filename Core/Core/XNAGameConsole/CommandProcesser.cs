namespace XNAGameConsole
{
    using System;
    using System.Linq;

    internal class CommandProcesser
    {
        private static string[] GetArguments(string buffer)
        {
            int index = buffer.IndexOf(' ');
            if (index < 0)
            {
                return new string[0];
            }
            return (from a in buffer.Substring(index, buffer.Length - index).Split(new char[] { ' ' })
                where a != ""
                select a).ToArray<string>();
        }

        private static string GetCommandName(string buffer)
        {
            int index = buffer.IndexOf(' ');
            return buffer.Substring(0, (index < 0) ? buffer.Length : index);
        }

        public string Process(string buffer)
        {
            string commandName = GetCommandName(buffer);
            IConsoleCommand command = (from c in GameConsoleOptions.Commands
                where c.Name == commandName
                select c).FirstOrDefault<IConsoleCommand>();
            string[] arguments = GetArguments(buffer);
            if (command == null)
            {
                return "ERROR: Command not found";
            }
            try
            {
                return command.Execute(arguments);
            }
            catch (Exception exception)
            {
                return ("ERROR: " + exception.Message);
            }
        }
    }
}

