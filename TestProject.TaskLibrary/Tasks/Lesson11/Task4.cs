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
    public class Task4 : IRunnable
    {
        public void Run()
        {
            int a, b;
            ConsIO.Clear();
            string s = "*** Now you are in Lesson11.Task4 ***\n    Catch ArgumentException by parameter. To make exception enter a<0 or b>0." +
                       "\nTo continue press 'Enter' key.";
            ConsIO.WriteLine(s);
            s = ConsIO.ReadLine();
            ConsIO.CheckForExitTask(ref s);
            try
            {
                ConsIO.Write("Enter a: ");
                s = ConsIO.ReadLine();
                ConsIO.CheckForExitTask(ref s);
                a = Validators.GetIntNumber(s);
                ConsIO.Write("Enter b: ");
                s = ConsIO.ReadLine();
                ConsIO.CheckForExitTask(ref s);
                b = Validators.GetIntNumber(s);
                DoSomeMath(a, b);
            }
            catch (ArgumentException e)
                when (e.ParamName == "a")
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
                when (e.ParamName == "b")
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ConsIO.WriteLine();
            }
        }

        public static void DoSomeMath(int a, int b)
        {
            if (a<0)
            {
                throw new ArgumentException("Parameter should be greater than 0", "a");
            }

            if (b>0)
            {
                throw new ArgumentException("Parameter should be less than 0", "b");
            }
        }
        

    }
    
    
}
