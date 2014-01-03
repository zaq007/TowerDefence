namespace XNAGameConsole.KeyboardCapture
{
    using System;

    internal class CharacterEventArgs : EventArgs
    {
        private readonly char character;
        private readonly int lParam;

        public CharacterEventArgs(char character, int lParam)
        {
            this.character = character;
            this.lParam = lParam;
        }

        public bool AltPressed
        {
            get
            {
                return ((this.lParam & 0x20000000) > 0);
            }
        }

        public char Character
        {
            get
            {
                return this.character;
            }
        }

        public bool ExtendedKey
        {
            get
            {
                return ((this.lParam & 0x1000000) > 0);
            }
        }

        public int Param
        {
            get
            {
                return this.lParam;
            }
        }

        public bool PreviousState
        {
            get
            {
                return ((this.lParam & 0x40000000) > 0);
            }
        }

        public int RepeatCount
        {
            get
            {
                return (this.lParam & 0xffff);
            }
        }

        public bool TransitionState
        {
            get
            {
                return ((this.lParam & -2147483648) > 0);
            }
        }
    }
}

