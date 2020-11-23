namespace Infra.Strategy
{
    public class PeriodWeek : IPeriodsStrategy
    {
        public static IPeriodsStrategy GetInstance(string description, IPeriodsStrategy instance)
        {
            bool isWeek = (description.Contains("week") || description.Contains("weeks")); 
            return (isWeek && instance == null) ? new PeriodWeek() : instance;
        }

        public int CalculateDays(int days)
        {
            return days * 7;
        }
    }
}