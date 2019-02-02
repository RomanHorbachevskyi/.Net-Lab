using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson1
{
    public class Task2 : IRunnable
    {
        public void Run()
        {
            Console.WriteLine("*** Now you are in Lesson1.Task2 ***");
            Console.WriteLine("    Sorry, To check Lesson1.Task2 we need to use Forms instead of .NET Core.\n");
            //Console.ReadLine();
        }
    }
}
