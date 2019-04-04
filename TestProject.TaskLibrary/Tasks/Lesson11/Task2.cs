using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;

namespace TestProject.TaskLibrary.Tasks.Lesson11
{
    public class Task2 : IRunnable
    {
        public void Run()
        {
            string s = "*** Now you are in Lesson11.Task2 ***\n    Generate IndexOutOfRangeException using 1 dim array." +
                       "\nTo continue press 'Enter' key.";
            ConsIO.WriteLine(s);
            s = ConsIO.ReadLine();
            ConsIO.CheckForExitTask(ref s);
            ConsIO.WriteLine("We did not get IndexOutOfRangeException. Value is: " + IndexRangeDestroyer.IndexOutOfRangeException().ToString());
            ConsIO.ReadLine();
        }
    }
    public class IndexRangeDestroyer
    {
        public static int IndexOutOfRangeException()
        {
            int[] array = { 1, 2, 3 };
            return array[array.Length + 1];
        }
    }
    
}
