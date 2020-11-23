namespace Infra.Strategy
{
    public class PeriodYear : IPeriodsStrategy
    {
        public static IPeriodsStrategy GetInstance(string description, IPeriodsStrategy instance)
        {
            bool isYear = (description.Contains("year") || description.Contains("years")); 
            return (isYear && instance == null) ? new PeriodYear() : instance;
        }

        public int CalculateDays(int days)
        {
            return days * 365;
        }
    }
}