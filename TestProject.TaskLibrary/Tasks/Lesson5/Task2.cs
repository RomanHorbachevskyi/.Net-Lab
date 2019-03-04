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
            string s = "*** Now you are in Lesson5.Task2 ***";
            ConsIO.WriteLine(s);

            int L = 10;
            int[] Ar = new int[L];
            int[] Ar1 =new int[L];
            int temp;
            int counter=0;
            for (int i = 0; i < L; i++)
            {
                temp = i*i;
                Ar[i] = temp;
                s = temp.ToString()+"; ";
                ConsIO.Write(s);
            }
            ConsIO.WriteLine("");
            bool isSimple=true;
            int j;
            for (int i = 0; i < Ar.Length; i++)
            {
                temp = Ar[i];
                /*if ((temp % 7 == 0))
                {
                    isSimple = false;
                    break;
                }
                if ((temp % 5 != 0))
                {
                    isSimple = false;
                    break;
                }
                if ((temp % 3 != 0))
                {
                    isSimple = false;
                    break;
                }
                if ((temp % 2 != 0))
                {
                    isSimple = false;
                    break;
                }*/

                /*if (isSimple == true)
                {

                }*/
                if ((temp==1)| (temp == 3)| (temp == 5)| (temp == 7))
                {
                    counter +=1;
                }
            }
            ConsIO.WriteLine("The array from above has {0} Simple numbers.",counter);
            ConsIO.ReadLine();
        }
    }
}
