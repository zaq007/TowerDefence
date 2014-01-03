namespace XNAGameConsole
{
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using Microsoft.Xna.Framework;

    public class GameConsoleOptions
    {
        public GameConsoleOptions()
        {
            this.ToggleKey = Keys.OemTilde;
            this.BackgroundColor = new Color(0, 0, 0, 0x7d);
            this.FontColor = Color.White;
            this.AnimationSpeed = 1f;
            this.CursorBlinkSpeed = 0.5f;
            this.Height = 300;
            this.Prompt = "$";
            this.Cursor = '_';
            this.Padding = 30;
            this.Margin = 30;
            this.OpenOnWrite = true;
        }

        public float AnimationSpeed { get; set; }

        public Color BackgroundColor { get; set; }

        public Color BufferColor { get; set; }

        internal static List<IConsoleCommand> Commands { get; set; }

        public char Cursor { get; set; }

        public float CursorBlinkSpeed { get; set; }

        public Color CursorColor { get; set; }

        public SpriteFont Font { get; set; }

        public Color FontColor
        {
            set
            {
                Color color;
                Color color2;
                Color color3;
                this.CursorColor = color = value;
                this.PromptColor = color2 = color;
                this.PastCommandOutputColor = color3 = color2;
                this.BufferColor = this.PastCommandColor = color3;
            }
        }

        public int Height { get; set; }

        public int Margin { get; set; }

        public bool OpenOnWrite { get; set; }

        internal static GameConsoleOptions Options { get; set; }
      

        public int Padding { get; set; }

        public Color PastCommandColor { get; set; }

        public Color PastCommandOutputColor { get; set; }

        public string Prompt { get; set; }

        public Color PromptColor { get; set; }

        internal Texture2D RoundedCorner { get; set; }

        public Keys ToggleKey { get; set; }
    }
}

