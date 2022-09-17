using OOSE.TDD.StringCalculator;

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
        public void StringWithoutValidNumberShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => calculator.StringCalculator.Add("a"));
        }

        [Fact]
        public void StringWithTwoNumbersSeparatedByACommaReturnsSum()
        {
            Assert.Equal(3, calculator.StringCalculator.Add("1,2"));
        }

        [Fact]
        public void StringWithTwoNumbersSeparatedByADifferentSeparatorThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => calculator.StringCalculator.Add("1;2"));
        }

        [Fact]
        public void StringWithThreeNumbersSeparatedByACommaReturnsSum()
        {
            Assert.Equal(6, calculator.StringCalculator.Add("1,2,3"));
        }

        [Fact]
        public void StringWithThreeNumbersAndTwoSeparatorsReturnsSum()
        {
            Assert.Equal(6, calculator.StringCalculator.Add("1\n2,3"));
        }

        [Fact]
        public void StringWithOneNumberAndTwoSeparatorsThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => calculator.StringCalculator.Add("1,\n"));
        }

        [Fact]
        public void StringWithTwoNumbersAndSemicolonACustomDelimiterReturnsSum()
        {
            Assert.Equal(3, calculator.StringCalculator.Add("//;\n1;2"));
        }

        [Fact]
        public void StringWithThreeNumbersAndExclamationMarkAsCustomDelimiterReturnsSum()
        {
            Assert.Equal(6, calculator.StringCalculator.Add("//!\n1!2!3"));
        }

        [Fact]
        public void StringWithThreeNumbersAndDollarSignAndNewLineAsCustomDelimiterReturnsSum()
        {
            Assert.Equal(6, calculator.StringCalculator.Add("//$\n1$2\n3"));
        }

        [Fact]
        public void StringNumberNegativeTwoReturnsThrowsArgumentExceptionContainingWrongNumber()
        {
            try
            {
                calculator.StringCalculator.Add("-2");
                Assert.True(false); // Test moet altijd falen, de echte check zit in de catch!
            }
            catch (ArgumentException e)
            {
                Assert.Contains("negatives not allowed", e.Message);
                Assert.Contains("-2", e.Message);
            }
        }

        [Fact]
        public void StringNumberTwoNegativesReturnsThrowsArgumentExceptionContainingWrongNumbers()
        {
            try
            {
                calculator.StringCalculator.Add("-2,-3");
                Assert.True(false);
            }
            catch (ArgumentException e)
            {
                Assert.Contains("negatives not allowed", e.Message);
                Assert.Contains("-2", e.Message);
                Assert.Contains("-3", e.Message);
            }
        }
    }
}