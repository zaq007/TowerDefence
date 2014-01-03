namespace XNAGameConsole
{
    using System;

    public interface IConsoleCommand
    {
        string Execute(string[] arguments);

        string Description { get; }

        string Name { get; }
    }
}

