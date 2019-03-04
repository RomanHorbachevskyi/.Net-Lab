using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;

namespace TestProject.TaskLibrary.Tasks.Lesson5
{
    public class Task1 : IRunnable
    {
        public void Run()
        {
            string s = "*** Now you are in Lesson5.Task1 ***";
            s = s+"\n   Enter array length to create it (L<10)";
            ConsIO.WriteLine(s);
            int n;
            Int32.TryParse(ConsIO.ReadLine(),out n);
            int[] Ar = new int[n];
            int[] Ar1 =new int[n];
            int temp;
            for (int i = 0; i < n; i++)
            {
                temp = i*i;
                Ar[i] = temp;
                s = temp.ToString();
                ConsIO.Write(s);
            }
            ConsIO.WriteLine("");
            for (int i = 0; i < n; i++)
            {

                temp = Ar[i];
                Ar1[i] = temp * temp * temp;
                s = Ar1[i].ToString();
                ConsIO.Write(s);
            }
            ConsIO.WriteLine("");
            ConsIO.ReadLine();
            
        }


    }
}
