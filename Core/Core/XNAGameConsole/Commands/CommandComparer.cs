namespace XNAGameConsole.Commands
{
    using System;
    using System.Collections.Generic;
    using XNAGameConsole;

    internal class CommandComparer : IComparer<IConsoleCommand>
    {
        public int Compare(IConsoleCommand x, IConsoleCommand y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}

