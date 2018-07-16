using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangaroo_Cage
{
    public static class DataModel
    {
        public static System.Windows.Forms.ContextMenu TrayMenu { get; set; }
        public static System.Windows.Forms.NotifyIcon TrayIcon { get; set; }
        public static int CurrentWeek { get { return CalendarMgr.GetCalWeek(); } }
        public static string NextWeeks { get { return CalendarMgr.GetNextWeeks(); } }
    }
}
