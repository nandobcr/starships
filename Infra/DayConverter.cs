using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Infra.Strategy;
using Infra.Factory;

namespace Infra
{
    public class DayConverter : IDayConverter
    {
        public int ConvertToDays(string description)
        {
            var regexNumber = new Regex(@"[^\d]");
            string days = regexNumber.Replace(description, "");
            int daysCount = (days == "") ? 0 : Convert.ToInt32(days);

            IPeriodsStrategy periodStrategy = PeriodsFactory.Create(description);
            if (periodStrategy != null)
            {
                return periodStrategy.CalculateDays(daysCount); 
            }

            return 0;
        }
    }
}