using Xunit;
using Domain.Calculation;

namespace Test.App
{
    public class CalculationStopsTest
    {
        [Fact]
        public void ShouldReturn9StopsWhenTheDistanceEqual1MillionAndMGLTEqual75AndConsumablesEqual60Days()
        {
            var calculationStops = new CalculationStops();
            int stopsRequired = calculationStops.CalculateStops(1000000, 75, 60);
            Assert.Equal(9, stopsRequired);
        }

        [Fact]
        public void ShouldReturn11StopsWhenTheDistanceEqual3MillionsAndMGLTEqual10AndConsumablesEqual1095Days()
        {
            var calculationStops = new CalculationStops();
            int stopsRequired = calculationStops.CalculateStops(3000000, 10, 1095);
            Assert.Equal(11, stopsRequired);
        }

        [Fact]
        public void ShouldReturn5StopsWhenTheDistanceEqual100HundredThousandAndMGLTEqual100AndConsumablesEqual7Days()
        {
            var calculationStops = new CalculationStops();
            int stopsRequired = calculationStops.CalculateStops(100000, 100, 7);
            Assert.Equal(5, stopsRequired);
        }

        [Fact]
        public void ShouldReturn0StopsWhenTheDistanceEqual100HundredThousandAndMGLTEqual0AndConsumablesEqual7Days()
        {
            var calculationStops = new CalculationStops();
            int stopsRequired = calculationStops.CalculateStops(100000, 0, 7);
            Assert.Equal(0, stopsRequired);
        }

        [Fact]
        public void ShouldReturn0StopsWhenTheDistanceEqual100HundredThousandAndMGLTEqual150AndConsumablesEqual0Days()
        {
            var calculationStops = new CalculationStops();
            int stopsRequired = calculationStops.CalculateStops(100000, 150, 0);
            Assert.Equal(0, stopsRequired);
        }        
    }
}