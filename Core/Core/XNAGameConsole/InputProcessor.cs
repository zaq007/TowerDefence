namespace XNAGameConsole
{
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;
    using XNAGameConsole.KeyboardCapture;

    internal class InputProcessor
    {
        private const int BACKSPACE = 8;
        private CommandProcesser commandProcesser;
        private const int ENTER = 13;
        private bool isActive;
        private bool isHandled;
        private const int TAB = 9;

        public event EventHandler Close;

        public event EventHandler ConsoleCommand;

        public event EventHandler Open;

        public event EventHandler PlayerCommand;

        public InputProcessor(CommandProcesser commandProcesser)
        {
            this.commandProcesser = commandProcesser;
            this.isActive = false;
            this.CommandHistory = new XNAGameConsole.CommandHistory();
            this.Out = new List<OutputLine>();
            this.Buffer = new OutputLine("", OutputLineType.Command);
            EventInput.CharEntered += new CharEnteredHandler(this.EventInput_CharEntered);
            EventInput.KeyDown += new XNAGameConsole.KeyboardCapture.KeyEventHandler(this.EventInput_KeyDown);
        }

        public void AddToBuffer(string text)
        {
            string[] strArray = (from line in text.Split(new char[] { '\n' })
                where line != ""
                select line).ToArray<string>();
            int index = 0;
            while (index < (strArray.Length - 1))
            {
                string str = strArray[index];
                OutputLine line1 = this.Buffer;
                line1.Output = line1.Output + str;
                this.ExecuteBuffer();
                index++;
            }
            OutputLine buffer = this.Buffer;
            buffer.Output = buffer.Output + strArray[index];
        }

        public void AddToOutput(string text)
        {
            if (GameConsoleOptions.Options.OpenOnWrite)
            {
                this.isActive = true;
                this.Open(this, EventArgs.Empty);
            }
            foreach (string str in text.Split(new char[] { '\n' }))
            {
                this.Out.Add(new OutputLine(str, OutputLineType.Output));
            }
        }

        private void AutoComplete()
        {
            int num = this.Buffer.Output.LastIndexOf(' ');
            string str = (num < 0) ? this.Buffer.Output : this.Buffer.Output.Substring(num + 1, (this.Buffer.Output.Length - num) - 1);
            IConsoleCommand matchingCommand = GetMatchingCommand(str);
            if (matchingCommand != null)
            {
                string str2 = matchingCommand.Name.Substring(str.Length);
                OutputLine buffer = this.Buffer;
                buffer.Output = buffer.Output + str2 + " ";
            }
        }

        private void EventInput_CharEntered(object sender, CharacterEventArgs e)
        {
            if (this.isHandled)
            {
                this.isHandled = false;
            }
            else
            {
                this.CommandHistory.Reset();
                switch (e.Character)
                {
                    case '\b':
                        if (this.Buffer.Output.Length <= 0)
                        {
                            break;
                        }
                        this.Buffer.Output = this.Buffer.Output.Substring(0, this.Buffer.Output.Length - 1);
                        return;

                    case '\t':
                        this.AutoComplete();
                        return;

                    case '\r':
                        this.ExecuteBuffer();
                        return;

                    default:
                        if (IsPrintable(e.Character))
                        {
                            OutputLine buffer = this.Buffer;
                            buffer.Output = buffer.Output + e.Character;
                        }
                        break;
                }
            }
        }

        private void EventInput_KeyDown(object sender, XNAGameConsole.KeyboardCapture.KeyEventArgs e)
        {
            if ((Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.V) && Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl)) && (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA))
            {
                this.AddToBuffer(Clipboard.GetText());
            }
            if (e.KeyCode == GameConsoleOptions.Options.ToggleKey)
            {
                this.ToggleConsole();
                this.isHandled = true;
            }
            switch (e.KeyCode)
            {
                case Microsoft.Xna.Framework.Input.Keys.Up:
                    this.Buffer.Output = this.CommandHistory.Previous();
                    return;

                case Microsoft.Xna.Framework.Input.Keys.Right:
                    break;

                case Microsoft.Xna.Framework.Input.Keys.Down:
                    this.Buffer.Output = this.CommandHistory.Next();
                    break;

                default:
                    return;
            }
        }

        private void ExecuteBuffer()
        {
            if (this.Buffer.Output.Length != 0)
            {
                IEnumerable<string> enumerable = from l in this.commandProcesser.Process(this.Buffer.Output).Split(new char[] { '\n' })
                    where l != ""
                    select l;
                this.Out.Add(new OutputLine(this.Buffer.Output, OutputLineType.Command));
                foreach (string str in enumerable)
                {
                    this.Out.Add(new OutputLine(str, OutputLineType.Output));
                }
                this.CommandHistory.Add(this.Buffer.Output);
                this.Buffer.Output = "";
            }
        }

        private static IConsoleCommand GetMatchingCommand(string command)
        {
            return (from c in GameConsoleOptions.Commands
                where (c.Name != null) && c.Name.StartsWith(command)
                select c).FirstOrDefault<IConsoleCommand>();
        }

        private static bool IsPrintable(char letter)
        {
            return GameConsoleOptions.Options.Font.Characters.Contains(letter);
        }

        private void ToggleConsole()
        {
            this.isActive = !this.isActive;
            if (this.isActive)
            {
                this.Open(this, EventArgs.Empty);
            }
            else
            {
                this.Close(this, EventArgs.Empty);
            }
        }

        public OutputLine Buffer { get; set; }

        public XNAGameConsole.CommandHistory CommandHistory { get; set; }

        public List<OutputLine> Out { get; set; }
    }
}

