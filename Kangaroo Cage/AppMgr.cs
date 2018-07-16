using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangaroo_Cage
{
    public static class AppMgr
    {
        public static void Run()
        {
            System.Windows.Forms.Application.Run(new SysTrayApp());
        }

        public static void OnExit(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        public static void OnTrayIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                DialogHandler.ShowMessage(DataModel.NextWeeks, "Next Weeks");
        }
    }
}
