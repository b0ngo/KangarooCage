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
            AppMgr.Run();
        }

        public SysTrayApp()
        {
            ContextMenuMgr ctxMenu = new ContextMenuMgr();
            ctxMenu.initMenu();

            TrayIconGenerator.Generate(DataModel.CurrentWeek.ToString());
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;

            base.OnLoad(e);
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
                DataModel.TrayIcon.Dispose();

            base.Dispose(isDisposing);
        }
    }
}
