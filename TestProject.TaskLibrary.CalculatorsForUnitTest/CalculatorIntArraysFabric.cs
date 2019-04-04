using System;
using TestProject.TaskLibrary.CalculatorsForUnitTest.Factory;

namespace TestProject.TaskLibrary.CalculatorsForUnitTest
{
    
    public class CalculatorIntArraysFabric:Calculator<int[]>
//<T>:ICalculator<int[]>
    {
        public CalculatorIntArraysFabric() { }

        /// <summary>
        /// Gets sum of 2 numbers
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public override int[] Sum(int[] first, int[] second)
        {
            try
            {
                int[] f, s;
                if (first.Length < second.Length)
                {
                    f = second;
                    s = f;
                }
                else
                {
                    f = first;
                    s = second;
                }

                var c = new int[f.Length];
                for (int i = 0; i < f.Length; i++)
                {
                    try
                    {
                        c[i] = f[i] + s[i];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        c[i] = f[i];
                    }
                }

                return c;
            }
            catch (NullReferenceException)
            {
                throw;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (StackOverflowException)
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
        public override int[] Sub(int[] first, int[] second)
        {
            try
            {
                int[] f, s;
                if (first.Length < second.Length)
                {
                    f = second;
                    s = f;
                }
                else
                {
                    f = first;
                    s = second;
                }

                var c = new int[f.Length];
                for (int i = 0; i < f.Length; i++)
                {
                    try
                    {
                        c[i] = f[i] - s[i];
                    }
                    catch (IndexOutOfRangeException)
                    { c[i] = f[i]; }
                }

                return c;
            }
            catch (NullReferenceException)
            { throw; }
            catch (ArgumentException)
            { throw; }
            catch (Exception)
            { throw; }
        }

        /// <summary>
        /// Gets power of 2 numbers
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public override int[] Mul(int[] first, int[] second)
        {
            try
            {
                int[] f, s;
                if (first.Length < second.Length)
                {
                    f = second;
                    s = f;
                }
                else
                {
                    f = first;
                    s = second;
                }

                var c = new int[f.Length];
                for (int i = 0; i < f.Length; i++)
                {
                    try
                    {
                        c[i] = f[i] * s[i];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        c[i] = f[i];
                    }
                }

                return c;
            }
            catch (NullReferenceException)
            { throw; }
            catch (ArgumentException)
            { throw; }
            catch (Exception)
            { throw; }
        }

        /// <summary>
        /// Gets quotient of division of 2 numbers
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public override int[] Div(int[] first, int[] second)
        {
            try
            {
                int[] f, s;
                if (first.Length < second.Length)
                {
                    f = second;
                    s = f;
                }
                else
                {
                    f = first;
                    s = second;
                }

                var c = new int[f.Length];
                for (int i = 0; i < f.Length; i++)
                {
                    try
                    {
                        c[i] = f[i] / s[i];
                    }
                    catch (DivideByZeroException)
                    { throw; }
                    catch (IndexOutOfRangeException)
                    {
                        c[i] = f[i];
                    }
                }

                return c;
            }
            catch (NullReferenceException)
            { throw; }
            catch (ArgumentException)
            { throw; }
            catch (DivideByZeroException)
            { throw; }
            catch (Exception)
            { throw; }
        }
    }
}
