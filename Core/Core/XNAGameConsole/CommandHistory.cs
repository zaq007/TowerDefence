namespace XNAGameConsole
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    internal class CommandHistory : List<string>
    {
        public void Add(string command)
        {
            foreach (string str in command.Split(new char[] { '\n' }))
            {
                if (str != "")
                {
                    base.Add(str);
                }
            }
            this.Reset();
        }

        public string Next()
        {
            if (base.Count == 0)
            {
                return "";
            }
            if ((this.Index + 1) <= (base.Count - 1))
            {
                int num;
                this.Index = num = this.Index + 1;
                return base[num];
            }
            return base[base.Count - 1];
        }

        public string Previous()
        {
            if (base.Count == 0)
            {
                return "";
            }
            if ((this.Index - 1) >= 0)
            {
                int num;
                this.Index = num = this.Index - 1;
                return base[num];
            }
            return base[0];
        }

        public void Reset()
        {
            this.Index = base.Count;
        }

        public int Index { get; private set; }
    }
}

