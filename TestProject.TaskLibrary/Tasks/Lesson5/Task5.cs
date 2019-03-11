using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities;

namespace TestProject.TaskLibrary.Tasks.Lesson5
{
    public class Task5 : IRunnable
    {
        public void Run()
        {
            int m;
            int[] jaggedArraysLengths;
            int[][] myArray;
            int[] arrayMax;
            int tempValue;
            int tempMax = 0;
            int jArrayLength;

            string s = "*** Now you are in Lesson5.Task5 ***\n   Make previous task using jagged array.";
            ConsIO.WriteLine(s);
            ConsIO.WriteLine("Now we are creating jagged array MxN(y).");
            
            ConsIO.Write("Enter M:");
            m = Validators.GetIntPositiveNumber(ConsIO.ReadLine());
            jaggedArraysLengths=new int[m];

            for (int i = 0; i < m; i++)
            {
                ConsIO.Write($"Enter length of {i} row (L>1): ");
                jaggedArraysLengths[i] = Validators.GetIntPositiveNumber(ConsIO.ReadLine());
            }

            ConsIO.WriteLine($"Now we are creating vector of Max's from the jagged array.");

            myArray = new int[m][];
            arrayMax = new int[m];
            
            for (int i = 0; i < m; i++)
            {
                jArrayLength = jaggedArraysLengths[i];
                myArray[i] = new int[jArrayLength];
                for (int j = 0; j < jArrayLength; j++)
                {
                    tempValue = i + j;
                    myArray[i][j] = tempValue;
                    if (tempMax < tempValue)
                        tempMax = tempValue;
                    ConsIO.Write($"{tempValue} ");
                }

                arrayMax[i] = tempMax;
                ConsIO.WriteLine();
            }
            ConsIO.WriteLine("Vector array of Max's:");
            for (int i = 0; i < m; i++)
            {
                ConsIO.Write(arrayMax[i].ToString() + "; ");
            }
            ConsIO.WriteLine();
            ConsIO.ReadLine();
        }
    }
}
