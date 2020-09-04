using System;
using Xunit;
using ConsoleCalculator;
using System.Text;

namespace CalculatorTests
{
    public class CalculatorTests
    {
        private Calculator calc;
       readonly StringBuilder str = new StringBuilder();

        [Fact]
        public void InitializeCalculator()
        {
            calc = new Calculator();
        }

        [Fact]
        public void IgnoreOtherChars()
        {
            InitializeCalculator();
            StringBuilder str = calc.DisplayString;
            calc.SendKeyPress('a');
            Assert.Equal(calc.DisplayString, str);
        }
        [Fact]
        public void Press_C()
        {
            InitializeCalculator();
            calc.SendKeyPress('3');
            calc.SendKeyPress('c');
            Assert.Equal( "0", calc.DisplayString.ToString());
        }

        [Fact]
        public void DisplayZeroOnStart()
        {
            InitializeCalculator();
            Assert.Equal( "0", calc.DisplayString.ToString());
        }
        [Fact]
        public void Press_S()
        {
            InitializeCalculator();
            calc.SendKeyPress('2');
            calc.SendKeyPress('s');
            Assert.Equal("-2",calc.DisplayString.ToString());
        }

        [Fact]
        public void CheckForCase()
        {
            InitializeCalculator();
            calc.SendKeyPress('1');
            calc.SendKeyPress('2');
            calc.SendKeyPress('+');
            Assert.Equal("12",calc.DisplayString.ToString());

            calc.SendKeyPress('2');
            calc.SendKeyPress('S');
            Assert.Equal("-2",calc.DisplayString.ToString());
            calc.SendKeyPress('S');
            Assert.Equal("2", calc.DisplayString.ToString());

            calc.SendKeyPress('S');
            calc.SendKeyPress('=');
            Assert.Equal("10", calc.DisplayString.ToString());
        }

        [Fact]
        public void CheckForNumbers()
        {
            InitializeCalculator();
            calc.SendKeyPress('2');
            calc.SendKeyPress('3');
            Assert.Equal("23", calc.DisplayString.ToString());

            calc.SendKeyPress('+');
            Assert.Equal("23", calc.DisplayString.ToString());

            calc.SendKeyPress('2');
            Assert.Equal("2", calc.DisplayString.ToString());

            calc.SendKeyPress('=');
            Assert.Equal("25", calc.DisplayString.ToString());
        }

        [Fact]
        public void DivideByZero()
        {
            InitializeCalculator();
            calc.SendKeyPress('2');
            calc.SendKeyPress('/');
            calc.SendKeyPress('0');
            calc.SendKeyPress('=');
            Assert.Equal("-E-", calc.DisplayString.ToString());
        }

        [Fact]
        public void ConsecutiveZero()
        {
            InitializeCalculator();
            calc.SendKeyPress('0');
            calc.SendKeyPress('0');
            calc.SendKeyPress('0');
            Assert.Equal("0", calc.DisplayString.ToString());

            calc.SendKeyPress('.');
            calc.SendKeyPress('0');
            calc.SendKeyPress('0');
            Assert.Equal("0.00", calc.DisplayString.ToString());
        }

    }
}
