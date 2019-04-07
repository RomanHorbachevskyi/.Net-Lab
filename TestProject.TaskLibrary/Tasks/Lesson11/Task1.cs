using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities;

namespace TestProject.TaskLibrary.Tasks.Lesson11
{
    public class Task1 : IRunnable
    {
        public void Run()
        {
            ConsIO.Clear();
            string s = "*** Now you are in Lesson11.Task1 ***\n    Generate StackOverflowException by recursion." +
                       "\nTo continue press 'Enter' key.";
            ConsIO.WriteLine(s);
            s = ConsIO.ReadLine();
            Validators.CheckForExitTask(ref s);
            ConsIO.WriteLine("We did not get StackOverflowException. Value is: " + StackDestroyer.GetStackOverflowException().ToString());
            ConsIO.ReadLine();
        }
    }
    public class StackDestroyer
    {
        public static int GetStackOverflowException()
        {
            int i = 1;
            return i + GetStackOverflowException();
        }
    }
    
}
