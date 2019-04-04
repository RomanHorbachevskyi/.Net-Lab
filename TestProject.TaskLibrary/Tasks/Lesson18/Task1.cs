using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities;
using TestProject.TaskLibrary.CalculatorsForUnitTest;
using TestProject.TaskLibrary.CalculatorsForUnitTest.Factory;


namespace TestProject.TaskLibrary.Tasks.Lesson18
{
    public class Task1 : IRunnable
    {
        public void Run()
        {
            string s = "*** Now you are in Lesson18.Task1 ***\n    Create calculator for 2 integers and Unit Tests";
            ConsIO.WriteLine(s);
            int f = 15;
            int sec = 15;
            
            //ConsIO.WriteLine(CalculatorInt.Sum(f, sec));

            var calc = new CalculatorIntFabric();
            //ConsIO.WriteLine(calc.Sum(f, sec));
            
            var calc2 = new CalculatorFactory<int>().CreateCalc();
            
            ConsIO.WriteLine(calc2.Sum(f, sec));
            ConsIO.ReadLine();
        }
    }
}
