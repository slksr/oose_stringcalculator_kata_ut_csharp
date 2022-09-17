using OOSE.TDD.StringCalculator;

namespace OOSE.TDD.StringCalculatorTests
{
    public class StringCalculatorFixture
    {
        public StringCalculatorFixture()
        {
            StringCalculator = new Calculator();
        }


        public Calculator StringCalculator { get; private set; }
    }
}