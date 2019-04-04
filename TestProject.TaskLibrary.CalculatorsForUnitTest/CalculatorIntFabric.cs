using System;
using TestProject.TaskLibrary.CalculatorsForUnitTest.Factory;

namespace TestProject.TaskLibrary.CalculatorsForUnitTest
{
    
    public class CalculatorIntFabric:Calculator<int>
//<T>:Calculator<int>
//ICalculator<int>
    {
        public CalculatorIntFabric() { }

        /// <summary>
        /// Gets sum of 2 numbers
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public override int Sum(int first, int second)
        {
            try
            {
                return (dynamic)first + second;
            }
            catch (NullReferenceException)
            {
                throw;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets difference after subtraction of 2 numbers 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public override int Sub(int first, int second)
        {
            try
            {
                return (dynamic)first - second;
            }
            catch (NullReferenceException)
            {
                throw;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets power of 2 numbers
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public override int Mul(int first, int second)
        {
            try
            {
                return (dynamic)first * second;
            }
            catch (NullReferenceException)
            {
                throw;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets quotient of division of 2 numbers
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public override int Div(int first, int second)
        {
            try
            {
                return (dynamic)first / second;
            }
            catch (DivideByZeroException)
            {
                throw;
            }
            catch (NullReferenceException)
            {
                throw;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
