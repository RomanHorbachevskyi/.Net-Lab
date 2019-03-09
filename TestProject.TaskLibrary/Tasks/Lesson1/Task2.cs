using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;

namespace TestProject.TaskLibrary.Tasks.Lesson1
{
    public class Task2 : IRunnable
    {
        public void Run()
        {
            ConsIO.WriteLine("*** Now you are in Lesson1.Task2 ***\n    Creating X-0 game in WinForms.");
            ConsIO.WriteLine("    Sorry, To check Lesson1.Task2 we need to use Forms instead of .NET Core.\n");
            ConsIO.WriteLine("    So open another solution: \"X_0.sln\" \n");
        }
    }
}
