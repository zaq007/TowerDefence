namespace XNAGameConsole
{
    using System;
    using System.Runtime.CompilerServices;

    internal class OutputLine
    {
        public OutputLine(string output, OutputLineType type)
        {
            this.Output = output;
            this.Type = type;
        }

        public override string ToString()
        {
            return this.Output;
        }

        public string Output { get; set; }

        public OutputLineType Type { get; set; }
    }
}

