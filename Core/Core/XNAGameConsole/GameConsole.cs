namespace XNAGameConsole
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using XNAGameConsole.Commands;
    using Core.Extensions;

    public class GameConsole
    {
        private readonly GameConsoleComponent console;

        public GameConsole(Game game, SpriteBatch spriteBatch) : this(game, spriteBatch, new IConsoleCommand[0], new GameConsoleOptions())
        {
        }

        public GameConsole(Game game, SpriteBatch spriteBatch, IEnumerable<IConsoleCommand> commands) : this(game, spriteBatch, commands, new GameConsoleOptions())
        {
        }

        public GameConsole(Game game, SpriteBatch spriteBatch, GameConsoleOptions options) : this(game, spriteBatch, new IConsoleCommand[0], options)
        {
        }

        public GameConsole(Game game, SpriteBatch spriteBatch, IEnumerable<IConsoleCommand> commands, GameConsoleOptions options)
        {
            //ResourceContentManager manager = new ResourceContentManager(game.Services, Resource1.ResourceManager);
            if (options.Font == null)
            {
                options.Font = TextureLoader.FDescr;
            }
            options.RoundedCorner = TextureLoader.Bullet;
            GameConsoleOptions.Options = options;
            GameConsoleOptions.Commands = commands.ToList<IConsoleCommand>();
            this.Enabled = true;
            this.console = new GameConsoleComponent(this, game, spriteBatch);
            game.Services.AddService(typeof(GameConsole), this);
            game.Components.Add(this.console);
        }

        public void AddCommand(params IConsoleCommand[] commands)
        {
            this.Commands.AddRange(commands);
        }

        public void AddCommand(string name, Func<string[], string> action)
        {
            this.AddCommand(name, action, "");
        }

        public void AddCommand(string name, Func<string[], string> action, string description)
        {
            this.Commands.Add(new CustomCommand(name, action, description));
        }

        public void WriteLine(string text)
        {
            this.console.WriteLine(text);
        }

        public List<IConsoleCommand> Commands
        {
            get
            {
                return GameConsoleOptions.Commands;
            }
        }

        public bool Enabled { get; set; }

        public bool Opened
        {
            get
            {
                return this.console.IsOpen;
            }
        }

        public GameConsoleOptions Options
        {
            get
            {
                return GameConsoleOptions.Options;
            }
        }
    }
}

