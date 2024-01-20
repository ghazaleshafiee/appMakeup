using MakeUp.Extensions;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace MakeUp.Tools
{
    public static class DateTimeUtils
    {
        private static string ToPersianDate(DateTime date, string format = "yyyy/MM/dd HH:mm:ss")
        {
            try
            {
                if (date.Year < 1600)
                {
                    date = ToGregorianDate(date).Value;
                }
                else
                {
                    date = ToPersian(date);
                }

                if (date.Kind == DateTimeKind.Utc)
                {
                    date = ToIranTimeZoneDateTime(date);
                }

                var persianDate = date.ToString(format);

                return persianDate.ToPersianString();
            }
            catch (Exception)
            {
                return date.ToString(format);
            }
        }

        private static DateTime ToPersian(DateTime date)
        {
            try
            {
                if (date.Year < 1600)
                {
                    return date;
                }

                PersianCalendar pc = new PersianCalendar();
                var seocond = pc.GetSecond(date);
                var minute = pc.GetMinute(date);
                var hour = pc.GetHour(date);
                var day = pc.GetDayOfMonth(date);
                var month = pc.GetMonth(date);
                var year = pc.GetYear(date);

                return new DateTime(year, month, day, hour, minute, seocond);

            }
            catch (Exception)
            {
                return date;
            }
        }

        private static string ToPersian(DateTime? date, string format = "yyyy/MM/dd HH:mm:ss") => date.HasValue ? ToPersianDate(date.Value, format) : null;

        public static string ToPersianDate(DateTime? date) => date.HasValue ? ToPersian(date, "yyyy/MM/dd") : null;

        public static string ToPersianTime(DateTime? date) => date.HasValue ? ToPersian(date, "HH:mm:ss") : null;

        private static DateTime ToIranTimeZoneDateTime(DateTime dateTime)
        {
            var iranStandardTime = TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(timeZoneInfo =>
 timeZoneInfo.StandardName.Contains("Iran") ||
 timeZoneInfo.StandardName.Contains("Tehran") ||
 timeZoneInfo.Id.Contains("Iran") ||
 timeZoneInfo.Id.Contains("Tehran"));

            if (iranStandardTime == null)
            {
                TimeZoneInfo.GetSystemTimeZones().FirstOrDefault();
            }

            return TimeZoneInfo.ConvertTime(dateTime, iranStandardTime);
        }

        private static DateTime? ToGregorianDate(DateTime persianDateTime)
        {
            try
            {
                var year = persianDateTime.Year;
                var month = persianDateTime.Month;
                var day = persianDateTime.Day;
                if (year > 1600)
                {
                    return persianDateTime;
                }

                PersianCalendar pc = new PersianCalendar();
                return new DateTime(year, month, day, pc);
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
