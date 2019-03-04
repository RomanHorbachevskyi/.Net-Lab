using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;

namespace TestProject.TaskLibrary.Tasks.Lesson5
{
    public class Task5 : IRunnable
    {
        public void Run()
        {
            string s = "*** Now you are in Lesson5.Task5 ***";
            ConsIO.WriteLine(s);
            ConsIO.WriteLine("Now we are creating jagged array MxN(y).");
            int m, n;
            ConsIO.Write("Enter M:");
            s = ConsIO.ReadLine();
            if ((s == "q") | (s == "b"))
            {
                Environment.Exit(0);
            }
            Int32.TryParse(s, out m);
            int[] arJ=new int[m];
            for (int i = 0; i < m; i++)
            {
                ConsIO.WriteLine($"Enter length of {i} row (L>1):");
                s = ConsIO.ReadLine();
                if ((s == "q") | (s == "b"))
                {
                    Environment.Exit(0);
                }
                Int32.TryParse(s, out arJ[i]);
            }

            ConsIO.WriteLine($"Now we are creating vector of Max's from the jagged array.");
            int[][] Ar = new int[m][];
            int[] aMax=new int[m];
            int temp;
            int tempMax =0;
            int tempVal;
            for (int i = 0; i < m; i++)
            {
                tempVal = arJ[i];
                Ar[i]=new int[tempVal];
                for (int j = 0; j < tempVal; j++)
                {
                    temp = i + j;
                    Ar[i][j] = temp;
                    if (tempMax < temp)
                        tempMax = temp;
                    ConsIO.Write($"{temp} ");
                }

                aMax[i] = tempMax;
                ConsIO.WriteLine("");
            }
            ConsIO.WriteLine("Vector array of Max's:");
            for (int i = 0; i < m; i++)
            {
                ConsIO.Write(aMax[i].ToString() + "; ");
            }
            ConsIO.WriteLine("");
            ConsIO.ReadLine();
        }
    }
}
