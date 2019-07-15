using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void DummyTest()
        {
            return;
        }
        [Fact]
            public void BasicOperationTest()
            {
                Assert.Equal("12",SolveEquation("10+2="));
            }
         [Fact]
            public void InvalidOperationTest()
            {
                Assert.Equal("-E-",SolveEquation("10/0="));
            }
         [Fact]
            public void MultipleZeroOperationTest3()
            {
                Assert.Equal("0.001",SolveEquation("00..001"));
            }
        [Fact]
            public void ToggleSignOperationTest()
            {
                Assert.Equal("10",SolveEquation("12+2sss="));
            }
         [Fact]
            public void ResetOperationTest()
            {
                Assert.Equal("0",SolveEquation("1+2+c"));
            }

         [Fact]
            public void TogglingTest()
            {
                Assert.Equal("8",SolveEquation("10+2S="));
            }

         [Fact]
            public void ComplexOperationTest()
            {
                Assert.Equal("6",SolveEquation("1+2+3+"));
            }
        
         public string SolveEquation(string equation)
        {
            Calculator calculator = new Calculator();
            string output = "";
            foreach (char ch in equation)
            {
                output = calculator.SendKeyPress(ch);
            }
            return output;
        }
    }
}
