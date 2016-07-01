using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ShiftDesktop
{
    // Class written by Dmitri Budnikov (a.k.a. Kretab Chabawenizc), http://stackoverflow.com/a/6407690/2391294
    // Minor modifications:
    //     * Added small delay buffer to improve reliability when sending multiple keystrokes.
    //     * Added KeyPress event to simplify single keystrokes
    static class KeyboardSend
    {
        //Delay between keystrokes. A slight delay between sending helps them register more consistently.
        const int _delayBuffer = 10; //milliseconds

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        private const int KEYEVENTF_EXTENDEDKEY = 1;
        private const int KEYEVENTF_KEYUP = 2;

        public static void KeyPress(Keys vKey)
        {
            KeyDown(vKey);
            KeyUp(vKey);
        }

        public static void KeyDown(Keys vKey)
        {
            keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
            Thread.Sleep(_delayBuffer);
        }

        public static void KeyUp(Keys vKey)
        {
            keybd_event((byte) vKey, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
            Thread.Sleep(_delayBuffer);
        }
    }
}