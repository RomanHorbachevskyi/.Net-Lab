using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.TaskLibrary.CalculatorsForUnitTest.Factory
{
    public class CalculatorFactory<T>// where T:class, new()
    {
        public Calculator<T> CreateCalc() //ICalculator<T> CreateCalc()
        {
            if (typeof(T) == typeof(int))
            {
                return new CalculatorIntFabric() as Calculator<T>;
            }
            if (typeof(T) == typeof(int[]))
            {
                return new CalculatorIntArraysFabric() as Calculator<T>;
            }
            return null;
        }
    }
}
