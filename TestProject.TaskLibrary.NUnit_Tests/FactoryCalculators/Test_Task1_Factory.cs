using System;
using NUnit.Framework;
//using TestProject.TaskLibrary.CalculatorsForUnitTest;
using TestProject.TaskLibrary.CalculatorsForUnitTest.Factory;

namespace TestProject.TaskLibrary.NUnit_Tests.FactoryCalculators
{
    [TestFixture]
    public class Test_Task1_Factory
    {
        private Calculator<int> _calc;

        [SetUp]
        public void SetUp()
        {
            _calc = new CalculatorFactory<int>().CreateCalc(); // = new CalculatorIntFabric();
        }

        [Test]
        [TestCase(0,0,0)]
        [TestCase(10,10,20)]
        [TestCase(-100,50,-50)]
        public void Add_TwoIntegers_ReturnSumOfIntegers(int a, int b, int expected)
        {
            //Calculator<int> _calc = new CalculatorFactory<int>().CreateCalc();
            var actual = _calc.Sum(a, b);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(10, 10, 0)]
        [TestCase(-100, 50, -150)]
        public void Subtract_TwoIntegers_ReturnDifferenceOfIntegers(int a, int b, int expected)
        {
            //Calculator<int> _calc = new CalculatorFactory<int>().CreateCalc();
            var actual = _calc.Sub(a, b);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(0, 10, 0)]
        [TestCase(10, 10, 1)]
        [TestCase(-100, 50, -2)]
        public void Divide_TwoIntegers_ReturnQuotientOfIntegers(int a, int b, int expected)
        {
            //Calculator<int> _calc = new CalculatorFactory<int>().CreateCalc();
            var actual = _calc.Div(a, b);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        [TestCase(0, 0)]
        [TestCase(10, 0)]
        [TestCase(-100, 0)]
        //[ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZero_TwoIntegers_ThrowsException(int a, int b)
        {
            //Calculator<int> _calc = new CalculatorFactory<int>().CreateCalc();
            Assert.Throws<DivideByZeroException>(() => _calc.Div(a, b));
        }


        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(10, 10, 100)]
        [TestCase(-100, 50, -5000)]
        public void Multiply_TwoIntegers_ReturnProductOfIntegers(int a, int b, int expected)
        {
            //Calculator<int> _calc = new CalculatorFactory<int>().CreateCalc();
            var actual = _calc.Mul(a, b);
            Assert.AreEqual(expected, actual);
        }

        //[Test]
        //[TestCase("0", "0")]
        ////[ExpectedException(typeof(DivideByZeroException))]
        //public void WrongType_TwoStrings_ArgumentException(string a, string b)
        //{
        //    Assert.Throws<ArgumentException>(() => _calc.Div(a, b));
        //}

        //[Test]
        //[TestCase(null, 0)]
        ////[ExpectedException(typeof(DivideByZeroException))]
        //public void NullValue_TwoIntegers_NullReferenceException(int? a, int b)
        //{
        //    Assert.Throws<ArgumentException>(() => _calc.Sum((int) a, b));
        //}
    }
}
