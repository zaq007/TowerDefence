namespace XNAGameConsole.KeyboardCapture
{
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Runtime.CompilerServices;

    internal class KeyEventArgs : EventArgs
    {
        public KeyEventArgs(Keys keyCode)
        {
            this.KeyCode = keyCode;
        }

        public Keys KeyCode { get; private set; }
    }
}

