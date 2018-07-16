using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangaroo_Cage
{
    public static class CalendarMgr
    {
        public static int GetCalWeek()
        {
            int weekNo;

            System.Globalization.DateTimeFormatInfo dfi = System.Globalization.DateTimeFormatInfo.CurrentInfo;
            System.Globalization.Calendar cal = dfi.Calendar;

            weekNo = cal.GetWeekOfYear(DateTime.Today, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            return weekNo;
        }

        public static string GetNextWeeks()
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

            for (int i = 0; i < counterNextWeeks; i++)
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
