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
    public class Task2 : IRunnable
    {
        public void Run()
        {
            string s = "*** Now you are in Lesson18.Task2 ***\n    Create calculator for 2 arrays of integers and Unit Tests";
            ConsIO.WriteLine(s);

            int[] fa = {1, 15, 25, 50};
            int[] seca = {2, 10, 0};

            var calc2 = new CalculatorFactory<int[]>().CreateCalc();
            var calc2Sum = calc2.Sum(fa, seca);
            
            foreach (var n in calc2Sum)
            {
                ConsIO.Write(n + " ");
            }
            
            ConsIO.ReadLine();
        }
    }

    
}
