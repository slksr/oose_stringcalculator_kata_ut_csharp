namespace OOSE.TDD.StringCalculatorTests
{
    /// <summary>
    /// Create a simple String calculator with a method int Add(string numbers). The method can take 0, 1 or 2 numbers, 
    /// and will return their sum (for an empty string it will return 0) for example “” or “1” or “1,2”
    /// </summary>
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

        [Fact]
        public void StringWithThreeNumbersSeparatedByACommaReturnsSum()
        {
            Assert.Equal(6, calculator.StringCalculator.Add("1,2,3"));
        }
    }
}