namespace Infra.Strategy
{
    public class PeriodMonth : IPeriodsStrategy
    {
        public static IPeriodsStrategy GetInstance(string description, IPeriodsStrategy instance)
        {
            bool isMonth = (description.Contains("month") || description.Contains("months")); 
            return (isMonth && instance == null) ? new PeriodMonth() : instance;
        }

        public int CalculateDays(int days)
        {
            return days * 30;
        }
    }
}