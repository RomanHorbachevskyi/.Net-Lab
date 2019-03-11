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
        const int LinesOnPage = 5;
        const string CharsForString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static List<string> _strElements;

        public void Run()
        {
            int strLength = 4;
            int strCount = 200;
            int pageToPrint = 0;
            int pagesCount;

            string str = "*** Now you are in Lesson9.Task5 ***";
            str = str + "\n    Work with List<T>, LINQ, Part 5";
            ConsIO.WriteLine(str);
            
            _strElements = new List<string>();

            // Adding random strings into the list strElements.
            for (int i = 0; i < strCount; i++)
            {
                _strElements.Add(Lesson6.Task3.GetRandomStr(CharsForString, strLength));
            }

            ConsIO.WriteLine($"Old count of elements (before deleting duplicates): {strCount}");

            // Removing duplicate elements from the list strElements.
            _strElements.Distinct();
            
            ConsIO.WriteLine($"Count before deleting elements with first 'Z': {_strElements.Count}");

            // Removing elements that begin from 'Z'.
            _strElements.RemoveAll(s => s[0] == 'Z');

            ConsIO.WriteLine($"New count of elements: {_strElements.Count}");

            ConsIO.WriteLine($"First and last elements before sorting: {_strElements.First()}; {_strElements.Last()}");

            var sortedElements = _strElements.OrderByDescending(element => element).ToList();

            ConsIO.WriteLine($"First and last elements after sorting: {sortedElements.First()}; {sortedElements.Last()}\n");

            #region Printing from the list
            
            if (_strElements.Count % LinesOnPage == 0)
            {
                pagesCount = _strElements.Count / LinesOnPage;
            }
            else
            {
                pagesCount = _strElements.Count / LinesOnPage + 1;
            }

            ConsIO.Write($"We have {pagesCount} pages. Enter the number of page you want to print(>0):");
            
            try
            {
                pageToPrint =Int32.Parse(ConsIO.ReadLine());
            }
            catch (Exception)
            {
                Environment.Exit(0);
            }
            
            Lesson6.Task3.DisplayPage(pageToPrint, sortedElements);
            
            #endregion
        }
    }
}
