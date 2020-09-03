using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleCalculator;
using System.Text;
namespace ConsoleCalculatorTest
{
    [TestClass]
    public class CalculatorUnitTest
    {
        private Calculator calc;
        StringBuilder  str = new StringBuilder();
        public void InitializeCalculator()
        {
            calc = new Calculator();
        }

        [TestMethod]
        public void IgnoreOtherChars()
        {
           InitializeCalculator();
            StringBuilder str = calc.DisplayString;            
            calc.SendKeyPress('a');
            Assert.AreEqual(calc.DisplayString, str);
        }

        [TestMethod]
        public void Press_C()
        {
            InitializeCalculator();       
            calc.SendKeyPress('3');
            calc.SendKeyPress('c');       
            Assert.AreEqual(calc.DisplayString.ToString(),"0");
        }
        
        [TestMethod]
        public void DisplayZeroOnStart()
        {
            InitializeCalculator();           
            Assert.AreEqual(calc.DisplayString.ToString(), "0");
        }

        [TestMethod]
        public void Press_S()
        {
            InitializeCalculator();
            calc.SendKeyPress('2');
            calc.SendKeyPress('s');
            Assert.AreEqual(calc.DisplayString.ToString(), "-2");
        }

        [TestMethod]
        public void CheckForCase()
        {
            InitializeCalculator();
            calc.SendKeyPress('1');
            calc.SendKeyPress('2');
            calc.SendKeyPress('+');
            Assert.AreEqual(calc.DisplayString.ToString(), "12");
                       
            calc.SendKeyPress('2');
            calc.SendKeyPress('S');
            Assert.AreEqual(calc.DisplayString.ToString(), "-2");
            calc.SendKeyPress('S');
            Assert.AreEqual(calc.DisplayString.ToString(), "2");

            calc.SendKeyPress('S');
            calc.SendKeyPress('=');
            Assert.AreEqual(calc.DisplayString.ToString(), "10");
        }

        [TestMethod]
        public void CheckForNumbers()
        {
            InitializeCalculator();
            calc.SendKeyPress('2');
            calc.SendKeyPress('3');
            Assert.AreEqual(calc.DisplayString.ToString(), "23");

            calc.SendKeyPress('+');
            Assert.AreEqual(calc.DisplayString.ToString(), "23");

            calc.SendKeyPress('2');
            Assert.AreEqual(calc.DisplayString.ToString(), "2");
            
            calc.SendKeyPress('=');
            Assert.AreEqual(calc.DisplayString.ToString(), "25");
        }

        [TestMethod]
        public void DivideByZero()
        {
            InitializeCalculator();
            calc.SendKeyPress('2');
            calc.SendKeyPress('/');   
            calc.SendKeyPress('0');
            calc.SendKeyPress('=');
            Assert.AreEqual(calc.DisplayString.ToString(), "-E-");
        }

        [TestMethod]
        public void ConsecutiveZero()
        {
            InitializeCalculator();
            calc.SendKeyPress('0');
            calc.SendKeyPress('0');
            calc.SendKeyPress('0');
            Assert.AreEqual(calc.DisplayString.ToString(), "0");

            calc.SendKeyPress('.');
            calc.SendKeyPress('0');
            calc.SendKeyPress('0');
            Assert.AreEqual(calc.DisplayString.ToString(), "0.00");
        }


    }
}
