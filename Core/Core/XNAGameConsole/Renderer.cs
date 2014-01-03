namespace XNAGameConsole
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Renderer
    {
        private Vector2 closedPosition;
        private State currentState = State.Closed;
        private Vector2 firstCommandPositionOffset;
        private readonly InputProcessor inputProcessor;
        private readonly int maxCharactersPerLine;
        private readonly float oneCharacterWidth;
        private Vector2 openedPosition;
        private readonly Texture2D pixel;
        private Vector2 position;
        private readonly SpriteBatch spriteBatch;
        private DateTime stateChangeTime;
        private readonly int width;

        public Renderer(Game game, SpriteBatch spriteBatch, InputProcessor inputProcessor)
        {
            this.width = game.GraphicsDevice.Viewport.Width;
            this.position = this.closedPosition = new Vector2((float) GameConsoleOptions.Options.Margin, (float) (-GameConsoleOptions.Options.Height - GameConsoleOptions.Options.RoundedCorner.Height));
            this.openedPosition = new Vector2((float) GameConsoleOptions.Options.Margin, 0f);
            this.spriteBatch = spriteBatch;
            this.inputProcessor = inputProcessor;
            this.pixel = new Texture2D(game.GraphicsDevice, 1, 1);            
            Color[] colorArray = new Color[] { Color.White };
            this.pixel.SetData<Color>(colorArray);
            this.firstCommandPositionOffset = Vector2.Zero;
            this.oneCharacterWidth = GameConsoleOptions.Options.Font.MeasureString("x").X;
            this.maxCharactersPerLine = (int) (((float) (this.Bounds.Width - (GameConsoleOptions.Options.Padding * 2))) / this.oneCharacterWidth);
        }

        public void Close()
        {
            if ((this.currentState != State.Closing) && (this.currentState != State.Closed))
            {
                this.stateChangeTime = DateTime.Now;
                this.currentState = State.Closing;
            }
        }

        public void Draw(GameTime gameTime)
        {
            if (this.currentState != State.Closed)
            {
                this.spriteBatch.Draw(this.pixel, this.Bounds, GameConsoleOptions.Options.BackgroundColor);
                this.DrawRoundedEdges();
                Vector2 pos = this.DrawCommands(this.inputProcessor.Out, this.FirstCommandPosition);
                pos = this.DrawPrompt(pos);
                Vector2 vector2 = this.DrawCommand(this.inputProcessor.Buffer.ToString(), pos, GameConsoleOptions.Options.BufferColor);
                this.DrawCursor(vector2, gameTime);
            }
        }

        private Vector2 DrawCommand(string command, Vector2 pos, Color color)
        {
            IEnumerable<string> enumerable = (command.Length > this.maxCharactersPerLine) ? SplitCommand(command, this.maxCharactersPerLine) : ((IEnumerable<string>) new string[] { command });
            foreach (string str in enumerable)
            {
                if (this.IsInBounds(pos.Y))
                {
                    this.spriteBatch.DrawString(GameConsoleOptions.Options.Font, str, pos, color);
                }
                this.ValidateFirstCommandPosition(pos.Y + GameConsoleOptions.Options.Font.LineSpacing);
                pos.Y += GameConsoleOptions.Options.Font.LineSpacing;
            }
            return pos;
        }

        private Vector2 DrawCommands(IEnumerable<OutputLine> lines, Vector2 pos)
        {
            float x = pos.X;
            foreach (OutputLine line in lines)
            {
                if (line.Type == OutputLineType.Command)
                {
                    pos = this.DrawPrompt(pos);
                }
                pos.Y = this.DrawCommand(line.ToString(), pos, (line.Type == OutputLineType.Command) ? GameConsoleOptions.Options.PastCommandColor : GameConsoleOptions.Options.PastCommandOutputColor).Y;
                pos.X = x;
            }
            return pos;
        }

        private void DrawCursor(Vector2 pos, GameTime gameTime)
        {
            if (this.IsInBounds(pos.Y))
            {
                string str = SplitCommand(this.inputProcessor.Buffer.ToString(), this.maxCharactersPerLine).Last<string>();
                pos.X += GameConsoleOptions.Options.Font.MeasureString(str).X;
                pos.Y -= GameConsoleOptions.Options.Font.LineSpacing;
                this.spriteBatch.DrawString(GameConsoleOptions.Options.Font, ((((int) (gameTime.TotalGameTime.Seconds / ((double) GameConsoleOptions.Options.CursorBlinkSpeed))) % 2) == 0) ? GameConsoleOptions.Options.Cursor.ToString() : "", pos, GameConsoleOptions.Options.CursorColor);
            }
        }

        private Vector2 DrawPrompt(Vector2 pos)
        {
            this.spriteBatch.DrawString(GameConsoleOptions.Options.Font, GameConsoleOptions.Options.Prompt, pos, GameConsoleOptions.Options.PromptColor);
            pos.X += (this.oneCharacterWidth * GameConsoleOptions.Options.Prompt.Length) + this.oneCharacterWidth;
            return pos;
        }

        private void DrawRoundedEdges()
        {
            this.spriteBatch.Draw(GameConsoleOptions.Options.RoundedCorner, new Vector2(this.position.X, this.position.Y + GameConsoleOptions.Options.Height), null, GameConsoleOptions.Options.BackgroundColor, 0f, Vector2.Zero, 1f, 0, 1f);
            //this.spriteBatch.Draw(GameConsoleOptions.Options.RoundedCorner, new Vector2((this.position.X + this.Bounds.Width) - GameConsoleOptions.Options.RoundedCorner.get_Width(), this.position.Y + GameConsoleOptions.Options.Height), null, GameConsoleOptions.Options.BackgroundColor, 0f, Vector2.Zero, 1f, 1, 1f);
            this.spriteBatch.Draw(this.pixel, new Rectangle(this.Bounds.X + GameConsoleOptions.Options.RoundedCorner.Width, this.Bounds.Y + GameConsoleOptions.Options.Height, this.Bounds.Width - (GameConsoleOptions.Options.RoundedCorner.Width * 2), GameConsoleOptions.Options.RoundedCorner.Height), GameConsoleOptions.Options.BackgroundColor);
        }

        private bool IsInBounds(float yPosition)
        {
            return (yPosition < (this.openedPosition.Y + GameConsoleOptions.Options.Height));
        }

        public void Open()
        {
            if ((this.currentState != State.Opening) && (this.currentState != State.Opened))
            {
                this.stateChangeTime = DateTime.Now;
                this.currentState = State.Opening;
            }
        }

        private static IEnumerable<string> SplitCommand(string command, int max)
        {
            List<string> list = new List<string>();
            while (command.Length > max)
            {
                string item = command.Substring(0, max);
                list.Add(item);
                command = command.Substring(max, command.Length - max);
            }
            list.Add(command);
            return list;
        }

        public void Update(GameTime gameTime)
        {
            if (this.currentState == State.Opening)
            {
                TimeSpan span = (TimeSpan) (DateTime.Now - this.stateChangeTime);
                this.position.Y = MathHelper.SmoothStep(this.position.Y, this.openedPosition.Y, (float) (span.TotalSeconds / ((double) GameConsoleOptions.Options.AnimationSpeed)));
                if (this.position.Y == this.openedPosition.Y)
                {
                    this.currentState = State.Opened;
                }
            }
            if (this.currentState == State.Closing)
            {
                TimeSpan span2 = (TimeSpan) (DateTime.Now - this.stateChangeTime);
                this.position.Y = MathHelper.SmoothStep(this.position.Y, this.closedPosition.Y, (float) (span2.TotalSeconds / ((double) GameConsoleOptions.Options.AnimationSpeed)));
                if (this.position.Y == this.closedPosition.Y)
                {
                    this.currentState = State.Closed;
                }
            }
        }

        private void ValidateFirstCommandPosition(float nextCommandY)
        {
            if (!this.IsInBounds(nextCommandY))
            {
                this.firstCommandPositionOffset.Y -= GameConsoleOptions.Options.Font.LineSpacing;
            }
        }

        private Rectangle Bounds
        {
            get
            {
                return new Rectangle((int) this.position.X, (int) this.position.Y, this.width - (GameConsoleOptions.Options.Margin * 2), GameConsoleOptions.Options.Height);
            }
        }

        private Vector2 FirstCommandPosition
        {
            get
            {
                return (new Vector2((float) this.InnerBounds.X, (float) this.InnerBounds.Y) + this.firstCommandPositionOffset);
            }
        }

        private Rectangle InnerBounds
        {
            get
            {
                return new Rectangle(this.Bounds.X + GameConsoleOptions.Options.Padding, this.Bounds.Y + GameConsoleOptions.Options.Padding, this.Bounds.Width - GameConsoleOptions.Options.Padding, this.Bounds.Height);
            }
        }

        public bool IsOpen
        {
            get
            {
                return (this.currentState == State.Opened);
            }
        }

        private enum State
        {
            Opened,
            Opening,
            Closed,
            Closing
        }
    }
}

