﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using TestProject.Common.Core.Classes;
using TestProject.Common.Core.Interfaces;

namespace TestProject.TaskLibrary.Tasks.Lesson4
{
    public class OptTask1 : IRunnable
    {
        static readonly Random rndGen = new Random();
        //const int strsOnPage = 5;
        const string strChars = "0123456789";
        int strLength = 2;
        private int rows = 50000;
        public void Run()
        {

            string s = "*** Now you are in Lesson4.OptTask1 ***";
            s = s + "\n    Compare BubbleSorting algorithms";
            ConsIO.WriteLine(s);
            var array = new int[rows];//{4,54,2,86,5,3,67,11,2,8};
            ConsIO.WriteLine("");

            for (int i = 0; i < rows; i++)
            {
                array[i]=(GetRundomInt(strChars, strLength));
            }

            var b = new BubbleSort();
            int[] array1 = (int[])array.Clone();
            //for (int i = 0; i < array.Length; i++) ConsIO.Write(array[i] + " ");
            ConsIO.WriteLine("");
            //PerformSort(array1,b);
            //for (int i=0;i<array1.Length;i++) ConsIO.Write(array1[i]+" ");
            ConsIO.Write("\n\n");

            var ob=new OptimizedBubbleSort();
            int[] array2 = (int[])array.Clone();
            //for (int i = 0; i < array.Length; i++) ConsIO.Write(array[i] + " ");
            ConsIO.WriteLine("");
            //PerformSort(array2,ob);
            //for (int i = 0; i < array2.Length; i++) ConsIO.Write(array2[i] + " ");

            ConsIO.Write("\n  Calculating sorting performance:");
            TestPerf(array1,b,array2,ob);
            ConsIO.ReadLine();
            //List<int> lt=new List<int>();

        }
        private static void PerformSort(int[] array, ISortAlgorithm algorithm)
        {
            algorithm.Sort(array);
        }

        private static void TestPerf(int[] array1, ISortAlgorithm alg1, int[] array2, ISortAlgorithm alg2)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            PerformSort(array1, alg1);
            stopWatch.Stop();
            ConsIO.WriteLine("Time to sort by Bubble: {0} miliseconds; {1} ticks", 
                stopWatch.ElapsedMilliseconds, stopWatch.ElapsedTicks);
            stopWatch.Reset();

            stopWatch.Start();
            PerformSort(array2, alg2);
            stopWatch.Stop();
            ConsIO.WriteLine("Time to sort by OptimizedBubble: {0} miliseconds; {1} ticks", 
                stopWatch.ElapsedMilliseconds, stopWatch.ElapsedTicks);
        }
        static int GetRundomInt(string ch, int strLength)
        {
            char[] str = new char[strLength];
            for (int i = 0; i < strLength; i++)
            {
                str[i] = ch[rndGen.Next(ch.Length)];
            }
            return int.Parse((str));
        }
    }

    public class BubbleSort:ISortAlgorithm
    {
        public void Sort(int[] array)
        {
            ConsIO.WriteLine("BubbleSort:");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        var temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
    public class OptimizedBubbleSort : ISortAlgorithm
    {
        public void Sort(int[] array)
        {
            ConsIO.WriteLine("OptimizedBubbleSort:");
            int length = array.Length;
            int temp = array[0];
            for (int i = 0; i < length; i++)
            {
                for (int j = i+1; j < length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }

}