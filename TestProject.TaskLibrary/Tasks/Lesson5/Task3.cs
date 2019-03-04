using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;

namespace TestProject.TaskLibrary.Tasks.Lesson5
{
    public class Task3 : IRunnable
    {
        public void Run()
        {
            string s = "*** Now you are in Lesson5.Task3 ***";
            ConsIO.WriteLine(s);
            ConsIO.WriteLine("    Enter size of the array that you want to check.");
            int L=0;

            Int32.TryParse(ConsIO.ReadLine(), out L);
            ConsIO.WriteLine($"    Enter an array (int), with {L} members:");
            

            int[] Ar = new int[L];
            int[] Ar1 =new int[L];
            int temp;
            bool isSim = true;

            for (int i = 0; i < L; i++)
            {
                s = ConsIO.ReadLine();
                if ((s == "q") | (s == "b"))
                {
                    Environment.Exit(0);
                }
                Int32.TryParse(s, out Ar[i]);
                
            }
            ConsIO.WriteLine("");
            
            //checking the array for symetrics
            for (int i = 0; i < L/2; i++)
            {
                if (Ar[i] != Ar[L - i - 1])
                {
                    isSim = false;
                    break;
                }
            }
            if (isSim==true)
                ConsIO.WriteLine("The array from above is Symetric.");
            else
            {
                ConsIO.WriteLine("The array from above is Not Symetric.");
            }
            ConsIO.ReadLine();
        }
    }
}
