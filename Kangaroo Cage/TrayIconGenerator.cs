using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kangaroo_Cage
{
    static class TrayIconGenerator
    {
        private static NotifyIcon TrayIcon;

        private static void GetTrayIcon() { TrayIcon = DataModel.TrayIcon; }
        private static void SetTrayIcon() { DataModel.TrayIcon = TrayIcon; }

        public static void Generate(string str)
        {
            GetTrayIcon();

            if (TrayIcon == null)
                TrayIcon = new NotifyIcon();

            TrayIcon.Icon = CreateIcon(str);
            TrayIcon.MouseClick += new MouseEventHandler(AppMgr.OnTrayIcon_MouseClick);
            TrayIcon.ContextMenu = DataModel.TrayMenu;
            TrayIcon.Visible = true;

            SetTrayIcon();
        }

        private static Icon CreateIcon(string str)
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
    }
}
