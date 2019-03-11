using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities;

namespace TestProject.TaskLibrary.Tasks.Lesson5
{
    public class Task1 : IRunnable
    {
        public void Run()
        {
            int Length;
            int temp;
            string s = "*** Now you are in Lesson5.Task1 ***\n  Work with arrays.";
            s = s+"\n   Get new array from cubed values of defined one." +
                "\n   Enter array length to create it (L<10)";
            ConsIO.WriteLine(s);
            
            Length = Validators.GetIntPositiveNumber(ConsIO.ReadLine());

            int[] myArray = new int[Length];
            int[] myArray1 =new int[Length];
            
            // Generating an array of integers:
            for (int i = 0; i < Length; i++)
            {
                temp = i*i;
                myArray[i] = temp;
                ConsIO.Write(temp.ToString());
            }
            ConsIO.WriteLine("\nNew array of cubed elements from defined array:");
            for (int i = 0; i < Length; i++)
            {

                temp = myArray[i];
                myArray1[i] = temp * temp * temp;
                ConsIO.Write(myArray1[i].ToString());
            }
            ConsIO.WriteLine();
            ConsIO.ReadLine();
        }
    }
}
