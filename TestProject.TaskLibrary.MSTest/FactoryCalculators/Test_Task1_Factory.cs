using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TestProject.TaskLibrary.CalculatorsForUnitTest;
using TestProject.TaskLibrary.CalculatorsForUnitTest.Factory;

namespace TestProject.TaskLibrary.MSTest.FactoryCalculators
{
    [TestClass]
    public class Test_Task1_Factory
    {
        private Calculator<int> calc;// = new CalculatorIntFabric();

        [TestInitialize]
        public void TestInit()
        {
            calc = new CalculatorFactory<int>().CreateCalc(); // = new CalculatorIntFabric();
        }

        [DataTestMethod]
        [DataRow(0,0,0)]
        [DataRow(10,10,20)]
        [DataRow(-100,50,-50)]
        public void Add_TwoIntegers_ReturnSumOfIntegers(int a, int b, int expected)
        {
            //var calc = new CalculatorIntFabric();
            var actual = calc.Sum(a, b);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(10, 10, 0)]
        [DataRow(-100, 50, -150)]
        public void Subtract_TwoIntegers_ReturnDifferenceOfIntegers(int a, int b, int expected)
        {
            //var calc = new CalculatorIntFabric();
            var actual = calc.Sub(a, b);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, 10, 0)]
        [DataRow(10, 10, 1)]
        [DataRow(-100, 50, -2)]
        public void Divide_TwoIntegers_ReturnQuotientOfIntegers(int a, int b, int expected)
        {
            //var calc = new CalculatorIntFabric();
            var actual = calc.Div(a, b);
            Assert.AreEqual(expected, actual);
        }


        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(10, 0)]
        [DataRow(-100, 0)]
        //[ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZero_TwoIntegers_ThrowsException(int a, int b)
        {
            //var calc = new CalculatorIntFabric();
            Assert.ThrowsException<DivideByZeroException>(() => calc.Div(a, b));
        }


        [DataTestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(10, 10, 100)]
        [DataRow(-100, 50, -5000)]
        public void Multiply_TwoIntegers_ReturnProductOfIntegers(int a, int b, int expected)
        {
            //var calc = new CalculatorIntFabric();
            var actual = calc.Mul(a, b);
            Assert.AreEqual(expected, actual);
        }
    }
}
