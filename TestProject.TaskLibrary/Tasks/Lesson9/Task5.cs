using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using TestProject.Common.Core.Interfaces;
using TestProject.Common.Core.Classes;

namespace TestProject.TaskLibrary.Tasks.Lesson9
{
    public class Task5 : IRunnable
    {
        static readonly Random rndGen =new Random();
        const int strsOnPage = 5;
        const string strChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static List<string> strElements;

        public void Run()
        {
            string str = "*** Now you are in Lesson6.Task3 ***";
            str = str + "\n    Work with List<T>, Part 3";
            ConsIO.WriteLine(str);
            int strLength = 4;
            int strCount = 200;
            int pageToPrint = 0;
            int pagesCount;
            //string tempStr;

            strElements = new List<string>();

            // Adding rundom strings into the list strElements.
            for (int i = 0; i < strCount; i++)
            {
                strElements.Add(Lesson6.Task3.GetRundomStr(strChars,strLength));
            }

            ConsIO.WriteLine($"Old count of elements (before deleting duplicates): {strCount}");

            // Removing duplicate elements from the list strElements.
            strElements.Distinct();
            
            ConsIO.WriteLine($"Count before deleting elements with first 'Z': {strElements.Count}");

            // Removing elements that begin from 'Z'.
            strElements.RemoveAll(s => s[0] == 'Z');

            ConsIO.WriteLine($"New count of elements: {strElements.Count}");

            ConsIO.WriteLine($"First and last elements before sorting: {strElements.First()}; {strElements.Last()}");

            var sortedElements = strElements.OrderByDescending(strE => strE).ToList();

            ConsIO.WriteLine($"First and last elements after sorting: {sortedElements.First()}; {sortedElements.Last()}\n");

            #region Printing from the list
            
            if (strElements.Count%strsOnPage==0)
            {
                pagesCount = strElements.Count / strsOnPage;
            }
            else
            {
                pagesCount = strElements.Count / strsOnPage + 1;
            }
            ConsIO.Write($"We have {pagesCount} pages. Enter the number of page you want to print(>0):");
            
            try
            {
                pageToPrint =Int32.Parse(ConsIO.ReadLine());
            }
            catch (Exception e)
            {
                Environment.Exit(0);
            }
            //Int32.TryParse(ConsIO.Read(), out pPrint);
            
            Lesson6.Task3.DisplayPage(pageToPrint, sortedElements);
            #endregion
        }
    }
}
