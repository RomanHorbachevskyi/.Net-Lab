using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;

namespace TestProject.TaskLibrary.Tasks.Lesson1
{
    public class Task1 : IRunnable
    {
        public void Run()
        {
            ConsIO.WriteLine("*** Now you are in Lesson1.Task1 ***");
            ConsIO.WriteLine ("    Hello, world!\n");
        }
    }
}
