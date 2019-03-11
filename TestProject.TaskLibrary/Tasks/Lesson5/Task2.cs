using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;

namespace TestProject.TaskLibrary.Tasks.Lesson5
{
    public class Task2 : IRunnable
    {
        public void Run()
        {
            const int Length = 10;
            int[] myArray = new int[Length];
            int temp;
            int counter = 0;

            string s = "*** Now you are in Lesson5.Task2 ***\n";
            s = s + "       Get quantity of simple numbers in the defined array.";
            ConsIO.WriteLine(s);
            
            for (int i = 0; i < Length; i++)
            {
                temp = i*i;
                myArray[i] = temp;
                s = temp + "; ";
                ConsIO.Write(s);
            }
            ConsIO.WriteLine();
            
            foreach (var value in myArray)
            {
                temp = value;
                if ((temp == 1)| (temp == 3)| (temp == 5)| (temp == 7))
                {
                    counter +=1;
                }
            }
            ConsIO.WriteLine("The array from above has {0} Simple numbers.", counter);
            ConsIO.ReadLine();
        }
    }
}
