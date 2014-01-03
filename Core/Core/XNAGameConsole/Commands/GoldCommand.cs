using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XNAGameConsole;
using Core.Extensions;

namespace Core.XNAGameConsole.Commands
{
    internal class GoldCommand : IConsoleCommand
    {
        public string Execute(string[] arguments)
        {
            int gold;
            try
            {
                gold = Int32.Parse(arguments[0]);
            }
            catch (Exception e)
            {
                return "Error";
            }
            Player.Gold += gold;
            return "added";
        }

        public string Description
        {
            get
            {
                return "Adding gold";
            }
        }

        public string Name
        {
            get
            {
                return "gold";
            }
        }

    }
}
