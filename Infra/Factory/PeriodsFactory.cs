using Infra.Strategy;

namespace Infra.Factory
{
    public static class PeriodsFactory
    {
        public static IPeriodsStrategy Create(string description)
        {
            IPeriodsStrategy instance = null;
            instance = PeriodDay.GetInstance(description, instance);
            instance = PeriodWeek.GetInstance(description, instance);
            instance = PeriodMonth.GetInstance(description, instance);
            instance = PeriodYear.GetInstance(description, instance);
            
            return instance;            
        } 
    }
}