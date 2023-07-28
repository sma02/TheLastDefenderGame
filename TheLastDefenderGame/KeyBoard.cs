using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame
{
    class KeyBoard
    {
        [DllImport("user32.dll")]
        private static extern short GetKeyState(int nVirtKey);
        public static bool IsKeyPressed(Key key)
        {
            return GetKeyState((int)key) < 0;
        }
    }
    public enum Key
    {
        Backspace = 8,
        Tab,
        Enter = 13,
        Shift = 16,
        Control,
        Escape = 27,
        CapsLock = 20,
        Space = 32,
        PageUp,
        PageDown,
        End,
        Home,
        LeftArrow,
        UpArrow,
        RightArrow,
        DownArrow,
        Select,
        Printscreen = 44,
        Insert,
        Delete,
        Key0 = 48,
        Key1,
        Key2,
        Key3,
        Key4,
        Key5,
        Key6,
        Key7,
        Key8,
        Key9,
        A = 65,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z,
        WinLeft,
        WinRight,
        Num0 = 96,
        Num1,
        Num2,
        Num3,
        Num4,
        Num5,
        Num6,
        Num7,
        Num8,
        Num9,
        F1 = 112,
        F2,
        F3,
        F4,
        F5,
        F6,
        F7,
        F8,
        F9,
        F10,
        F11,

        F12,

        NumLock = 144,

        ScrollLock
    }
}
