using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson1.NestedSpace
{
    public class Nested : IRunnable
    {
        public void Run()
        {
            ConsIO.WriteLine("*** Now you are in Lesson1.NestedSpace.Task1 ***");
            ConsIO.WriteLine("    Nested, task!\n");
            ConsIO.ReadLine();
        }
    }
}
