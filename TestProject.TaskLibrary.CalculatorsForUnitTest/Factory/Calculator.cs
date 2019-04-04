using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.TaskLibrary.CalculatorsForUnitTest.Factory
{
    public abstract class Calculator<T>
    {
        public abstract T Sum(T first, T second);

        public abstract T Sub(T first, T second);

        public abstract T Mul(T first, T second);

        public abstract T Div(T first, T second);
    }
}
