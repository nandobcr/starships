using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Infra
{
    public class DayConverter : IDayConverter
    {
        public int ConvertToDays(string source)
        {
            var periods = new List<string>(){ "day", "days", "week", "weeks", "month", "months", "year", "years" };
            string descriptionOfPeriod = string.Empty;

            foreach (var period in periods)
            {
                int index = source.IndexOf(period);
                if (index > -1)
                {
                    descriptionOfPeriod = source.Substring(index);
                }
            }  

            var regexNumber = new Regex(@"[^\d]");
            string sourceNumber = regexNumber.Replace(source, "");
            int daysCount = (sourceNumber == "") ? 0 : Convert.ToInt32(sourceNumber);
            
            switch (descriptionOfPeriod)
            {
                case "day":
                case "days":
                    return daysCount;
                case "week":
                case "weeks":
                    return daysCount * 7;
                case "month":
                case "months":
                    return daysCount * 30;
                case "year":
                case "years":
                    return daysCount * 365;
                default:
                    return 0;
            }
        }
    }
}