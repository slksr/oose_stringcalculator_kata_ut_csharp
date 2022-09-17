namespace OOSE.TDD.StringCalculatorTests
{
    public class StringCalculatorTest : IClassFixture<StringCalculatorFixture>
    {
        private readonly StringCalculatorFixture calculator;

        public StringCalculatorTest(StringCalculatorFixture calculator)
        {
            this.calculator = calculator;
        }

        [Fact]
        public void EmptyStringReturnsZero()
        {
            Assert.Equal(0, calculator.StringCalculator.Add(""));
        }

        [Fact]
        public void StringNumberOneReturnsOne()
        {
            Assert.Equal(1, calculator.StringCalculator.Add("1"));
        }

        [Fact]
        public void StringNumberTwoReturnsTwo()
        {
            Assert.Equal(2, calculator.StringCalculator.Add("2"));
        }

        [Fact] 
        public void StringWithoutValidNumberShouldThrowIllegalArgumentException()
        {
            Assert.Throws<FormatException>(() => calculator.StringCalculator.Add("a"));
        }

        [Fact]
        public void StringWithTwoNumbersSeparatedByACommaReturnsSum()
        {
            Assert.Equal(3, calculator.StringCalculator.Add("1,2"));
        }

        [Fact]
        public void StringWithTwoNumbersSeparatedByADifferentSeparatorThrowsIllegalArgumentException()
        {
            Assert.Throws<FormatException>(() => calculator.StringCalculator.Add("1;2"));
        }
    }
}