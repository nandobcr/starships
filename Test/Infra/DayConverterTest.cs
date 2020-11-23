using Xunit;
using Infra;

namespace Test.Infra
{
    public class DayConverterTest
    {
        public readonly IDayConverter DayConverter;

        public DayConverterTest()
        {
            this.DayConverter = new DayConverter();
        }

        [Fact]
        public void ShouldConvertIn1DayWhenOriginEqual1Day()
        {
            int daysCount = this.DayConverter.ConvertToDays("1 day");
            Assert.Equal(1, daysCount);
        }

        [Fact]
        public void ShouldConvertIn5DaysWhenOriginEqual5Days()
        {
            int daysCount = this.DayConverter.ConvertToDays("5 days");
            Assert.Equal(5, daysCount);
        }
        
        [Fact]
        public void ShouldConvertIn7DaysWhenOriginEqual1Week()
        {
            int daysCount = this.DayConverter.ConvertToDays("1 week");
            Assert.Equal(7, daysCount);
        }

        [Fact]
        public void ShouldConvertIn21DaysWhenOriginEqual3Weeks()
        {
            int daysCount = this.DayConverter.ConvertToDays("3 weeks");
            Assert.Equal(21, daysCount);
        }

        [Fact]
        public void ShouldConvertIn30DaysWhenOriginEqual1Month()
        {
            int daysCount = this.DayConverter.ConvertToDays("1 month");
            Assert.Equal(30, daysCount);
        }

        [Fact]
        public void ShouldConvertIn180DaysWhenOriginEqual6Months()
        {
            int daysCount = this.DayConverter.ConvertToDays("6 months");
            Assert.Equal(180, daysCount);
        }

        [Fact]
        public void ShouldConvertIn365DaysWhenOriginEqual1Year()
        {
            int daysCount = this.DayConverter.ConvertToDays("1 year");
            Assert.Equal(365, daysCount);            
        }

        [Fact]
        public void ShouldConvertIn1825DaysWhenOriginEqual5Years()
        {
            int daysCount = this.DayConverter.ConvertToDays("5 years");
            Assert.Equal(1825, daysCount);            
        }

        [Fact]
        public void ShouldConvertIn0DayWhenOriginUnkown()
        {
            int daysCount = this.DayConverter.ConvertToDays("unknow");
            Assert.Equal(0, daysCount);
        }
    }
}