using System;
using NUnit.Framework;
using TestProject.TaskLibrary.CalculatorsForUnitTest;
//using TestProject.TaskLibrary.Tasks.Lesson18;


namespace TestProject.TaskLibrary.NUnit_Tests.Lesson18
{
    [TestFixture]
    public class Test_Task1
    {
        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(10, 10, 20)]
        [TestCase(-100, 50, -50)]
        public void Add_TwoIntegers_ReturnSumOfIntegers(int first, int second, int expected)
        {
            var actual = CalculatorInt.Sum(first, second);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(10, 10, 0)]
        [TestCase(-100, 50, -150)]
        public void Subtract_TwoIntegers_ReturnDifferenceOfIntegers(int first, int second, int expected)
        {
            var actual = CalculatorInt.Sub(first, second);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(0, 10, 0)]
        [TestCase(10, 10, 1)]
        [TestCase(-100, 50, -2)]
        public void Divide_TwoIntegers_ReturnQuotientOfIntegers(int first, int second, int expected)
        {
            var actual = CalculatorInt.Div(first, second);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        [TestCase(0, 0)]
        [TestCase(10, 0)]
        [TestCase(-100, 0)]
        //[ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZero_TwoIntegers_ThrowsException(int first, int second)
        {
            //CalculatorInt.Div(a, b);
            Assert.Throws<DivideByZeroException>(() => CalculatorInt.Div(first, second));
        }


        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(10, 10, 100)]
        [TestCase(-100, 50, -5000)]
        public void Multiply_TwoIntegers_ReturnProductOfIntegers(int first, int second, int expected)
        {
            var actual = CalculatorInt.Mul(first, second);
            Assert.AreEqual(expected, actual);
        }
    }
}