namespace Infra.Strategy
{
    public class PeriodDay : IPeriodsStrategy
    {
        public static IPeriodsStrategy GetInstance(string description, IPeriodsStrategy instance)
        {
            bool isDay = (description.Contains("day") || description.Contains("days")); 
            return (isDay && instance == null) ? new PeriodDay() : instance;
        }

        public int CalculateDays(int days)
        {
            return days;
        }
    }
}