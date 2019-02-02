using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson1
{
    public class Task1 : IRunnable
    {
        public void Run()
        {
            /*Console.WriteLine("When you are in the Task, to Quit testing press \"q\", to break Task press \"b\".\n" +
                              "To proceed next press any key");
            Console.ReadLine();
            Console.WriteLine("");
            */
            Console.WriteLine("*** Now you are in Lesson1.Task2 ***");
            Console.WriteLine ("    Hello, world!\n");
        }
    }
}
