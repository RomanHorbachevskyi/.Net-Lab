using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject.TaskLibrary.CalculatorsForUnitTest;
//using TestProject.TaskLibrary.Tasks.Lesson18;

namespace TestProject.TaskLibrary.MSTest.Lesson18
{
    [TestClass]
    public class Test_Task1
    {
        [DataTestMethod]
        [DataRow(0,0,0)]
        [DataRow(10,10,20)]
        [DataRow(-100,50,-50)]
        public void Add_TwoIntegers_ReturnSumOfIntegers(int first, int second, int expected)
        {
            var actual = CalculatorInt.Sum(first, second);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(10, 10, 0)]
        [DataRow(-100, 50, -150)]
        public void Subtract_TwoIntegers_ReturnDifferenceOfIntegers(int first, int second, int expected)
        {
            var actual = CalculatorInt.Sub(first, second);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, 10, 0)]
        [DataRow(10, 10, 1)]
        [DataRow(-100, 50, -2)]
        public void Divide_TwoIntegers_ReturnQuatientOfIntegers(int first, int second, int expected)
        {
            var actual = CalculatorInt.Div(first, second);
            Assert.AreEqual(expected, actual);
        }


        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(10, 0)]
        [DataRow(-100, 0)]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZero_TwoIntegers_ThrowsException(int first, int second)
        {
            CalculatorInt.Div(first, second);
            //Assert.ThrowsException<DivideByZeroException>(() => CalculatorInt.Div(a, b));
        }


        [DataTestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(10, 10, 100)]
        [DataRow(-100, 50, -5000)]
        public void Multiply_TwoIntegers_ReturnProductOfIntegers(int first, int second, int expected)
        {
            var actual = CalculatorInt.Mul(first, second);
            Assert.AreEqual(expected, actual);
        }
    }
}
