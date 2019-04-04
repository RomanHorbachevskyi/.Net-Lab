using System;
using NUnit.Framework;
//using TestProject.TaskLibrary.CalculatorsForUnitTest;
using TestProject.TaskLibrary.CalculatorsForUnitTest.Factory;

namespace TestProject.TaskLibrary.NUnit_Tests.FactoryCalculators
{
    [TestFixture]
    public class Test_Task2_Factory
    {
        private Calculator<int[]> _calc;

        [SetUp]
        public void SetUp()
        {
            _calc = new CalculatorFactory<int[]>().CreateCalc();
        }

        [Test]
        [TestCase(new int[] {1, 15, 25, 50},new int[] { 2, 10, 0}, new int[]{3,25,25,50})]

        //[TestCase(10, 10, 20)]
        //[TestCase(-100, 50, -50)]
        public void Add_TwoIntegerArrays_ReturnArraySumOfIntegers(int[] a, int[] b, int[] expected)
        {
            var actual = _calc.Sum(a, b);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new int[] { 1, 15, 25, 50 }, new int[] { 2, 10, 0 }, new int[] { -1, 5, 25, 50 })]
        //[TestCase(10, 10, 0)]
        //[TestCase(-100, 50, -150)]
        public void Subtract_TwoIntegerArrays_ReturnArrayDifferenceOfIntegers(int[] a, int[] b, int[] expected)
        {
            var actual = _calc.Sub(a, b);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(new int[] { 1, 15, 25, 50 }, new int[] { 2, 10, 1 }, new int[] { 0, 1, 25, 50 })]
        //[TestCase(10, 10, 1)]
        //[TestCase(-100, 50, -2)]
        public void Divide_TwoIntegerArrays_ReturnArrayQuotientOfIntegers(int[] a, int[] b, int[] expected)
        {
            var actual = _calc.Div(a, b);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        [TestCase(new int[] { 1, 15, 25, 50 }, new int[] { 2, 10, 0 })]
        //[TestCase(10, 0)]
        //[TestCase(-100, 0)]
        //[ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZero_TwoIntegerArrays_ThrowsException(int[] a, int[] b)
        {
            //var calc = new CalculatorIntFabric();
            Assert.Throws<DivideByZeroException>(() => _calc.Div(a, b));
        }


        [Test]
        [TestCase(new int[] { 1, 15, 25, 50 }, new int[] { 2, 10, 0 }, new int[] { 2, 150, 0, 50 })]
        //[TestCase(10, 10, 100)]
        //[TestCase(-100, 50, -5000)]
        public void Multiply_TwoIntegerArrays_ReturnArrayProductOfIntegers(int[] a, int[] b, int[] expected)
        {
            //var calc = new CalculatorIntFabric();
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
        //    Assert.Throws<ArgumentException>(() => _calc.Sum(a, b));
        //}
    }
}
