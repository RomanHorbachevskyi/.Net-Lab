using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;

namespace TestProject.TaskLibrary.Tasks.Lesson5
{
    public class Task4 : IRunnable
    {
        public void Run()
        {
            string s = "*** Now you are in Lesson5.Task4 ***";
            ConsIO.WriteLine(s);
            ConsIO.WriteLine("Now we are creating matrice MxN.");
            int m, n;
            ConsIO.Write("Enter M>1:");
            s = ConsIO.ReadLine();
            if ((s == "q") | (s == "b"))
            {
                Environment.Exit(0);
            }
            Int32.TryParse(s, out m);
            ConsIO.Write("Enter N>1:");
            s = ConsIO.ReadLine();
            if ((s == "q") | (s == "b"))
            {
                Environment.Exit(0);
            }
            Int32.TryParse(s, out n);
            ConsIO.WriteLine($"Now we are creating vector of Max's from the array MxN={m}x{n}.");
            int[,] Ar = new int[m,n];
            int[] aMax=new int[m];
            int temp;
            int tempMax =0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    temp = i + j;
                    Ar[i, j] = temp;
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
