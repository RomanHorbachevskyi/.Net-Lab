using System;

namespace TestProject.TaskLibrary.CalculatorsForUnitTest
{
    public static class CalculatorInt
    {
        /// <summary>
        /// Gets sum of 2 integers
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static int Sum(int first, int second)
        {
            try
            {
                return first + second;
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Gets difference after subtraction of 2 integers 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static int Sub(int first, int second)
        {
            try
            {
                return first - second;
            }
            catch (Exception e)
            {
                //ConsIO.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Gets power of 2 integers
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static int Mul(int first, int second)
        {
            try
            {
                return first * second;
            }
            catch (Exception e)
            {
                //ConsIO.WriteLine(e);
                throw;
            }

        }

        /// <summary>
        /// Gets quotient of division of 2 integers
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static int Div(int first, int second)
        {
            try
            {
                return first / second;
            }
            catch (DivideByZeroException e)
            {
                //ConsIO.WriteLine("Division on 0", e);
                throw;
            }
        }
    }
}
