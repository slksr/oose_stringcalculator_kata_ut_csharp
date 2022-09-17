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
    }
}