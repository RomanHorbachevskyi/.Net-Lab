using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities;

namespace TestProject.TaskLibrary.Tasks.Lesson5
{
    public class Task3 : IRunnable
    {
        public void Run()
        {
            int Length;
            bool isSymmetric = true;
            string s = "*** Now you are in Lesson5.Task3 ***\n";
            s = s + "       Check entered array of integers for symmetry.";
            ConsIO.WriteLine(s);
            ConsIO.WriteLine("    Enter the size of the array that you want to check.");

            Length = Validators.GetIntPositiveNumber(ConsIO.ReadLine());
            ConsIO.WriteLine($"    Enter an array (int), with {Length} members:");

            int[] myArray = new int[Length];

            for (int i = 0; i < Length; i++)
            {
                myArray[i] = Validators.GetIntNumber(ConsIO.ReadLine());
            }
            ConsIO.WriteLine();
            
            //checking the array for symmetry
            for (int i = 0; i < Length/2; i++)
            {
                if (myArray[i] == myArray[Length - i - 1]) continue;
                isSymmetric = false;
                break;
            }
            if (isSymmetric)
                ConsIO.WriteLine("The array from above is Symmetric.");
            else
            {
                ConsIO.WriteLine("The array from above is Not Symmetric.");
            }
            ConsIO.ReadLine();
        }
    }
}
