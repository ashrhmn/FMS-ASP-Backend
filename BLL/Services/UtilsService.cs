using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UtilsService
    {
        public static string GetNextWeekDay(string day)
        {
            var days = new List<string>() { "sunday", "monday", "tuesday", "wednesday", "thursday", "friday", "saturday" };
            if (!days.Contains(day.ToLower())) return null;
            var target = days.IndexOf(day);
            var from = (int)DateTime.Now.DayOfWeek;
            var diff = target > from ? target - from : target + 7 - from;
            var next = DateTime.Now.AddDays(diff).ToShortDateString();
            return next;
        }
    }
}
