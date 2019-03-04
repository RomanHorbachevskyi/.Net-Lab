using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;

namespace TestProject.TaskLibrary.Tasks.Lesson5
{
    public class CW_Task1 : IRunnable
    {
        public void Run()
        {
            /*Console.WriteLine("When you are in the Task, to Quit testing press \"q\", to break Task press \"b\".\n" +
                              "To proceed next press any key");
            Console.ReadLine();
            Console.WriteLine("");
            */
            int itemscount = 3;
            int tempI,tempJ;
            //create twodimensionalarray
            int[,] twoDimensionalArray=new int[itemscount,itemscount];
            //create jugged array
            var jaggedArray = new int[itemscount][];
            for (var i = 0; i < itemscount; i++)
            {
                tempI = i + itemscount;
                jaggedArray[i]=new int[(tempI)];   //012
            }                                           //1234    
                                                        //23456
            for (var i = 0; i < itemscount; i++)
            {
                tempJ = itemscount + i;
                for (var j = 0; j <tempJ; j++)
                {
                    //twoDimensionalArray[i, j] = 1;
                    jaggedArray[i][j] = i+j;
                    Console.Write(jaggedArray[i][j]);
                    //Console.Write(twoDimensionalArray[i, j]);
                    //Console.Write(jaggedArray[i][j]);
                }

                Console.WriteLine();
                //Console.ReadLine();
            }

            Console.WriteLine("");
            Console.WriteLine(jaggedArray[2].Length);
            Console.ReadLine();
            /*string s= "*** Now you are in Lesson5.Task2 ***";
            ConsIO.Write(ref s);
            Console.WriteLine ("    Hello, world!\n");
            int[] a = new[] { 99, 98, 97 };*/

        }

        /*static int GetSumForOneZeroBasedArray(int[] array)
        {
            var sum = 0;
            for (var i = 0; i < array.Length; i++)
                sum += array[i];
            return sum;
        }*/

    }
}
