using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kangaroo_Cage
{
    public class SysTrayApp : Form
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.Run(new SysTrayApp());
        }

        private NotifyIcon TrayIcon;
        private ContextMenu TrayMenu;

        public SysTrayApp()
        {
            TrayMenu = new ContextMenu();
            TrayMenu.MenuItems.Add("Exit", OnExit);

            TrayIcon = new NotifyIcon();
            TrayIcon.Icon = CreateIcon(GetCalWeek().ToString());
            TrayIcon.MouseClick += new MouseEventHandler(TrayIcon_MouseClick);
            TrayIcon.ContextMenu = TrayMenu;
            TrayIcon.Visible = true;

        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;

            base.OnLoad(e);
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
                TrayIcon.Dispose();

            base.Dispose(isDisposing);
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                MessageBox.Show(GetNextWeeks(), "Calendar Weeks", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Icon CreateIcon(string str)
        {
            Font font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular, GraphicsUnit.Pixel);
            Brush brush = new SolidBrush(Color.White);
            Bitmap bitmapText = new Bitmap(16, 16);
            Graphics g = System.Drawing.Graphics.FromImage(bitmapText);

            IntPtr hIcon;

            g.Clear(Color.Transparent);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            g.DrawString(str, font, brush, -4, -2);
            hIcon = bitmapText.GetHicon();

            return (System.Drawing.Icon.FromHandle(hIcon));
        }

        private static int GetCalWeek()
        {
            int weekNo;

            System.Globalization.DateTimeFormatInfo dfi = System.Globalization.DateTimeFormatInfo.CurrentInfo;
            System.Globalization.Calendar cal = dfi.Calendar;

            weekNo = cal.GetWeekOfYear(DateTime.Today, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            return weekNo;
        }

        private static string GetNextWeeks()
        {
            return GetNextWeeks(5);
        }

        private static string GetNextWeeks(int counterNextWeeks)
        {
            string r = "Overview Calendar Weeks \r\n \r\n";
            int currWeek = GetCalWeek();

            System.Globalization.DateTimeFormatInfo dfi = System.Globalization.DateTimeFormatInfo.CurrentInfo;
            System.Globalization.Calendar cal = dfi.Calendar;

            // get the first day of the current week
            DateTime baseDate = DateTime.Today.AddDays(-(double)DateTime.Today.DayOfWeek + 1);

            for(int i = 0; i < counterNextWeeks; i++)
            {
                r += "KW " + currWeek.ToString() + ": \t";
                r += baseDate.Date.ToShortDateString();
                r += " - ";
                r += baseDate.AddDays(6).ToShortDateString();
                r += "\r\n";

                baseDate = baseDate.AddDays(7);
                currWeek++;
            }

            return r;
        }

    }
}
