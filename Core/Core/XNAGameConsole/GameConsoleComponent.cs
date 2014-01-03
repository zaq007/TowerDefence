namespace XNAGameConsole
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using XNAGameConsole.Commands;
    using XNAGameConsole.KeyboardCapture;
    using Core.XNAGameConsole.Commands;
    using Core.Extensions;

    internal class GameConsoleComponent : DrawableGameComponent
    {
        private readonly GameConsole console;
        private readonly InputProcessor inputProcesser;
        private readonly Renderer renderer;
        private readonly SpriteBatch spriteBatch;

        public GameConsoleComponent(GameConsole console, Game game, SpriteBatch spriteBatch) : base(game)
        {
            EventHandler handler = null;
            EventHandler handler2 = null;
            this.console = console;
            EventInput.Initialize(game.Window);
            this.spriteBatch = spriteBatch;
            this.AddPresetCommands();
            this.inputProcesser = new InputProcessor(new CommandProcesser());
            if (handler == null)
            {
                handler = delegate (object s, EventArgs e) {
                    this.renderer.Open();
                };
            }
            this.inputProcesser.Open += handler;
            if (handler2 == null)
            {
                handler2 = delegate (object s, EventArgs e) {
                    this.renderer.Close();
                };
            }
            this.inputProcesser.Close += handler2;
            this.renderer = new Renderer(game, spriteBatch, this.inputProcesser);
            IConsoleCommand[] collection = new IConsoleCommand[] { new ClearScreenCommand(this.inputProcesser), new ExitCommand(game), new HelpCommand(), new GoldCommand(), new CustomCommand("live", delegate(string[] x) { Player.Health += Int32.Parse(x[0]); return "ok"; }, "") };
            GameConsoleOptions.Commands.AddRange(collection);
        }

        private void AddPresetCommands()
        {
        }

        public override void Draw(GameTime gameTime)
        {
            if (this.console.Enabled)
            {
                this.spriteBatch.Begin();
                this.renderer.Draw(gameTime);
                this.spriteBatch.End();
                base.Draw(gameTime);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (this.console.Enabled)
            {
                this.renderer.Update(gameTime);
                base.Update(gameTime);
            }
        }

        public void WriteLine(string text)
        {
            this.inputProcesser.AddToOutput(text);
        }

        public bool IsOpen
        {
            get
            {
                return this.renderer.IsOpen;
            }
        }
    }
}

