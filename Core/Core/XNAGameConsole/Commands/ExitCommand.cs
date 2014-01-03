namespace XNAGameConsole.Commands
{
    using Microsoft.Xna.Framework;
    using System;
    using XNAGameConsole;

    internal class ExitCommand : IConsoleCommand
    {
        private readonly Game game;

        public ExitCommand(Game game)
        {
            this.game = game;
        }

        public string Execute(string[] arguments)
        {
            this.game.Exit();
            return "Exiting the game";
        }

        public string Description
        {
            get
            {
                return "Forcefully exists the game";
            }
        }

        public string Name
        {
            get
            {
                return "exit";
            }
        }
    }
}

