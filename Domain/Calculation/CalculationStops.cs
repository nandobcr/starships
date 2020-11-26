namespace Domain.Calculation
{
    public class CalculationStops
    {
        private const int Hour = 24; 

        public int CalculateStops(int distance, int mglt, int daysCount)
        {
            int autonomy = (daysCount * Hour * mglt);
            return (autonomy > 0) ? (distance / autonomy) : 0;
        }
    }
}