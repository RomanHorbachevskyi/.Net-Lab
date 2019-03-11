using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Classes.Utilities;

namespace TestProject.TaskLibrary.Tasks.Lesson5
{
    public class Task4 : IRunnable
    {
        public void Run()
        {
            int m, n;
            int[,] myArray;
            int[] arrayMax;
            int temp;
            int tempMax = 0;

            string s = "*** Now you are in Lesson5.Task4 ***\n";
            s = s + "       On the basis of the array (MxN, M>1, N>1) create the vector\n" +
                "       which contains elements with maximum value\n" +
                "       from every row";
            ConsIO.WriteLine(s);
            ConsIO.WriteLine("Now we are creating matrix MxN.");
            
            ConsIO.Write("Enter M>1:  ");
            m = Validators.GetIntPositiveNumber(ConsIO.ReadLine());
            ConsIO.Write("Enter N>1:  ");
            n = Validators.GetIntPositiveNumber(ConsIO.ReadLine());
            ConsIO.WriteLine($"Now we are creating vector of Max's from the array MxN={m}x{n}.");

            myArray = new int[m,n];
            arrayMax = new int[m];
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    temp = i + j;
                    myArray[i, j] = temp;
                    if (tempMax < temp)
                        tempMax = temp;
                    ConsIO.Write($"{temp} ");
                }

                arrayMax[i] = tempMax;
                ConsIO.WriteLine();
            }
            ConsIO.WriteLine("Vector array of Max's:");
            for (int i = 0; i < m; i++)
            {
                ConsIO.Write(arrayMax[i] + "; ");
            }
            ConsIO.WriteLine();
            ConsIO.ReadLine();
        }
    }
}
