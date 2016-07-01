using System;
using System.Windows.Forms;

namespace ShiftDesktop
{
    /// <summary>
    /// Sends keyboard key combos Ctrl+Win+Left or Ctrl+Win+Right to shift virtual desktops in Windows 10, or key combo Win+Tab to show the application switcher.
    /// Implemented as a WinForm rather than a console app to prevent taskbar icon from showing when assigned to a mouse button or keyboard media button.
    /// May be referenced by other .NET assemblies so public methods can be called directly.
    /// </summary>
    public partial class ShiftForm : Form
    {

        #region Command-line interface

        /// <summary>
        /// Shifts to the previous or next (left or right) virtual desktop in Windows 10, depending on args
        /// </summary>
        /// <param name="args">Use argument "/l" to shift left, "/r" to shift right, "/a" for app switcher, "/?" for help.</param>
        public static void Main(string[] args)
        {
            if (FirstArgStartsWith(args, "a"))
            {
                //Show application switcher
                ShowApplicationSwitcher();
            }
            else if (FirstArgStartsWith(args, "l"))
            {
                //Shift desktop left
                ShiftDesktopLeft();
            }
            else if (FirstArgStartsWith(args, "r"))
            {
                //Shift desktop left
                ShiftDesktopRight();
            }
            else
            {
                //Show Help message
                ShowUsageMessage();
            }
        }

        /// <summary>
        /// Quick-and-dirty check to see if the first argument starts with the given string. Case-insensitive. 
        /// Example: FirstArgStartsWith(args, "x") will return true for -X, /x, \X, -x1, /Xylophone, etc.
        /// </summary>
        private static Boolean FirstArgStartsWith(string[] args, string flag)
        {
            return (args.Length > 0 && args[0].ToLower().IndexOf(flag) == 1);
        }

        private static void ShowUsageMessage()
        {
            Console.WriteLine(@"Usage:");
            Console.WriteLine(@"    ""ShiftDesktop /l"" to shift to the previous (left) Windows 10 virtual desktop");
            Console.WriteLine(@"    ""ShiftDesktop /r"" to shift to the next (right) Windows 10 virtual desktop");
            Console.WriteLine(@"    ""ShiftDesktop /a"" to show application switcher");
        }

        #endregion


        #region .NET code API
        /// <summary>
        /// Simulates key-press combo Win+Tab, to show the Windows 10 application switcher.
        /// </summary>
        public static void ShowApplicationSwitcher()
        {
            DesktopShifter.SendCtrlTabKeyCombo();
        }

        /// <summary>
        /// Simulates key-press combo Ctrl+Win+Left, to shift to the previous (left) virtual desktop in Windows 10.
        /// </summary>
        public static void ShiftDesktopLeft()
        {
            DesktopShifter.ShiftDesktop(DesktopShifter.Direction.Left);
        }

        /// <summary>
        /// Simulates key-press combo Ctrl+Win+Left, to shift to the next (right) virtual desktop in Windows 10.
        /// </summary>
        public static void ShiftDesktopRight()
        {
            DesktopShifter.ShiftDesktop(DesktopShifter.Direction.Right);
        }
        #endregion
        

        #region Form plumbing

        private void ShiftForm_Load(object sender, EventArgs e)
        {
            //Immediately close the form, as it's not intended for display or user input.
            this.Close();
        }
        public ShiftForm()
        {
            InitializeComponent();
        }

        #endregion

    }
}
