namespace XNAGameConsole.KeyboardCapture
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    internal static class EventInput
    {
        private const int DLGC_WANTALLKEYS = 4;
        private const int GWL_WNDPROC = -4;
        private static IntPtr hIMC;
        private static WndProc hookProcDelegate;
        private static bool initialized;
        private static IntPtr prevWndProc;
        private const int WM_CHAR = 0x102;
        private const int WM_GETDLGCODE = 0x87;
        private const int WM_IME_COMPOSITION = 0x10f;
        private const int WM_IME_SETCONTEXT = 0x281;
        private const int WM_INPUTLANGCHANGE = 0x51;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;

        public static  event CharEnteredHandler CharEntered;

        public static  event KeyEventHandler KeyDown;

        public static  event KeyEventHandler KeyUp;

        [DllImport("user32.dll")]
        private static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        private static IntPtr HookProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            IntPtr ptr = CallWindowProc(prevWndProc, hWnd, msg, wParam, lParam);
            uint num = msg;
            if (num <= 0x87)
            {
                switch (num)
                {
                    case 0x51:
                        ImmAssociateContext(hWnd, hIMC);
                        return (IntPtr) 1;

                    case 0x87:
                        return (IntPtr) (ptr.ToInt32() | 4);
                }
                return ptr;
            }
            switch (num)
            {
                case 0x100:
                    if (KeyDown != null)
                    {
                        KeyDown(null, new KeyEventArgs((Keys) ((int) wParam)));
                    }
                    return ptr;

                case 0x101:
                    if (KeyUp != null)
                    {
                        KeyUp(null, new KeyEventArgs((Keys) ((int) wParam)));
                    }
                    return ptr;

                case 0x102:
                    if (CharEntered != null)
                    {
                        CharEntered(null, new CharacterEventArgs((char) ((int) wParam), lParam.ToInt32()));
                    }
                    return ptr;

                case 0x281:
                    if (wParam.ToInt32() == 1)
                    {
                        ImmAssociateContext(hWnd, hIMC);
                    }
                    return ptr;
            }
            return ptr;
        }

        [DllImport("Imm32.dll")]
        private static extern IntPtr ImmAssociateContext(IntPtr hWnd, IntPtr hIMC);
        [DllImport("Imm32.dll")]
        private static extern IntPtr ImmGetContext(IntPtr hWnd);
        public static void Initialize(GameWindow window)
        {
            if (initialized)
            {
                throw new InvalidOperationException("TextInput.Initialize can only be called once!");
            }
            hookProcDelegate = new WndProc(EventInput.HookProc);
            prevWndProc = (IntPtr) SetWindowLong(window.Handle, -4, (int) Marshal.GetFunctionPointerForDelegate(hookProcDelegate));
            hIMC = ImmGetContext(window.Handle);
            initialized = true;
        }

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    }
}

