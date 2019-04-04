using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.TaskLibrary.CalculatorsForUnitTest.Factory
{
    interface ICalculator<T>
    {
        T Sum(T first, T second);

        T Sub(T first, T second);

        T Mul(T first, T second);

        T Div(T first, T second);
    }
}
