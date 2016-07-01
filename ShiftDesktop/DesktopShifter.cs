using System.Threading;
using System.Windows.Forms;

namespace ShiftDesktop
{
    internal class DesktopShifter
    {
        internal enum Direction
        {
            Left,
            Right
        }

        internal static void ShiftDesktop(Direction direction)
        {
            Keys directionKey = direction == Direction.Left ? Keys.Left : Keys.Right;
            SendCtrlWinKeyCombo(directionKey);
        }

        internal static void SendCtrlTabKeyCombo()
        {
            KeyboardSend.KeyDown(Keys.LWin);
            KeyboardSend.KeyPress(Keys.Tab);
            KeyboardSend.KeyUp(Keys.LWin);
        }

        private static void SendCtrlWinKeyCombo(Keys key)
        {
            KeyboardSend.KeyDown(Keys.ControlKey);
            KeyboardSend.KeyDown(Keys.LWin);
            KeyboardSend.KeyPress(key);
            KeyboardSend.KeyUp(Keys.LWin);
            KeyboardSend.KeyUp(Keys.ControlKey);
        }
    }
}
